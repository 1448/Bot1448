namespace Installer
{
    partial class Installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.userInfo = new System.Windows.Forms.Label();
            this.chkDark = new System.Windows.Forms.CheckBox();
            this.grpOptional = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.grpOptional.SuspendLayout();
            this.SuspendLayout();
            // 
            // userInfo
            // 
            this.userInfo.AutoSize = true;
            this.userInfo.Location = new System.Drawing.Point(12, 9);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(306, 13);
            this.userInfo.TabIndex = 0;
            this.userInfo.Text = "This app will download the latest version of Bot1448 in your PC.";
            // 
            // chkDark
            // 
            this.chkDark.AutoSize = true;
            this.chkDark.Location = new System.Drawing.Point(18, 19);
            this.chkDark.Name = "chkDark";
            this.chkDark.Size = new System.Drawing.Size(101, 17);
            this.chkDark.TabIndex = 3;
            this.chkDark.Text = "Use dark theme";
            this.chkDark.UseVisualStyleBackColor = true;
            // 
            // grpOptional
            // 
            this.grpOptional.Controls.Add(this.chkDark);
            this.grpOptional.Location = new System.Drawing.Point(12, 25);
            this.grpOptional.Name = "grpOptional";
            this.grpOptional.Size = new System.Drawing.Size(352, 43);
            this.grpOptional.TabIndex = 4;
            this.grpOptional.TabStop = false;
            this.grpOptional.Text = "Download settings";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(248, 75);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Download";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(12, 112);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 14);
            this.lblInfo.TabIndex = 6;
            // 
            // Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 137);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpOptional);
            this.Controls.Add(this.userInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Installer";
            this.Text = "Bot1448 Installer";
            this.grpOptional.ResumeLayout(false);
            this.grpOptional.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userInfo;
        private System.Windows.Forms.CheckBox chkDark;
        private System.Windows.Forms.GroupBox grpOptional;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblInfo;
    }
}

