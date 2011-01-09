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

            var username = System.Environment.UserName;
            var homePage = new Page( Repository[username + ".wiki"] );
            if (homePage.IsNew)
                homePage["Title"] = username + "'s Home Page";

            LoadDocument( homePage );
            SearchFilterChanged();

            timer.AutoReset = false;
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdatePreview(ActivePage);
            SaveDocument();
        }

        private void UpdatePreview(Page page)
        {
            if (page != null)
            {
                var wikiText = page.Text;
                var renderedText = wikiRenderer.Render(wikiText);
                previewBrowser.DocumentText = renderedText;
            }
            else
            {
                previewBrowser.DocumentText = string.Empty;
            }
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
                UpdatePreview(ActivePage);
            }
        }

        private void LoadDocument(Page page)
        {
            loading = true;
            SaveDocument();

            ActivePage = page;
            editor.Text = ActivePage.Text;
            searchText.Clear();
            editor.Focus();

            loading = false;

            Text = ActivePage == null
                ? string.Empty
                : string.Format("{0} - Merki", ActivePage["Title"]);
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
                    lvi.Tag = page;
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
            if (search.SelectedItems.Count == 0)
            {
                UpdatePreview(null);
            }
            else
            {
                var page = (Page)search.SelectedItems[0].Tag;
                UpdatePreview(page);
            }
        }

        private void newPageMenuItem_Click(object sender, EventArgs e)
        {
            var newPageDialog = new NewPageForm();
            var result = newPageDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var name = Guid.NewGuid() + ".wiki";
                var page = new Page( Repository[name] );
                page["Title"] = newPageDialog.PageTitle;
                LoadDocument(page);
            }
        }

        private void ResizeSearchBox(object sender, EventArgs e)
        {
            pageTitleColumnHeader.Width = search.Width - search.Margin.Horizontal;
        }

        private void SearchResultActivated(object sender, EventArgs e)
        {
            if (search.SelectedItems.Count > 0)
            {
                var page = (Page)search.SelectedItems[0].Tag;
                LoadDocument(page);
            }

        }
    }
}
