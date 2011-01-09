using System.Windows.Forms;
using System.IO;
using System;

using Timer = System.Timers.Timer;
using System.Collections.Generic;

namespace Merki
{
    public partial class MainForm : Form
    {
        Page ActivePage { get; set; }
        Repository Repository { get; set; }
        WikiRenderer wikiRenderer = new WikiRenderer();
        Timer timer = new Timer(250);
        bool loading = false;

        public MainForm(Repository repository)
        {
            Repository = repository;
            InitializeComponent();
            LoadDocument("home.wiki");
            SearchFilterChanged();

            timer.AutoReset = false;
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdatePreview();
            SaveDocument();
        }

        private void UpdatePreview()
        {
            var wikiText = editor.Text;
            var renderedText = wikiRenderer.Render(wikiText);
            previewBrowser.DocumentText = renderedText;
        }

        private void EditorChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                timer.Stop();
                timer.Start();
            }
            else
            {
                UpdatePreview();
            }
        }

        private void LoadDocument(string filename)
        {
            loading = true;
            SaveDocument();

            var fileInfo = Repository[filename];
            ActivePage = new Page(fileInfo);
            editor.Text = ActivePage.Text;

            loading = false;
        }

        private void SaveDocument()
        {
            if (ActivePage != null)
            {
                ActivePage.Text = editor.Text;
                ActivePage.Save();
            }

            Repository.Add();
            Repository.Commit();
            Repository.Push();
            Repository.Pull();
            // TODO: Check time stamp on active document
            Repository.Update();
        }

        private void SearchFilterChanged()
        {
            if (searchText.Text.Length == 0)
            {
                searchBox.Visible = false;
                editBox.Visible = true;
                editBox.Dock = DockStyle.Fill;
            }
            else
            {
                editBox.Visible = false;
                searchBox.Visible = true;
                searchBox.Dock = DockStyle.Fill;

                var pages = Page.Search(Repository.Directory, searchText.Text);
                var lvic = search.Items;
                lvic.Clear();
                foreach (var page in pages)
                {
                    var lvi = new ListViewItem(page["Title"]);
                    lvic.Add(lvi);
                }
            }
        }

        private void SearchFilterChanged(object sender, EventArgs e)
        {
            SearchFilterChanged();
        }

        private void SearchResultSelected(object sender, EventArgs e)
        {

        }

        private void SearchResultSelectedForEdit(object sender, EventArgs e)
        {

        }
    }
}
