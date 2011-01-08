using System.Diagnostics;
using System.IO;
using System;

namespace Merki
{
    public class Repository
    {
        string Root { get; set; }
        string UserName { get; set; }

        public Repository(string rootDirectory, string username)
        {
            Root = rootDirectory;
            UserName = username;
        }

        public bool Initialized
        {
            get
            {
                var path = Path.Combine(Root, ".hg");
                var result = Directory.Exists(path);
                return result;
            }
        }

        public void Clone(string url)
        {
            if (Initialized) throw new Exception("Already Initialized!");
            Exec("clone {0} {1}", url, Root);
        }

        public void Commit()
        {
            Exec("commit -m automatic -u \"{0}\"", UserName);
        }

        public void Push()
        {
            Exec("push");
        }

        public void Pull()
        {
            Exec("pull");
        }

        public void Update()
        {
            // TODO: Detect conflicts
            Exec("update");
        }

        int Exec(string commandFormat, params object[] args)
        {
            var cmd = String.Format(commandFormat, args);

            var pi = new ProcessStartInfo("hg", cmd);
            //pi.CreateNoWindow = false;
            pi.RedirectStandardError = true;
            pi.RedirectStandardInput = false;
            pi.RedirectStandardOutput = true;
            pi.UseShellExecute = false;
            //pi.WindowStyle = ProcessWindowStyle.Hidden;
            pi.WorkingDirectory = new FileInfo(Root).DirectoryName;

            var p = Process.Start(pi);
            p.WaitForExit();

            var outputText = p.StandardOutput.ReadToEnd();
            var outputError = p.StandardError.ReadToEnd();

            return p.ExitCode;
        }

        public string LoadFromFile(string filename)
        {
            var file = Path.Combine(Root, filename);
            var fullpath = new FileInfo(file).FullName;
            var result = File.ReadAllText(fullpath);
            return result;
        }

        public void WriteToFile(string filename, string content)
        {
            var file = Path.Combine(Root, filename);
            var fullpath = new FileInfo(file).FullName;
            File.WriteAllText(fullpath, content);
        }
    }
}
