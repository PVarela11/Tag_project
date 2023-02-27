using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Tåg_project.Core
{
    public partial class ComponentsForm : Form
    {
        public string teste
        {
            get { return txtComponent.Text; }
        }
        List<string> listAux = new List<string>();
        int imgCount = 0, aux=0;
        public List<Component> componentsList = new List<Component>();
        public ComponentsForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.MotionControlIcon;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnNewComponent_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                //Save and add another
                Component x = new Component(txtComponent.Text, listAux, txtDescription.Text);
                componentsList.Add(x);
                txtComponent.Clear();
                txtDescription.Clear();
                //initialImagesPath.Clear();
                pboxImage.Enabled = false;
                pboxImage.Image = null;
                pboxImage.BackColor = Color.Transparent;
                pboxImage.Enabled = false;
                pboxImage.BackColor = System.Drawing.Color.FromArgb(119, 155, 230);
                pboxImage.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
                //aux = 0;
                lblImage.Text = "Import component image";
            }else MessageBox.Show("You should insert all the data before saving this component!");
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //Save and close
            if (validate())
            {
                Component x = new Component(txtComponent.Text, listAux, txtDescription.Text);
                componentsList.Add(x);
                this.Close();
            }
            else MessageBox.Show("You should insert all the data before saving this component!");
            
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Select Valid Document(*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in dialog.FileNames)
                {
                    // do something with path
                    listAux.Add(fileName);
                    imgCount++;
                }
                pboxImage.ImageLocation = listAux[0];
                pboxImage.Enabled = true;
                lblImage.Text = listAux.Count.ToString() + " images imported";
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            aux = 0;
            listAux.Clear();
            pboxImage.Enabled = false;
            pboxImage.Image = null;
            pboxImage.BackColor = Color.Transparent;
            pboxImage.Enabled = false;
            pboxImage.BackColor = System.Drawing.Color.FromArgb(119, 155, 230);
            pboxImage.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            aux = 0;
            lblImage.Text = "Import component image";
        }

        private void pboxImage_Click(object sender, EventArgs e)
        {
            if (aux < listAux.Count - 1)
            {
                aux++;
                pboxImage.ImageLocation = listAux[aux];
            }
            else
            {
                aux = 0;
                pboxImage.ImageLocation = listAux[aux];
            }
        }

        private bool validate()
        {
            if (txtComponent.TextLength < 4)
            {
                MessageBox.Show("Component name should be bigger than that");
                return false;
            }
            else if (listAux.Count == 0)
            {
                MessageBox.Show("You should import some images of the component first");
                return false;
            }
            else if (txtDescription.TextLength < 20)
            {
                MessageBox.Show("Write a more detailed description please");
                return false;
            }
            return true;
        }
    }
}
