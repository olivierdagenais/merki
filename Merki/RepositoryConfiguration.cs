using System.Windows.Forms;
using System;

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
