using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PMS_v1.ExceptionHandler
{
    /// <summary>
    /// One known database error and the message to show for it.
    ///   Number    the MySQL error number (for example 1062 = duplicate value)
    ///   Contains  optional: the error text must also contain this (for example the name of the unique key)
    ///   Message   what to show; null = show the database's own message
    ///   Title     optional message box title
    ///   Icon      optional message box icon
    /// </summary>
    public sealed class ErrorRule
    {
        public int Number { get; }
        public string? Message { get; }
        public string? Contains { get; }
        public string? Title { get; }
        public MessageBoxIcon Icon { get; }

        public ErrorRule(int number, string? message, string? contains = null,
            string? title = null, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            Number = number;
            Message = message;
            Contains = contains;
            Title = title;
            Icon = icon;
        }

        internal bool Matches(Exception ex) =>
            ex is MySqlException db && db.Number == Number &&
            (Contains == null || db.Message.Contains(Contains, StringComparison.Ordinal));
    }
}
