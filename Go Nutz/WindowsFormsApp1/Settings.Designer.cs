namespace WindowsFormsApp1
{
    partial class Settings
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
            this.VolumeUp = new System.Windows.Forms.Button();
            this.ReturnToMenu = new System.Windows.Forms.Button();
            this.VolumeDown = new System.Windows.Forms.Button();
            this.Mute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VolumeUp
            // 
            this.VolumeUp.Location = new System.Drawing.Point(711, 390);
            this.VolumeUp.Name = "VolumeUp";
            this.VolumeUp.Size = new System.Drawing.Size(130, 80);
            this.VolumeUp.TabIndex = 0;
            this.VolumeUp.Text = "Volume up";
            this.VolumeUp.UseVisualStyleBackColor = true;
            // 
            // ReturnToMenu
            // 
            this.ReturnToMenu.Location = new System.Drawing.Point(57, 613);
            this.ReturnToMenu.Name = "ReturnToMenu";
            this.ReturnToMenu.Size = new System.Drawing.Size(130, 80);
            this.ReturnToMenu.TabIndex = 1;
            this.ReturnToMenu.Text = "Return";
            this.ReturnToMenu.UseVisualStyleBackColor = true;
            this.ReturnToMenu.Click += new System.EventHandler(this.ReturnToMenu_Click);
            // 
            // VolumeDown
            // 
            this.VolumeDown.Location = new System.Drawing.Point(711, 476);
            this.VolumeDown.Name = "VolumeDown";
            this.VolumeDown.Size = new System.Drawing.Size(130, 80);
            this.VolumeDown.TabIndex = 2;
            this.VolumeDown.Text = "Volume down";
            this.VolumeDown.UseVisualStyleBackColor = true;
            // 
            // Mute
            // 
            this.Mute.Location = new System.Drawing.Point(711, 613);
            this.Mute.Name = "Mute";
            this.Mute.Size = new System.Drawing.Size(130, 80);
            this.Mute.TabIndex = 3;
            this.Mute.Text = "Mute";
            this.Mute.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 744);
            this.Controls.Add(this.Mute);
            this.Controls.Add(this.VolumeDown);
            this.Controls.Add(this.ReturnToMenu);
            this.Controls.Add(this.VolumeUp);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button VolumeUp;
        private System.Windows.Forms.Button ReturnToMenu;
        private System.Windows.Forms.Button VolumeDown;
        private System.Windows.Forms.Button Mute;
    }
}