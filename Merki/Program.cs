using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Merki
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (RepositoryValid)
                Application.Run(new MainForm());
        }

        static bool RepositoryValid
        {
            get
            {
                var repoPath = "repo/.hg";
                var repositoryConfiguration = new RepositoryConfiguration();

                while (!Directory.Exists(repoPath))
                {
                    var result = repositoryConfiguration.ShowDialog();
                    if (result != DialogResult.OK)
                        return false;

                    var url = repositoryConfiguration.RepositoryUrl;
                    // TODO: Clone repository
                }
                return true;
            }
        }
    }
}
