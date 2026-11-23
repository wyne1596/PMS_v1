#nullable disable
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PMS_v1   // keep as PMS_v1 so every page can see it
{
    /// <summary>
    /// The fields for each page's form. Every Key matches a database column, and every
    /// fixed choice matches the enum in the database exactly (spelling counts).
    ///
    /// Dropdowns marked "fill from database" start empty. The page fills them before
    /// ShowDialog with:  f.SetOptions("unit", new[] { new ComboItem(151, "101"), ... });
    /// After OK, f.Values["unit"] is the id (int), ready for an @parameter.
    /// </summary>
    public static class FormDefinitions
    {
        private static readonly string[] UnitFurnishing = { "Unfurnished", "Semi-Furnished", "Fully Furnished" };

        // ---------------- resident ----------------
        public static FormField[] Resident()
        {
            return new[]
            {
                new FormField { Key = "firstName", Label = "First name", MaxLength = 45 },
                new FormField { Key = "lastName", Label = "Last name", MaxLength = 45 },
                new FormField { Key = "contact", Label = "Contact no.", Type = FieldType.Phone, Required = false },
                new FormField { Key = "email", Label = "Email", MaxLength = 100, Required = false },
                new FormField { Key = "birthdate", Label = "Birthdate", Type = FieldType.Date, Required = false },
                new FormField { Key = "emergencyContact", Label = "Emergency no.", Type = FieldType.Phone, Required = false }
            };
        }

        public static string ValidateResident(Dictionary<string, object> v)
        {
            var email = v["email"] as string;
            if (email != null && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Enter a valid email address.";

            if (v["birthdate"] is DateTime && (DateTime)v["birthdate"] > DateTime.Today)
                return "Birthdate can't be in the future.";

            return null;
        }

        // ---------------- units ----------------
        // Occupied is set by leases, so it is not a choice. For a unit that is already
        // occupied, pass occupied: true and the status shows as "Occupied", locked,
        // and the base rent is locked too until the unit is vacant again.
        public static FormField[] Unit(bool occupied = false)
        {
            return new[]
            {
                new FormField { Key = "unitNo", Label = "Unit no.", MaxLength = 10 },
                new FormField { Key = "floor", Label = "Floor", Type = FieldType.Number, DefaultValue = 1 },
                new FormField { Key = "furnishing", Label = "Furnishing", Type = FieldType.Dropdown,
                    Options = UnitFurnishing, DefaultValue = "Unfurnished" },
                new FormField { Key = "baseRent", Label = "Base rent", Type = FieldType.Money, ReadOnly = occupied },
                new FormField { Key = "status", Label = "Status", Type = FieldType.Dropdown,
                    Options = occupied ? new[] { "Occupied" } : new[] { "Vacant", "Under Maintenance" },
                    DefaultValue = occupied ? "Occupied" : "Vacant", ReadOnly = occupied }
            };
        }

        // ---------------- lease ----------------
        // unit: fill from database with VACANT units only; resident: fill from database.
        // Pre-fill monthlyRent from the chosen unit's base rent in the page.
        // startLocked (Edit only): the start date can change only while the lease is still Pending
        public static FormField[] Lease(FormMode mode = FormMode.New, bool startLocked = false)
        {
            bool edit = mode == FormMode.Edit;
            return new[]
            {
                new FormField { Key = "resident", Label = "Tenant", Type = FieldType.Dropdown, ReadOnly = edit },
                new FormField { Key = "unit", Label = "Unit", Type = FieldType.Dropdown, ReadOnly = edit },
                new FormField { Key = "startDate", Label = "Start date", Type = FieldType.Date,
                    DefaultValue = DateTime.Today, ReadOnly = startLocked },
                new FormField { Key = "endDate", Label = "End date", Type = FieldType.Date,
                    DefaultValue = DateTime.Today.AddYears(1) },
                new FormField { Key = "monthlyRent", Label = "Monthly rent", Type = FieldType.Money },
                new FormField { Key = "deposit", Label = "Deposit", Type = FieldType.Money, Required = false },
                new FormField { Key = "status", Label = "Status", Type = FieldType.Dropdown,
                    Options = edit
                        ? new[] { "Pending", "Active", "Expired", "Terminated" }
                        : new[] { "Pending", "Active" },
                    DefaultValue = "Pending" }
            };
        }

        public static string ValidateLease(Dictionary<string, object> v)
        {
            if ((DateTime)v["endDate"] <= (DateTime)v["startDate"])
                return "End date must be after the start date.";

            if (v["status"] as string == "Active")
            {
                if ((DateTime)v["startDate"] > DateTime.Today)
                    return "An Active lease can't start in the future.";
                if ((DateTime)v["endDate"] < DateTime.Today)
                    return "An Active lease can't have an end date that has passed.";
            }
            return null;
        }

        // ---------------- billing ----------------
        // lease: fill from database with ACTIVE leases, text like "Maria Santos - Unit 101".
        //        In Edit, fill it with just the bill's own lease (it is read-only).
        // Status is not asked: it is worked out from the payments (v_billing view),
        // so a new bill is always Unpaid. Edit adds "Cancel bill", the only way to cancel.
        public static FormField[] Bill(FormMode mode = FormMode.New)
        {
            bool edit = mode == FormMode.Edit;
            var list = new List<FormField>
            {
                new FormField { Key = "lease", Label = "Tenant / unit", Type = FieldType.Dropdown, ReadOnly = edit },
                new FormField { Key = "billType", Label = "Bill type", Type = FieldType.Dropdown,
                    Options = new[] { "Rent", "Utilities", "Penalty", "Association Dues", "Other" },
                    DefaultValue = "Rent" },
                new FormField { Key = "billDate", Label = "Bill date", Type = FieldType.Date,
                    DefaultValue = DateTime.Today },
                new FormField { Key = "dueDate", Label = "Due date", Type = FieldType.Date,
                    DefaultValue = DateTime.Today.AddDays(10) },
                new FormField { Key = "amount", Label = "Amount", Type = FieldType.Money }
            };

            if (edit)
            {
                list.Add(new FormField
                {
                    Key = "cancelled",
                    Label = "Cancel bill",
                    Type = FieldType.Dropdown,
                    Options = new[] { "No", "Yes" },
                    DefaultValue = "No"
                });
            }
            return list.ToArray();
        }

        public static string ValidateBill(Dictionary<string, object> v)
        {
            if ((DateTime)v["dueDate"] < (DateTime)v["billDate"])
                return "Due date can't be before the bill date.";
            return null;
        }

        // ---------------- payments ----------------
        // Each payment is a row in the payment table; the bill's paid amount, balance and status
        // come from those rows (v_billing view). Only money that actually arrived is recorded,
        // so there is no status field (a returned payment is marked Refunded in the database).
        // refNo: leave it blank and the page creates one (like BT-20261103-0001);
        //        type it to keep an outside number, such as a bank or e-wallet transaction no.
        // bill: fill from database with unpaid / partially paid bills,
        //       text like "B-0007 - Maria Santos - P6,000.00 left".
        // Add a Validator in the page to stop an amount above the remaining balance.
        public static FormField[] Payment()
        {
            return new[]
            {
                new FormField { Key = "bill", Label = "Bill", Type = FieldType.Dropdown },
                new FormField { Key = "amount", Label = "Amount", Type = FieldType.Money },
                new FormField { Key = "mode", Label = "Payment mode", Type = FieldType.Dropdown,
                    Options = new[] { "Cash", "Bank Transfer", "E-Wallet", "Check", "Credit Card", "Debit Card" },
                    DefaultValue = "Cash" },
                new FormField { Key = "paymentDate", Label = "Payment date", Type = FieldType.Date,
                    DefaultValue = DateTime.Today },
                new FormField { Key = "refNo", Label = "Reference no.", MaxLength = 45, Required = false }
            };
        }

        // ---------------- maintenance ----------------
        // unit: fill from database and add new ComboItem(null, "Common area") as the first choice.
        // resident / technician: fill from database (optional).
        // Statuses are the database names: Open, In Progress, Resolved, Closed.
        public static FormField[] Maintenance(FormMode mode = FormMode.New)
        {
            var list = new List<FormField>
            {
                new FormField { Key = "unit", Label = "Unit", Type = FieldType.Dropdown },
                new FormField { Key = "resident", Label = "Reported by", Type = FieldType.Dropdown, Required = false },
                new FormField { Key = "problem", Label = "Problem", Type = FieldType.LongText, MaxLength = 255 },
                new FormField { Key = "maintenanceType", Label = "Type", Type = FieldType.Dropdown,
                    Options = new[] { "Plumbing", "Electrical", "Appliance", "Structural", "Other" } },
                new FormField { Key = "priority", Label = "Priority", Type = FieldType.Dropdown,
                    Options = new[] { "Low", "Medium", "High", "Urgent" }, DefaultValue = "Medium" },
                new FormField { Key = "dateReported", Label = "Date reported", Type = FieldType.Date,
                    DefaultValue = DateTime.Today }
            };

            if (mode == FormMode.Edit)
            {
                list.Add(new FormField
                {
                    Key = "status",
                    Label = "Status",
                    Type = FieldType.Dropdown,
                    Options = new[] { "Open", "In Progress", "Resolved", "Closed" },
                    DefaultValue = "Open"
                });
                list.Add(new FormField { Key = "technician", Label = "Assigned to", Type = FieldType.Dropdown, Required = false });
                list.Add(new FormField { Key = "dateCompleted", Label = "Date completed", Type = FieldType.Date, Required = false });
                list.Add(new FormField { Key = "cost", Label = "Cost", Type = FieldType.Money, Required = false });
                list.Add(new FormField
                {
                    Key = "repairDetails",
                    Label = "Repair details",
                    Type = FieldType.LongText,
                    Required = false,
                    MaxLength = 255
                });
            }
            return list.ToArray();
        }

        public static string ValidateMaintenance(Dictionary<string, object> v)
        {
            if (v.ContainsKey("status"))
            {
                var status = v["status"] as string;
                if ((status == "Resolved" || status == "Closed") && v["dateCompleted"] == null)
                    return "Enter the completion date for a resolved request.";
            }

            if (v.ContainsKey("dateCompleted") && v["dateCompleted"] is DateTime)
            {
                var completed = (DateTime)v["dateCompleted"];
                if (completed < (DateTime)v["dateReported"])
                    return "Completion date can't be before the date reported.";
                if (completed > DateTime.Today)
                    return "Completion date can't be in the future.";
            }
            return null;
        }
    }
}