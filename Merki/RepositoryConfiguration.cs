﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Merki
{
    public partial class RepositoryConfiguration : Form
    {
        public string RepositoryUrl
        {
            get
            {
                var result = cloneUrl.Text;
                return result;
            }
        }

        public RepositoryConfiguration()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}