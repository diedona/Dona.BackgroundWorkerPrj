namespace Donah.BackgroundWorkerPrj.WindowsForms
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
            this.btnForceThread2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblThread1Status = new System.Windows.Forms.Label();
            this.lblThread2Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnForceThread2
            // 
            this.btnForceThread2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnForceThread2.Location = new System.Drawing.Point(12, 12);
            this.btnForceThread2.Name = "btnForceThread2";
            this.btnForceThread2.Size = new System.Drawing.Size(115, 44);
            this.btnForceThread2.TabIndex = 0;
            this.btnForceThread2.Text = "Force Thread 2";
            this.btnForceThread2.UseVisualStyleBackColor = true;
            this.btnForceThread2.Click += new System.EventHandler(this.btnForceThread2_Click);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(504, 236);
            this.listBox1.TabIndex = 1;
            // 
            // lblThread1Status
            // 
            this.lblThread1Status.AutoSize = true;
            this.lblThread1Status.Location = new System.Drawing.Point(155, 12);
            this.lblThread1Status.Name = "lblThread1Status";
            this.lblThread1Status.Size = new System.Drawing.Size(86, 13);
            this.lblThread1Status.TabIndex = 2;
            this.lblThread1Status.Text = "Thread 1 Status:";
            // 
            // lblThread2Status
            // 
            this.lblThread2Status.AutoSize = true;
            this.lblThread2Status.Location = new System.Drawing.Point(155, 43);
            this.lblThread2Status.Name = "lblThread2Status";
            this.lblThread2Status.Size = new System.Drawing.Size(86, 13);
            this.lblThread2Status.TabIndex = 3;
            this.lblThread2Status.Text = "Thread 2 Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 339);
            this.Controls.Add(this.lblThread2Status);
            this.Controls.Add(this.lblThread1Status);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnForceThread2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnForceThread2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblThread1Status;
        private System.Windows.Forms.Label lblThread2Status;
    }
}

