namespace P_MasterMind_Graphique
{
    partial class Game
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
            this.lblTries = new System.Windows.Forms.Label();
            this.lblresultUserTry = new System.Windows.Forms.Label();
            this.lblPossibleColors = new System.Windows.Forms.Label();
            this.lblColor1 = new System.Windows.Forms.Label();
            this.lblColor2 = new System.Windows.Forms.Label();
            this.lblColor3 = new System.Windows.Forms.Label();
            this.lblColor4 = new System.Windows.Forms.Label();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnPink = new System.Windows.Forms.Button();
            this.btnPurple = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTries
            // 
            this.lblTries.AutoSize = true;
            this.lblTries.BackColor = System.Drawing.Color.Transparent;
            this.lblTries.Location = new System.Drawing.Point(36, 9);
            this.lblTries.Name = "lblTries";
            this.lblTries.Size = new System.Drawing.Size(37, 13);
            this.lblTries.TabIndex = 0;
            this.lblTries.Text = "Essais";
            // 
            // lblresultUserTry
            // 
            this.lblresultUserTry.AutoSize = true;
            this.lblresultUserTry.Location = new System.Drawing.Point(165, 9);
            this.lblresultUserTry.Name = "lblresultUserTry";
            this.lblresultUserTry.Size = new System.Drawing.Size(46, 13);
            this.lblresultUserTry.TabIndex = 0;
            this.lblresultUserTry.Text = "Résultat";
            // 
            // lblPossibleColors
            // 
            this.lblPossibleColors.AutoSize = true;
            this.lblPossibleColors.Location = new System.Drawing.Point(270, 9);
            this.lblPossibleColors.Name = "lblPossibleColors";
            this.lblPossibleColors.Size = new System.Drawing.Size(103, 13);
            this.lblPossibleColors.TabIndex = 0;
            this.lblPossibleColors.Text = "Couleurs disponibles";
            // 
            // lblColor1
            // 
            this.lblColor1.AutoSize = true;
            this.lblColor1.BackColor = System.Drawing.Color.White;
            this.lblColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor1.Location = new System.Drawing.Point(12, 36);
            this.lblColor1.Name = "lblColor1";
            this.lblColor1.Size = new System.Drawing.Size(15, 15);
            this.lblColor1.TabIndex = 1;
            this.lblColor1.Text = "  ";
            // 
            // lblColor2
            // 
            this.lblColor2.AutoSize = true;
            this.lblColor2.BackColor = System.Drawing.Color.White;
            this.lblColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor2.Location = new System.Drawing.Point(33, 36);
            this.lblColor2.Name = "lblColor2";
            this.lblColor2.Size = new System.Drawing.Size(15, 15);
            this.lblColor2.TabIndex = 1;
            this.lblColor2.Text = "  ";
            // 
            // lblColor3
            // 
            this.lblColor3.AutoSize = true;
            this.lblColor3.BackColor = System.Drawing.Color.White;
            this.lblColor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor3.Location = new System.Drawing.Point(54, 36);
            this.lblColor3.Name = "lblColor3";
            this.lblColor3.Size = new System.Drawing.Size(15, 15);
            this.lblColor3.TabIndex = 1;
            this.lblColor3.Text = "  ";
            // 
            // lblColor4
            // 
            this.lblColor4.AutoSize = true;
            this.lblColor4.BackColor = System.Drawing.Color.White;
            this.lblColor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor4.Location = new System.Drawing.Point(75, 36);
            this.lblColor4.Name = "lblColor4";
            this.lblColor4.Size = new System.Drawing.Size(15, 15);
            this.lblColor4.TabIndex = 1;
            this.lblColor4.Text = "  ";
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(260, 31);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(24, 23);
            this.btnRed.TabIndex = 2;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.colors_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Lime;
            this.btnGreen.Location = new System.Drawing.Point(290, 31);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(24, 23);
            this.btnGreen.TabIndex = 2;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.colors_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Location = new System.Drawing.Point(320, 31);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(24, 23);
            this.btnBlue.TabIndex = 2;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.colors_Click);
            // 
            // btnOrange
            // 
            this.btnOrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOrange.Location = new System.Drawing.Point(350, 31);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(24, 23);
            this.btnOrange.TabIndex = 2;
            this.btnOrange.UseVisualStyleBackColor = false;
            this.btnOrange.Click += new System.EventHandler(this.colors_Click);
            // 
            // btnPink
            // 
            this.btnPink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPink.Location = new System.Drawing.Point(333, 65);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(24, 23);
            this.btnPink.TabIndex = 2;
            this.btnPink.UseVisualStyleBackColor = false;
            this.btnPink.Click += new System.EventHandler(this.colors_Click);
            // 
            // btnPurple
            // 
            this.btnPurple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPurple.Location = new System.Drawing.Point(303, 65);
            this.btnPurple.Name = "btnPurple";
            this.btnPurple.Size = new System.Drawing.Size(24, 23);
            this.btnPurple.TabIndex = 2;
            this.btnPurple.UseVisualStyleBackColor = false;
            this.btnPurple.Click += new System.EventHandler(this.colors_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.Location = new System.Drawing.Point(273, 65);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(24, 23);
            this.btnYellow.TabIndex = 2;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.colors_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Effacer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDeleteTry_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Quitter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnExitGame_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 640);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnPurple);
            this.Controls.Add(this.btnPink);
            this.Controls.Add(this.btnOrange);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.lblColor4);
            this.Controls.Add(this.lblColor3);
            this.Controls.Add(this.lblColor2);
            this.Controls.Add(this.lblColor1);
            this.Controls.Add(this.lblPossibleColors);
            this.Controls.Add(this.lblresultUserTry);
            this.Controls.Add(this.lblTries);
            this.Name = "Game";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTries;
        private System.Windows.Forms.Label lblresultUserTry;
        private System.Windows.Forms.Label lblPossibleColors;
        private System.Windows.Forms.Label lblColor1;
        private System.Windows.Forms.Label lblColor2;
        private System.Windows.Forms.Label lblColor3;
        private System.Windows.Forms.Label lblColor4;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnPurple;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}