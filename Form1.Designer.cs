namespace Turbidity
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnRequestMsg = new System.Windows.Forms.Button();
            this.txtReceivedMsg = new System.Windows.Forms.TextBox();
            this.lblTurbidReading = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuTabControl = new System.Windows.Forms.TabControl();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.richTextBoxAboutInfo = new System.Windows.Forms.RichTextBox();
            this.editTabPage = new System.Windows.Forms.TabPage();
            this.cmbBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.txtBoxComPort = new System.Windows.Forms.TextBox();
            this.lblSetBaudRate = new System.Windows.Forms.Label();
            this.lblSetComPort = new System.Windows.Forms.Label();
            this.lblSetTimeInterval = new System.Windows.Forms.Label();
            this.txtBoxTimeInterval = new System.Windows.Forms.TextBox();
            this.btnSaveConfigInput = new System.Windows.Forms.Button();
            this.btnCancelConfigInput = new System.Windows.Forms.Button();
            this.menuTabControl.SuspendLayout();
            this.aboutTabPage.SuspendLayout();
            this.editTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRequestMsg
            // 
            this.btnRequestMsg.BackColor = System.Drawing.Color.Black;
            this.btnRequestMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequestMsg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRequestMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestMsg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRequestMsg.Location = new System.Drawing.Point(547, 147);
            this.btnRequestMsg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRequestMsg.Name = "btnRequestMsg";
            this.btnRequestMsg.Size = new System.Drawing.Size(167, 53);
            this.btnRequestMsg.TabIndex = 0;
            this.btnRequestMsg.Text = "START";
            this.btnRequestMsg.UseVisualStyleBackColor = false;
            this.btnRequestMsg.Click += new System.EventHandler(this.btnRequestMsg_Click);
            // 
            // txtReceivedMsg
            // 
            this.txtReceivedMsg.Cursor = System.Windows.Forms.Cursors.No;
            this.txtReceivedMsg.Location = new System.Drawing.Point(547, 78);
            this.txtReceivedMsg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtReceivedMsg.Name = "txtReceivedMsg";
            this.txtReceivedMsg.ReadOnly = true;
            this.txtReceivedMsg.Size = new System.Drawing.Size(205, 35);
            this.txtReceivedMsg.TabIndex = 1;
            // 
            // lblTurbidReading
            // 
            this.lblTurbidReading.AutoSize = true;
            this.lblTurbidReading.BackColor = System.Drawing.Color.Transparent;
            this.lblTurbidReading.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTurbidReading.Location = new System.Drawing.Point(542, 12);
            this.lblTurbidReading.Name = "lblTurbidReading";
            this.lblTurbidReading.Size = new System.Drawing.Size(210, 29);
            this.lblTurbidReading.TabIndex = 2;
            this.lblTurbidReading.Text = "Turbidity Reading:";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuTabControl
            // 
            this.menuTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.menuTabControl.Controls.Add(this.aboutTabPage);
            this.menuTabControl.Controls.Add(this.editTabPage);
            this.menuTabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuTabControl.Location = new System.Drawing.Point(12, 12);
            this.menuTabControl.Name = "menuTabControl";
            this.menuTabControl.SelectedIndex = 0;
            this.menuTabControl.Size = new System.Drawing.Size(428, 425);
            this.menuTabControl.TabIndex = 3;
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Controls.Add(this.richTextBoxAboutInfo);
            this.aboutTabPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.aboutTabPage.Location = new System.Drawing.Point(4, 41);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTabPage.Size = new System.Drawing.Size(420, 380);
            this.aboutTabPage.TabIndex = 0;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAboutInfo
            // 
            this.richTextBoxAboutInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxAboutInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxAboutInfo.ForeColor = System.Drawing.Color.White;
            this.richTextBoxAboutInfo.Location = new System.Drawing.Point(25, 25);
            this.richTextBoxAboutInfo.Name = "richTextBoxAboutInfo";
            this.richTextBoxAboutInfo.ReadOnly = true;
            this.richTextBoxAboutInfo.Size = new System.Drawing.Size(368, 328);
            this.richTextBoxAboutInfo.TabIndex = 0;
            this.richTextBoxAboutInfo.Text = "This is a test of words in here!";
            // 
            // editTabPage
            // 
            this.editTabPage.Controls.Add(this.cmbBoxBaudRate);
            this.editTabPage.Controls.Add(this.txtBoxComPort);
            this.editTabPage.Controls.Add(this.lblSetBaudRate);
            this.editTabPage.Controls.Add(this.lblSetComPort);
            this.editTabPage.Controls.Add(this.lblSetTimeInterval);
            this.editTabPage.Controls.Add(this.txtBoxTimeInterval);
            this.editTabPage.Controls.Add(this.btnSaveConfigInput);
            this.editTabPage.Controls.Add(this.btnCancelConfigInput);
            this.editTabPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.editTabPage.Location = new System.Drawing.Point(4, 41);
            this.editTabPage.Name = "editTabPage";
            this.editTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.editTabPage.Size = new System.Drawing.Size(420, 380);
            this.editTabPage.TabIndex = 1;
            this.editTabPage.Text = "Edit Settings";
            this.editTabPage.UseVisualStyleBackColor = true;
            // 
            // cmbBoxBaudRate
            // 
            this.cmbBoxBaudRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxBaudRate.FormattingEnabled = true;
            this.cmbBoxBaudRate.Items.AddRange(new object[] {
            "",
            "9600",
            "1200",
            "2400",
            "4800",
            "19200"});
            this.cmbBoxBaudRate.Location = new System.Drawing.Point(33, 158);
            this.cmbBoxBaudRate.Name = "cmbBoxBaudRate";
            this.cmbBoxBaudRate.Size = new System.Drawing.Size(100, 37);
            this.cmbBoxBaudRate.TabIndex = 10;
            // 
            // txtBoxComPort
            // 
            this.txtBoxComPort.Location = new System.Drawing.Point(33, 256);
            this.txtBoxComPort.Name = "txtBoxComPort";
            this.txtBoxComPort.Size = new System.Drawing.Size(100, 35);
            this.txtBoxComPort.TabIndex = 8;
            // 
            // lblSetBaudRate
            // 
            this.lblSetBaudRate.AutoSize = true;
            this.lblSetBaudRate.BackColor = System.Drawing.Color.Transparent;
            this.lblSetBaudRate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSetBaudRate.Location = new System.Drawing.Point(25, 224);
            this.lblSetBaudRate.Name = "lblSetBaudRate";
            this.lblSetBaudRate.Size = new System.Drawing.Size(161, 29);
            this.lblSetBaudRate.TabIndex = 7;
            this.lblSetBaudRate.Text = "Set COM Port";
            // 
            // lblSetComPort
            // 
            this.lblSetComPort.AutoSize = true;
            this.lblSetComPort.BackColor = System.Drawing.Color.Transparent;
            this.lblSetComPort.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSetComPort.Location = new System.Drawing.Point(25, 125);
            this.lblSetComPort.Name = "lblSetComPort";
            this.lblSetComPort.Size = new System.Drawing.Size(167, 29);
            this.lblSetComPort.TabIndex = 5;
            this.lblSetComPort.Text = "Set Baud Rate";
            // 
            // lblSetTimeInterval
            // 
            this.lblSetTimeInterval.AutoSize = true;
            this.lblSetTimeInterval.BackColor = System.Drawing.Color.Transparent;
            this.lblSetTimeInterval.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSetTimeInterval.Location = new System.Drawing.Point(25, 25);
            this.lblSetTimeInterval.Name = "lblSetTimeInterval";
            this.lblSetTimeInterval.Size = new System.Drawing.Size(194, 29);
            this.lblSetTimeInterval.TabIndex = 4;
            this.lblSetTimeInterval.Text = "Set Time Interval";
            // 
            // txtBoxTimeInterval
            // 
            this.txtBoxTimeInterval.Location = new System.Drawing.Point(33, 60);
            this.txtBoxTimeInterval.Name = "txtBoxTimeInterval";
            this.txtBoxTimeInterval.Size = new System.Drawing.Size(100, 35);
            this.txtBoxTimeInterval.TabIndex = 3;
            // 
            // btnSaveConfigInput
            // 
            this.btnSaveConfigInput.BackColor = System.Drawing.Color.Black;
            this.btnSaveConfigInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveConfigInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveConfigInput.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveConfigInput.Location = new System.Drawing.Point(20, 328);
            this.btnSaveConfigInput.Name = "btnSaveConfigInput";
            this.btnSaveConfigInput.Size = new System.Drawing.Size(117, 34);
            this.btnSaveConfigInput.TabIndex = 2;
            this.btnSaveConfigInput.Text = "SAVE";
            this.btnSaveConfigInput.UseVisualStyleBackColor = false;
            this.btnSaveConfigInput.Click += new System.EventHandler(this.btnSaveConfigInput_Click);
            // 
            // btnCancelConfigInput
            // 
            this.btnCancelConfigInput.BackColor = System.Drawing.Color.Black;
            this.btnCancelConfigInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelConfigInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelConfigInput.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelConfigInput.Location = new System.Drawing.Point(179, 328);
            this.btnCancelConfigInput.Name = "btnCancelConfigInput";
            this.btnCancelConfigInput.Size = new System.Drawing.Size(117, 35);
            this.btnCancelConfigInput.TabIndex = 1;
            this.btnCancelConfigInput.Text = "CLEAR";
            this.btnCancelConfigInput.UseVisualStyleBackColor = false;
            this.btnCancelConfigInput.Click += new System.EventHandler(this.btnCancelConfigInput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 468);
            this.Controls.Add(this.menuTabControl);
            this.Controls.Add(this.lblTurbidReading);
            this.Controls.Add(this.txtReceivedMsg);
            this.Controls.Add(this.btnRequestMsg);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Turbidity Reading Collector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuTabControl.ResumeLayout(false);
            this.aboutTabPage.ResumeLayout(false);
            this.editTabPage.ResumeLayout(false);
            this.editTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRequestMsg;
        private System.Windows.Forms.TextBox txtReceivedMsg;
        private System.Windows.Forms.Label lblTurbidReading;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl menuTabControl;
        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.TabPage editTabPage;
        private System.Windows.Forms.Button btnCancelConfigInput;
        private System.Windows.Forms.TextBox txtBoxTimeInterval;
        private System.Windows.Forms.Button btnSaveConfigInput;
        private System.Windows.Forms.Label lblSetComPort;
        private System.Windows.Forms.Label lblSetTimeInterval;
        private System.Windows.Forms.TextBox txtBoxComPort;
        private System.Windows.Forms.Label lblSetBaudRate;
        private System.Windows.Forms.ComboBox cmbBoxBaudRate;
        private System.Windows.Forms.RichTextBox richTextBoxAboutInfo;
    }
}

