using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Tåg_project.FileManipulation;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Tåg_project.Core
{
    public partial class Home : Form
    {
        Import import;
        string path, serialNum, tempPath, observations, comments, process, labelPath, summary,
            componentBeforeFrontImg1, componentBeforeBackImg1, componentBeforeFrontImg2, componentBeforeBackImg2, componentBeforeFrontImg3, componentBeforeBackImg3,
            componentAfterFrontImg1, componentAfterBackImg1, componentAfterFrontImg2, componentAfterBackImg2, componentAfterFrontImg3, componentAfterBackImg3,
            componentName, componentDescription;
        List<Component> componentsList = new List<Component>();
        bool isClean, troubleshoot, repair, result1, result2, result3, goodState, damaged, notFunctional;
        bool isImported = false;
        int page = 0;
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

        //Disabling image import buttons so the user doesn't enter images in the wrong order
        //Hidding the panels that will appear later in the application
        private void InitialDesign()
        {
            pnlFinal.Width = 0;
            pnlBoxes.Width = 0;
            pnlComponents.Width = 0;
            lblTopPanel.Text = "Identification";
            btnImportAfterBack2.Enabled = false;
            btnImportAfterBack3.Enabled = false;
            btnImportAfterFront2.Enabled = false;
            btnImportAfterFront3.Enabled = false;
            btnImportBeforeBack2.Enabled = false;
            btnImportBeforeBack3.Enabled = false;
            btnImportBeforeFront2.Enabled = false;
            btnImportBeforeFront3.Enabled = false;
            btnPrev.Enabled = false;
            goodState = false;
            damaged = false;
            notFunctional = false;
        }

        #region FileManipulation
        //Import of all the data inside the previously created folder by the application
        private void importData()
        {
            import = new Import(path);
            serialNum = import.serialNum;
            if (serialNum != null)
            {
                if (serialNum.Length == 8)
                {
                    isImported = true;
                    txt6DigitSerialNum.Enabled = false;
                    txt6DigitSerialNum.Text = serialNum.Substring(0,6);
                    txt2DigitSerialNum.Enabled = false;
                    txt2DigitSerialNum.Text = serialNum.Substring(6, 2);
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

        //Export of all the data inserted by the user into a new or a previously created folder
        private void Export()
        {
            if (validateInputs(0))
            {
                serialNum = txt6DigitSerialNum.Text + txt2DigitSerialNum.Text;
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
                    //isExported = true;
                }
                else
                {
                    MessageBox.Show("Select a valid path!");
                }
            }
        }

        //Export of the pdf file containing all the information in the app within the specified structure by the program
        private void ExportPDF(string p)
        {
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
        private void checkedListBoxState_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Uncheck all other items except the current one being checked
            for (int i = 0; i < checkedListBoxState.Items.Count; ++i)
            {
                if (i != e.Index)
                {
                    checkedListBoxState.SetItemChecked(i, false);
                }
            }
        }
        private void checkedListBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxState.SelectedIndex == 0)
            {
                goodState = true;
                notFunctional = false;
                damaged = false;
            }
            else if (checkedListBoxState.SelectedIndex == 1)
            {
                goodState = false;
                notFunctional = false;
                damaged = true;
            }
            else if (checkedListBoxState.SelectedIndex == 2)
            {
                goodState = false;
                notFunctional = true;
                damaged = false;
            }
        }
        private void btnCatalog_Click(object sender, EventArgs e)
        {
            Component component = new Component();
            if (!listBoxCatalog.Items.Contains(txtComboCatalog.Text))
            {
                listBoxCatalog.Items.Add(txtComboCatalog.Text);
                component.name = txtComboCatalog.Text;
                component.quantity = txtComponentQuantity.Text;
                component.state = checkedListBoxState.SelectedItem.ToString();
                component.location = txtComponentLocation.Text;
                component.componentBeforeFrontImage1 = componentBeforeFrontImg1;
                component.componentBeforeFrontImage2 = componentBeforeFrontImg2;
                component.componentBeforeFrontImage3 = componentBeforeFrontImg3;
                component.componentBeforeBackImage1 = componentBeforeBackImg1;
                component.componentBeforeBackImage2 = componentBeforeBackImg2;
                component.componentBeforeBackImage3 = componentBeforeBackImg3;
                listBoxComponents.Items.Add(comboComponents.Text);
                componentsList.Add(component);
                ClearComponentPanel();
            }
            else
            {
                Component componentToFind = componentsList.Find(x => x.name == txtComboCatalog.Text);
                componentToFind.name = txtComboCatalog.Text;
                componentToFind.quantity = txtComponentQuantity.Text;
                componentToFind.state = checkedListBoxState.SelectedItem.ToString();
                componentToFind.location = txtComponentLocation.Text;
                componentToFind.componentBeforeFrontImage1 = componentBeforeFrontImg1;
                componentToFind.componentBeforeFrontImage2 = componentBeforeFrontImg2;
                componentToFind.componentBeforeFrontImage3 = componentBeforeFrontImg3;
                componentToFind.componentBeforeBackImage1 = componentBeforeBackImg1;
                componentToFind.componentBeforeBackImage2 = componentBeforeBackImg2;
                componentToFind.componentBeforeBackImage3 = componentBeforeBackImg3;
                ClearComponentPanel();
            }
        }
        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            componentName = comboComponents.Text;
            componentDescription = txtDescription.Text;
            if (componentName != "" && componentDescription != "" && componentAfterFrontImg1 != null && componentAfterBackImg1 != null &&
                componentBeforeFrontImg1 != null && componentBeforeBackImg1 != null)
            {
                if (!listBoxComponents.Items.Contains(comboComponents.Text))
                {
                    componentsList.Add(new Component(componentName,
                        componentBeforeFrontImg1, componentBeforeFrontImg2, componentBeforeFrontImg3,
                        componentBeforeBackImg1, componentBeforeBackImg2, componentBeforeBackImg3,
                        componentAfterFrontImg1, componentAfterFrontImg2, componentAfterFrontImg3,
                        componentAfterBackImg1, componentAfterBackImg2, componentAfterBackImg3,
                        componentDescription));
                    listBoxComponents.Items.Add(comboComponents.Text);
                    ClearComponentPanel();
                }
                else
                {
                    Component componentToFind = componentsList.Find(x => x.name == componentName);
                    componentToFind.description = componentDescription;
                    componentToFind.componentBeforeFrontImage1 = componentBeforeFrontImg1;
                    componentToFind.componentBeforeFrontImage2 = componentBeforeFrontImg2;
                    componentToFind.componentBeforeFrontImage3 = componentBeforeFrontImg3;
                    componentToFind.componentBeforeBackImage1 = componentBeforeBackImg1;
                    componentToFind.componentBeforeBackImage2 = componentBeforeBackImg2;
                    componentToFind.componentBeforeBackImage3 = componentBeforeBackImg3;
                    componentToFind.componentAfterFrontImage1 = componentAfterFrontImg1;
                    componentToFind.componentAfterFrontImage2 = componentAfterFrontImg2;
                    componentToFind.componentAfterFrontImage3 = componentAfterFrontImg3;
                    componentToFind.componentAfterBackImage1 = componentAfterBackImg1;
                    componentToFind.componentAfterBackImage2 = componentAfterBackImg2;
                    componentToFind.componentAfterBackImage3 = componentAfterBackImg3;

                    ClearComponentPanel();
                }
            }
            else MessageBox.Show("You need to insert more data about the component.");
        }

        private void ClearComponentPanel()
        {
            //Clear variables
            componentDescription = "";
            componentName = "";
            componentBeforeFrontImg1 = null;
            componentBeforeFrontImg2 = null;
            componentBeforeFrontImg3 = null;
            componentAfterFrontImg1 = null;
            componentAfterFrontImg2 = null;
            componentAfterFrontImg3 = null;
            componentBeforeBackImg1 = null;
            componentBeforeBackImg2 = null;
            componentBeforeBackImg3 = null;
            componentAfterBackImg1 = null;
            componentAfterBackImg2 = null;
            componentAfterBackImg3 = null;
            //Clear controls
            comboComponents.Text = "";
            txtDescription.Text = "";
            btnImportAfterFront1.Text = "Add image";
            btnImportAfterFront2.Text = "Add image";
            btnImportAfterFront3.Text = "Add image";
            btnImportBeforeFront1.Text = "Add image";
            btnImportBeforeFront2.Text = "Add image";
            btnImportBeforeFront3.Text = "Add image";
            btnImportAfterBack1.Text = "Add image";
            btnImportAfterBack2.Text = "Add image";
            btnImportAfterBack3.Text = "Add image";
            btnImportBeforeBack1.Text = "Add image";
            btnImportBeforeBack2.Text = "Add image";
            btnImportBeforeBack3.Text = "Add image";
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

        private void btnClearImages_Click(object sender, EventArgs e)
        {
            string btnName = (sender as System.Windows.Forms.Button).Name;
            if (btnName == "btnClearBeforeImages")
            {
                componentBeforeFrontImg1 = null;
                componentBeforeFrontImg2 = null;
                componentBeforeFrontImg3 = null;
                componentBeforeBackImg1 = null;
                componentBeforeBackImg2 = null;
                componentBeforeBackImg3 = null;
                btnImportBeforeFront1.Text = "Add image";
                btnImportBeforeFront2.Text = "Add image";
                btnImportBeforeFront3.Text = "Add image";
                btnImportBeforeBack1.Text = "Add image";
                btnImportBeforeBack2.Text = "Add image";
                btnImportBeforeBack3.Text = "Add image";

                btnImportBeforeFront2.Enabled = false;
                btnImportBeforeFront3.Enabled = false;
                btnImportBeforeBack3.Enabled = false;
                btnImportBeforeBack2.Enabled = false;
            }
            else if (btnName == "btnClearAfterImages")
            {
                componentAfterFrontImg1 = null;
                componentAfterFrontImg2 = null;
                componentAfterFrontImg3 = null;
                componentAfterBackImg1 = null;
                componentAfterBackImg2 = null;
                componentAfterBackImg3 = null;
                btnImportAfterFront1.Text = "Add image";
                btnImportAfterFront2.Text = "Add image";
                btnImportAfterFront3.Text = "Add image";
                btnImportAfterBack1.Text = "Add image";
                btnImportAfterBack2.Text = "Add image";
                btnImportAfterBack3.Text = "Add image";

                btnImportAfterFront2.Enabled = false;
                btnImportAfterFront3.Enabled = false;
                btnImportAfterBack3.Enabled = false;
                btnImportAfterBack2.Enabled = false;
            }
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            string btnName = (sender as System.Windows.Forms.Button).Name;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Select Valid Document(*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (btnName == "btnImportBeforeFront1")
                {
                    componentBeforeFrontImg1 = dialog.FileName;
                    btnImportBeforeFront1.Text = "Image imported";
                    btnImportBeforeFront2.Enabled = true;
                }
                else if (btnName == "btnImportBeforeFront2")
                {
                    btnImportBeforeFront2.Text = "Image imported";
                    componentBeforeFrontImg2 = dialog.FileName;
                    btnImportBeforeFront3.Enabled = true;
                }
                else if (btnName == "btnImportBeforeFront3")
                {
                    btnImportBeforeFront3.Text = "Image imported";
                    componentBeforeFrontImg3 = dialog.FileName;
                }
                else if (btnName == "btnImportBeforeBack1")
                {
                    btnImportBeforeBack1.Text = "Image imported";
                    componentBeforeBackImg1 = dialog.FileName;
                    btnImportBeforeBack2.Enabled = true;
                }
                else if (btnName == "btnImportBeforeBack2")
                {
                    btnImportBeforeBack2.Text = "Image imported";
                    componentBeforeBackImg2 = dialog.FileName;
                    btnImportBeforeBack3.Enabled = true;
                }
                else if (btnName == "btnImportBeforeBack3")
                {
                    btnImportBeforeBack3.Text = "Image imported";
                    componentBeforeBackImg3 = dialog.FileName;
                }
                else if (btnName == "btnImportAfterFront1")
                {
                    btnImportAfterFront1.Text = "Image imported";
                    componentAfterFrontImg1 = dialog.FileName;
                    btnImportAfterFront2.Enabled = true;
                }
                else if (btnName == "btnImportAfterFront2")
                {
                    btnImportAfterFront2.Text = "Image imported";
                    componentAfterFrontImg2 = dialog.FileName;
                    btnImportAfterFront3.Enabled = true;
                }
                else if (btnName == "btnImportAfterFront3")
                {
                    btnImportAfterFront3.Text = "Image imported";
                    componentAfterFrontImg3 = dialog.FileName;
                }
                else if (btnName == "btnImportAfterBack1")
                {
                    btnImportAfterBack1.Text = "Image imported";
                    componentAfterBackImg1 = dialog.FileName;
                    btnImportAfterBack2.Enabled = true;
                }
                else if (btnName == "btnImportAfterBack2")
                {
                    btnImportAfterBack2.Text = "Image imported";
                    componentAfterBackImg2 = dialog.FileName;
                    btnImportAfterBack3.Enabled = true;
                }
                else if (btnName == "btnImportAfterBack3")
                {
                    btnImportAfterBack3.Text = "Image imported";
                    componentAfterBackImg3 = dialog.FileName;
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

                            if (comp.componentBeforeFrontImage1 != null)
                            {
                                componentBeforeFrontImg1 = comp.componentBeforeFrontImage1;
                                btnImportBeforeFront1.Text = "Image imported";
                                btnImportBeforeFront2.Enabled = true;
                            }
                            else btnImportBeforeFront1.Text = "Add image";

                            if (comp.componentBeforeFrontImage2 != null)
                            {
                                componentBeforeFrontImg2 = comp.componentBeforeFrontImage2;
                                btnImportBeforeFront2.Text = "Image imported";
                                btnImportBeforeFront3.Enabled = true;
                            }
                            else btnImportBeforeFront2.Text = "Add image";
                            if (comp.componentBeforeFrontImage3 != null)
                            {
                                componentBeforeFrontImg3 = comp.componentBeforeFrontImage3;
                                btnImportBeforeFront3.Text = "Image imported";
                            }
                            else btnImportBeforeFront3.Text = "Add image";
                            if (comp.componentAfterFrontImage1 != null)
                            {
                                componentAfterFrontImg1 = comp.componentAfterFrontImage1;
                                btnImportAfterFront1.Text = "Image imported";
                                btnImportAfterFront2.Enabled = true;
                            }
                            else
                                btnImportAfterFront1.Text = "Add image";
                            if (comp.componentAfterFrontImage2 != null)
                            {
                                componentAfterFrontImg2 = comp.componentAfterFrontImage2;
                                btnImportAfterFront2.Text = "Image imported";
                                btnImportAfterFront3.Enabled = true;
                            }
                            else
                                btnImportAfterFront2.Text = "Add image";
                            if (comp.componentAfterFrontImage3 != null)
                            {
                                componentAfterFrontImg3 = comp.componentAfterFrontImage3;
                                btnImportAfterFront3.Text = "Image imported";
                            }
                            else
                                btnImportAfterFront3.Text = "Add image";



                            if (comp.componentBeforeBackImage1 != null)
                            {
                                componentBeforeBackImg1 = comp.componentBeforeBackImage1;
                                btnImportBeforeBack1.Text = "Image imported";
                                btnImportBeforeBack2.Enabled = true;
                            }
                            else btnImportBeforeBack1.Text = "Add image";
                            if (comp.componentBeforeBackImage2 != null)
                            {
                                componentBeforeBackImg2 = comp.componentBeforeBackImage2;
                                btnImportBeforeBack2.Text = "Image imported";
                                btnImportBeforeBack3.Enabled = true;
                            }
                            else btnImportBeforeBack2.Text = "Add image";
                            if (comp.componentBeforeBackImage3 != null)
                            {
                                componentBeforeBackImg3 = comp.componentBeforeBackImage3;
                                btnImportBeforeBack3.Text = "Image imported";
                            }
                            else btnImportBeforeBack3.Text = "Add image";
                            if (comp.componentAfterBackImage1 != null)
                            {
                                componentAfterBackImg1 = comp.componentAfterBackImage1;
                                btnImportAfterBack1.Text = "Image imported";
                                btnImportAfterBack2.Enabled = true;
                            }
                            else
                                btnImportAfterBack1.Text = "Add image";
                            if (comp.componentAfterBackImage2 != null)
                            {
                                componentAfterBackImg2 = comp.componentAfterBackImage2;
                                btnImportAfterBack2.Text = "Image imported";
                                btnImportAfterBack3.Enabled = true;
                            }
                            else
                                btnImportAfterBack2.Text = "Add image";
                            if (comp.componentAfterBackImage3 != null)
                            {
                                componentAfterBackImg3 = comp.componentAfterBackImage3;
                                btnImportAfterBack3.Text = "Image imported";
                            }
                            else
                                btnImportAfterBack3.Text = "Add image";
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

        private void listBoxComponents_KeyDown(object sender, KeyEventArgs e)
        {
            string listBoxName = (sender as System.Windows.Forms.ListBox).Name;
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (listBoxName == "listBoxComponents" && listBoxComponents.SelectedIndex >= 0)
                {
                    listBoxComponents.Items.RemoveAt(listBoxComponents.SelectedIndex);
                }else if (listBoxName == "listBoxCatalog" && listBoxCatalog.SelectedIndex >= 0)
                {
                    listBoxCatalog.Items.RemoveAt(listBoxCatalog.SelectedIndex);
                }
            }
        }

        

        
        #endregion

        #region Data validation and error prevention
        //Serial number should be 8 digits and label image should be imported
        private bool validateInputs(int page)
        {
            if (page == 0)
            {
                if (txt6DigitSerialNum.TextLength != 6 && txt2DigitSerialNum.TextLength != 2)
                {
                    MessageBox.Show("The unit number is not in the right format!\nMake sure there are 6 numbers in the left and 2 in the right.");
                    return false;
                }else if (labelPath == null)
                {
                    MessageBox.Show("Label image wasn't imported");
                    return false;
                }
            }
            return true;
        }
        //The limit of lines in the textbox is 3 so the PDF has the right format
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
        //The separator is used in the csv file so the textbox shouldn't allow it
        private void txtPreventSeparator(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '|')
            {
                e.Handled = true;
            }
        }
        //The serial number cannot contain chars
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