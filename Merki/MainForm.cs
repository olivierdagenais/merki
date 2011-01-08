using System.Windows.Forms;
using System.IO;
using System;

using Timer = System.Timers.Timer;

namespace Merki
{
    public partial class MainForm : Form
    {
        string Document { get; set; }
        Repository Repository { get; set; }
        WikiRenderer wikiRenderer = new WikiRenderer();
        Timer timer = new Timer(250);

        public MainForm(Repository repository)
        {
            Repository = repository;
            InitializeComponent();
            LoadDocument("home.wiki");

            timer.AutoReset = false;
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var wikiText = editor.Text;
            var renderedText = wikiRenderer.Render(wikiText);
            previewBrowser.DocumentText = renderedText;
            SaveDocument();
        }

        private void EditorChanged(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }

        private void LoadDocument(string filename)
        {
            Document = filename;
            editor.Text = Repository.LoadFromFile(filename);
        }

        private void SaveDocument()
        {
            Repository.WriteToFile(Document, editor.Text);
            Repository.Commit();
            Repository.Push();
            Repository.Pull();
            // TODO: Check time stamp on active document
            Repository.Update();
        }
    }
}
