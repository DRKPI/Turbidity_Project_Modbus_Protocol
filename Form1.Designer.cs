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
            this.SuspendLayout();
            // 
            // btnRequestMsg
            // 
            this.btnRequestMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestMsg.Location = new System.Drawing.Point(690, 241);
            this.btnRequestMsg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRequestMsg.Name = "btnRequestMsg";
            this.btnRequestMsg.Size = new System.Drawing.Size(164, 71);
            this.btnRequestMsg.TabIndex = 0;
            this.btnRequestMsg.Text = "START";
            this.btnRequestMsg.UseVisualStyleBackColor = true;
            // 
            // txtReceivedMsg
            // 
            this.txtReceivedMsg.Cursor = System.Windows.Forms.Cursors.No;
            this.txtReceivedMsg.Location = new System.Drawing.Point(690, 175);
            this.txtReceivedMsg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtReceivedMsg.Name = "txtReceivedMsg";
            this.txtReceivedMsg.Size = new System.Drawing.Size(164, 35);
            this.txtReceivedMsg.TabIndex = 1;
            // 
            // lblTurbidReading
            // 
            this.lblTurbidReading.AutoSize = true;
            this.lblTurbidReading.Location = new System.Drawing.Point(685, 106);
            this.lblTurbidReading.Name = "lblTurbidReading";
            this.lblTurbidReading.Size = new System.Drawing.Size(210, 29);
            this.lblTurbidReading.TabIndex = 2;
            this.lblTurbidReading.Text = "Turbidity Reading:";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 574);
            this.Controls.Add(this.lblTurbidReading);
            this.Controls.Add(this.txtReceivedMsg);
            this.Controls.Add(this.btnRequestMsg);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Turbidity Reading Collector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRequestMsg;
        private System.Windows.Forms.TextBox txtReceivedMsg;
        private System.Windows.Forms.Label lblTurbidReading;
        private System.Windows.Forms.Timer timer1;
    }
}

