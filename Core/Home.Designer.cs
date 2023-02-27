namespace Tåg_project.Core
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.btnPrev = new FontAwesome.Sharp.IconButton();
            this.lblTopPanel = new System.Windows.Forms.Label();
            this.pnlFirst = new System.Windows.Forms.Panel();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.btnImportLabel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnImportImage = new System.Windows.Forms.Button();
            this.pboxImages = new FontAwesome.Sharp.IconPictureBox();
            this.lblImages = new System.Windows.Forms.Label();
            this.lblSerialNum = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.pnlBoxes = new System.Windows.Forms.Panel();
            this.lblTroubleshoot = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.lblClean = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxRepair = new System.Windows.Forms.CheckBox();
            this.cboxTroubleshoot = new System.Windows.Forms.CheckBox();
            this.cboxClean = new System.Windows.Forms.CheckBox();
            this.pnlFinal = new System.Windows.Forms.Panel();
            this.lblComponent = new System.Windows.Forms.Label();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.btnClearFinalImage = new System.Windows.Forms.Button();
            this.btnImportFinalImg = new System.Windows.Forms.Button();
            this.pboxFinalImages = new FontAwesome.Sharp.IconPictureBox();
            this.lblFinalImages = new System.Windows.Forms.Label();
            this.cboxResult2 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboxResult3 = new System.Windows.Forms.CheckBox();
            this.cboxResult1 = new System.Windows.Forms.CheckBox();
            this.btnClearComponents = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlFirst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImages)).BeginInit();
            this.pnlBoxes.SuspendLayout();
            this.pnlFinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFinalImages)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(61)))));
            this.pnlTop.Controls.Add(this.iconButton1);
            this.pnlTop.Controls.Add(this.btnNext);
            this.pnlTop.Controls.Add(this.btnPrev);
            this.pnlTop.Controls.Add(this.lblTopPanel);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(824, 62);
            this.pnlTop.TabIndex = 0;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.DarkCyan;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(740, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(42, 62);
            this.iconButton1.TabIndex = 3;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
            this.btnNext.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNext.Location = new System.Drawing.Point(782, 0);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(42, 62);
            this.btnNext.TabIndex = 2;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.IconChar = FontAwesome.Sharp.IconChar.Backward;
            this.btnPrev.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.btnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrev.Location = new System.Drawing.Point(0, 0);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(42, 62);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblTopPanel
            // 
            this.lblTopPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTopPanel.AutoSize = true;
            this.lblTopPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTopPanel.ForeColor = System.Drawing.Color.White;
            this.lblTopPanel.Location = new System.Drawing.Point(379, 24);
            this.lblTopPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTopPanel.Name = "lblTopPanel";
            this.lblTopPanel.Size = new System.Drawing.Size(85, 21);
            this.lblTopPanel.TabIndex = 0;
            this.lblTopPanel.Text = "Top panel";
            // 
            // pnlFirst
            // 
            this.pnlFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pnlFirst.Controls.Add(this.lblCaminho);
            this.pnlFirst.Controls.Add(this.label13);
            this.pnlFirst.Controls.Add(this.txtSummary);
            this.pnlFirst.Controls.Add(this.btnImportLabel);
            this.pnlFirst.Controls.Add(this.lblTitle);
            this.pnlFirst.Controls.Add(this.btnClearImage);
            this.pnlFirst.Controls.Add(this.btnImportImage);
            this.pnlFirst.Controls.Add(this.pboxImages);
            this.pnlFirst.Controls.Add(this.lblImages);
            this.pnlFirst.Controls.Add(this.lblSerialNum);
            this.pnlFirst.Controls.Add(this.txtSerialNum);
            this.pnlFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFirst.Location = new System.Drawing.Point(0, 62);
            this.pnlFirst.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFirst.Name = "pnlFirst";
            this.pnlFirst.Size = new System.Drawing.Size(0, 437);
            this.pnlFirst.TabIndex = 3;
            // 
            // lblCaminho
            // 
            this.lblCaminho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCaminho.Location = new System.Drawing.Point(-387, 170);
            this.lblCaminho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(197, 19);
            this.lblCaminho.TabIndex = 58;
            this.lblCaminho.Text = "Insert a image of the PCB label";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.Location = new System.Drawing.Point(-388, 235);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 19);
            this.label13.TabIndex = 57;
            this.label13.Text = "Summary:";
            // 
            // txtSummary
            // 
            this.txtSummary.AcceptsReturn = true;
            this.txtSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSummary.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSummary.Location = new System.Drawing.Point(-385, 258);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(2);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(506, 154);
            this.txtSummary.TabIndex = 56;
            // 
            // btnImportLabel
            // 
            this.btnImportLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportLabel.Location = new System.Drawing.Point(-385, 191);
            this.btnImportLabel.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportLabel.Name = "btnImportLabel";
            this.btnImportLabel.Size = new System.Drawing.Size(118, 28);
            this.btnImportLabel.TabIndex = 54;
            this.btnImportLabel.Text = "Import";
            this.btnImportLabel.UseVisualStyleBackColor = true;
            this.btnImportLabel.Click += new System.EventHandler(this.btnImportLabel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(0, 95);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = resources.GetString("lblTitle.Text");
            // 
            // btnClearImage
            // 
            this.btnClearImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearImage.Location = new System.Drawing.Point(207, 338);
            this.btnClearImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(118, 28);
            this.btnClearImage.TabIndex = 11;
            this.btnClearImage.Text = "Clear";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImg_Click);
            // 
            // btnImportImage
            // 
            this.btnImportImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportImage.Location = new System.Drawing.Point(207, 306);
            this.btnImportImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Size = new System.Drawing.Size(118, 28);
            this.btnImportImage.TabIndex = 10;
            this.btnImportImage.Text = "Import";
            this.btnImportImage.UseVisualStyleBackColor = true;
            this.btnImportImage.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // pboxImages
            // 
            this.pboxImages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pboxImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pboxImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxImages.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.pboxImages.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxImages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pboxImages.IconSize = 150;
            this.pboxImages.Location = new System.Drawing.Point(189, 152);
            this.pboxImages.Margin = new System.Windows.Forms.Padding(2);
            this.pboxImages.Name = "pboxImages";
            this.pboxImages.Size = new System.Drawing.Size(150, 150);
            this.pboxImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxImages.TabIndex = 9;
            this.pboxImages.TabStop = false;
            this.pboxImages.Click += new System.EventHandler(this.pboxImages_Click);
            // 
            // lblImages
            // 
            this.lblImages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblImages.AutoSize = true;
            this.lblImages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImages.Location = new System.Drawing.Point(197, 109);
            this.lblImages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(131, 38);
            this.lblImages.TabIndex = 8;
            this.lblImages.Text = "Insert images of the\r\nPCB before cleaning";
            // 
            // lblSerialNum
            // 
            this.lblSerialNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSerialNum.AutoSize = true;
            this.lblSerialNum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSerialNum.Location = new System.Drawing.Point(-389, 109);
            this.lblSerialNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSerialNum.Name = "lblSerialNum";
            this.lblSerialNum.Size = new System.Drawing.Size(98, 19);
            this.lblSerialNum.TabIndex = 4;
            this.lblSerialNum.Text = "Serial Number:";
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSerialNum.Location = new System.Drawing.Point(-385, 130);
            this.txtSerialNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialNum.MaxLength = 4;
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(119, 20);
            this.txtSerialNum.TabIndex = 3;
            this.txtSerialNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNum_KeyPress);
            // 
            // pnlBoxes
            // 
            this.pnlBoxes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pnlBoxes.Controls.Add(this.lblTroubleshoot);
            this.pnlBoxes.Controls.Add(this.label10);
            this.pnlBoxes.Controls.Add(this.txtComments);
            this.pnlBoxes.Controls.Add(this.label1);
            this.pnlBoxes.Controls.Add(this.txtObservations);
            this.pnlBoxes.Controls.Add(this.lblClean);
            this.pnlBoxes.Controls.Add(this.label7);
            this.pnlBoxes.Controls.Add(this.txtProcess);
            this.pnlBoxes.Controls.Add(this.label8);
            this.pnlBoxes.Controls.Add(this.cboxRepair);
            this.pnlBoxes.Controls.Add(this.cboxTroubleshoot);
            this.pnlBoxes.Controls.Add(this.cboxClean);
            this.pnlBoxes.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBoxes.Location = new System.Drawing.Point(-801, 62);
            this.pnlBoxes.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBoxes.Name = "pnlBoxes";
            this.pnlBoxes.Size = new System.Drawing.Size(803, 437);
            this.pnlBoxes.TabIndex = 19;
            // 
            // lblTroubleshoot
            // 
            this.lblTroubleshoot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTroubleshoot.AutoSize = true;
            this.lblTroubleshoot.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTroubleshoot.Location = new System.Drawing.Point(211, 49);
            this.lblTroubleshoot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTroubleshoot.Name = "lblTroubleshoot";
            this.lblTroubleshoot.Size = new System.Drawing.Size(368, 19);
            this.lblTroubleshoot.TabIndex = 48;
            this.lblTroubleshoot.TabStop = true;
            this.lblTroubleshoot.Text = "Was the board troubleshooting following the instructions ?";
            this.lblTroubleshoot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTroubleshoot_LinkClicked);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.Location = new System.Drawing.Point(72, 313);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 19);
            this.label10.TabIndex = 56;
            this.label10.Text = "Comments:";
            // 
            // txtComments
            // 
            this.txtComments.AcceptsReturn = true;
            this.txtComments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComments.Location = new System.Drawing.Point(72, 334);
            this.txtComments.Margin = new System.Windows.Forms.Padding(2);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(664, 78);
            this.txtComments.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(69, 216);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 19);
            this.label1.TabIndex = 54;
            this.label1.Text = "Other observations:";
            // 
            // txtObservations
            // 
            this.txtObservations.AcceptsReturn = true;
            this.txtObservations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtObservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtObservations.Location = new System.Drawing.Point(71, 239);
            this.txtObservations.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.Size = new System.Drawing.Size(664, 63);
            this.txtObservations.TabIndex = 53;
            // 
            // lblClean
            // 
            this.lblClean.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClean.AutoSize = true;
            this.lblClean.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClean.Location = new System.Drawing.Point(211, 18);
            this.lblClean.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClean.Name = "lblClean";
            this.lblClean.Size = new System.Drawing.Size(301, 19);
            this.lblClean.TabIndex = 49;
            this.lblClean.TabStop = true;
            this.lblClean.Text = "Was the board clean following the instructions ?";
            this.lblClean.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClean_LinkClicked);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(68, 111);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 19);
            this.label7.TabIndex = 52;
            this.label7.Text = "Please explain what was done:";
            // 
            // txtProcess
            // 
            this.txtProcess.AcceptsReturn = true;
            this.txtProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcess.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProcess.Location = new System.Drawing.Point(68, 132);
            this.txtProcess.Margin = new System.Windows.Forms.Padding(2);
            this.txtProcess.Multiline = true;
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(664, 67);
            this.txtProcess.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(211, 80);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(255, 19);
            this.label8.TabIndex = 50;
            this.label8.Text = "Has any repairs been made to the PCB ?";
            // 
            // cboxRepair
            // 
            this.cboxRepair.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxRepair.AutoSize = true;
            this.cboxRepair.Location = new System.Drawing.Point(581, 83);
            this.cboxRepair.Margin = new System.Windows.Forms.Padding(2);
            this.cboxRepair.Name = "cboxRepair";
            this.cboxRepair.Size = new System.Drawing.Size(15, 14);
            this.cboxRepair.TabIndex = 47;
            this.cboxRepair.UseVisualStyleBackColor = true;
            // 
            // cboxTroubleshoot
            // 
            this.cboxTroubleshoot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxTroubleshoot.AutoSize = true;
            this.cboxTroubleshoot.Location = new System.Drawing.Point(581, 53);
            this.cboxTroubleshoot.Margin = new System.Windows.Forms.Padding(2);
            this.cboxTroubleshoot.Name = "cboxTroubleshoot";
            this.cboxTroubleshoot.Size = new System.Drawing.Size(15, 14);
            this.cboxTroubleshoot.TabIndex = 46;
            this.cboxTroubleshoot.UseVisualStyleBackColor = true;
            // 
            // cboxClean
            // 
            this.cboxClean.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxClean.AutoSize = true;
            this.cboxClean.Location = new System.Drawing.Point(581, 23);
            this.cboxClean.Margin = new System.Windows.Forms.Padding(2);
            this.cboxClean.Name = "cboxClean";
            this.cboxClean.Size = new System.Drawing.Size(15, 14);
            this.cboxClean.TabIndex = 45;
            this.cboxClean.UseVisualStyleBackColor = true;
            // 
            // pnlFinal
            // 
            this.pnlFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pnlFinal.Controls.Add(this.btnClearComponents);
            this.pnlFinal.Controls.Add(this.lblComponent);
            this.pnlFinal.Controls.Add(this.btnAddComponent);
            this.pnlFinal.Controls.Add(this.btnClearFinalImage);
            this.pnlFinal.Controls.Add(this.btnImportFinalImg);
            this.pnlFinal.Controls.Add(this.pboxFinalImages);
            this.pnlFinal.Controls.Add(this.lblFinalImages);
            this.pnlFinal.Controls.Add(this.cboxResult2);
            this.pnlFinal.Controls.Add(this.label12);
            this.pnlFinal.Controls.Add(this.label11);
            this.pnlFinal.Controls.Add(this.label9);
            this.pnlFinal.Controls.Add(this.cboxResult3);
            this.pnlFinal.Controls.Add(this.cboxResult1);
            this.pnlFinal.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFinal.Location = new System.Drawing.Point(2, 62);
            this.pnlFinal.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFinal.Name = "pnlFinal";
            this.pnlFinal.Size = new System.Drawing.Size(822, 437);
            this.pnlFinal.TabIndex = 17;
            // 
            // lblComponent
            // 
            this.lblComponent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblComponent.AutoSize = true;
            this.lblComponent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblComponent.Location = new System.Drawing.Point(325, 32);
            this.lblComponent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComponent.Name = "lblComponent";
            this.lblComponent.Size = new System.Drawing.Size(172, 19);
            this.lblComponent.TabIndex = 43;
            this.lblComponent.Text = "No components added yet";
            this.lblComponent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddComponent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddComponent.Location = new System.Drawing.Point(287, 53);
            this.btnAddComponent.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(118, 28);
            this.btnAddComponent.TabIndex = 42;
            this.btnAddComponent.Text = "Add";
            this.btnAddComponent.UseVisualStyleBackColor = true;
            this.btnAddComponent.Click += new System.EventHandler(this.btnAddComponent_Click);
            // 
            // btnClearFinalImage
            // 
            this.btnClearFinalImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearFinalImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFinalImage.Location = new System.Drawing.Point(344, 378);
            this.btnClearFinalImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearFinalImage.Name = "btnClearFinalImage";
            this.btnClearFinalImage.Size = new System.Drawing.Size(118, 28);
            this.btnClearFinalImage.TabIndex = 41;
            this.btnClearFinalImage.Text = "Clear";
            this.btnClearFinalImage.UseVisualStyleBackColor = true;
            this.btnClearFinalImage.Click += new System.EventHandler(this.btnClearImg_Click);
            // 
            // btnImportFinalImg
            // 
            this.btnImportFinalImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportFinalImg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFinalImg.Location = new System.Drawing.Point(344, 347);
            this.btnImportFinalImg.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportFinalImg.Name = "btnImportFinalImg";
            this.btnImportFinalImg.Size = new System.Drawing.Size(118, 28);
            this.btnImportFinalImg.TabIndex = 40;
            this.btnImportFinalImg.Text = "Import";
            this.btnImportFinalImg.UseVisualStyleBackColor = true;
            this.btnImportFinalImg.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // pboxFinalImages
            // 
            this.pboxFinalImages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pboxFinalImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pboxFinalImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxFinalImages.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.pboxFinalImages.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxFinalImages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pboxFinalImages.IconSize = 118;
            this.pboxFinalImages.Location = new System.Drawing.Point(344, 226);
            this.pboxFinalImages.Margin = new System.Windows.Forms.Padding(2);
            this.pboxFinalImages.Name = "pboxFinalImages";
            this.pboxFinalImages.Size = new System.Drawing.Size(118, 118);
            this.pboxFinalImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxFinalImages.TabIndex = 39;
            this.pboxFinalImages.TabStop = false;
            this.pboxFinalImages.Click += new System.EventHandler(this.pboxFinalImages_Click);
            // 
            // lblFinalImages
            // 
            this.lblFinalImages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFinalImages.AutoSize = true;
            this.lblFinalImages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFinalImages.Location = new System.Drawing.Point(345, 209);
            this.lblFinalImages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFinalImages.Name = "lblFinalImages";
            this.lblFinalImages.Size = new System.Drawing.Size(127, 19);
            this.lblFinalImages.TabIndex = 38;
            this.lblFinalImages.Text = "Import PCB images";
            // 
            // cboxResult2
            // 
            this.cboxResult2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxResult2.AutoSize = true;
            this.cboxResult2.Location = new System.Drawing.Point(589, 139);
            this.cboxResult2.Margin = new System.Windows.Forms.Padding(2);
            this.cboxResult2.Name = "cboxResult2";
            this.cboxResult2.Size = new System.Drawing.Size(15, 14);
            this.cboxResult2.TabIndex = 37;
            this.cboxResult2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(221, 135);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 19);
            this.label12.TabIndex = 32;
            this.label12.Text = "No errors found";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.Location = new System.Drawing.Point(221, 102);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(354, 19);
            this.label11.TabIndex = 33;
            this.label11.Text = "Repair done without the gurantee the components work";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.Location = new System.Drawing.Point(223, 166);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(282, 19);
            this.label9.TabIndex = 34;
            this.label9.Text = "Work was done but the problem wasn\'t fixed";
            // 
            // cboxResult3
            // 
            this.cboxResult3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxResult3.AutoSize = true;
            this.cboxResult3.Location = new System.Drawing.Point(589, 170);
            this.cboxResult3.Margin = new System.Windows.Forms.Padding(2);
            this.cboxResult3.Name = "cboxResult3";
            this.cboxResult3.Size = new System.Drawing.Size(15, 14);
            this.cboxResult3.TabIndex = 36;
            this.cboxResult3.UseVisualStyleBackColor = true;
            // 
            // cboxResult1
            // 
            this.cboxResult1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxResult1.AutoSize = true;
            this.cboxResult1.Location = new System.Drawing.Point(589, 106);
            this.cboxResult1.Margin = new System.Windows.Forms.Padding(2);
            this.cboxResult1.Name = "cboxResult1";
            this.cboxResult1.Size = new System.Drawing.Size(15, 14);
            this.cboxResult1.TabIndex = 35;
            this.cboxResult1.UseVisualStyleBackColor = true;
            // 
            // btnClearComponents
            // 
            this.btnClearComponents.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearComponents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearComponents.Location = new System.Drawing.Point(409, 53);
            this.btnClearComponents.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearComponents.Name = "btnClearComponents";
            this.btnClearComponents.Size = new System.Drawing.Size(118, 28);
            this.btnClearComponents.TabIndex = 44;
            this.btnClearComponents.Text = "Clear";
            this.btnClearComponents.UseVisualStyleBackColor = true;
            this.btnClearComponents.Click += new System.EventHandler(this.btnClearComponents_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(824, 499);
            this.Controls.Add(this.pnlFirst);
            this.Controls.Add(this.pnlBoxes);
            this.Controls.Add(this.pnlFinal);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFirst.ResumeLayout(false);
            this.pnlFirst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImages)).EndInit();
            this.pnlBoxes.ResumeLayout(false);
            this.pnlBoxes.PerformLayout();
            this.pnlFinal.ResumeLayout(false);
            this.pnlFinal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFinalImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTopPanel;
        private System.Windows.Forms.Panel pnlFirst;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnImportImage;
        private FontAwesome.Sharp.IconPictureBox pboxImages;
        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.Label lblSerialNum;
        private System.Windows.Forms.TextBox txtSerialNum;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnPrev;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel pnlBoxes;
        private System.Windows.Forms.LinkLabel lblTroubleshoot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.LinkLabel lblClean;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cboxRepair;
        private System.Windows.Forms.CheckBox cboxTroubleshoot;
        private System.Windows.Forms.CheckBox cboxClean;
        private System.Windows.Forms.Panel pnlFinal;
        private System.Windows.Forms.Button btnClearFinalImage;
        private System.Windows.Forms.Button btnImportFinalImg;
        private FontAwesome.Sharp.IconPictureBox pboxFinalImages;
        private System.Windows.Forms.Label lblFinalImages;
        private System.Windows.Forms.CheckBox cboxResult2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cboxResult3;
        private System.Windows.Forms.CheckBox cboxResult1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Button btnImportLabel;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.Label lblComponent;
        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.Button btnClearComponents;
    }
}