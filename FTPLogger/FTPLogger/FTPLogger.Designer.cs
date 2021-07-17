
using System.Windows.Forms;

namespace FTPLogger
{
    partial class FTPLogger
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
            this.components = new System.ComponentModel.Container();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.logDisplay = new System.Windows.Forms.RichTextBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.FtpConnect = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.hostBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportLabel = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(501, 55);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(115, 23);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.TextChanged += new System.EventHandler(this.TestBox_TextChanged);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(162, 177);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(0, 15);
            this.outputLabel.TabIndex = 1;
            // 
            // logDisplay
            // 
            this.logDisplay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.logDisplay.Location = new System.Drawing.Point(29, 103);
            this.logDisplay.Name = "logDisplay";
            this.logDisplay.ReadOnly = true;
            this.logDisplay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logDisplay.Size = new System.Drawing.Size(740, 178);
            this.logDisplay.TabIndex = 3;
            this.logDisplay.TabStop = false;
            this.logDisplay.Text = "";
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(419, 293);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(147, 39);
            this.ExportButton.TabIndex = 6;
            this.ExportButton.Text = "Export Log and Exit";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // FtpConnect
            // 
            this.FtpConnect.Location = new System.Drawing.Point(654, 44);
            this.FtpConnect.Name = "FtpConnect";
            this.FtpConnect.Size = new System.Drawing.Size(115, 42);
            this.FtpConnect.TabIndex = 4;
            this.FtpConnect.Text = "Connect to Ftp";
            this.FtpConnect.UseVisualStyleBackColor = true;
            this.FtpConnect.Click += new System.EventHandler(this.FtpConnect_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(432, 58);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(60, 15);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(213, 58);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(63, 15);
            this.usernameLabel.TabIndex = 7;
            this.usernameLabel.Text = "Username:";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(29, 58);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(35, 15);
            this.hostLabel.TabIndex = 8;
            this.hostLabel.Text = "Host:";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(285, 55);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(115, 23);
            this.usernameBox.TabIndex = 2;
            // 
            // hostBox
            // 
            this.hostBox.Location = new System.Drawing.Point(76, 55);
            this.hostBox.Name = "hostBox";
            this.hostBox.Size = new System.Drawing.Size(115, 23);
            this.hostBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(334, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "FTP Logger";
            // 
            // ExportLabel
            // 
            this.ExportLabel.AutoSize = true;
            this.ExportLabel.Location = new System.Drawing.Point(55, 305);
            this.ExportLabel.Name = "ExportLabel";
            this.ExportLabel.Size = new System.Drawing.Size(71, 15);
            this.ExportLabel.TabIndex = 12;
            this.ExportLabel.Text = "Export Path:";
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(132, 302);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(242, 23);
            this.PathBox.TabIndex = 5;
            this.toolTip1.SetToolTip(this.PathBox, "Default path is Desktop");
            // 
            // FTPLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 344);
            this.ControlBox = false;
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.ExportLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.FtpConnect);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.logDisplay);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.passwordBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FTPLogger";
            this.Text = "FTPLogger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.RichTextBox logDisplay;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button FtpConnect;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox hostBox;
        private Label label1;
        private Label ExportLabel;
        private TextBox PathBox;
        private ToolTip toolTip1;
    }
}

