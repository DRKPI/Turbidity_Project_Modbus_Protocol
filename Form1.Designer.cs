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
            this.editTabPage = new System.Windows.Forms.TabPage();
            this.menuTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRequestMsg
            // 
            this.btnRequestMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequestMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestMsg.Location = new System.Drawing.Point(547, 147);
            this.btnRequestMsg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRequestMsg.Name = "btnRequestMsg";
            this.btnRequestMsg.Size = new System.Drawing.Size(167, 53);
            this.btnRequestMsg.TabIndex = 0;
            this.btnRequestMsg.Text = "START";
            this.btnRequestMsg.UseVisualStyleBackColor = true;
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
            this.menuTabControl.Controls.Add(this.aboutTabPage);
            this.menuTabControl.Controls.Add(this.editTabPage);
            this.menuTabControl.Location = new System.Drawing.Point(12, 12);
            this.menuTabControl.Name = "menuTabControl";
            this.menuTabControl.SelectedIndex = 0;
            this.menuTabControl.Size = new System.Drawing.Size(527, 550);
            this.menuTabControl.TabIndex = 3;
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Location = new System.Drawing.Point(4, 38);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTabPage.Size = new System.Drawing.Size(519, 508);
            this.aboutTabPage.TabIndex = 0;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // editTabPage
            // 
            this.editTabPage.Location = new System.Drawing.Point(4, 38);
            this.editTabPage.Name = "editTabPage";
            this.editTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.editTabPage.Size = new System.Drawing.Size(519, 508);
            this.editTabPage.TabIndex = 1;
            this.editTabPage.Text = "Edit Settings";
            this.editTabPage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 574);
            this.Controls.Add(this.menuTabControl);
            this.Controls.Add(this.lblTurbidReading);
            this.Controls.Add(this.txtReceivedMsg);
            this.Controls.Add(this.btnRequestMsg);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Turbidity Reading Collector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuTabControl.ResumeLayout(false);
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
    }
}

