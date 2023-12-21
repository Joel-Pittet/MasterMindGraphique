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
            this.lblBlackCase = new System.Windows.Forms.Label();
            this.lblWhiteCase = new System.Windows.Forms.Label();
            this.lblRappel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTries
            // 
            this.lblTries.AutoSize = true;
            this.lblTries.BackColor = System.Drawing.Color.Transparent;
            this.lblTries.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTries.Location = new System.Drawing.Point(36, 9);
            this.lblTries.Name = "lblTries";
            this.lblTries.Size = new System.Drawing.Size(56, 24);
            this.lblTries.TabIndex = 0;
            this.lblTries.Text = "Essais";
            // 
            // lblresultUserTry
            // 
            this.lblresultUserTry.AutoSize = true;
            this.lblresultUserTry.BackColor = System.Drawing.Color.Transparent;
            this.lblresultUserTry.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblresultUserTry.Location = new System.Drawing.Point(160, 9);
            this.lblresultUserTry.Name = "lblresultUserTry";
            this.lblresultUserTry.Size = new System.Drawing.Size(74, 24);
            this.lblresultUserTry.TabIndex = 0;
            this.lblresultUserTry.Text = "Résultat";
            // 
            // lblPossibleColors
            // 
            this.lblPossibleColors.AutoSize = true;
            this.lblPossibleColors.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPossibleColors.Location = new System.Drawing.Point(35, 297);
            this.lblPossibleColors.Name = "lblPossibleColors";
            this.lblPossibleColors.Size = new System.Drawing.Size(188, 28);
            this.lblPossibleColors.TabIndex = 0;
            this.lblPossibleColors.Text = "Couleurs disponibles";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Silver;
            this.btnDelete.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(273, 223);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 36);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Effacer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(273, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Quitter";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnExitGame_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.SpringGreen;
            this.btnCheck.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(273, 274);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(99, 36);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Valider";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblBlackCase
            // 
            this.lblBlackCase.AutoSize = true;
            this.lblBlackCase.BackColor = System.Drawing.Color.Black;
            this.lblBlackCase.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackCase.ForeColor = System.Drawing.Color.White;
            this.lblBlackCase.Location = new System.Drawing.Point(37, 400);
            this.lblBlackCase.Name = "lblBlackCase";
            this.lblBlackCase.Size = new System.Drawing.Size(280, 17);
            this.lblBlackCase.TabIndex = 4;
            this.lblBlackCase.Text = "Case noire = couleur juste mais mauvais endroit";
            // 
            // lblWhiteCase
            // 
            this.lblWhiteCase.AutoSize = true;
            this.lblWhiteCase.BackColor = System.Drawing.Color.White;
            this.lblWhiteCase.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteCase.ForeColor = System.Drawing.Color.Black;
            this.lblWhiteCase.Location = new System.Drawing.Point(37, 422);
            this.lblWhiteCase.Name = "lblWhiteCase";
            this.lblWhiteCase.Size = new System.Drawing.Size(254, 17);
            this.lblWhiteCase.TabIndex = 4;
            this.lblWhiteCase.Text = "Case blanche = couleur juste et bon endroit";
            // 
            // lblRappel
            // 
            this.lblRappel.AutoSize = true;
            this.lblRappel.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRappel.Location = new System.Drawing.Point(37, 369);
            this.lblRappel.Name = "lblRappel";
            this.lblRappel.Size = new System.Drawing.Size(205, 20);
            this.lblRappel.TabIndex = 4;
            this.lblRappel.Text = "Rappel des couleurs de résultats";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(399, 640);
            this.Controls.Add(this.lblWhiteCase);
            this.Controls.Add(this.lblRappel);
            this.Controls.Add(this.lblBlackCase);
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
        private System.Windows.Forms.Label lblBlackCase;
        private System.Windows.Forms.Label lblWhiteCase;
        private System.Windows.Forms.Label lblRappel;
    }
}