using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tåg_project.FileManipulation;
using TrainReport;

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
            if (path != null)
            {
                openForm();
            }
        }
    }
}
