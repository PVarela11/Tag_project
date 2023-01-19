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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFinal = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlFirst = new System.Windows.Forms.Panel();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnImportImage = new System.Windows.Forms.Button();
            this.pboxImages = new FontAwesome.Sharp.IconPictureBox();
            this.lblImages = new System.Windows.Forms.Label();
            this.lblClean = new System.Windows.Forms.Label();
            this.cboxClean = new System.Windows.Forms.CheckBox();
            this.lblSerialNum = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCreatePDF = new System.Windows.Forms.Button();
            this.btnInstructions = new System.Windows.Forms.Button();
            this.btnPrev = new FontAwesome.Sharp.IconButton();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.pnlTop.SuspendLayout();
            this.pnlFinal.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlFirst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImages)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlTop.Controls.Add(this.btnNext);
            this.pnlTop.Controls.Add(this.btnPrev);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(800, 100);
            this.pnlTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top panel";
            // 
            // pnlFinal
            // 
            this.pnlFinal.Controls.Add(this.label4);
            this.pnlFinal.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFinal.Location = new System.Drawing.Point(790, 100);
            this.pnlFinal.Name = "pnlFinal";
            this.pnlFinal.Size = new System.Drawing.Size(10, 350);
            this.pnlFinal.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Last Panel";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.label3);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMiddle.Location = new System.Drawing.Point(780, 100);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(10, 350);
            this.pnlMiddle.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Middle Panel";
            // 
            // pnlFirst
            // 
            this.pnlFirst.Controls.Add(this.btnInstructions);
            this.pnlFirst.Controls.Add(this.btnCreatePDF);
            this.pnlFirst.Controls.Add(this.btnClearImage);
            this.pnlFirst.Controls.Add(this.btnImportImage);
            this.pnlFirst.Controls.Add(this.pboxImages);
            this.pnlFirst.Controls.Add(this.lblImages);
            this.pnlFirst.Controls.Add(this.lblClean);
            this.pnlFirst.Controls.Add(this.cboxClean);
            this.pnlFirst.Controls.Add(this.lblSerialNum);
            this.pnlFirst.Controls.Add(this.txtSerialNum);
            this.pnlFirst.Controls.Add(this.btnExport);
            this.pnlFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFirst.Location = new System.Drawing.Point(0, 100);
            this.pnlFirst.Name = "pnlFirst";
            this.pnlFirst.Size = new System.Drawing.Size(780, 350);
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
            this.pboxImages.BackColor = System.Drawing.SystemColors.Control;
            this.pboxImages.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pboxImages.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.pboxImages.IconColor = System.Drawing.SystemColors.ControlText;
            this.pboxImages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pboxImages.IconSize = 160;
            this.pboxImages.Location = new System.Drawing.Point(343, 109);
            this.pboxImages.Name = "pboxImages";
            this.pboxImages.Size = new System.Drawing.Size(163, 160);
            this.pboxImages.TabIndex = 9;
            this.pboxImages.TabStop = false;
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
            // lblClean
            // 
            this.lblClean.AutoSize = true;
            this.lblClean.Location = new System.Drawing.Point(31, 281);
            this.lblClean.Name = "lblClean";
            this.lblClean.Size = new System.Drawing.Size(123, 16);
            this.lblClean.TabIndex = 6;
            this.lblClean.Text = "Is the board clean ?";
            // 
            // cboxClean
            // 
            this.cboxClean.AutoSize = true;
            this.cboxClean.Location = new System.Drawing.Point(34, 300);
            this.cboxClean.Name = "cboxClean";
            this.cboxClean.Size = new System.Drawing.Size(18, 17);
            this.cboxClean.TabIndex = 5;
            this.cboxClean.UseVisualStyleBackColor = true;
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
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(163, 22);
            this.txtSerialNum.TabIndex = 3;
            this.txtSerialNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNum_KeyPress);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(675, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Save";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCreatePDF
            // 
            this.btnCreatePDF.Location = new System.Drawing.Point(675, 35);
            this.btnCreatePDF.Name = "btnCreatePDF";
            this.btnCreatePDF.Size = new System.Drawing.Size(99, 23);
            this.btnCreatePDF.TabIndex = 12;
            this.btnCreatePDF.Text = "Create PDF";
            this.btnCreatePDF.UseVisualStyleBackColor = true;
            this.btnCreatePDF.Click += new System.EventHandler(this.btnCreatePDF_Click);
            // 
            // btnInstructions
            // 
            this.btnInstructions.Location = new System.Drawing.Point(675, 64);
            this.btnInstructions.Name = "btnInstructions";
            this.btnInstructions.Size = new System.Drawing.Size(99, 23);
            this.btnInstructions.TabIndex = 13;
            this.btnInstructions.Text = "Instructions";
            this.btnInstructions.UseVisualStyleBackColor = true;
            this.btnInstructions.Click += new System.EventHandler(this.btnInstructions_Click);
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
            this.btnPrev.IconColor = System.Drawing.Color.Black;
            this.btnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrev.Location = new System.Drawing.Point(0, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 100);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
            this.btnNext.IconColor = System.Drawing.Color.Black;
            this.btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNext.Location = new System.Drawing.Point(725, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 100);
            this.btnNext.TabIndex = 2;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFirst;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnImportImage;
        private FontAwesome.Sharp.IconPictureBox pboxImages;
        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.Label lblClean;
        private System.Windows.Forms.CheckBox cboxClean;
        private System.Windows.Forms.Label lblSerialNum;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.Button btnCreatePDF;
        private System.Windows.Forms.Button btnInstructions;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnPrev;
    }
}