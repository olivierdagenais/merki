namespace Merki
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.searchText = new System.Windows.Forms.ToolStripTextBox();
            this.searchBox = new System.Windows.Forms.GroupBox();
            this.search = new System.Windows.Forms.ListView();
            this.editor = new System.Windows.Forms.TextBox();
            this.split = new System.Windows.Forms.SplitContainer();
            this.leftPane = new System.Windows.Forms.Panel();
            this.editBox = new System.Windows.Forms.GroupBox();
            this.previewBox = new System.Windows.Forms.GroupBox();
            this.previewBrowser = new System.Windows.Forms.WebBrowser();
            this.menu.SuspendLayout();
            this.searchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.leftPane.SuspendLayout();
            this.editBox.SuspendLayout();
            this.previewBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchText});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(540, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // searchText
            // 
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(100, 21);
            this.searchText.TextChanged += new System.EventHandler(this.SearchFilterChanged);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Controls.Add(this.search);
            this.searchBox.Location = new System.Drawing.Point(6, 140);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(258, 139);
            this.searchBox.TabIndex = 2;
            this.searchBox.TabStop = false;
            this.searchBox.Text = "Search";
            // 
            // search
            // 
            this.search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search.FullRowSelect = true;
            this.search.Location = new System.Drawing.Point(3, 16);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(252, 120);
            this.search.TabIndex = 0;
            this.search.UseCompatibleStateImageBehavior = false;
            this.search.View = System.Windows.Forms.View.List;
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(3, 16);
            this.editor.Multiline = true;
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(255, 96);
            this.editor.TabIndex = 0;
            this.editor.TextChanged += new System.EventHandler(this.EditorChanged);
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 25);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.leftPane);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.previewBox);
            this.split.Size = new System.Drawing.Size(540, 285);
            this.split.SplitterDistance = 270;
            this.split.TabIndex = 3;
            // 
            // leftPane
            // 
            this.leftPane.Controls.Add(this.editBox);
            this.leftPane.Controls.Add(this.searchBox);
            this.leftPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPane.Location = new System.Drawing.Point(0, 0);
            this.leftPane.Name = "leftPane";
            this.leftPane.Size = new System.Drawing.Size(270, 285);
            this.leftPane.TabIndex = 1;
            // 
            // editBox
            // 
            this.editBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editBox.Controls.Add(this.editor);
            this.editBox.Location = new System.Drawing.Point(3, 4);
            this.editBox.Name = "editBox";
            this.editBox.Size = new System.Drawing.Size(261, 115);
            this.editBox.TabIndex = 0;
            this.editBox.TabStop = false;
            this.editBox.Text = "Edit";
            // 
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.Controls.Add(this.previewBrowser);
            this.previewBox.Location = new System.Drawing.Point(3, 4);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(260, 276);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            this.previewBox.Text = "Preview";
            // 
            // previewBrowser
            // 
            this.previewBrowser.AllowWebBrowserDrop = false;
            this.previewBrowser.CausesValidation = false;
            this.previewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBrowser.IsWebBrowserContextMenuEnabled = false;
            this.previewBrowser.Location = new System.Drawing.Point(3, 16);
            this.previewBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.previewBrowser.Name = "previewBrowser";
            this.previewBrowser.ScriptErrorsSuppressed = true;
            this.previewBrowser.Size = new System.Drawing.Size(254, 257);
            this.previewBrowser.TabIndex = 0;
            this.previewBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 310);
            this.Controls.Add(this.split);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Merki";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.searchBox.ResumeLayout(false);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.leftPane.ResumeLayout(false);
            this.editBox.ResumeLayout(false);
            this.editBox.PerformLayout();
            this.previewBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripTextBox searchText;
        private System.Windows.Forms.GroupBox searchBox;
        private System.Windows.Forms.ListView search;
        private System.Windows.Forms.TextBox editor;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.GroupBox editBox;
        private System.Windows.Forms.GroupBox previewBox;
        private System.Windows.Forms.WebBrowser previewBrowser;
        private System.Windows.Forms.Panel leftPane;
    }
}

