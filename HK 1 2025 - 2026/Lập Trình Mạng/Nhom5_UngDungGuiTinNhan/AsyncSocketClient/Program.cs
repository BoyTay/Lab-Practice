using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncSocketClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var authForm = new frmAuth())
            {
                var result = authForm.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(authForm.AuthenticatedUsername))
                {
                    Application.Run(new frmClient(authForm.AuthenticatedUsername, authForm.AuthenticatedPassword));
                }
            }
        }
    }
}
