#nullable disable
using System;

namespace PMS_v1   // keep as PMS_v1 so every page can see it
{
    /// <summary>
    /// The fields for each page's form. To change a form, edit its list here.
    /// All dropdown choices below are placeholders: swap them for real values later.
    /// </summary>
    public static class FormDefinitions
    {
        private static readonly string[] SampleTenants = { "Angela Cruz", "Jose Reyes", "Maria Santos" };
        private static readonly string[] SampleUnits = { "Unit 101", "Unit 102", "Unit 103" };

        public static FormField[] Bill()
        {
            return new[]
            {
                new FormField { Key = "tenant", Label = "Tenant", Type = FieldType.Dropdown, Options = SampleTenants },
                new FormField { Key = "billType", Label = "Bill type", Type = FieldType.Dropdown,
                    Options = new[] { "Rent", "Utilities", "Penalty", "Association Dues", "Other" }, DefaultValue = "Rent" },
                new FormField { Key = "billDate", Label = "Bill date", Type = FieldType.Date },
                new FormField { Key = "dueDate", Label = "Due date", Type = FieldType.Date },
                new FormField { Key = "amount", Label = "Amount", Type = FieldType.Money },
                new FormField { Key = "status", Label = "Status", Type = FieldType.Dropdown,
                    Options = new[] { "Unpaid", "Partially Paid", "Paid", "Overdue", "Canceled" }, DefaultValue = "Unpaid" }
            };
        }

        public static FormField[] Lease()
        {
            return new[]
            {
                new FormField { Key = "tenant", Label = "Tenant", Type = FieldType.Dropdown, Options = SampleTenants },
                new FormField { Key = "unit", Label = "Unit", Type = FieldType.Dropdown, Options = SampleUnits },
                new FormField { Key = "startDate", Label = "Start date", Type = FieldType.Date },
                new FormField { Key = "endDate", Label = "End date", Type = FieldType.Date,
                    DefaultValue = DateTime.Today.AddYears(1) },
                new FormField { Key = "monthlyRent", Label = "Monthly rent", Type = FieldType.Money },
                new FormField { Key = "status", Label = "Status", Type = FieldType.Dropdown,
                    Options = new[] { "Pending", "Active", "Terminated" }, DefaultValue = "Pending" }
            };
        }

        public static FormField[] Payment()
        {
            return new[]
            {
                new FormField { Key = "tenant", Label = "Tenant", Type = FieldType.Dropdown, Options = SampleTenants },
                new FormField { Key = "amount", Label = "Amount", Type = FieldType.Money },
                new FormField { Key = "method", Label = "Payment method", Type = FieldType.Dropdown,
                    Options = new[] { "Cash", "Bank Transfer", "Check", "E-Wallet" } },
                new FormField { Key = "paymentDate", Label = "Payment date", Type = FieldType.Date },
                new FormField { Key = "status", Label = "Status", Type = FieldType.Dropdown,
                    Options = new[] { "Pending", "Completed", "Failed", "Refunded" }, DefaultValue = "Pending" }
            };
        }

        public static FormField[] Maintenance()
        {
            return new[]
            {
                new FormField { Key = "unit", Label = "Unit", Type = FieldType.Dropdown, Options = SampleUnits },
                new FormField { Key = "issue", Label = "Issue", Type = FieldType.Text },
                new FormField { Key = "priority", Label = "Priority", Type = FieldType.Dropdown,
                    Options = new[] { "Low", "Medium", "High" }, DefaultValue = "Medium" },
                new FormField { Key = "reportedDate", Label = "Date reported", Type = FieldType.Date },
                new FormField { Key = "status", Label = "Status", Type = FieldType.Dropdown,
                    Options = new[] { "Pending", "In Progress", "Completed" }, DefaultValue = "Pending" }
            };
        }
    }
}