﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Markup;

namespace Interface
{
    public partial class MainForm : Form
    {
        WikiRenderer wikiRenderer = new WikiRenderer();

        public MainForm()
        {
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