﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        TrainReport.FileManipulation.Import import;
        string path, whichComponents, finalText, week, serialNum, lastTwoDigitsOfYear;
        bool isClean, isEvaluated, isComponentReplaced, finalEvaluation;
        int initialImagesCount = 0, aux = 0, finalImagesCount = 0, page = 0;
        List<string> initialImagesPath = new List<string>();
        List<string> finalImagesPath  = new List<string>();
        List<string> listAux = new List<string>();
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
            pnlFinal.Width = 0;
            pnlMiddle.Width = 0;
            DateTime date = DateTime.Now;
            CultureInfo ci = CultureInfo.InvariantCulture;
            int weekNumber = ci.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (weekNumber < 10)
            {
                week = "0" + weekNumber;
            }
            lastTwoDigitsOfYear = date.ToString("yy");

            pboxImages.Enabled= false;
            pboxFinalImages.Enabled = false;
            btnPrev.Enabled = false;
            txtComponents.Enabled = false;
        }

        private void UpdateDesign()
        {
            lblImages.Text = initialImagesCount.ToString() + "image(s)";
        }

        #region FileManipulation
        //TODO: import the values from .import to the local variables and create new funcion to update values on UI
        private void importData()
        {
            import = new TrainReport.FileManipulation.Import(path);
            serialNum = import.serialNum;
            txtSerialNum.Text = serialNum;
            cboxClean.Checked = import.isClean;;
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
            lblImages.Text = initialImagesCount.ToString();
            initialImagesPath.Clear();
            initialImagesPath = import.initialImagesPath;
            initialImagesCount = initialImagesPath.Count();
            finalImagesPath.Clear();
            finalImagesPath = import.finalImagesPath;
            finalImagesCount= finalImagesPath.Count();

            if (initialImagesPath.Count != 0)
            {
                pboxImages.Enabled = true;
                pboxImages.ImageLocation = initialImagesPath[0];
            }
            if(finalImagesPath.Count != 0)
            {
                pboxFinalImages.Enabled = true;
                pboxFinalImages.ImageLocation = finalImagesPath[0];
            }
        }
        #endregion

        #region Button clicks and textbox key press
        private void btnExport_Click(object sender, EventArgs e)
        {
            //Checks if textbox has data and saves the string as int
            if (txtSerialNum.Text != "" && import == null)
            {
                serialNum = lastTwoDigitsOfYear + week + txtSerialNum.Text;
                Console.WriteLine(serialNum.ToString());
            }

            isClean = cboxClean.Checked;
            isEvaluated = cboxEletricalEvaluation.Checked;
            isComponentReplaced = cboxComponents.Checked;
            whichComponents = txtComponents.Text;
            finalEvaluation = cboxApproved.Checked;
            finalText = txtFinalThoughts.Text;

            if (path == null)
            {
                MessageBox.Show("Choose the directory where the files will be placed, note that a new folder will be created in there!");
                path = FolderDialogHelper.SelectedFolder();
            }
            
            if (path != null)
            {
                TrainReport.FileManipulation.Export export = new TrainReport.FileManipulation.Export(
                    serialNum,
                    isClean,
                    isEvaluated,
                    isComponentReplaced,
                    whichComponents,
                    finalEvaluation,
                    finalText,
                    initialImagesPath,
                    finalImagesPath,
                    initialImagesCount,
                    path);
                path = export.path;
                UpdateDesign();
            }else
            {
                MessageBox.Show("Select a valid path!");
            }
        }

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
                    listAux.Add(fileName);
                    imgCount++;
                }
                if(name == "btnImportFinalImg"){
                    finalImagesPath.AddRange(listAux);
                    finalImagesCount += imgCount;
                    pboxFinalImages.ImageLocation = finalImagesPath[0];
                    pboxFinalImages.Enabled = true;
                }
                else if (name == "btnImportImage")
                {
                    initialImagesPath.AddRange(listAux);
                    initialImagesCount += imgCount;
                    pboxImages.ImageLocation = initialImagesPath[0];
                    lblImages.Text = initialImagesCount.ToString() + " images imported";
                    pboxImages.Enabled = true;
                }
            }

            else return;
        }

        private void cboxComponents_CheckedChanged(object sender, EventArgs e)
        {
            txtComponents.Enabled = cboxComponents.Checked;
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            if(validateInputs(0) && validateInputs(2))
            {
                if (path == null)
                {
                   path = FileManipulation.FolderDialogHelper.SelectedFolder();
                }

                if (path != null)
                {
                    serialNum = lastTwoDigitsOfYear + week + txtSerialNum.Text;
                    isClean = cboxClean.Checked;
                    isEvaluated = cboxEletricalEvaluation.Checked;
                    isComponentReplaced = cboxComponents.Checked;
                    whichComponents = txtComponents.Text;
                    finalEvaluation = cboxApproved.Checked;
                    finalText = txtFinalThoughts.Text;
                    TrainReport.FileManipulation.ExportPDF pdf = new TrainReport.FileManipulation.ExportPDF(
                        path,
                        initialImagesPath,
                        finalImagesPath,
                        serialNum,
                        isClean,
                        isEvaluated,
                        isComponentReplaced,
                        whichComponents,
                        finalEvaluation,
                        finalText
                        );
                    return;
                }
            } 
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
            if((sender as Button).Name == "btnClearImage")
            {
                initialImagesPath.Clear();
                pboxImages.Enabled = false;
                pboxImages.Image = null;
                pboxImages.BackColor = System.Drawing.Color.FromArgb(119, 155, 230);
                aux = 0;
                lblImages.Text = "";
                //TODO:
                //deleteImg()
            }
            else
            {
                finalImagesPath.Clear();
                pboxFinalImages.Enabled = false;
                pboxFinalImages.Image = null;
                pboxFinalImages.BackColor = System.Drawing.Color.FromArgb(119, 155, 230);
                //aux = 0;
                //lblImages.Text = "";
            }
            
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
            if (aux < initialImagesCount - 1)
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
            if (aux < finalImagesPath.Count - 1)
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
            if (page == 0 && validateInputs(page))
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

        private bool validateInputs(int page)
        {
            if (page == 0)
            {
                if (txtSerialNum.TextLength < 4)
                {
                    MessageBox.Show("Serial Number should be 4 digits");
                    return false;
                }else if (initialImagesPath.Count == 0)
                {
                    MessageBox.Show("You should import some images of the PCB first");
                    return false;
                }
            }else if(page==2)
            {
                if (txtFinalThoughts.TextLength < 4)
                {
                    MessageBox.Show("You should write something to conclude this report");
                    return false;
                }
                else if (finalImagesPath.Count == 0)
                {
                    MessageBox.Show("You should import some images of the PCB first");
                    return false;
                }
            }
            return true;
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