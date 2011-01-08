﻿using System.Diagnostics;
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
            Exec("clone {0} {1}", url, Root);
        }

        int Exec(string commandFormat, params string[] args)
        {
            var cmd = String.Format(commandFormat, args);

            var pi = new ProcessStartInfo("hg", cmd);
            pi.CreateNoWindow = true;
            pi.RedirectStandardError = false;
            pi.RedirectStandardInput = false;
            pi.RedirectStandardOutput = false;
            pi.UseShellExecute = true;
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            pi.WorkingDirectory = new FileInfo(Root).DirectoryName;

            var p = Process.Start(pi);
            p.WaitForExit();
            return p.ExitCode;
        }
    }
}
