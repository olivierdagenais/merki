using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Merki
{
    public partial class NewPageForm : Form
    {
        public string PageTitle { get { return pageTitle.Text; } }

        public NewPageForm()
        {
            InitializeComponent();
            ValidateFields();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void pageTitleChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        void ValidateFields()
        {
            var validator = new Regex(@"^[a-zA-Z0-9'\s]+$");
            okButton.Enabled = validator.IsMatch(pageTitle.Text);
        }
    }
}
