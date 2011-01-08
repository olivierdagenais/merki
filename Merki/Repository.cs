using System.Diagnostics;
using System.IO;
using System;

namespace Merki
{
    public class Repository
    {
        string Root { get; set; }

        public Repository(string rootDirectory)
        {
            Root = rootDirectory;
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
            Exec(new FileInfo(Root).Directory, "clone {0} {1}", url, Root);
        }

        public void Add()
        {
            Exec("add .");
        }

        public void Commit()
        {
            Exec("commit -m automatic");
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
            var result = Exec(new DirectoryInfo(Root), commandFormat, args);
            return result;
        }

        int Exec(DirectoryInfo workingDirectory, string commandFormat, params object[] args)
        {
            var cmd = String.Format(commandFormat, args);

            var pi = new ProcessStartInfo("hg", cmd);
            pi.CreateNoWindow = true;
            pi.UseShellExecute = false;
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            pi.WorkingDirectory = workingDirectory.FullName;

            var p = Process.Start(pi);
            p.WaitForExit();

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
