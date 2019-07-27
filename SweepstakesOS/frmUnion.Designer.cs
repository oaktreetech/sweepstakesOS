namespace SweepstakesOS
{
    partial class frmUnion
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
            if(disposing && (components != null))
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmdAddFile = new System.Windows.Forms.Button();
            this.cmdUnion = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmdAddFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstHeaders = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkConvert = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entry Files to Union";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(336, 208);
            this.listBox1.TabIndex = 1;
            // 
            // cmdAddFile
            // 
            this.cmdAddFile.Enabled = false;
            this.cmdAddFile.Location = new System.Drawing.Point(276, 297);
            this.cmdAddFile.Name = "cmdAddFile";
            this.cmdAddFile.Size = new System.Drawing.Size(75, 23);
            this.cmdAddFile.TabIndex = 1;
            this.cmdAddFile.Text = "Add File";
            this.cmdAddFile.UseVisualStyleBackColor = true;
            this.cmdAddFile.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdUnion
            // 
            this.cmdUnion.Location = new System.Drawing.Point(643, 392);
            this.cmdUnion.Name = "cmdUnion";
            this.cmdUnion.Size = new System.Drawing.Size(75, 42);
            this.cmdUnion.TabIndex = 2;
            this.cmdUnion.Text = "Perform Union";
            this.cmdUnion.UseVisualStyleBackColor = true;
            this.cmdUnion.Click += new System.EventHandler(this.cmdUnion_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmdAddFolder
            // 
            this.cmdAddFolder.Location = new System.Drawing.Point(195, 297);
            this.cmdAddFolder.Name = "cmdAddFolder";
            this.cmdAddFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdAddFolder.TabIndex = 3;
            this.cmdAddFolder.Text = "Add Folder";
            this.cmdAddFolder.UseVisualStyleBackColor = true;
            this.cmdAddFolder.Click += new System.EventHandler(this.cmdAddFolder_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstHeaders);
            this.groupBox2.Location = new System.Drawing.Point(360, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 227);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shared Headers";
            // 
            // lstHeaders
            // 
            this.lstHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHeaders.FormattingEnabled = true;
            this.lstHeaders.Location = new System.Drawing.Point(3, 16);
            this.lstHeaders.Name = "lstHeaders";
            this.lstHeaders.Size = new System.Drawing.Size(194, 208);
            this.lstHeaders.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "*Only Looks for CSV Files*";
            // 
            // chkConvert
            // 
            this.chkConvert.AutoSize = true;
            this.chkConvert.Checked = true;
            this.chkConvert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConvert.Location = new System.Drawing.Point(18, 41);
            this.chkConvert.Name = "chkConvert";
            this.chkConvert.Size = new System.Drawing.Size(248, 17);
            this.chkConvert.TabIndex = 7;
            this.chkConvert.Text = "Convert All Excel Files without Correspong CSV";
            this.chkConvert.UseVisualStyleBackColor = true;
            // 
            // frmUnion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 446);
            this.Controls.Add(this.chkConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdAddFolder);
            this.Controls.Add(this.cmdUnion);
            this.Controls.Add(this.cmdAddFile);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUnion";
            this.Text = "frmUnion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button cmdAddFile;
        private System.Windows.Forms.Button cmdUnion;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cmdAddFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstHeaders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkConvert;
    }
}