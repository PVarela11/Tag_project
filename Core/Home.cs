using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using Tåg_project.FileManipulation;
using CheckBox = System.Windows.Forms.CheckBox;
using ListBox = System.Windows.Forms.ListBox;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Tåg_project.Core
{
    public partial class Home : Form
    {
        Import import;
        string path, serialNum, tempPath, observations, comments, process, labelPath, summary,
            componentBeforeFrontImg1, componentBeforeBackImg1, componentBeforeFrontImg2, componentBeforeBackImg2, componentBeforeFrontImg3, componentBeforeBackImg3,
            componentAfterFrontImg1, componentAfterBackImg1, componentAfterFrontImg2, componentAfterBackImg2, componentAfterFrontImg3, componentAfterBackImg3,
            componentName, componentDescription, page, arrivalDate;
        List<Component> componentsList = new List<Component>();
        bool isClean, troubleshoot, result1, result2, result3, storage, cleaning, repairing, upgrade;
        bool isImported = false;
        List<string> initialImagesPath = new List<string>(), listAux = new List<string>(), finalImagesPath = new List<string>();
        int lastSelectedIndex = -1, state; // initialize to an invalid index
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
            dateTimePicker.Value = DateTime.Now;
            pnlCatalog.Width = 0;
            pnlTroubleshoot.Width = 0;
            pnlRepair.Width = 0;
            pnlCleaning.Width = 0;
            page = "Identification";
            lblTopPanel.Text = page;
            btnImportAfterBack2.Enabled = false;
            btnImportAfterBack3.Enabled = false;
            btnImportAfterFront2.Enabled = false;
            btnImportAfterFront3.Enabled = false;
            btnImportBeforeBack2.Enabled = false;
            btnImportBeforeBack3.Enabled = false;
            btnImportBeforeFront2.Enabled = false;
            btnImportBeforeFront3.Enabled = false;
            btnPrev.Enabled = false;
        }
        #region General Functions
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
            txtComboCatalog.Text = "";
            txtComponentQuantity.Text = "";
            txtComponentLocation.Text = "";
            checkedListBoxState.SelectedIndex = -1;
            checkedListBoxState.SetItemChecked(0, false);
            checkedListBoxState.SetItemChecked(1, false);
            checkedListBoxState.SetItemChecked(2, false);
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
        #endregion

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

                    cBoxStorage.Checked = import.storage;
                    cBoxCleaning.Checked = import.cleaning;
                    cBoxRepairing.Checked = import.repairing;
                    cBoxUpgrade.Checked = import.upgrade;
                    arrivalDate = import.arrivalDate;
                    try
                    {
                        dateTimePicker.Value = System.DateTime.Parse(arrivalDate);
                    }
                    catch
                    {
                        MessageBox.Show("Error import the arrival date");
                    }
                    if (import.components.Count > 0)
                    {
                        componentsList = import.components;
                        componentsList.Sort(new NameComparer());
                        foreach (Component comp in componentsList)
                        {
                            listBoxComponents.Items.Add(comp.name);
                            listBoxCatalog.Items.Add(comp.name);
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
            if (validateInputs("Identification"))
            {
                serialNum = txt6DigitSerialNum.Text + txt2DigitSerialNum.Text;
                isClean = cboxClean.Checked;
                observations = txtObservations.Text;
                comments = txtComments.Text;
                process = txtProcess.Text;
                troubleshoot = cboxTroubleshoot.Checked;
                repairing = cboxRepair.Checked;
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
                        repairing,
                        result1,
                        result2,
                        result3,
                        isImported,
                        summary,
                        labelPath,
                        componentsList,
                        storage,
                        cleaning,
                        repairing,
                        upgrade,
                        arrivalDate
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
            repairing = cboxRepair.Checked;
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
                repairing,
                summary,
                labelPath,
                componentsList,
                storage,
                cleaning,
                repairing,
                upgrade,
                arrivalDate
                );
            return;
        }
        #endregion

        #region Design controls actions
        #region Identification
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            arrivalDate = dateTimePicker.Value.ToString("D");
        }
        private void cBoxIdentification_CheckedChanged(object sender, EventArgs e)
        {
            string processName = (sender as CheckBox).Name;
            if (processName == "cBoxUpgrade")
            {
                if (upgrade)
                {
                    upgrade = false;
                }
                else upgrade = true;
            }
            else if (processName == "cBoxCleaning")
            {
                if (cleaning)
                {
                    cleaning = false;
                }
                else cleaning = true;
            }
            else if (processName == "cBoxRepairing")
            {
                if (repairing)
                {
                    repairing = false;
                }
                else repairing = true;
            }
            else if (processName == "cBoxStorage")
            {
                if (storage)
                {
                    storage = false;
                }
                else storage = true;
            }
        }
        #endregion
        #region Panel Catalog
        private void listBoxCatalogComponent_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = listBoxCatalog.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    string name = listBoxCatalog.Items[index].ToString();
                    Component componentToFind = componentsList.Find(x => x.name == name);
                    txtComboCatalog.Text = name;
                    txtComponentQuantity.Text = componentToFind.quantity;
                    txtComponentLocation.Text = componentToFind.location;
                    //checkedListBoxState.SelectedIndex = componentToFind.state;
                    checkedListBoxState.SetItemChecked(componentToFind.state, true);
                    if (componentToFind.componentBeforeFrontImage1 != null)
                    {
                        componentBeforeFrontImg1 = componentToFind.componentBeforeFrontImage1;
                        btnImportBeforeFront1.Text = "Image imported";
                        btnImportBeforeFront2.Enabled = true;
                    }
                    else btnImportBeforeFront1.Text = "Add image";

                    if (componentToFind.componentBeforeFrontImage2 != null)
                    {
                        componentBeforeFrontImg2 = componentToFind.componentBeforeFrontImage2;
                        btnImportBeforeFront2.Text = "Image imported";
                        btnImportBeforeFront3.Enabled = true;
                    }
                    else btnImportBeforeFront2.Text = "Add image";

                    if (componentToFind.componentBeforeFrontImage3 != null)
                    {
                        componentBeforeFrontImg3 = componentToFind.componentBeforeFrontImage3;
                        btnImportBeforeFront3.Text = "Image imported";
                    }
                    else btnImportBeforeFront3.Text = "Add image";

                    if (componentToFind.componentBeforeBackImage1 != null)
                    {
                        componentBeforeBackImg1 = componentToFind.componentBeforeBackImage1;
                        btnImportBeforeBack1.Text = "Image imported";
                        btnImportBeforeBack2.Enabled = true;
                    }
                    else btnImportBeforeBack1.Text = "Add image";
                    if (componentToFind.componentBeforeBackImage2 != null)
                    {
                        componentBeforeBackImg2 = componentToFind.componentBeforeBackImage2;
                        btnImportBeforeBack2.Text = "Image imported";
                        btnImportBeforeBack3.Enabled = true;
                    }
                    else btnImportBeforeBack2.Text = "Add image";
                    if (componentToFind.componentBeforeBackImage3 != null)
                    {
                        componentBeforeBackImg3 = componentToFind.componentBeforeBackImage3;
                        btnImportBeforeBack3.Text = "Image imported";
                    }
                    else btnImportBeforeBack3.Text = "Add image";
                }
            }
        }
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
                state = 0;
                checkedListBoxState.SelectedIndexChanged -= checkedListBoxState_SelectedIndexChanged; // temporarily disable the event handler
                checkedListBoxState.SelectedIndex = lastSelectedIndex; // reset the selected index to the previous value
                checkedListBoxState.SelectedIndexChanged += checkedListBoxState_SelectedIndexChanged; // re-enable the event handler
            }
            else if (checkedListBoxState.SelectedIndex == 1)
            {
                state = 1;
                checkedListBoxState.SelectedIndexChanged -= checkedListBoxState_SelectedIndexChanged; // temporarily disable the event handler
                checkedListBoxState.SelectedIndex = lastSelectedIndex; // reset the selected index to the previous value
                checkedListBoxState.SelectedIndexChanged += checkedListBoxState_SelectedIndexChanged; // re-enable the event handler
            }
            else if (checkedListBoxState.SelectedIndex == 2)
            {
                state = 2;
                checkedListBoxState.SelectedIndexChanged -= checkedListBoxState_SelectedIndexChanged; // temporarily disable the event handler
                checkedListBoxState.SelectedIndex = lastSelectedIndex; // reset the selected index to the previous value
                checkedListBoxState.SelectedIndexChanged += checkedListBoxState_SelectedIndexChanged; // re-enable the event handler
            }
            else
            {
                state = 0;
                lastSelectedIndex = -1;
            }
        }
        private void btnCatalogAddComponent_Click(object sender, EventArgs e)
        {
            if (txtComboCatalog.Text != "" && txtComponentQuantity.Text != "" && componentBeforeFrontImg1 != null && componentBeforeBackImg1 != null
                && txtComponentQuantity.Text != "" && txtComponentLocation.Text != "" && checkedListBoxState.CheckedItems.Count == 1)
            {
                Component component = new Component();
                if (!listBoxCatalog.Items.Contains(txtComboCatalog.Text))
                {
                    listBoxCatalog.Items.Add(txtComboCatalog.Text);
                    component.name = txtComboCatalog.Text;
                    component.quantity = txtComponentQuantity.Text;
                    component.state = state;
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
                    componentToFind.state = state;
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
            else MessageBox.Show("You need to insert more data about the component.");
        }
        #endregion
        #region Cleaning

        #endregion
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
            ClearComponentPanel();
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
            if (validateInputs("Identification"))
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
            if (page == "Identification" && validateInputs(page))
            {
                page = "Catalog";
                lblTitle.Visible = false;
                lblTopPanel.Text = page;
                pnlCatalog.Width = pnlIdentification.Width;
                pnlIdentification.Width = 0;
                pnlRepair.Width = 0;
                pnlTroubleshoot.Width = 0;
                pnlCleaning.Width = 0;
                btnPrev.Enabled = true;
                //If cleaning is not selected change the next button to export pdf button
                if (!cleaning)
                {
                    ChangeNextToExport();
                    //ChangeButtonNext();
                    //btnNext.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
                    //btnNext.Click -= btnNext_Click;
                    //btnNext.Click -= btnCreatePDF_Click;
                    //btnNext.Click += new EventHandler(btnCreatePDF_Click);
                }
            }
            else if (page == "Catalog" && validateInputs(page))
            {
                page="Cleaning";
                lblTopPanel.Text = page;
                pnlCleaning.Width = pnlCatalog.Width;
                pnlIdentification.Width = 0;
                pnlRepair.Width = 0;
                pnlTroubleshoot.Width = 0;
                pnlCatalog.Width = 0;
                //if (!troubleshoot)
                //{
                //    btnNext.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
                //    btnNext.Click -= btnNext_Click;
                //    btnNext.Click -= btnCreatePDF_Click;
                //    btnNext.Click += new EventHandler(btnCreatePDF_Click);
                //}
            }
            else if (page == "Cleaning")
            {
                page = "Troubleshoot";
                lblTopPanel.Text = page;
                pnlTroubleshoot.Width = pnlCleaning.Width;
                pnlIdentification.Width = 0;
                pnlRepair.Width = 0;
                pnlCleaning.Width = 0;
                pnlCatalog.Width = 0;
                if (!repairing)
                {
                    ChangeNextToExport();
                    //btnNext.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
                    //btnNext.Click -= btnNext_Click;
                    //btnNext.Click -= btnCreatePDF_Click;
                    //btnNext.Click += new EventHandler(btnCreatePDF_Click);
                }
            }
            else if(page == "Troubleshoot")
            {
                page = "Repair";
                lblTopPanel.Text = page;
                pnlRepair.Width = pnlTroubleshoot.Width;
                pnlIdentification.Width = 0;
                pnlTroubleshoot.Width = 0;
                pnlCleaning.Width = 0;
                pnlCatalog.Width = 0;

                //btnNext.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
                //btnNext.Click -= btnNext_Click;
                //btnNext.Click -= btnCreatePDF_Click;
                //btnNext.Click += new EventHandler(btnCreatePDF_Click);
                ChangeNextToExport();
                //if (!repairing)
                //{
                //    btnNext.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
                //    btnNext.Click -= btnNext_Click;
                //    btnNext.Click -= btnCreatePDF_Click;
                //    btnNext.Click += new EventHandler(btnCreatePDF_Click);
                //}
            }
        }

        private void ChangeNextToExport()
        {
            btnNext.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            btnNext.Click -= btnNext_Click;
            btnNext.Click -= btnCreatePDF_Click;
            btnNext.Click += new EventHandler(btnCreatePDF_Click);
        }
        private void ChangeExportToNext()
        {
            btnNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
            btnNext.Click -= btnNext_Click;
            btnNext.Click -= btnCreatePDF_Click;
            btnNext.Click += new EventHandler(btnNext_Click);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (page == "Catalog")
            {
                page = "Identification";
                lblTitle.Visible = true;
                lblTopPanel.Text = page;
                btnPrev.Enabled = false;
                pnlIdentification.Width = pnlCatalog.Width;
                pnlCatalog.Width = 0;
                pnlRepair.Width = 0;
                pnlTroubleshoot.Width = 0;
                pnlCleaning.Width = 0;
                ChangeExportToNext();
                    //btnNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
                    //btnNext.Click -= btnCreatePDF_Click;
                    //btnNext.Click -= btnNext_Click;
                    //btnNext.Click += new EventHandler(btnNext_Click);
                
            }
            else if (page == "Cleaning")
            {
                page = "Catalog";
                lblTopPanel.Text = page;
                pnlCatalog.Width = pnlCleaning.Width;
                pnlIdentification.Width = 0;
                pnlRepair.Width = 0;
                pnlTroubleshoot.Width = 0;
                pnlCleaning.Width = 0;
                ChangeExportToNext();
                //btnNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
                //btnNext.Click -= btnCreatePDF_Click;
                //btnNext.Click -= btnNext_Click;
                //btnNext.Click += new EventHandler(btnNext_Click);

            }
            else if (page == "Troubleshoot")
            {
                page = "Cleaning";
                lblTopPanel.Text = page;
                
                pnlCleaning.Width = pnlTroubleshoot.Width;
                pnlIdentification.Width = 0;
                pnlRepair.Width = 0;
                pnlTroubleshoot.Width = 0;
                pnlCatalog.Width = 0;
                ChangeExportToNext();
                //btnNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
                //btnNext.Click -= btnCreatePDF_Click;
                //btnNext.Click -= btnNext_Click;
                //btnNext.Click += new EventHandler(btnNext_Click);
            }
            else if (page == "Repair")
            {
                page = "Troubleshoot";
                lblTopPanel.Text = page;

                pnlTroubleshoot.Width = pnlRepair.Width;
                pnlIdentification.Width = 0;
                pnlRepair.Width = 0;
                pnlCleaning.Width = 0;
                pnlCatalog.Width = 0;
                ChangeExportToNext();
                //btnNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
                //btnNext.Click -= btnCreatePDF_Click;
                //btnNext.Click -= btnNext_Click;
                //btnNext.Click += new EventHandler(btnNext_Click);
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
        private bool validateInputs(string page)
        {
            if (page == "Identification")
            {
                if (txt6DigitSerialNum.TextLength != 6 || txt2DigitSerialNum.TextLength != 2)
                {
                    MessageBox.Show("The unit number is not in the right format!\nMake sure there are 6 numbers in the left and 2 in the right.");
                    return false;
                }else if (labelPath == null)
                {
                    MessageBox.Show("Label image wasn't imported.");
                    return false;
                }else if(arrivalDate == null)
                {
                    MessageBox.Show("Please edit the arrival date.");
                    return false;
                }else if(!storage && !cleaning && !repairing && !upgrade)
                {
                    MessageBox.Show("Please define what is the order.");
                    return false;
                }
            }
            else if(page == "Catalog")
            {
                if (componentsList.Count < 1)
                {
                    MessageBox.Show("Please catalog at least 1 component");
                    return false;
                }
            }
            if (serialNum == null)
            {
                serialNum = txt6DigitSerialNum.Text + txt2DigitSerialNum.Text;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || e.KeyChar == '|')
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}