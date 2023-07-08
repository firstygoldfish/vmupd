namespace vmupd
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.butVMUpdate = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.butHelp = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(12, 65);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(776, 429);
            this.txtOutput.TabIndex = 0;
            // 
            // butVMUpdate
            // 
            this.butVMUpdate.Image = ((System.Drawing.Image)(resources.GetObject("butVMUpdate.Image")));
            this.butVMUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butVMUpdate.Location = new System.Drawing.Point(12, 11);
            this.butVMUpdate.Name = "butVMUpdate";
            this.butVMUpdate.Size = new System.Drawing.Size(150, 48);
            this.butVMUpdate.TabIndex = 1;
            this.butVMUpdate.Text = "Update VM";
            this.butVMUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVMUpdate.UseVisualStyleBackColor = true;
            this.butVMUpdate.Click += new System.EventHandler(this.butVMUpdate_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 25);
            this.lblStatus.Text = "Ready";
            // 
            // butHelp
            // 
            this.butHelp.Image = ((System.Drawing.Image)(resources.GetObject("butHelp.Image")));
            this.butHelp.Location = new System.Drawing.Point(168, 11);
            this.butHelp.Name = "butHelp";
            this.butHelp.Size = new System.Drawing.Size(48, 48);
            this.butHelp.TabIndex = 3;
            this.butHelp.UseVisualStyleBackColor = true;
            this.butHelp.Click += new System.EventHandler(this.butHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.butHelp);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.butVMUpdate);
            this.Controls.Add(this.txtOutput);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "VMUpd - Capita : OASys - Carl Last 2023";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button butVMUpdate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button butHelp;
    }
}

