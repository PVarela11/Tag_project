using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Tåg_project.FileManipulation;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Tåg_project.Core
{
    public partial class Home : Form
    {
        Import import;
        string path, week, serialNum, lastTwoDigitsOfYear, tempPath, observations, comments, process, labelPath, summary,
            componentBeforeImg1, componentBeforeImg2, componentBeforeImg3, componentAfterImg1, componentAfterImg2, componentAfterImg3,
            componentName, componentDescription;
        List<Component> componentsList = new List<Component>();
        bool isClean, troubleshoot, repair, result1, result2, result3;
        bool isImported = false, isExported = false;
        int aux = 0, aux1 = 0, page = 0;
        List<Component> listaComponentes;
        List<string> initialImagesPath = new List<string>(), listAux = new List<string>(), finalImagesPath = new List<string>();
        public Home(string tempPath)
        {
            InitializeComponent();
            InitialDesign();
            path = tempPath;
            if (tempPath != null)
            {
                importData();
            }
        }

        private void InitialDesign()
        {
            pnlFinal.Width = 0;
            pnlBoxes.Width = 0;
            pnlComponents.Width = 0;
            lblTopPanel.Text = "Identification";
            DateTime date = DateTime.Now;
            CultureInfo ci = CultureInfo.InvariantCulture;
            int weekNumber = ci.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (weekNumber < 10)
            {
                week = "0" + weekNumber;
            }
            else week = weekNumber.ToString();
            lastTwoDigitsOfYear = date.ToString("yy");

            //pboxImages.Enabled = false;
            //pboxFinalImages.Enabled = false;
            btnPrev.Enabled = false;
        }

        private void UpdateDesign()
        {
            //if(initialImagesPath.Count>0)
            //lblImages.Text = initialImagesPath.Count.ToString() + "image(s) imported" ;
            //if(finalImagesPath.Count>0)
            //lblFinalImages.Text = finalImagesPath.Count.ToString() + "image(s) imported";
        }

        #region FileManipulation
        //TODO: import the values from .import to the local variables and create new funcion to update values on UI
        private void importData()
        {
            import = new Import(path);
            serialNum = import.serialNum;
            if (serialNum != null)
            {
                if (serialNum.Length == 8)
                {
                    isImported = true;
                    txtSerialNum.Enabled = false;
                    txtSerialNum.Text = serialNum;
                    cboxClean.Checked = import.isClean; ;
                    isClean = import.isClean;
                    cboxTroubleshoot.Checked = import.troubleshoot;
                    cboxRepair.Checked = import.repair;
                    txtProcess.Text = import.process;
                    txtComments.Text = import.comments;
                    txtObservations.Text = import.observations;
                    cboxResult1.Checked = import.result1;
                    cboxResult2.Checked = import.result2;
                    cboxResult3.Checked = import.result3;
                    labelPath = import.labelPath;
                    lblCaminho.Text = "Imported " + Path.GetFileName(labelPath);
                    summary = import.summary;
                    txtSummary.Text = summary;

                    if (import.components.Count > 0)
                    {
                        componentsList = import.components;
                        foreach (Component comp in componentsList)
                        {
                            listBoxComponents.Items.Add(comp.name);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Corrupted data inside the file.");
                    path = null;
                }
            }
            else
            {
                MessageBox.Show("No report data found."); 
                path = null;
            }
        }

        private void Export()
        {
            //Checks if textbox has data and saves the string as int
            //if (txtSerialNum.Text != "" && import == null)
            //{
            //    //serialNum = lastTwoDigitsOfYear + week + txtSerialNum.Text;
            //    Console.WriteLine(serialNum.ToString());
            //}
            if (validateInputs(0))
            {
                serialNum = txtSerialNum.Text;
                isClean = cboxClean.Checked;
                observations = txtObservations.Text;
                comments = txtComments.Text;
                process = txtProcess.Text;
                troubleshoot = cboxTroubleshoot.Checked;
                repair = cboxRepair.Checked;
                result1 = cboxResult1.Checked;
                result2 = cboxResult2.Checked;
                result3 = cboxResult3.Checked;
                summary = txtSummary.Text;

                if (path == null)
                {
                    MessageBox.Show("Choose the directory where the files will be placed, note that a new folder will be created in there!");
                    path = FolderDialogHelper.SelectedFolder();
                }

                if (path != null)
                {
                    Export export = new Export(
                        serialNum,
                        isClean,
                        path,
                        observations,
                        comments,
                        process,
                        troubleshoot,
                        repair,
                        result1,
                        result2,
                        result3,
                        isImported,
                        summary,
                        labelPath,
                        componentsList
                        );

                    path = export.path;
                    UpdateDesign();
                    isExported = true;
                }
                else
                {
                    MessageBox.Show("Select a valid path!");
                }
            }
        }

        private bool validateInputs(int page)
        {
            if (page == 0)
            {
                if (txtSerialNum.TextLength < 8)
                {
                    MessageBox.Show("Serial Number should be 8 digits");
                    return false;
                }
            }
            //    //else if (initialImagesPath.Count == 0)
            //    //{
            //    //    MessageBox.Show("You should import some images of the PCB first");
            //    //    return false;
            //    //}
            //    else if (labelPath==null)
            //    {
            //        MessageBox.Show("You should import the label of PCB first");
            //        return false;
            //    }
            //}
            //else if (page == 1)
            //{
            //    if (txtProcess.TextLength == 0)
            //    {
            //        MessageBox.Show("You should write something about the work done");
            //        return false;
            //    }
            //}
            //else if (page == 2)
            //{
            //    if (finalImagesPath.Count == 0)
            //    {
            //        MessageBox.Show("You should import some images of the PCB first");
            //        return false;
            //    }
            //}
            return true;
        }

        private void ExportPDF(string p)
        {
            //Export();
            //if (serialNum == null)
            //{
            //    //Console.WriteLine(serialNum);
            //    MessageBox.Show("Serial number should be 8 digits");
            //    return;
            //    //serialNum = lastTwoDigitsOfYear + week + txtSerialNum.Text;
            //}
            isClean = cboxClean.Checked;
            troubleshoot = cboxTroubleshoot.Checked;
            repair = cboxRepair.Checked;
            observations = txtObservations.Text;
            comments = txtComments.Text;
            process = txtProcess.Text;
            result1 = cboxResult1.Checked;
            result2 = cboxResult2.Checked;
            result3 = cboxResult3.Checked;
            summary = txtSummary.Text;

            ExportPDF pdf = new ExportPDF(
                p,
                initialImagesPath,
                finalImagesPath,
                serialNum,
                isClean,
                troubleshoot,
                observations,
                process,
                comments,
                result1,
                result2,
                result3,
                repair,
                summary,
                labelPath,
                componentsList
                );
            return;
        }
        #endregion

        #region Design controls actions

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            componentName = comboComponents.Text;
            componentDescription = txtDescription.Text;
            if (componentName != "" && componentDescription != "" && componentAfterImg1 != null && componentBeforeImg1 != null)
            {
                if (!listBoxComponents.Items.Contains(comboComponents.Text))
                {
                    componentsList.Add(new Component(componentName, componentBeforeImg1, componentBeforeImg2, componentBeforeImg3, componentAfterImg1, componentAfterImg2, componentAfterImg3, componentDescription));
                    listBoxComponents.Items.Add(comboComponents.Text);
                    ClearComponentPanel();
                }
                else
                {
                    Component componentToFind = componentsList.Find(x => x.name == componentName);
                    componentToFind.description = componentDescription;
                    componentToFind.componentBeforeImage1 = componentBeforeImg1;
                    componentToFind.componentBeforeImage2 = componentBeforeImg2;
                    componentToFind.componentBeforeImage3 = componentBeforeImg3;
                    componentToFind.componentAfterImage1 = componentAfterImg1;
                    componentToFind.componentAfterImage2 = componentAfterImg2;
                    componentToFind.componentAfterImage3 = componentAfterImg3;
                    ClearComponentPanel();
                }
                
            }
        }

        private void ClearComponentPanel()
        {
            //Clear variables
            componentDescription = "";
            componentName = "";
            componentBeforeImg1 = null;
            componentBeforeImg2 = null;
            componentBeforeImg3 = null;
            componentAfterImg1 = null;
            componentAfterImg2 = null;
            componentAfterImg3 = null;
            //Clear controls
            comboComponents.Text = "";
            txtDescription.Text = "";
            btnImportAfter1.Text = "Add image";
            btnImportAfter2.Text = "Add image";
            btnImportAfter3.Text = "Add image";
            btnImportBefore1.Text = "Add image";
            btnImportBefore2.Text = "Add image";
            btnImportBefore3.Text = "Add image";
        }

        private void lblTroubleshoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowFile.OpenFile("Troubleshooting.pdf");
        }
        private void lblClean_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowFile.OpenFile("CleaningOuter.pdf");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            //listAux.Clear();
            string btnName = (sender as System.Windows.Forms.Button).Name;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Select Valid Document(*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg";
            //dialog.Multiselect = true;
            //int imgCount = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //foreach (string fileName in dialog.FileNames)
                //{
                //    // do something with path
                //    listAux.Add(fileName);
                //    imgCount++;
                //}
                if (btnName == "btnImportBefore1")
                {
                    componentBeforeImg1 = dialog.FileName;
                    btnImportBefore1.Text = "Image imported";
                    //pboxFinalImages.BackColor = System.Drawing.Color.FromArgb(119, 156, 230);
                    //finalImagesPath.AddRange(listAux);
                    //finalImagesCount += imgCount;
                    //pboxFinalImages.ImageLocation = finalImagesPath[0];
                    //pboxFinalImages.Enabled = true;
                    //lblFinalImages.Text = finalImagesPath.Count.ToString() + " images imported";
                }
                else if (btnName == "btnImportBefore2")
                {
                    btnImportBefore2.Text = "Image imported";
                    componentBeforeImg2 = dialog.FileName;
                    //pboxImages.BackColor = System.Drawing.Color.FromArgb(119, 155, 230);
                    //initialImagesPath.AddRange(listAux);
                    //initialImagesCount += imgCount;
                    //pboxImages.ImageLocation = initialImagesPath[0];
                    //lblImages.Text = initialImagesPath.Count.ToString() + " images imported";
                    //pboxImages.Enabled = true;
                }
                else if (btnName == "btnImportBefore3")
                {
                    btnImportBefore3.Text = "Image imported";
                    componentBeforeImg3 = dialog.FileName;
                }
                else if (btnName == "btnImportAfter1")
                {
                    btnImportAfter1.Text = "Image imported";
                    componentAfterImg1 = dialog.FileName;
                }
                else if (btnName == "btnImportAfter2")
                {
                    btnImportAfter2.Text = "Image imported";
                    componentAfterImg2 = dialog.FileName;
                }
                else if (btnName == "btnImportAfter3")
                {
                    btnImportAfter3.Text = "Image imported";
                    componentAfterImg3 = dialog.FileName;
                }
                else if (btnName == "btnImportLabel")
                {
                    lblCaminho.Text = "Imported " + dialog.FileName;
                    labelPath = dialog.FileName;
                }
            }
        
            else return;
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            if (validateInputs(0) && validateInputs(2))
            {
                if (path == null || !isImported)
                {
                    DialogResult result = MessageBox.Show("Would you like to save the report first ?", "Save Report", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Export();
                        if (path != null)
                        {
                            isImported= true;
                            ExportPDF(path);
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        tempPath = FileManipulation.FolderDialogHelper.SelectedFolder();
                        if (tempPath != null)
                        {
                            ExportPDF(tempPath);
                        }
                    }
                }
                else
                {   
                    Export();
                    ExportPDF(path);
                }
            }
        }

        //private void btnClearImg_Click(object sender, EventArgs e)
        //{
        //    if ((sender as Button).Name == "btnClearImage")
        //    {
        //        initialImagesPath.Clear();
        //        //pboxImages.Enabled = false;
        //        //pboxImages.Image = null;
        //        //pboxImages.BackColor = Color.Transparent;
        //        //pboxImages.Enabled = false;
        //        //pboxImages.BackColor = System.Drawing.Color.FromArgb(119, 155, 230);
        //        //pboxImages.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
        //        aux = 0;
        //        //lblImages.Text = "Import PCB Image";
        //        //TODO:
        //        //deleteImg()
        //    }
        //    else if ((sender as Button).Name == "btnClearFinalImage")
        //    {
        //        finalImagesPath.Clear();
        //        //pboxFinalImages.Enabled = false;
        //        //pboxFinalImages.Image = null;
        //        //pboxFinalImages.BackColor = System.Drawing.Color.FromArgb(119, 156, 230);
        //        //pboxFinalImages.BackColor = Color.Transparent;
        //        ////pboxFinalImages.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
        //        aux1 = 0;
        //        //lblFinalImages.Text = "Import PCB Image";
        //    }
        //
        //}

        //private void pboxImages_Click(object sender, EventArgs e)
        //{
        //    if (aux < initialImagesPath.Count - 1)
        //    {
        //        aux++;
        //        //pboxImages.ImageLocation = initialImagesPath[aux];
        //    }
        //    else
        //    {
        //        aux = 0;
        //        //pboxImages.ImageLocation = initialImagesPath[aux];
        //    }
        //
        //}

        private void listBoxComponent_Click(object sender, EventArgs e)
        {
            if (listBoxComponents.SelectedItem != null)
            {
                string temp = listBoxComponents.SelectedItem.ToString();
                if (listBoxComponents.SelectedIndex >= 0)
                {
                    //MessageBox.Show(listBoxComponents.SelectedItem.ToString());
                    foreach (Component comp in componentsList)
                    {
                        if (comp.name == temp)
                        {
                            comboComponents.Text = comp.name;
                            txtDescription.Text = comp.description;
                            if (comp.componentBeforeImage1 != null)
                            {
                                componentBeforeImg1 = comp.componentBeforeImage1;
                                btnImportBefore1.Text = "Image imported";
                            }
                            else btnImportBefore1.Text = "Add image";
                            if (comp.componentBeforeImage2 != null)
                            {
                                componentBeforeImg2 = comp.componentBeforeImage2;
                                btnImportBefore2.Text = "Image imported";
                            }
                            else btnImportBefore2.Text = "Add image";
                            if (comp.componentBeforeImage3 != null)
                            {
                                componentBeforeImg3 = comp.componentBeforeImage3;
                                btnImportBefore3.Text = "Image imported";
                            }
                            else btnImportBefore3.Text = "Add image";
                            if (comp.componentAfterImage1 != null)
                            {
                                componentAfterImg1 = comp.componentAfterImage1;
                                btnImportAfter1.Text = "Image imported";
                            }
                            else
                                btnImportAfter1.Text = "Add image";
                            if (comp.componentAfterImage2 != null)
                            {
                                componentAfterImg2 = comp.componentAfterImage2;
                                btnImportAfter2.Text = "Image imported";
                            }
                            else
                                btnImportAfter2.Text = "Add image";
                            if (comp.componentAfterImage3 != null)
                            {
                                componentAfterImg3 = comp.componentAfterImage3;
                                btnImportAfter3.Text = "Image imported";
                            }
                            else
                                btnImportAfter3.Text = "Add image";
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            lblClean.Visible = true;
            if (page == 0 && validateInputs(page))
            {
                lblTitle.Visible = false;
                lblTopPanel.Text = "PCB Process";
                page++;
                btnPrev.Enabled = true;
                pnlBoxes.Width = pnlFirst.Width;
                //pnlMiddle.Width = pnlFirst.Width;
                pnlFinal.Width = 0;
                pnlFirst.Width = 0;
                //pnlMiddle.Width = 0;
                btnPrev.Enabled = true;

            }
            else if (page == 1)
            {
                lblTopPanel.Text = "Results";
                page++;
                //iconButton1.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
                //iconButton1.Click -= btnExport_Click;
                //iconButton1.Click += new EventHandler(btnCreatePDF_Click);
                pnlFinal.Width = pnlBoxes.Width;
                pnlBoxes.Width = 0;
                pnlFirst.Width = 0;
                //pnlMiddle.Width = 0;
                //btnNext.Enabled = false;
            }
            else if(page == 2)
            {
                lblTopPanel.Text = "Components";
                page++;
                btnNext.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
                btnNext.Click -= btnNext_Click;
                btnNext.Click += new EventHandler(btnCreatePDF_Click);
                pnlComponents.Width = pnlFinal.Width;
                pnlFinal.Width = 0;
                pnlFirst.Width = 0;
                pnlBoxes.Width = 0;
                //btnNext.Enabled = false;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (page == 1)
            {
                lblTitle.Visible = true;
                lblTopPanel.Text = "Identification";
                btnPrev.Enabled = false;
                pnlFirst.Width = pnlBoxes.Width;
                pnlBoxes.Width = pnlFinal.Width = 0;
                page--;
            }
            else if (page == 2)
            {
                //iconButton1.IconChar = FontAwesome.Sharp.IconChar.Save;
                //iconButton1.Click -= btnCreatePDF_Click;
                //iconButton1.Click += new EventHandler(btnExport_Click);
                lblTopPanel.Text = "PCB Process";
                pnlBoxes.Width = pnlFinal.Width;
                pnlFirst.Width = pnlFinal.Width = 0;
                page--;
                btnNext.Enabled = true;
            }
            else if (page == 3)
            {
                btnNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
                btnNext.Click -= btnCreatePDF_Click;
                btnNext.Click += new EventHandler(btnNext_Click);
                lblTopPanel.Text = "Results";
                pnlFinal.Width = pnlComponents.Width;
                pnlFirst.Width = 0;
                pnlComponents.Width = 0;
                pnlBoxes.Width = 0;
                page--;
                btnNext.Enabled = true;
            }
        }

        private void txtSerialNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void listBoxComponents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (listBoxComponents.SelectedIndex >= 0)
                {
                    listBoxComponents.Items.RemoveAt(listBoxComponents.SelectedIndex);
                }
            }
        }

        private void txtPreventSeparator(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '|')
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}