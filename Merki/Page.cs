using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace Merki
{
    public class Page
    {
        public string Text { get; set; }
        public FileInfo DiskFile { get; set; }
        Dictionary<string, string> meta = new Dictionary<string, string>();

        public Page(FileInfo wikiFile)
        {
            DiskFile = wikiFile;
            Reload();
        }

        public void Reload()
        {
            var metaRegex = new Regex(@"^([^:]+):(.*)$", RegexOptions.Compiled);

            var pageText = File.ReadAllText(DiskFile.FullName);
            using (var sr = new StringReader(pageText))
            {
                for (;;)
                {
                    var line = sr.ReadLine();
                    var match = metaRegex.Match(line);
                    if (!match.Success) break;

                    var key = match.Groups[1].Value.Trim();
                    var value = match.Groups[2].Value.Trim();
                    this[key] = value;
                }
                // the empty line gets skipped

                Text = sr.ReadToEnd();
            }
        }

        public void Save()
        {
            using (var sw = new StringWriter())
            {
                foreach (var key in meta.Keys)
                    sw.WriteLine("{0}: {1}", key, this[key]);

                sw.WriteLine();

                sw.Write(Text);

                File.WriteAllText(DiskFile.FullName, sw.ToString());
            }
        }

        public string this[string key]
        {
            get
            {
                var result = meta[key];
                return result;
            }
            set
            {
                meta.Add(key, value);
            }
        }

        public bool Matches(string filter)
        {
            var result = Text.Contains(filter);
            return result;
        }

        public static List<Page> Search(DirectoryInfo repositoryRoot, string filter)
        {
            var result = new List<Page>();

            var keywords = filter.Split(' ');
            foreach (var fileInfo in repositoryRoot.GetFiles("*.wiki"))
            {
                var page = new Page(fileInfo);

                bool matches = true;
                foreach (var keyword in keywords)
                {
                    if (!page.Matches(keyword))
                    {
                        matches = false;
                        break;
                    }
                }

                if (matches)
                    result.Add(page);
            }

            return result;
        }
    }
}
