namespace SweepstakesOS
{
    partial class frmExcludeEntries
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
            this.cmbExclude = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbOriginal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdExclude = new System.Windows.Forms.Button();
            this.ucExclude = new SweepstakesOS.ucEntryFileOpenControl();
            this.ucOriginal = new SweepstakesOS.ucEntryFileOpenControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbExclude
            // 
            this.cmbExclude.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbExclude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExclude.FormattingEnabled = true;
            this.cmbExclude.Location = new System.Drawing.Point(103, 105);
            this.cmbExclude.Name = "cmbExclude";
            this.cmbExclude.Size = new System.Drawing.Size(94, 21);
            this.cmbExclude.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Column To Exclude By";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbOriginal, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbExclude, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(92, 88);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 140);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // cmbOriginal
            // 
            this.cmbOriginal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbOriginal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOriginal.FormattingEnabled = true;
            this.cmbOriginal.Location = new System.Drawing.Point(3, 105);
            this.cmbOriginal.Name = "cmbOriginal";
            this.cmbOriginal.Size = new System.Drawing.Size(94, 21);
            this.cmbOriginal.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Location = new System.Drawing.Point(62, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Field Matching";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Original Column";
            // 
            // cmdExclude
            // 
            this.cmdExclude.Location = new System.Drawing.Point(311, 280);
            this.cmdExclude.Name = "cmdExclude";
            this.cmdExclude.Size = new System.Drawing.Size(75, 23);
            this.cmdExclude.TabIndex = 8;
            this.cmdExclude.Text = "Exclude";
            this.cmdExclude.UseVisualStyleBackColor = true;
            this.cmdExclude.Click += new System.EventHandler(this.cmdExclude_Click);
            // 
            // ucExclude
            // 
            this.ucExclude.FilePath = null;
            this.ucExclude.FileType = SweepstakesOS.FileType.CSV;
            this.ucExclude.LabelText = "Exclude From:";
            this.ucExclude.Location = new System.Drawing.Point(24, 50);
            this.ucExclude.Name = "ucExclude";
            this.ucExclude.OutputName = "exclude";
            this.ucExclude.Size = new System.Drawing.Size(329, 32);
            this.ucExclude.TabIndex = 1;
            this.ucExclude.NewFileSelected += new System.EventHandler(this.ucExclude_NewFileSelected);
            // 
            // ucOriginal
            // 
            this.ucOriginal.FilePath = null;
            this.ucOriginal.FileType = SweepstakesOS.FileType.CSV;
            this.ucOriginal.LabelText = "Entries";
            this.ucOriginal.Location = new System.Drawing.Point(24, 12);
            this.ucOriginal.Name = "ucOriginal";
            this.ucOriginal.OutputName = "original";
            this.ucOriginal.Size = new System.Drawing.Size(329, 32);
            this.ucOriginal.TabIndex = 0;
            this.ucOriginal.NewFileSelected += new System.EventHandler(this.ucOriginal_NewFileSelected);
            // 
            // frmExcludeEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 315);
            this.Controls.Add(this.cmdExclude);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ucExclude);
            this.Controls.Add(this.ucOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmExcludeEntries";
            this.Text = "frmExcludeEntries";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucEntryFileOpenControl ucOriginal;
        private ucEntryFileOpenControl ucExclude;
        private System.Windows.Forms.ComboBox cmbExclude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOriginal;
        private System.Windows.Forms.Button cmdExclude;
    }
}