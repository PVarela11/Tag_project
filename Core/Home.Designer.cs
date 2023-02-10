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
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFinalThoughts = new System.Windows.Forms.RichTextBox();
            this.cboxApproved = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblComponents = new System.Windows.Forms.Label();
            this.txtComponents = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxComponents = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxEletricalEvaluation = new System.Windows.Forms.CheckBox();
            this.pnlFirst = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
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
            this.btnClearFinalImg = new System.Windows.Forms.Button();
            this.btnImportFinalImg = new System.Windows.Forms.Button();
            this.pboxFinalImages = new FontAwesome.Sharp.IconPictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboxResult2 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboxResult3 = new System.Windows.Forms.CheckBox();
            this.cboxResult1 = new System.Windows.Forms.CheckBox();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnImportImage = new System.Windows.Forms.Button();
            this.pboxImages = new FontAwesome.Sharp.IconPictureBox();
            this.lblImages = new System.Windows.Forms.Label();
            this.lblSerialNum = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlFirst.SuspendLayout();
            this.pnlBoxes.SuspendLayout();
            this.pnlFinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFinalImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImages)).BeginInit();
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
            this.pnlTop.Size = new System.Drawing.Size(1099, 81);
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
            this.iconButton1.Location = new System.Drawing.Point(987, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(56, 81);
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
            this.btnNext.Location = new System.Drawing.Point(1043, 0);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(56, 81);
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
            this.btnPrev.Size = new System.Drawing.Size(56, 81);
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
            this.lblTopPanel.Location = new System.Drawing.Point(505, 31);
            this.lblTopPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTopPanel.Name = "lblTopPanel";
            this.lblTopPanel.Size = new System.Drawing.Size(104, 28);
            this.lblTopPanel.TabIndex = 0;
            this.lblTopPanel.Text = "Top panel";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pnlMiddle.Controls.Add(this.label6);
            this.pnlMiddle.Controls.Add(this.txtFinalThoughts);
            this.pnlMiddle.Controls.Add(this.cboxApproved);
            this.pnlMiddle.Controls.Add(this.label4);
            this.pnlMiddle.Controls.Add(this.button1);
            this.pnlMiddle.Controls.Add(this.button2);
            this.pnlMiddle.Controls.Add(this.lblComponents);
            this.pnlMiddle.Controls.Add(this.txtComponents);
            this.pnlMiddle.Controls.Add(this.label3);
            this.pnlMiddle.Controls.Add(this.cboxComponents);
            this.pnlMiddle.Controls.Add(this.label2);
            this.pnlMiddle.Controls.Add(this.cboxEletricalEvaluation);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMiddle.Location = new System.Drawing.Point(1089, 81);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(10, 572);
            this.pnlMiddle.TabIndex = 2;
            this.pnlMiddle.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 274);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Final Thoughts :";
            // 
            // txtFinalThoughts
            // 
            this.txtFinalThoughts.Location = new System.Drawing.Point(262, 296);
            this.txtFinalThoughts.Margin = new System.Windows.Forms.Padding(2);
            this.txtFinalThoughts.Name = "txtFinalThoughts";
            this.txtFinalThoughts.Size = new System.Drawing.Size(512, 70);
            this.txtFinalThoughts.TabIndex = 22;
            this.txtFinalThoughts.Text = "";
            // 
            // cboxApproved
            // 
            this.cboxApproved.AutoSize = true;
            this.cboxApproved.Location = new System.Drawing.Point(488, 249);
            this.cboxApproved.Margin = new System.Windows.Forms.Padding(2);
            this.cboxApproved.Name = "cboxApproved";
            this.cboxApproved.Size = new System.Drawing.Size(91, 21);
            this.cboxApproved.TabIndex = 19;
            this.cboxApproved.Text = "Approved";
            this.cboxApproved.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 250);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Final Eletrical Evaluation";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 19);
            this.button1.TabIndex = 17;
            this.button1.Text = "Instructions";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(586, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 19);
            this.button2.TabIndex = 15;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblComponents
            // 
            this.lblComponents.AutoSize = true;
            this.lblComponents.Location = new System.Drawing.Point(14, 162);
            this.lblComponents.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComponents.Name = "lblComponents";
            this.lblComponents.Size = new System.Drawing.Size(233, 17);
            this.lblComponents.TabIndex = 14;
            this.lblComponents.Text = "Which components were replaced ?";
            // 
            // txtComponents
            // 
            this.txtComponents.AcceptsReturn = true;
            this.txtComponents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComponents.Location = new System.Drawing.Point(16, 185);
            this.txtComponents.Margin = new System.Windows.Forms.Padding(2);
            this.txtComponents.Multiline = true;
            this.txtComponents.Name = "txtComponents";
            this.txtComponents.Size = new System.Drawing.Size(242, 119);
            this.txtComponents.TabIndex = 13;
            this.txtComponents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreventSeparator);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Components replaced";
            // 
            // cboxComponents
            // 
            this.cboxComponents.AutoSize = true;
            this.cboxComponents.Location = new System.Drawing.Point(136, 110);
            this.cboxComponents.Margin = new System.Windows.Forms.Padding(2);
            this.cboxComponents.Name = "cboxComponents";
            this.cboxComponents.Size = new System.Drawing.Size(18, 17);
            this.cboxComponents.TabIndex = 11;
            this.cboxComponents.UseVisualStyleBackColor = true;
            this.cboxComponents.CheckedChanged += new System.EventHandler(this.cboxComponents_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Eletrical Evaluation";
            // 
            // cboxEletricalEvaluation
            // 
            this.cboxEletricalEvaluation.AutoSize = true;
            this.cboxEletricalEvaluation.Location = new System.Drawing.Point(136, 60);
            this.cboxEletricalEvaluation.Margin = new System.Windows.Forms.Padding(2);
            this.cboxEletricalEvaluation.Name = "cboxEletricalEvaluation";
            this.cboxEletricalEvaluation.Size = new System.Drawing.Size(18, 17);
            this.cboxEletricalEvaluation.TabIndex = 9;
            this.cboxEletricalEvaluation.UseVisualStyleBackColor = true;
            // 
            // pnlFirst
            // 
            this.pnlFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pnlFirst.Controls.Add(this.lblTitle);
            this.pnlFirst.Controls.Add(this.pnlBoxes);
            this.pnlFirst.Controls.Add(this.pnlFinal);
            this.pnlFirst.Controls.Add(this.btnClearImage);
            this.pnlFirst.Controls.Add(this.btnImportImage);
            this.pnlFirst.Controls.Add(this.pboxImages);
            this.pnlFirst.Controls.Add(this.lblImages);
            this.pnlFirst.Controls.Add(this.lblSerialNum);
            this.pnlFirst.Controls.Add(this.txtSerialNum);
            this.pnlFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFirst.Location = new System.Drawing.Point(0, 81);
            this.pnlFirst.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFirst.Name = "pnlFirst";
            this.pnlFirst.Size = new System.Drawing.Size(1089, 572);
            this.pnlFirst.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(0, 124);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = resources.GetString("lblTitle.Text");
            // 
            // pnlBoxes
            // 
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
            this.pnlBoxes.Location = new System.Drawing.Point(-1067, 0);
            this.pnlBoxes.Name = "pnlBoxes";
            this.pnlBoxes.Size = new System.Drawing.Size(1076, 572);
            this.pnlBoxes.TabIndex = 19;
            // 
            // lblTroubleshoot
            // 
            this.lblTroubleshoot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTroubleshoot.AutoSize = true;
            this.lblTroubleshoot.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTroubleshoot.Location = new System.Drawing.Point(284, 64);
            this.lblTroubleshoot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTroubleshoot.Name = "lblTroubleshoot";
            this.lblTroubleshoot.Size = new System.Drawing.Size(458, 23);
            this.lblTroubleshoot.TabIndex = 48;
            this.lblTroubleshoot.TabStop = true;
            this.lblTroubleshoot.Text = "Was the board troubleshooting following the instructions ?";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.Location = new System.Drawing.Point(98, 413);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 23);
            this.label10.TabIndex = 56;
            this.label10.Text = "Comments:";
            // 
            // txtComments
            // 
            this.txtComments.AcceptsReturn = true;
            this.txtComments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComments.Location = new System.Drawing.Point(98, 437);
            this.txtComments.Margin = new System.Windows.Forms.Padding(2);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(885, 102);
            this.txtComments.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(95, 283);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 23);
            this.label1.TabIndex = 54;
            this.label1.Text = "Other observations:";
            // 
            // txtObservations
            // 
            this.txtObservations.AcceptsReturn = true;
            this.txtObservations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtObservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtObservations.Location = new System.Drawing.Point(97, 313);
            this.txtObservations.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.Size = new System.Drawing.Size(886, 83);
            this.txtObservations.TabIndex = 53;
            // 
            // lblClean
            // 
            this.lblClean.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClean.AutoSize = true;
            this.lblClean.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClean.Location = new System.Drawing.Point(284, 24);
            this.lblClean.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClean.Name = "lblClean";
            this.lblClean.Size = new System.Drawing.Size(376, 23);
            this.lblClean.TabIndex = 49;
            this.lblClean.TabStop = true;
            this.lblClean.Text = "Was the board clean following the instructions ?";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(93, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 23);
            this.label7.TabIndex = 52;
            this.label7.Text = "Please explain what was done:";
            // 
            // txtProcess
            // 
            this.txtProcess.AcceptsReturn = true;
            this.txtProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcess.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProcess.Location = new System.Drawing.Point(94, 173);
            this.txtProcess.Margin = new System.Windows.Forms.Padding(2);
            this.txtProcess.Multiline = true;
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(886, 88);
            this.txtProcess.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(284, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(317, 23);
            this.label8.TabIndex = 50;
            this.label8.Text = "Has any repairs been made to the PCB ?";
            // 
            // cboxRepair
            // 
            this.cboxRepair.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxRepair.AutoSize = true;
            this.cboxRepair.Location = new System.Drawing.Point(777, 109);
            this.cboxRepair.Margin = new System.Windows.Forms.Padding(2);
            this.cboxRepair.Name = "cboxRepair";
            this.cboxRepair.Size = new System.Drawing.Size(18, 17);
            this.cboxRepair.TabIndex = 47;
            this.cboxRepair.UseVisualStyleBackColor = true;
            // 
            // cboxTroubleshoot
            // 
            this.cboxTroubleshoot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxTroubleshoot.AutoSize = true;
            this.cboxTroubleshoot.Location = new System.Drawing.Point(777, 69);
            this.cboxTroubleshoot.Margin = new System.Windows.Forms.Padding(2);
            this.cboxTroubleshoot.Name = "cboxTroubleshoot";
            this.cboxTroubleshoot.Size = new System.Drawing.Size(18, 17);
            this.cboxTroubleshoot.TabIndex = 46;
            this.cboxTroubleshoot.UseVisualStyleBackColor = true;
            // 
            // cboxClean
            // 
            this.cboxClean.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxClean.AutoSize = true;
            this.cboxClean.Location = new System.Drawing.Point(777, 30);
            this.cboxClean.Margin = new System.Windows.Forms.Padding(2);
            this.cboxClean.Name = "cboxClean";
            this.cboxClean.Size = new System.Drawing.Size(18, 17);
            this.cboxClean.TabIndex = 45;
            this.cboxClean.UseVisualStyleBackColor = true;
            // 
            // pnlFinal
            // 
            this.pnlFinal.Controls.Add(this.btnClearFinalImg);
            this.pnlFinal.Controls.Add(this.btnImportFinalImg);
            this.pnlFinal.Controls.Add(this.pboxFinalImages);
            this.pnlFinal.Controls.Add(this.label13);
            this.pnlFinal.Controls.Add(this.cboxResult2);
            this.pnlFinal.Controls.Add(this.label12);
            this.pnlFinal.Controls.Add(this.label11);
            this.pnlFinal.Controls.Add(this.label9);
            this.pnlFinal.Controls.Add(this.cboxResult3);
            this.pnlFinal.Controls.Add(this.cboxResult1);
            this.pnlFinal.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFinal.Location = new System.Drawing.Point(9, 0);
            this.pnlFinal.Name = "pnlFinal";
            this.pnlFinal.Size = new System.Drawing.Size(1080, 572);
            this.pnlFinal.TabIndex = 17;
            // 
            // btnClearFinalImg
            // 
            this.btnClearFinalImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearFinalImg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFinalImg.Location = new System.Drawing.Point(450, 463);
            this.btnClearFinalImg.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearFinalImg.Name = "btnClearFinalImg";
            this.btnClearFinalImg.Size = new System.Drawing.Size(158, 37);
            this.btnClearFinalImg.TabIndex = 41;
            this.btnClearFinalImg.Text = "Clear";
            this.btnClearFinalImg.UseVisualStyleBackColor = true;
            // 
            // btnImportFinalImg
            // 
            this.btnImportFinalImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportFinalImg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFinalImg.Location = new System.Drawing.Point(450, 422);
            this.btnImportFinalImg.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportFinalImg.Name = "btnImportFinalImg";
            this.btnImportFinalImg.Size = new System.Drawing.Size(158, 37);
            this.btnImportFinalImg.TabIndex = 40;
            this.btnImportFinalImg.Text = "Import";
            this.btnImportFinalImg.UseVisualStyleBackColor = true;
            // 
            // pboxFinalImages
            // 
            this.pboxFinalImages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pboxFinalImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pboxFinalImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxFinalImages.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.pboxFinalImages.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxFinalImages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pboxFinalImages.IconSize = 154;
            this.pboxFinalImages.Location = new System.Drawing.Point(450, 264);
            this.pboxFinalImages.Margin = new System.Windows.Forms.Padding(2);
            this.pboxFinalImages.Name = "pboxFinalImages";
            this.pboxFinalImages.Size = new System.Drawing.Size(158, 154);
            this.pboxFinalImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxFinalImages.TabIndex = 39;
            this.pboxFinalImages.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.Location = new System.Drawing.Point(451, 242);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 23);
            this.label13.TabIndex = 38;
            this.label13.Text = "Import PCB images";
            // 
            // cboxResult2
            // 
            this.cboxResult2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxResult2.AutoSize = true;
            this.cboxResult2.Location = new System.Drawing.Point(474, 122);
            this.cboxResult2.Margin = new System.Windows.Forms.Padding(2);
            this.cboxResult2.Name = "cboxResult2";
            this.cboxResult2.Size = new System.Drawing.Size(18, 17);
            this.cboxResult2.TabIndex = 37;
            this.cboxResult2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(338, 117);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 23);
            this.label12.TabIndex = 32;
            this.label12.Text = "No errors found";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.Location = new System.Drawing.Point(338, 73);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(383, 23);
            this.label11.TabIndex = 33;
            this.label11.Text = "Repair done without the gurantee the PCB works";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.Location = new System.Drawing.Point(340, 157);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(350, 23);
            this.label9.TabIndex = 34;
            this.label9.Text = "Work was done but the problem wasn\'t fixed";
            // 
            // cboxResult3
            // 
            this.cboxResult3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxResult3.AutoSize = true;
            this.cboxResult3.Location = new System.Drawing.Point(694, 162);
            this.cboxResult3.Margin = new System.Windows.Forms.Padding(2);
            this.cboxResult3.Name = "cboxResult3";
            this.cboxResult3.Size = new System.Drawing.Size(18, 17);
            this.cboxResult3.TabIndex = 36;
            this.cboxResult3.UseVisualStyleBackColor = true;
            // 
            // cboxResult1
            // 
            this.cboxResult1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxResult1.AutoSize = true;
            this.cboxResult1.Location = new System.Drawing.Point(725, 79);
            this.cboxResult1.Margin = new System.Windows.Forms.Padding(2);
            this.cboxResult1.Name = "cboxResult1";
            this.cboxResult1.Size = new System.Drawing.Size(18, 17);
            this.cboxResult1.TabIndex = 35;
            this.cboxResult1.UseVisualStyleBackColor = true;
            // 
            // btnClearImage
            // 
            this.btnClearImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearImage.Location = new System.Drawing.Point(465, 446);
            this.btnClearImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(158, 37);
            this.btnClearImage.TabIndex = 11;
            this.btnClearImage.Text = "Clear";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImg_Click);
            // 
            // btnImportImage
            // 
            this.btnImportImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportImage.Location = new System.Drawing.Point(465, 405);
            this.btnImportImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Size = new System.Drawing.Size(158, 37);
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
            this.pboxImages.IconSize = 154;
            this.pboxImages.Location = new System.Drawing.Point(465, 247);
            this.pboxImages.Margin = new System.Windows.Forms.Padding(2);
            this.pboxImages.Name = "pboxImages";
            this.pboxImages.Size = new System.Drawing.Size(158, 154);
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
            this.lblImages.Location = new System.Drawing.Point(466, 225);
            this.lblImages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(157, 23);
            this.lblImages.TabIndex = 8;
            this.lblImages.Text = "Import PCB images";
            // 
            // lblSerialNum
            // 
            this.lblSerialNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSerialNum.AutoSize = true;
            this.lblSerialNum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSerialNum.Location = new System.Drawing.Point(483, 160);
            this.lblSerialNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSerialNum.Name = "lblSerialNum";
            this.lblSerialNum.Size = new System.Drawing.Size(123, 23);
            this.lblSerialNum.TabIndex = 4;
            this.lblSerialNum.Text = "Serial Number:";
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSerialNum.Location = new System.Drawing.Point(466, 185);
            this.txtSerialNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialNum.MaxLength = 4;
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(157, 23);
            this.txtSerialNum.TabIndex = 3;
            this.txtSerialNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNum_KeyPress);
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1099, 653);
            this.Controls.Add(this.pnlFirst);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.pnlFirst.ResumeLayout(false);
            this.pnlFirst.PerformLayout();
            this.pnlBoxes.ResumeLayout(false);
            this.pnlBoxes.PerformLayout();
            this.pnlFinal.ResumeLayout(false);
            this.pnlFinal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFinalImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTopPanel;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlFirst;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnImportImage;
        private FontAwesome.Sharp.IconPictureBox pboxImages;
        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.Label lblSerialNum;
        private System.Windows.Forms.TextBox txtSerialNum;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnPrev;
        private System.Windows.Forms.Label lblComponents;
        private System.Windows.Forms.TextBox txtComponents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cboxComponents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cboxEletricalEvaluation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtFinalThoughts;
        private System.Windows.Forms.CheckBox cboxApproved;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Button btnClearFinalImg;
        private System.Windows.Forms.Button btnImportFinalImg;
        private FontAwesome.Sharp.IconPictureBox pboxFinalImages;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cboxResult2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cboxResult3;
        private System.Windows.Forms.CheckBox cboxResult1;
        private System.Windows.Forms.Label lblTitle;
    }
}