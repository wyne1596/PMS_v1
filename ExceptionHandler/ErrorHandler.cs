using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PMS_v1.ExceptionHandler
{
    /// <summary>
    /// The one place that shows errors.
    ///
    ///   Program.Main:      ErrorHandler.Install();                              // catches everything nobody else caught
    ///   a page's catch:    catch (Exception ex) { ErrorHandler.Show(this, ex, ErrorRules.Resident); }
    ///   a message only:    string text = ErrorHandler.Describe(ex, ErrorRules.Lease);
    ///   a failed page load: ErrorHandler.ShowLoadError(this, "report", "Reports");
    /// </summary>
    public static class ErrorHandler
    {
        private static bool installed;
        private static bool showing;   // so a repeating error can't stack message boxes

        /// <summary>
        /// Call once at the start of Main, before any window is created. After this, an error that no
        /// page handled shows a message instead of closing the app.
        /// </summary>
        public static void Install()
        {
            if (installed) return;
            installed = true;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, e) => ShowUnexpected(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            {
                if (e.ExceptionObject is Exception ex) ShowUnexpected(ex);
            };
        }

        /// <summary>The message for an error: the first matching rule's message, otherwise the error's own message.</summary>
        public static string Describe(Exception ex, params ErrorRule[] rules)
        {
            ErrorRule? rule = Find(ex, rules);
            return rule?.Message ?? ex.Message;
        }

        /// <summary>Shows an error in a message box, using the first matching rule (or the error's own message).</summary>
        public static void Show(IWin32Window? owner, Exception ex, params ErrorRule[] rules)
        {
            ErrorRule? rule = Find(ex, rules);
            Display(owner, rule?.Message ?? ex.Message, rule?.Title, rule?.Icon ?? MessageBoxIcon.None);
        }

        /// <summary>A page could not load its data (what = "report", "dashboard", ...).</summary>
        public static void ShowLoadError(IWin32Window? owner, string what, string title)
        {
            Display(owner, "The " + what + " couldn't be loaded. Check the database connection and try again.",
                title, MessageBoxIcon.Warning);
        }

        /// <summary>The chosen file is not a picture the app can read.</summary>
        public static void ShowInvalidPicture(IWin32Window? owner)
        {
            Display(owner, "That file couldn't be read as a picture. Choose a JPG, PNG or BMP.",
                "Can't use that file", MessageBoxIcon.Warning);
        }

        // ---------- inside ----------
        private static ErrorRule? Find(Exception ex, ErrorRule[] rules)
        {
            foreach (ErrorRule rule in rules)
                if (rule.Matches(ex)) return rule;
            return null;
        }

        private static void ShowUnexpected(Exception ex)
        {
            if (showing) return;
            showing = true;
            try
            {
                string text = ex is MySqlException
                    ? "A database error occurred. Check the database connection and try again.\n\n" + ex.Message
                    : "Something went wrong.\n\n" + ex.Message;
                Display(null, text, "Unexpected error", MessageBoxIcon.Error);
            }
            finally
            {
                showing = false;
            }
        }

        private static void Display(IWin32Window? owner, string message, string? title, MessageBoxIcon icon)
        {
            if (title == null && icon == MessageBoxIcon.None)
                MessageBox.Show(owner, message);
            else
                MessageBox.Show(owner, message, title ?? Application.ProductName, MessageBoxButtons.OK, icon);
        }
    }
}
