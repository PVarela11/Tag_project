namespace Tåg_project.Core
{
    partial class ComponentsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnImportImage = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnNewComponent = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtComponent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearBeforeImage = new System.Windows.Forms.Button();
            this.btnImportBeforeImage = new System.Windows.Forms.Button();
            this.lblImportBeforeImage = new System.Windows.Forms.Label();
            this.btnClearAfterImage = new System.Windows.Forms.Button();
            this.btnImportAfterImage = new System.Windows.Forms.Button();
            this.lblImportAfterImage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Add new component";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(361, 291);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(81, 19);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(29, 328);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(742, 84);
            this.txtDescription.TabIndex = 52;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearImage.Location = new System.Drawing.Point(102, 220);
            this.btnClearImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(118, 28);
            this.btnClearImage.TabIndex = 56;
            this.btnClearImage.Text = "Clear";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnImportImage
            // 
            this.btnImportImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportImage.Location = new System.Drawing.Point(102, 188);
            this.btnImportImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Size = new System.Drawing.Size(118, 28);
            this.btnImportImage.TabIndex = 55;
            this.btnImportImage.Text = "Import";
            this.btnImportImage.UseVisualStyleBackColor = true;
            this.btnImportImage.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // lblImage
            // 
            this.lblImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImage.Location = new System.Drawing.Point(98, 167);
            this.lblImage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(124, 19);
            this.lblImage.TabIndex = 53;
            this.lblImage.Text = "Component Image";
            // 
            // btnNewComponent
            // 
            this.btnNewComponent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewComponent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewComponent.Location = new System.Drawing.Point(341, 453);
            this.btnNewComponent.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewComponent.Name = "btnNewComponent";
            this.btnNewComponent.Size = new System.Drawing.Size(118, 28);
            this.btnNewComponent.TabIndex = 57;
            this.btnNewComponent.Text = "Add new";
            this.btnNewComponent.UseVisualStyleBackColor = true;
            this.btnNewComponent.Click += new System.EventHandler(this.btnNewComponent_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(341, 485);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(118, 28);
            this.btnFinish.TabIndex = 58;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(341, 517);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 28);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtComponent
            // 
            this.txtComponent.Location = new System.Drawing.Point(341, 88);
            this.txtComponent.Name = "txtComponent";
            this.txtComponent.Size = new System.Drawing.Size(118, 20);
            this.txtComponent.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(338, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 61;
            this.label1.Text = "Component Name:";
            // 
            // btnClearBeforeImage
            // 
            this.btnClearBeforeImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearBeforeImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBeforeImage.Location = new System.Drawing.Point(341, 220);
            this.btnClearBeforeImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearBeforeImage.Name = "btnClearBeforeImage";
            this.btnClearBeforeImage.Size = new System.Drawing.Size(118, 28);
            this.btnClearBeforeImage.TabIndex = 64;
            this.btnClearBeforeImage.Text = "Clear";
            this.btnClearBeforeImage.UseVisualStyleBackColor = true;
            this.btnClearBeforeImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnImportBeforeImage
            // 
            this.btnImportBeforeImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportBeforeImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportBeforeImage.Location = new System.Drawing.Point(341, 188);
            this.btnImportBeforeImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportBeforeImage.Name = "btnImportBeforeImage";
            this.btnImportBeforeImage.Size = new System.Drawing.Size(118, 28);
            this.btnImportBeforeImage.TabIndex = 63;
            this.btnImportBeforeImage.Text = "Import";
            this.btnImportBeforeImage.UseVisualStyleBackColor = true;
            this.btnImportBeforeImage.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // lblImportBeforeImage
            // 
            this.lblImportBeforeImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblImportBeforeImage.AutoSize = true;
            this.lblImportBeforeImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImportBeforeImage.Location = new System.Drawing.Point(339, 148);
            this.lblImportBeforeImage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImportBeforeImage.Name = "lblImportBeforeImage";
            this.lblImportBeforeImage.Size = new System.Drawing.Size(123, 38);
            this.lblImportBeforeImage.TabIndex = 62;
            this.lblImportBeforeImage.Text = "Component image\r\nbefore cleaning";
            // 
            // btnClearAfterImage
            // 
            this.btnClearAfterImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearAfterImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAfterImage.Location = new System.Drawing.Point(590, 220);
            this.btnClearAfterImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearAfterImage.Name = "btnClearAfterImage";
            this.btnClearAfterImage.Size = new System.Drawing.Size(118, 28);
            this.btnClearAfterImage.TabIndex = 67;
            this.btnClearAfterImage.Text = "Clear";
            this.btnClearAfterImage.UseVisualStyleBackColor = true;
            this.btnClearAfterImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnImportAfterImage
            // 
            this.btnImportAfterImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportAfterImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportAfterImage.Location = new System.Drawing.Point(589, 188);
            this.btnImportAfterImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportAfterImage.Name = "btnImportAfterImage";
            this.btnImportAfterImage.Size = new System.Drawing.Size(118, 28);
            this.btnImportAfterImage.TabIndex = 66;
            this.btnImportAfterImage.Text = "Import";
            this.btnImportAfterImage.UseVisualStyleBackColor = true;
            this.btnImportAfterImage.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // lblImportAfterImage
            // 
            this.lblImportAfterImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblImportAfterImage.AutoSize = true;
            this.lblImportAfterImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImportAfterImage.Location = new System.Drawing.Point(585, 148);
            this.lblImportAfterImage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImportAfterImage.Name = "lblImportAfterImage";
            this.lblImportAfterImage.Size = new System.Drawing.Size(123, 38);
            this.lblImportAfterImage.TabIndex = 65;
            this.lblImportAfterImage.Text = "Component image\r\nafter cleaning";
            // 
            // ComponentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(155)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.btnClearAfterImage);
            this.Controls.Add(this.btnImportAfterImage);
            this.Controls.Add(this.lblImportAfterImage);
            this.Controls.Add(this.btnClearBeforeImage);
            this.Controls.Add(this.btnImportBeforeImage);
            this.Controls.Add(this.lblImportBeforeImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComponent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnNewComponent);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.btnImportImage);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComponentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Component";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnImportImage;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnNewComponent;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtComponent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearBeforeImage;
        private System.Windows.Forms.Button btnImportBeforeImage;
        private System.Windows.Forms.Label lblImportBeforeImage;
        private System.Windows.Forms.Button btnClearAfterImage;
        private System.Windows.Forms.Button btnImportAfterImage;
        private System.Windows.Forms.Label lblImportAfterImage;
    }
}