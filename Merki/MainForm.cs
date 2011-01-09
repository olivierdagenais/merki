﻿using System.Windows.Forms;
using System.IO;
using System;

using Timer = System.Timers.Timer;

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
    }
}
