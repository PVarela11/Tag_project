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
using System.Windows.Media;
using Tåg_project.FileManipulation;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Tåg_project.Core
{
    public partial class Home : Form
    {
        string path, whichComponents, finalText;
        bool isClean, isEvaluated, isComponentReplaced, finalEvaluation;
        int serialNum, initialImgCount = 0, aux = 0, finalImageCount = 0;
        List<string> initialImagesPath = new List<string>();
        List<string> finalImagesPath  = new List<string>();
        List<string> listAux = new List<string>();
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
            pboxImages.Enabled= false;
            pboxFinalImages.Enabled = false;
            btnPrev.Enabled = false;
            lblComponents.Enabled = false;
            lblComponents.Visible= false;
            txtComponents.Enabled = false;
            txtComponents.Visible= false;
        }

        private void UpdateDesign()
        {
            lblImages.Text = initialImgCount.ToString() + "image(s)";
            //lbl_Dir.Text = "The current directory is: " + path;
        }

        #region FileManipulation
        //TODO: import the values from .import to the local variables and create new funcion to update values on UI
        private void importData()
        {
            TrainReport.FileManipulation.Import import = new TrainReport.FileManipulation.Import(path);
            txtSerialNum.Text = import.serialNum.ToString();
            cboxClean.Checked = import.isClean;;
            serialNum = import.serialNum;
            isClean = import.isClean;
            cboxEletricalEvaluation.Checked = import.isEvaluated;
            cboxComponents.Checked = import.isComponentReplaced;
            if (cboxComponents.Checked)
            {
                txtComponents.Enabled= true;
                txtComponents.Visible= true;
                txtComponents.Text = import.whichComponents.ToString();
            }
            txtFinalThoughts.Text = import.finalText;
            cboxApproved.Checked = import.finalEvaluation;
            lblImages.Text = initialImgCount.ToString();
            initialImagesPath.Clear();
            initialImagesPath = import.initialImagesPath;
            initialImgCount = initialImagesPath.Count();
            //finalImagesPath.Clear();
            //finalImagesPath = import.finalImagesPath;

            if (initialImagesPath.Count != 0)
            {
                pboxImages.Enabled = true;
                pboxImages.ImageLocation = initialImagesPath[0];
            }

            //if (finalImagesPath.Count != 0)
            //{
            //    pboxFinalImages.Enabled = true;
            //    pboxFinalImages.ImageLocation = finalImagesPath[0];
            //}

        }
        #endregion

        #region Button clicks and textbox key press
        private void btnExport_Click(object sender, EventArgs e)
        {
            //if (initialImgCount > 0)
            //{
            //Checks if textbox has data and saves the string as int
            if (txtSerialNum.Text != "")
            {
                serialNum = int.Parse(txtSerialNum.Text);
                Console.WriteLine(serialNum.ToString());
            }

            isClean = cboxClean.Checked;
            isEvaluated = cboxEletricalEvaluation.Checked;
            isComponentReplaced = cboxComponents.Checked;
            whichComponents = txtComponents.Text;
            finalEvaluation = cboxApproved.Checked;
            finalText = txtFinalThoughts.Text;

            MessageBox.Show("Choose the directory where the files will be placed, note that a new folder will be created in there!");
            path = FolderDialogHelper.SelectedFolder();
            
            if (path != null)
            {
                TrainReport.FileManipulation.Export export = new TrainReport.FileManipulation.Export(serialNum, isClean, isEvaluated, isComponentReplaced, whichComponents, finalEvaluation, finalText, initialImagesPath, finalImagesPath, initialImgCount, false, path);
                path = export.path;
                UpdateDesign();
            }else
            {
                MessageBox.Show("Select a valid path!");
            }
        }

        //else
        //{
        //    MessageBox.Show("You need to import some images of the PCB first!", "Image not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            listAux.Clear();
            string name = (sender as Button).Name;
            pboxImages.BackColor = System.Drawing.Color.FromArgb(119, 155, 230);
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Select Valid Document(*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg";
            dialog.Multiselect = true;
            int imgCount = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in dialog.FileNames)
                {
                    // do something with path
                    //initialImagesPath.Add(fileName);
                    listAux.Add(fileName);
                    imgCount++;
                }
                if(name == "btnImportFinalImg"){
                    finalImagesPath.AddRange(listAux);
                    finalImageCount += imgCount;
                    pboxFinalImages.ImageLocation = finalImagesPath[0];
                    pboxFinalImages.Enabled = true;
                }
                else if (name == "btnImportImage")
                {
                    initialImagesPath.AddRange(listAux);
                    initialImgCount += imgCount;
                    pboxImages.ImageLocation = initialImagesPath[0];
                    lblImages.Text = initialImgCount.ToString() + " images imported";
                    pboxImages.Enabled = true;
                }
            }

            else return;
        }
        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            isClean = cboxClean.Checked;
            isEvaluated = cboxEletricalEvaluation.Checked;
            isComponentReplaced = cboxComponents.Checked;
            whichComponents = txtComponents.Text;
            finalEvaluation = cboxApproved.Checked;
            finalText = txtFinalThoughts.Text;
            TrainReport.FileManipulation.ExportPDF pdf = new TrainReport.FileManipulation.ExportPDF(path, initialImagesPath, 
                finalImagesPath, serialNum, isClean, isEvaluated, isComponentReplaced, whichComponents, finalEvaluation, finalText);
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
            initialImagesPath.Clear();
            pboxImages.Enabled = false;
            pboxImages.Image = null;
            pboxImages.BackColor= System.Drawing.Color.FromArgb(119, 155, 230);
            aux = 0;
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
                btnNext.Enabled = true;
            }
        }

        private void pboxImages_Click(object sender, EventArgs e)
        {
            if (aux < initialImgCount - 1)
            {
                aux++;
                pboxImages.ImageLocation = initialImagesPath[aux];
            }
            else
            {
                aux = 0;
                pboxImages.ImageLocation = initialImagesPath[aux];
            }
            
        }

        private void pboxFinalImages_Click(object sender, EventArgs e)
        {
            if (aux < finalImageCount - 1)
            {
                aux++;
                pboxFinalImages.ImageLocation = finalImagesPath[aux];
            }
            else
            {
                aux = 0;
                pboxFinalImages.ImageLocation = finalImagesPath[aux];
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
                btnNext.Enabled = false;
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