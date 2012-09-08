namespace AFSBrowser {
    partial class PathsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnNext = new System.Windows.Forms.Button();
            this.openAfsFD = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBxISOpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblConfig = new System.Windows.Forms.Label();
            this.txtBxConfig = new System.Windows.Forms.TextBox();
            this.openConfigFD = new System.Windows.Forms.OpenFileDialog();
            this.btnConfigBrowse = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(382, 203);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // openAfsFD
            // 
            this.openAfsFD.FileName = "openFileDialog1";
            this.openAfsFD.Title = "\"\\\\afs\\iu.edu\\public\\sudoc\\volumes\\\"";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(8, 157);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Bro&wse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBxISOpath
            // 
            this.txtBxISOpath.Location = new System.Drawing.Point(8, 131);
            this.txtBxISOpath.Name = "txtBxISOpath";
            this.txtBxISOpath.Size = new System.Drawing.Size(449, 20);
            this.txtBxISOpath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter the path to the file or image you wish to open:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(8, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Location = new System.Drawing.Point(8, 14);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(337, 39);
            this.lblConfig.TabIndex = 5;
            this.lblConfig.Text = "Please enter the path to your Virtual Machine Configuration File (.vmx) \r\n( i.e. " +
                "Windows XP Professional.vmx )\r\n\r\n";
            // 
            // txtBxConfig
            // 
            this.txtBxConfig.Location = new System.Drawing.Point(8, 46);
            this.txtBxConfig.Name = "txtBxConfig";
            this.txtBxConfig.Size = new System.Drawing.Size(449, 20);
            this.txtBxConfig.TabIndex = 6;
            // 
            // openConfigFD
            // 
            this.openConfigFD.FileName = "openFileDialog1";
            // 
            // btnConfigBrowse
            // 
            this.btnConfigBrowse.Location = new System.Drawing.Point(8, 73);
            this.btnConfigBrowse.Name = "btnConfigBrowse";
            this.btnConfigBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnConfigBrowse.TabIndex = 7;
            this.btnConfigBrowse.Text = "&Browse";
            this.btnConfigBrowse.UseVisualStyleBackColor = true;
            this.btnConfigBrowse.Click += new System.EventHandler(this.btnConfigBrowse_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Location = new System.Drawing.Point(382, 236);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 8;
            this.btnPrev.Text = "< &Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(89, 157);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(323, 39);
            this.lblNote.TabIndex = 9;
            this.lblNote.Text = "* Note: If you are wanting to use a file or image that is on the AFS,\r\n   it may " +
                "take a few seconds after clicking Browse until you see the \r\n   file dialog. Ple" +
                "ase be aware that this is normal.\r\n";
            // 
            // PathsForm
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 271);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnConfigBrowse);
            this.Controls.Add(this.txtBxConfig);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxISOpath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnNext);
            this.Name = "PathsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.OpenFileDialog openAfsFD;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBxISOpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.TextBox txtBxConfig;
        private System.Windows.Forms.OpenFileDialog openConfigFD;
        private System.Windows.Forms.Button btnConfigBrowse;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblNote;

    }
}