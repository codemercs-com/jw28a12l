namespace WriteLed
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOut0 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOut1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOut2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbOut3 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMatrix = new System.Windows.Forms.Label();
            this.lblButtons = new System.Windows.Forms.Label();
            this.lblAxis3 = new System.Windows.Forms.Label();
            this.lblAxis2 = new System.Windows.Forms.Label();
            this.lblAxis0 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAxis1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.Location = new System.Drawing.Point(12, 214);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(406, 82);
            this.listLog.TabIndex = 2;
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(119, 138);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Enabled = false;
            this.btnWrite.Location = new System.Drawing.Point(119, 138);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 4;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Output 0:";
            // 
            // cmbOut0
            // 
            this.cmbOut0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOut0.FormattingEnabled = true;
            this.cmbOut0.Items.AddRange(new object[] {
            "Idle",
            "Static on",
            "Fast blink",
            "Heart beat"});
            this.cmbOut0.Location = new System.Drawing.Point(63, 23);
            this.cmbOut0.Name = "cmbOut0";
            this.cmbOut0.Size = new System.Drawing.Size(121, 21);
            this.cmbOut0.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output 1:";
            // 
            // cmbOut1
            // 
            this.cmbOut1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOut1.FormattingEnabled = true;
            this.cmbOut1.Items.AddRange(new object[] {
            "Idle",
            "Static on",
            "Fast blink",
            "Heart beat"});
            this.cmbOut1.Location = new System.Drawing.Point(63, 50);
            this.cmbOut1.Name = "cmbOut1";
            this.cmbOut1.Size = new System.Drawing.Size(121, 21);
            this.cmbOut1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output 2:";
            // 
            // cmbOut2
            // 
            this.cmbOut2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOut2.FormattingEnabled = true;
            this.cmbOut2.Items.AddRange(new object[] {
            "Idle",
            "Static on",
            "Fast blink",
            "Heart beat"});
            this.cmbOut2.Location = new System.Drawing.Point(63, 77);
            this.cmbOut2.Name = "cmbOut2";
            this.cmbOut2.Size = new System.Drawing.Size(121, 21);
            this.cmbOut2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Output 3:";
            // 
            // cmbOut3
            // 
            this.cmbOut3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOut3.FormattingEnabled = true;
            this.cmbOut3.Items.AddRange(new object[] {
            "Idle",
            "Static on",
            "Fast blink",
            "Heart beat"});
            this.cmbOut3.Location = new System.Drawing.Point(63, 104);
            this.cmbOut3.Name = "cmbOut3";
            this.cmbOut3.Size = new System.Drawing.Size(121, 21);
            this.cmbOut3.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbOut0);
            this.groupBox1.Controls.Add(this.btnWrite);
            this.groupBox1.Controls.Add(this.cmbOut3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbOut2);
            this.groupBox1.Controls.Add(this.cmbOut1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 167);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Outputs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMatrix);
            this.groupBox2.Controls.Add(this.lblButtons);
            this.groupBox2.Controls.Add(this.btnRead);
            this.groupBox2.Controls.Add(this.lblAxis3);
            this.groupBox2.Controls.Add(this.lblAxis2);
            this.groupBox2.Controls.Add(this.lblAxis0);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblAxis1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(218, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 167);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inputs";
            // 
            // lblMatrix
            // 
            this.lblMatrix.AutoSize = true;
            this.lblMatrix.Location = new System.Drawing.Point(84, 114);
            this.lblMatrix.Name = "lblMatrix";
            this.lblMatrix.Size = new System.Drawing.Size(33, 13);
            this.lblMatrix.TabIndex = 9;
            this.lblMatrix.Text = "None";
            // 
            // lblButtons
            // 
            this.lblButtons.AutoSize = true;
            this.lblButtons.Location = new System.Drawing.Point(84, 97);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(33, 13);
            this.lblButtons.TabIndex = 9;
            this.lblButtons.Text = "None";
            // 
            // lblAxis3
            // 
            this.lblAxis3.AutoSize = true;
            this.lblAxis3.Location = new System.Drawing.Point(45, 74);
            this.lblAxis3.Name = "lblAxis3";
            this.lblAxis3.Size = new System.Drawing.Size(33, 13);
            this.lblAxis3.TabIndex = 9;
            this.lblAxis3.Text = "None";
            // 
            // lblAxis2
            // 
            this.lblAxis2.AutoSize = true;
            this.lblAxis2.Location = new System.Drawing.Point(45, 58);
            this.lblAxis2.Name = "lblAxis2";
            this.lblAxis2.Size = new System.Drawing.Size(33, 13);
            this.lblAxis2.TabIndex = 9;
            this.lblAxis2.Text = "None";
            // 
            // lblAxis0
            // 
            this.lblAxis0.AutoSize = true;
            this.lblAxis0.Location = new System.Drawing.Point(45, 26);
            this.lblAxis0.Name = "lblAxis0";
            this.lblAxis0.Size = new System.Drawing.Size(33, 13);
            this.lblAxis0.TabIndex = 9;
            this.lblAxis0.Text = "None";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Buttonmatrix:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Buttons:";
            // 
            // lblAxis1
            // 
            this.lblAxis1.AutoSize = true;
            this.lblAxis1.Location = new System.Drawing.Point(45, 42);
            this.lblAxis1.Name = "lblAxis1";
            this.lblAxis1.Size = new System.Drawing.Size(33, 13);
            this.lblAxis1.TabIndex = 9;
            this.lblAxis1.Text = "None";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Axis 3:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Axis 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Axis 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Axis 0:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(343, 302);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 339);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "JoyWarrior28A12L Sample";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOut0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOut1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOut2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbOut3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMatrix;
        private System.Windows.Forms.Label lblButtons;
        private System.Windows.Forms.Label lblAxis3;
        private System.Windows.Forms.Label lblAxis2;
        private System.Windows.Forms.Label lblAxis0;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAxis1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
    }
}

