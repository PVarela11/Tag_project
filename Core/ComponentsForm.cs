using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Tåg_project.Core
{
    public partial class ComponentsForm : Form
    {
        public string teste
        {
            get { return txtComponent.Text; }
        }
        string componentImg, componentBeforeImg, componentAfterImg, name;
        public List<Component> componentsList = new List<Component>();
        public ComponentsForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.MotionControlIcon;
            btnFinish.DialogResult = DialogResult.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewComponent_Click(object sender, EventArgs e)
        {
            btnFinish.DialogResult = DialogResult.None;
            if (validate())
            {
                //Save and add another
                Component x = new Component(txtComponent.Text, componentImg, componentBeforeImg, componentAfterImg, txtDescription.Text);
                componentsList.Add(x);
                componentImg = null;
                componentBeforeImg = null;
                componentAfterImg = null;
                txtComponent.Clear();
                txtDescription.Clear();
                lblImage.Text = "Import component image";
                lblImportAfterImage.Text = "Import component image";
                lblImportBeforeImage.Text = "Import component image";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if(txtComponent.Text == "" && txtDescription.Text == "" && componentAfterImg == null && componentBeforeImg == null && componentImg == null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            //Save and close
            if (validate())
            {
                this.DialogResult = DialogResult.OK;
                Component x = new Component(txtComponent.Text, componentImg, componentBeforeImg, componentAfterImg, txtDescription.Text);
                componentsList.Add(x);
                this.Close();
            }
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            name = (sender as Button).Name;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Select Valid Document(*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (name == "btnImportImage")
                {
                    componentImg = dialog.FileName;
                    lblImage.Text = "Image imported";
                }
                else if (name == "btnImportBeforeImage")
                {
                    componentBeforeImg = dialog.FileName;
                    lblImportBeforeImage.Text = "Image imported";
                }
                else if (name == "btnImportAfterImage")
                {
                    componentAfterImg= dialog.FileName;
                    lblImportAfterImage.Text = "Image imported";
                }
                
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            name = (sender as Button).Name;
            if (name == "btnClearImage")
            {
                componentImg = null;
                lblImage.Text = "Component Image";
            }
            else if (name == "btnClearBeforeImage")
            {
                componentBeforeImg = null;
                lblImportBeforeImage.Text = "Component image\r\nbefore cleaning";
            }
            else if (name == "btnClearAfterImage")
            {
                componentAfterImg = null;
                lblImportAfterImage.Text = "Component image\r\nafter cleaning";
            }
        }

        private bool validate()
        {
            if (txtComponent.Text == null)
            {
                MessageBox.Show("What is the name of the component ?");
                return false;
            }
            else if (componentAfterImg == null || componentBeforeImg == null || componentImg == null)
            {
                MessageBox.Show("You should import all the images of the component");
                return false;
            }
            else if (txtDescription.TextLength < 20)
            {
                MessageBox.Show("Write a more detailed description please");
                return false;
            }
            return true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            // Limit the number of lines to 3
            int maxLines = 3;

            // Get the current number of lines
            int numLines = txtDescription.GetLineFromCharIndex(txtDescription.TextLength) + 1;

            // If the number of lines exceeds the limit, delete the extra lines
            if (numLines > maxLines)
            {
                int firstCharIndex = txtDescription.GetFirstCharIndexFromLine(maxLines);
                // Make sure the start index is valid
                if (firstCharIndex >= 0 && firstCharIndex < txtDescription.TextLength)
                {
                    txtDescription.Text = txtDescription.Text.Remove(firstCharIndex);
                    txtDescription.SelectionStart = txtDescription.TextLength;
                }
            }
        }
    }
}
