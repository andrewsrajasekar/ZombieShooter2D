namespace ZombieShooter2D
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
            this.ammoText = new System.Windows.Forms.Label();
            this.scoreText = new System.Windows.Forms.Label();
            this.healthText = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.playerCharacter = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.playerCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // ammoText
            // 
            this.ammoText.AutoSize = true;
            this.ammoText.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ammoText.Location = new System.Drawing.Point(12, 13);
            this.ammoText.Name = "ammoText";
            this.ammoText.Size = new System.Drawing.Size(129, 32);
            this.ammoText.TabIndex = 0;
            this.ammoText.Text = "Ammo : 0";
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.Location = new System.Drawing.Point(354, 13);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(109, 32);
            this.scoreText.TabIndex = 1;
            this.scoreText.Text = "Kills : 0";
            // 
            // healthText
            // 
            this.healthText.AutoSize = true;
            this.healthText.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthText.Location = new System.Drawing.Point(625, 13);
            this.healthText.Name = "healthText";
            this.healthText.Size = new System.Drawing.Size(118, 32);
            this.healthText.TabIndex = 2;
            this.healthText.Text = "Health : ";
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(732, 12);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(178, 32);
            this.healthBar.TabIndex = 3;
            this.healthBar.Value = 100;
            // 
            // playerCharacter
            // 
            this.playerCharacter.Image = global::ZombieShooter2D.Properties.Resources.up;
            this.playerCharacter.Location = new System.Drawing.Point(392, 541);
            this.playerCharacter.Name = "playerCharacter";
            this.playerCharacter.Size = new System.Drawing.Size(71, 100);
            this.playerCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerCharacter.TabIndex = 4;
            this.playerCharacter.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(922, 653);
            this.Controls.Add(this.playerCharacter);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.healthText);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.ammoText);
            this.Name = "Form1";
            this.Text = "Zombie Shooter 2D";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.playerCharacter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ammoText;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Label healthText;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox playerCharacter;
        private System.Windows.Forms.Timer gameTimer;
    }
}

