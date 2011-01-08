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

            var repo = new Repository("repo");
            if (RepositoryValid(repo))
                Application.Run(new MainForm(repo));
        }

        static bool RepositoryValid(Repository repo)
        {
            var repositoryConfiguration = new RepositoryConfiguration();

            while (!repo.Initialized)
            {
                var result = repositoryConfiguration.ShowDialog();
                if (result != DialogResult.OK)
                    return false;

                var url = repositoryConfiguration.RepositoryUrl;
                repo.Clone(url);
            }
            return true;
        }
    }
}
