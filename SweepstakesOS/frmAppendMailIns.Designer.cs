namespace SweepstakesOS
{
    partial class frmAppendMailIns
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
            this.numEntriesPerMailIn = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAppend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numMailIns = new System.Windows.Forms.NumericUpDown();
            this.ucEntryFileOpenControl1 = new SweepstakesOS.ucEntryFileOpenControl();
            this.txtWriteName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numEntriesPerMailIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMailIns)).BeginInit();
            this.SuspendLayout();
            // 
            // numEntriesPerMailIn
            // 
            this.numEntriesPerMailIn.Location = new System.Drawing.Point(119, 71);
            this.numEntriesPerMailIn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEntriesPerMailIn.Name = "numEntriesPerMailIn";
            this.numEntriesPerMailIn.Size = new System.Drawing.Size(120, 20);
            this.numEntriesPerMailIn.TabIndex = 0;
            this.numEntriesPerMailIn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entries Per Mail-In";
            // 
            // cmdAppend
            // 
            this.cmdAppend.Location = new System.Drawing.Point(261, 99);
            this.cmdAppend.Name = "cmdAppend";
            this.cmdAppend.Size = new System.Drawing.Size(75, 23);
            this.cmdAppend.TabIndex = 3;
            this.cmdAppend.Text = "Append Mail-Ins";
            this.cmdAppend.UseVisualStyleBackColor = true;
            this.cmdAppend.Click += new System.EventHandler(this.cmdAppend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "# of Mail-In Entries";
            // 
            // numMailIns
            // 
            this.numMailIns.Location = new System.Drawing.Point(119, 45);
            this.numMailIns.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMailIns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMailIns.Name = "numMailIns";
            this.numMailIns.Size = new System.Drawing.Size(120, 20);
            this.numMailIns.TabIndex = 4;
            this.numMailIns.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // ucEntryFileOpenControl1
            // 
            this.ucEntryFileOpenControl1.FilePath = null;
            this.ucEntryFileOpenControl1.FileType = SweepstakesOS.FileType.CSV;
            this.ucEntryFileOpenControl1.LabelText = "Entry File:";
            this.ucEntryFileOpenControl1.Location = new System.Drawing.Point(12, 12);
            this.ucEntryFileOpenControl1.Name = "ucEntryFileOpenControl1";
            this.ucEntryFileOpenControl1.OutputName = "temp";
            this.ucEntryFileOpenControl1.Size = new System.Drawing.Size(329, 32);
            this.ucEntryFileOpenControl1.TabIndex = 1;
            // 
            // txtWriteName
            // 
            this.txtWriteName.Location = new System.Drawing.Point(119, 99);
            this.txtWriteName.Name = "txtWriteName";
            this.txtWriteName.Size = new System.Drawing.Size(120, 20);
            this.txtWriteName.TabIndex = 6;
            this.txtWriteName.Text = "Mail-In";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Text Name";
            // 
            // frmAppendMailIns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 153);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWriteName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numMailIns);
            this.Controls.Add(this.cmdAppend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucEntryFileOpenControl1);
            this.Controls.Add(this.numEntriesPerMailIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAppendMailIns";
            this.Text = "Append Mail-In Entries";
            ((System.ComponentModel.ISupportInitialize)(this.numEntriesPerMailIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMailIns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numEntriesPerMailIn;
        private ucEntryFileOpenControl ucEntryFileOpenControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdAppend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMailIns;
        private System.Windows.Forms.TextBox txtWriteName;
        private System.Windows.Forms.Label label3;
    }
}