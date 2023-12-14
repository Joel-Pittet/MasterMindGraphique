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
            this.btnDelete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
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
            this.lblPossibleColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPossibleColors.Location = new System.Drawing.Point(58, 294);
            this.lblPossibleColors.Name = "lblPossibleColors";
            this.lblPossibleColors.Size = new System.Drawing.Size(133, 16);
            this.lblPossibleColors.TabIndex = 0;
            this.lblPossibleColors.Text = "Couleurs disponibles";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(273, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 36);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Effacer";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(273, 274);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(99, 36);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Valider";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 640);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblPossibleColors);
            this.Controls.Add(this.lblresultUserTry);
            this.Controls.Add(this.lblTries);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTries;
        private System.Windows.Forms.Label lblresultUserTry;
        private System.Windows.Forms.Label lblPossibleColors;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCheck;
    }
}