using System;
using System.IO;
using System.Windows.Forms;
using Tåg_project.FileManipulation;

namespace Tåg_project.Core
{
    public partial class StartForm : Form
    {
        private string path;
        private Form _currentChildForm;
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            openForm();
        }

        private void openForm()
        {
            Panel parentPanel = (Panel)this.Parent;
            var parentForm = parentPanel;
            _currentChildForm?.Close();
            _currentChildForm = new Home(path);
            _currentChildForm.Owner = this;
            Utils.OpenChildForm(_currentChildForm, parentForm);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            path = FolderDialogHelper.SelectedFolder();
            if (path != null && HasDesiredProperty(path))
            {
                openForm();
            }
            else
            {
                MessageBox.Show("Select a valid Path", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private bool HasDesiredProperty(string folder)
        {
            // Get the name of the folder without the full path.
            string folderName = Path.GetFileName(folder);

            // Check if the folder name consists of only numbers.
            if (folderName != "")
            {
                foreach (char c in folderName)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
            }
            else return false;
            

            return true;
        }
    }
}
