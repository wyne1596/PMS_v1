using Microsoft.VisualBasic.ApplicationServices;
using PMS_v1.Pages.Main;
using PMS_v1.ExceptionHandler;

namespace PMS_v1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ErrorHandler.Install();   // an error nobody handled shows a message instead of closing the app
            ApplicationConfiguration.Initialize();

            while (true)
            {
                var login = new Login();
                if (login.ShowDialog() != DialogResult.OK) break;

                var main = new Main();
                Application.Run(main);

                if (!main.LoggedOut) break;   // closed with X, so exit the app
            }


        }
    }
}