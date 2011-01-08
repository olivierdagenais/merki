using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Markup;

namespace Merki
{
    public partial class MainForm : Form
    {
        Repository Repository { get; set; }
        WikiRenderer wikiRenderer = new WikiRenderer();

        public MainForm(Repository repository)
        {
            Repository = repository;
            InitializeComponent();
        }

        private void UpdatePreview(object sender, EventArgs e)
        {
            var wikiText = editor.Text;
            var renderedText = wikiRenderer.Render(wikiText);
            previewBrowser.DocumentText = renderedText;
        }
    }
}
