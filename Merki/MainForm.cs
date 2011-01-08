using System.Windows.Forms;
using System;

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
