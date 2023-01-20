using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Tåg_project.FileManipulation;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Tåg_project.Core
{
    public partial class Home : Form
    {
        string path;
        bool clean;
        int serialNum, imgCount;
        List<string> imagesPath = new List<string>();
        int page = 0;
        public Home(string tempPath)
        {
            InitializeComponent();
            InitialDesign();
            path = tempPath;
            if (tempPath != null)
            {
                importData();
                //lbl_Dir.Text = "The current directory is: " + tempPath;
            }
            //else lbl_Dir.Text = "There is no directory selected";
        }

        private void InitialDesign()
        {
            btnPrev.Enabled = false;
            lblComponents.Enabled = false;
            lblComponents.Visible= false;
            txtComponents.Enabled = false;
            txtComponents.Visible= false;
        }

        private void UpdateDesign()
        {
            lblImages.Text = imgCount.ToString() + "image(s)";
            //lbl_Dir.Text = "The current directory is: " + path;
        }

        #region FileManipulation
        //TODO: import the values from .import to the local variables and create new funcion to update values on UI
        private void importData()
        {
            TrainReport.FileManipulation.Import import = new TrainReport.FileManipulation.Import(path);
            txtSerialNum.Text = import.serialNum.ToString();
            cboxClean.Checked = import.isClean;
            imgCount = import.imgCount;
            serialNum = import.serialNum;
            clean = import.isClean;
            lblImages.Text = imgCount.ToString();
            imagesPath.Clear();
            imagesPath = import.imagesPath;
        }
        #endregion

        #region Button clicks and textbox key press
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (imgCount > 0)
            {
                //Checks if textbox has data and saves the string as int
                if (txtSerialNum.Text != "")
                {
                    serialNum = int.Parse(txtSerialNum.Text);
                    Console.WriteLine(serialNum.ToString());
                }

                clean = cboxClean.Checked;
                MessageBox.Show("First choose the directory where the files will be placed, note that a new folder will be created in there!");
                path = FolderDialogHelper.SelectedFolder();
                if (path != null)
                {
                    TrainReport.FileManipulation.Export export = new TrainReport.FileManipulation.Export(serialNum, clean, imagesPath, imgCount, false, path);
                    path = export.path;
                    UpdateDesign();
                }
            }
            else
            {
                MessageBox.Show("You need to import some images of the PCB first!", "Image not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //imgCount = 0;
            dialog.Filter = "Select Valid Document(*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in dialog.FileNames)
                {
                    // do something with path
                    imagesPath.Add(fileName);
                    imgCount++;
                }
                lblImages.Text = imgCount.ToString() + " images imported";
            }
            else return;
        }
        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            TrainReport.FileManipulation.ExportPDF pdf = new TrainReport.FileManipulation.ExportPDF(path, imagesPath, serialNum);
            return;
        }
        private void btnInstructions_Click(object sender, EventArgs e)
        {
            Process mydoc = new Process();
            mydoc.StartInfo.FileName = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\teste.docx";
            mydoc.Start();
            //browser.Dock = DockStyle.Fill;
            //browser.Visible = true;
            //browser.Navigate("C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\teste\\oldReports\\Report_1010\\Report_1010.pdf");
        }
        private void btnClearImg_Click(object sender, EventArgs e)
        {
            imagesPath.Clear();
            lblImages.Text = "";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (page == 1)
            {
                btnPrev.Enabled = false;
                pnlFirst.Width = pnlMiddle.Width;
                pnlMiddle.Width = pnlFinal.Width = 0;
                page--;
            }else if (page == 2)
            {
                pnlMiddle.Width = pnlFinal.Width;
                pnlFirst.Width = pnlFinal.Width = 0;
                page--;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (page == 0)
            {
                page++;
                btnPrev.Enabled = true;
                pnlMiddle.Width = pnlFirst.Width;
                pnlFinal.Width = pnlFirst.Width = 0;
                btnPrev.Enabled = true;
            }else if (page == 1)
            {
                page++;
                pnlFinal.Width = pnlMiddle.Width;
                pnlMiddle.Width = pnlFirst.Width = 0;
            }
        }

        private void txtSerialNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
