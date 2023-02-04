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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.btnPrev = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFinal = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFinalThoughts = new System.Windows.Forms.RichTextBox();
            this.btnClearFinalImg = new System.Windows.Forms.Button();
            this.btnImportFinalImg = new System.Windows.Forms.Button();
            this.pboxFinalImages = new FontAwesome.Sharp.IconPictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxApproved = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreatePDF = new System.Windows.Forms.Button();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblComponents = new System.Windows.Forms.Label();
            this.txtComponents = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxComponents = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxEletricalEvaluation = new System.Windows.Forms.CheckBox();
            this.lblClean = new System.Windows.Forms.Label();
            this.cboxClean = new System.Windows.Forms.CheckBox();
            this.pnlFirst = new System.Windows.Forms.Panel();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnImportImage = new System.Windows.Forms.Button();
            this.pboxImages = new FontAwesome.Sharp.IconPictureBox();
            this.lblImages = new System.Windows.Forms.Label();
            this.lblSerialNum = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlFinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFinalImages)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            this.pnlFirst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImages)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(61)))));
            this.pnlTop.Controls.Add(this.btnNext);
            this.pnlTop.Controls.Add(this.btnPrev);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(940, 100);
            this.pnlTop.TabIndex = 0;
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
            this.btnNext.Location = new System.Drawing.Point(865, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 100);
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
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 100);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(426, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top panel";
            // 
            // pnlFinal
            // 
            this.pnlFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pnlFinal.Controls.Add(this.button5);
            this.pnlFinal.Controls.Add(this.button6);
            this.pnlFinal.Controls.Add(this.label6);
            this.pnlFinal.Controls.Add(this.txtFinalThoughts);
            this.pnlFinal.Controls.Add(this.btnClearFinalImg);
            this.pnlFinal.Controls.Add(this.btnImportFinalImg);
            this.pnlFinal.Controls.Add(this.pboxFinalImages);
            this.pnlFinal.Controls.Add(this.label5);
            this.pnlFinal.Controls.Add(this.cboxApproved);
            this.pnlFinal.Controls.Add(this.label4);
            this.pnlFinal.Controls.Add(this.btnCreatePDF);
            this.pnlFinal.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFinal.Location = new System.Drawing.Point(930, 100);
            this.pnlFinal.Name = "pnlFinal";
            this.pnlFinal.Size = new System.Drawing.Size(10, 430);
            this.pnlFinal.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(817, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "Instructions";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(817, 13);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 23);
            this.button6.TabIndex = 22;
            this.button6.Text = "Save";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Final Thoughts :";
            // 
            // txtFinalThoughts
            // 
            this.txtFinalThoughts.Location = new System.Drawing.Point(377, 119);
            this.txtFinalThoughts.Name = "txtFinalThoughts";
            this.txtFinalThoughts.Size = new System.Drawing.Size(539, 250);
            this.txtFinalThoughts.TabIndex = 20;
            this.txtFinalThoughts.Text = "";
            // 
            // btnClearFinalImg
            // 
            this.btnClearFinalImg.Location = new System.Drawing.Point(250, 347);
            this.btnClearFinalImg.Name = "btnClearFinalImg";
            this.btnClearFinalImg.Size = new System.Drawing.Size(75, 23);
            this.btnClearFinalImg.TabIndex = 19;
            this.btnClearFinalImg.Text = "Clear";
            this.btnClearFinalImg.UseVisualStyleBackColor = true;
            this.btnClearFinalImg.Click += new System.EventHandler(this.btnClearImg_Click);
            // 
            // btnImportFinalImg
            // 
            this.btnImportFinalImg.Location = new System.Drawing.Point(162, 346);
            this.btnImportFinalImg.Name = "btnImportFinalImg";
            this.btnImportFinalImg.Size = new System.Drawing.Size(75, 23);
            this.btnImportFinalImg.TabIndex = 18;
            this.btnImportFinalImg.Text = "Import";
            this.btnImportFinalImg.UseVisualStyleBackColor = true;
            this.btnImportFinalImg.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // pboxFinalImages
            // 
            this.pboxFinalImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pboxFinalImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxFinalImages.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.pboxFinalImages.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxFinalImages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pboxFinalImages.IconSize = 160;
            this.pboxFinalImages.Location = new System.Drawing.Point(162, 173);
            this.pboxFinalImages.Name = "pboxFinalImages";
            this.pboxFinalImages.Size = new System.Drawing.Size(163, 160);
            this.pboxFinalImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxFinalImages.TabIndex = 17;
            this.pboxFinalImages.TabStop = false;
            this.pboxFinalImages.Click += new System.EventHandler(this.pboxFinalImages_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Import PCB images";
            // 
            // cboxApproved
            // 
            this.cboxApproved.AutoSize = true;
            this.cboxApproved.Location = new System.Drawing.Point(193, 92);
            this.cboxApproved.Name = "cboxApproved";
            this.cboxApproved.Size = new System.Drawing.Size(89, 20);
            this.cboxApproved.TabIndex = 15;
            this.cboxApproved.Text = "Approved";
            this.cboxApproved.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Final Eletrical Evaluation";
            // 
            // btnCreatePDF
            // 
            this.btnCreatePDF.Location = new System.Drawing.Point(746, 395);
            this.btnCreatePDF.Name = "btnCreatePDF";
            this.btnCreatePDF.Size = new System.Drawing.Size(170, 23);
            this.btnCreatePDF.TabIndex = 13;
            this.btnCreatePDF.Text = "Create PDF";
            this.btnCreatePDF.UseVisualStyleBackColor = true;
            this.btnCreatePDF.Click += new System.EventHandler(this.btnCreatePDF_Click);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pnlMiddle.Controls.Add(this.button1);
            this.pnlMiddle.Controls.Add(this.button2);
            this.pnlMiddle.Controls.Add(this.lblComponents);
            this.pnlMiddle.Controls.Add(this.txtComponents);
            this.pnlMiddle.Controls.Add(this.label3);
            this.pnlMiddle.Controls.Add(this.cboxComponents);
            this.pnlMiddle.Controls.Add(this.label2);
            this.pnlMiddle.Controls.Add(this.cboxEletricalEvaluation);
            this.pnlMiddle.Controls.Add(this.lblClean);
            this.pnlMiddle.Controls.Add(this.cboxClean);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMiddle.Location = new System.Drawing.Point(122, 100);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(808, 430);
            this.pnlMiddle.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(783, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Instructions";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(783, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblComponents
            // 
            this.lblComponents.AutoSize = true;
            this.lblComponents.Location = new System.Drawing.Point(18, 200);
            this.lblComponents.Name = "lblComponents";
            this.lblComponents.Size = new System.Drawing.Size(220, 16);
            this.lblComponents.TabIndex = 14;
            this.lblComponents.Text = "Which components were replaced ?";
            // 
            // txtComponents
            // 
            this.txtComponents.AcceptsReturn = true;
            this.txtComponents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComponents.Location = new System.Drawing.Point(21, 228);
            this.txtComponents.Multiline = true;
            this.txtComponents.Name = "txtComponents";
            this.txtComponents.Size = new System.Drawing.Size(322, 146);
            this.txtComponents.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Components replaced";
            // 
            // cboxComponents
            // 
            this.cboxComponents.AutoSize = true;
            this.cboxComponents.Location = new System.Drawing.Point(183, 136);
            this.cboxComponents.Name = "cboxComponents";
            this.cboxComponents.Size = new System.Drawing.Size(18, 17);
            this.cboxComponents.TabIndex = 11;
            this.cboxComponents.UseVisualStyleBackColor = true;
            this.cboxComponents.CheckedChanged += new System.EventHandler(this.cboxComponents_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Eletrical Evaluation";
            // 
            // cboxEletricalEvaluation
            // 
            this.cboxEletricalEvaluation.AutoSize = true;
            this.cboxEletricalEvaluation.Location = new System.Drawing.Point(183, 74);
            this.cboxEletricalEvaluation.Name = "cboxEletricalEvaluation";
            this.cboxEletricalEvaluation.Size = new System.Drawing.Size(18, 17);
            this.cboxEletricalEvaluation.TabIndex = 9;
            this.cboxEletricalEvaluation.UseVisualStyleBackColor = true;
            // 
            // lblClean
            // 
            this.lblClean.AutoSize = true;
            this.lblClean.Location = new System.Drawing.Point(18, 13);
            this.lblClean.Name = "lblClean";
            this.lblClean.Size = new System.Drawing.Size(82, 16);
            this.lblClean.TabIndex = 8;
            this.lblClean.Text = "Board Clean";
            // 
            // cboxClean
            // 
            this.cboxClean.AutoSize = true;
            this.cboxClean.Location = new System.Drawing.Point(183, 12);
            this.cboxClean.Name = "cboxClean";
            this.cboxClean.Size = new System.Drawing.Size(18, 17);
            this.cboxClean.TabIndex = 7;
            this.cboxClean.UseVisualStyleBackColor = true;
            // 
            // pnlFirst
            // 
            this.pnlFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pnlFirst.Controls.Add(this.btnClearImage);
            this.pnlFirst.Controls.Add(this.btnImportImage);
            this.pnlFirst.Controls.Add(this.pboxImages);
            this.pnlFirst.Controls.Add(this.lblImages);
            this.pnlFirst.Controls.Add(this.lblSerialNum);
            this.pnlFirst.Controls.Add(this.txtSerialNum);
            this.pnlFirst.Controls.Add(this.btnExport);
            this.pnlFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFirst.Location = new System.Drawing.Point(0, 100);
            this.pnlFirst.Name = "pnlFirst";
            this.pnlFirst.Size = new System.Drawing.Size(122, 430);
            this.pnlFirst.TabIndex = 3;
            // 
            // btnClearImage
            // 
            this.btnClearImage.Location = new System.Drawing.Point(431, 283);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(75, 23);
            this.btnClearImage.TabIndex = 11;
            this.btnClearImage.Text = "Clear";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImg_Click);
            // 
            // btnImportImage
            // 
            this.btnImportImage.Location = new System.Drawing.Point(343, 282);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Size = new System.Drawing.Size(75, 23);
            this.btnImportImage.TabIndex = 10;
            this.btnImportImage.Text = "Import";
            this.btnImportImage.UseVisualStyleBackColor = true;
            this.btnImportImage.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // pboxImages
            // 
            this.pboxImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.pboxImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxImages.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.pboxImages.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(10)))));
            this.pboxImages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pboxImages.IconSize = 160;
            this.pboxImages.Location = new System.Drawing.Point(343, 109);
            this.pboxImages.Name = "pboxImages";
            this.pboxImages.Size = new System.Drawing.Size(160, 160);
            this.pboxImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxImages.TabIndex = 9;
            this.pboxImages.TabStop = false;
            this.pboxImages.Click += new System.EventHandler(this.pboxImages_Click);
            // 
            // lblImages
            // 
            this.lblImages.AutoSize = true;
            this.lblImages.Location = new System.Drawing.Point(215, 109);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(122, 16);
            this.lblImages.TabIndex = 8;
            this.lblImages.Text = "Import PCB images";
            // 
            // lblSerialNum
            // 
            this.lblSerialNum.AutoSize = true;
            this.lblSerialNum.Location = new System.Drawing.Point(215, 48);
            this.lblSerialNum.Name = "lblSerialNum";
            this.lblSerialNum.Size = new System.Drawing.Size(96, 16);
            this.lblSerialNum.TabIndex = 4;
            this.lblSerialNum.Text = "Serial Number:";
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Location = new System.Drawing.Point(343, 48);
            this.txtSerialNum.MaxLength = 4;
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(163, 22);
            this.txtSerialNum.TabIndex = 3;
            this.txtSerialNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNum_KeyPress);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(807, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Save";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 530);
            this.Controls.Add(this.pnlFirst);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlFinal);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFinal.ResumeLayout(false);
            this.pnlFinal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFinalImages)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.pnlFirst.ResumeLayout(false);
            this.pnlFirst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFinal;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlFirst;
        private System.Windows.Forms.Button btnExport;
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
        private System.Windows.Forms.Label lblClean;
        private System.Windows.Forms.CheckBox cboxClean;
        private System.Windows.Forms.Button btnCreatePDF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtFinalThoughts;
        private System.Windows.Forms.Button btnClearFinalImg;
        private System.Windows.Forms.Button btnImportFinalImg;
        private FontAwesome.Sharp.IconPictureBox pboxFinalImages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboxApproved;
        private System.Windows.Forms.Label label4;
    }
}