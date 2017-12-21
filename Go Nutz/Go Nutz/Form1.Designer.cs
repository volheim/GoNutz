namespace Go_Nutz
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
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.ButtomCooldown = new System.Windows.Forms.Timer(this.components);
            this.GameDurationTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Interval = 25;
            this.GameLoop.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ButtomCooldown
            // 
            this.ButtomCooldown.Enabled = true;
            this.ButtomCooldown.Interval = 200;
            this.ButtomCooldown.Tick += new System.EventHandler(this.ButtomCooldown_Tick);
            // 
            // GameDurationTimer
            // 
            this.GameDurationTimer.Enabled = true;
            this.GameDurationTimer.Interval = 1000;
            this.GameDurationTimer.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 721);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1275, 760);
            this.MinimumSize = new System.Drawing.Size(1275, 760);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.Timer ButtomCooldown;
        private System.Windows.Forms.Timer GameDurationTimer;
    }
}

