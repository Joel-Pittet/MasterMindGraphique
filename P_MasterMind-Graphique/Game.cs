using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_MasterMind_Graphique
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        //Liste pour stocker les couleurs disponibles
        List<Color> ColorList = new List<Color>() 
        {Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Yellow, Color.Purple, Color.Pink};

        //Liste pour stocker le code secret
        List<Color> secretCode = new List<Color>();

        //Copie de la liste du code
        List<Color> copySecretCode = new List<Color>();

        //constante pour nombre de couleurs disponibles
        //const int COLORS_IN_GAME = ColorList.Count;

        //Tableau pour gérer les boutons de la zone des couleurs
        Button[] btnColor = new Button[7];

        //maximum de couleurs dans le code secret et dans les essais
        const int NB_COLORS = 4;

        //nombre maximum d'essais
        const int MAX_TRIES = 10;

        //tableau pour stocker les labels (essais du joueur)
        Label[,] gridLabels = new Label[NB_COLORS, MAX_TRIES];

        //tableau pour stocker les labels (resultats des essais du joueur)
        Label[,] gridResultLabels = new Label[NB_COLORS, MAX_TRIES];

        //compteur pour les labels de résultats
        int lblResultCount = 0;

        //Compteur pour les labels d'essais
        int lblCount = 0;

        //Compteur pour le nombre de label par ligne
        int nbLabelX = 0;

        //Pour placement du panel de la zone d'essais
        int panelTriesAxisX = 12;
        int panelTriesAxisY = 36;

        //Taille par défaut des labels
        const int LBL_SIZE = 25;

        //Pour placement du panel de la zone des couleurs
        int panelColorsAxisX = 130;
        int panelColorsAxisY = 300;

        //Taille par défaut des boutons de couleurs
        const int BTN_COLOR_SIZE = 25;

        //Pour placement des boutons des couleurs
        int btnColorAxisX = 0;
        int btnColorAxisY = 0;

        //Pour espacer les boutons de couleurs
        const int SPACE_BETWEEN_BUTTON = 2;

        //pour affichage des couleurs dans les labels d'essais
        int toColorLabel = 0;

        //pour changer de ligne pour les essais
        int countRow = 0;

        //Random pour le code secret
        Random RandomCode = new Random();

        //pour compter le nombre de couleurs juste au bon endroit
        int GoodColorPlace = 0;

        /// <summary>
        /// Lance la form en initialisant les panels d'essais et de couleurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Load(object sender, EventArgs e)
        {

            int x = 100;
            int y = 500;

            //création du code secret en utilisant la liste des couleurs
            for (int i = 0; i < NB_COLORS; i++)
            {

                int RandomColor = RandomCode.Next(ColorList.Count);

                //Ajoute les couleurs à la liste du code secret
                secretCode.Add(ColorList[RandomColor]);

                //Ajoute les couleurs dans la copie de la liste du code secret
                copySecretCode.Add(ColorList[RandomColor]);

                //Affichage du code via des labels de couleurs
                Label lblCode = new Label();




                lblCode.Location = new Point(x, y);

                x = x + 40;

                lblCode.BackColor = ColorList[RandomColor];


                //Donne une bordure au label
                lblCode.BorderStyle = BorderStyle.FixedSingle;

                //Change la taille du label
                lblCode.Size = new Size(LBL_SIZE, LBL_SIZE);

                Controls.Add(lblCode);
            }





            /***********************************Panel des labels d'essais***************************************/

            //Création du panel pour la zone d'essais
            Panel pnlTries = new Panel();

            //Placement du panel dans la Form
            pnlTries.Location = new Point(panelTriesAxisX, panelTriesAxisY);

            //Initialisation de la hauteur du panel
            pnlTries.Height = MAX_TRIES * LBL_SIZE;

            //Initialisation de la largeur du panel
            pnlTries.Width = NB_COLORS * LBL_SIZE;

            //Donne une bordure au panel
            pnlTries.BorderStyle = BorderStyle.FixedSingle;

            //Associe le panel à la form
            Controls.Add(pnlTries);


            /***********************************Panel des labels de résultats***************************************/

            //Création du panel pour la zone d'essais
            Panel pnlResults = new Panel();

            //Placement du panel dans la Form
            pnlResults.Location = new Point(panelTriesAxisX + 130, panelTriesAxisY);

            //Initialisation de la hauteur du panel
            pnlResults.Height = MAX_TRIES * LBL_SIZE;

            //Initialisation de la largeur du panel
            pnlResults.Width = NB_COLORS * LBL_SIZE;

            //Donne une bordure au panel
            pnlResults.BorderStyle = BorderStyle.FixedSingle;

            //Associe le panel à la form
            Controls.Add(pnlResults);


            /***************************************Panel pour zone de couleurs*********************************/

            //Création du panel pour la zone des couleurs
            Panel pnlColors = new Panel();

            //Placement du panel de la zone des couleurs dans la Form
            pnlColors.Location = new Point(panelColorsAxisX - 100, panelColorsAxisY + 30);

            //Initialisation de la hauteur du panel de la zone des couleurs
            pnlColors.Height = BTN_COLOR_SIZE + 3;

            //Initialisation de la largeur du panel de la zone des couleurs
            pnlColors.Width = (ColorList.Count + 1) * BTN_COLOR_SIZE;

            //Associe le panel à la form
            Controls.Add(pnlColors);

            /*********************************Affichage des labels de la zone d'essais***************************/


            //Affiche les labels en colonne
            for (int i = 0; i < MAX_TRIES; i++)
            {

                //change de ligne pour afficher les prochains labels en dessous de la ligne précédente
                panelTriesAxisY = +i * LBL_SIZE;

                //réinitialise l'axe X pour que le bouton soit tout à gauche du panel
                panelTriesAxisX = 0;

                //Affiche les labels en ligne
                for (int j = 0; j < NB_COLORS; j++)
                {
                    //Crée un label
                    Label colorLabels = new Label();

                    //Ajoute le label au tableau
                    gridLabels[j, i] = colorLabels;

                    //donne la couleur de fond blanche au label
                    colorLabels.BackColor = Color.White;

                    //Donne une bordure au label
                    colorLabels.BorderStyle = BorderStyle.FixedSingle;

                    //Ajoute 1 au compteur des labels pour le nom du label
                    lblCount++;

                    //Change le nom du label
                    colorLabels.Name = "lblColor" + lblCount;

                    //Change la taille du label
                    colorLabels.Size = new Size(LBL_SIZE, LBL_SIZE);

                    //Si la ligne est pleine, remet le compteur à zéro pour la ligne suivante
                    if (nbLabelX == NB_COLORS)
                    {
                        //Reinitialise le compteur de case pour compter la ligne suivante
                        nbLabelX = 0;
                    }

                    //Place le premier label de chaque ligne à gauche du panel sinon le place à la suite des autres
                    if (nbLabelX == 0)
                    {
                        //Place les 1er labels sur le côté gauche du panel
                        colorLabels.Location = new Point(panelTriesAxisX, panelTriesAxisY);
                    }
                    else
                    {
                        //Place les autres label sur la ligne les 1 après les autres
                        colorLabels.Location = new Point(panelTriesAxisX += LBL_SIZE, panelTriesAxisY);
                    }

                    //Incrémente le compteur de labels par ligne
                    nbLabelX++;

                    //Association du label au panel
                    pnlTries.Controls.Add(colorLabels);

                }
            }

            /********************************************Affichage des labels de résultats****************************************/

            //Affiche les labels en colonne
            for (int i = 0; i < MAX_TRIES; i++)
            {

                //change de ligne pour afficher les prochains labels en dessous de la ligne précédente
                panelTriesAxisY = +i * LBL_SIZE;

                //réinitialise l'axe X pour que le bouton soit tout à gauche du panel
                panelTriesAxisX = 0;

                //Affiche les labels en ligne
                for (int j = 0; j < NB_COLORS; j++)
                {
                    //Crée un label
                    Label resultLabels = new Label();

                    //Ajoute le label au tableau
                    gridResultLabels[j, i] = resultLabels;

                    //donne la couleur de fond blanche au label
                    resultLabels.BackColor = Color.White;

                    //Donne une bordure au label
                    resultLabels.BorderStyle = BorderStyle.FixedSingle;

                    //Ajoute 1 au compteur des labels pour le nom du label
                    lblResultCount++;

                    //Change le nom du label
                    resultLabels.Name = "lblResult" + lblResultCount;

                    //Change la taille du label
                    resultLabels.Size = new Size(LBL_SIZE, LBL_SIZE);

                    //Si la ligne est pleine, remet le compteur à zéro pour la ligne suivante
                    if (nbLabelX == NB_COLORS)
                    {
                        //Reinitialise le compteur de case pour compter la ligne suivante
                        nbLabelX = 0;
                    }

                    //Place le premier label de chaque ligne à gauche du panel sinon le place à la suite des autres
                    if (nbLabelX == 0)
                    {
                        //Place les 1er labels sur le côté gauche du panel
                        resultLabels.Location = new Point(panelTriesAxisX, panelTriesAxisY);
                    }
                    else
                    {
                        //Place les autres label sur la ligne les 1 après les autres
                        resultLabels.Location = new Point(panelTriesAxisX += LBL_SIZE, panelTriesAxisY);
                    }

                    //Incrémente le compteur de labels par ligne
                    nbLabelX++;

                    //Association du label au panel
                    pnlResults.Controls.Add(resultLabels);

                }
            }

            /******************************************Affichage des boutons de la zone des couleurs*************************************/

            //Affiche chaque couleur disponible dans le jeu sous forme de boutons
            for (int i = 0; i < ColorList.Count; i++)
            {

                //Crée un bouton pour chaque couleur
                btnColor[i]  = new Button();

                //Affiche la couleur dans le boutons
                btnColor[i].BackColor = ColorList[i];

                if (i == 0)
                {
                    //Affiche le bouton tout à gauche dans le panel
                    btnColor[i].Location = new Point(btnColorAxisX, btnColorAxisY);
                }
                else
                {
                    //Affiche le bouton dans le panel
                    btnColor[i].Location = new Point(btnColorAxisX + i * SPACE_BETWEEN_BUTTON + i * BTN_COLOR_SIZE, btnColorAxisY);
                }


                //Change la taille du bouton
                btnColor[i].Size = new Size(BTN_COLOR_SIZE, BTN_COLOR_SIZE + 1);

                //Change le nom de boutons
                btnColor[i].Name = "btn" + ColorList[i];

                //Attribue la méthode au bouton
                btnColor[i].Click += new EventHandler(colors_Click);

                //Associe les boutons au panel des couleurs
                pnlColors.Controls.Add(btnColor[i]);


            }
        }


        /// <summary>
        /// Affiche la couleur choisie dans la case des essais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colors_Click(object sender, EventArgs e)
        {
            if (toColorLabel == NB_COLORS)
            {
                toColorLabel = 0;
            }
            
            
            //recommence à la première case si la ligne est pleine pour pouvoir recommencer une autre ligne
            if (gridLabels[3, countRow].BackColor != Color.White)
            {

                //Message si la ligne d'essaie est remplie
                MessageBox.Show("La ligne est pleine");

                //désactive chaque boutons de couleurs
                foreach (Button btn in btnColor )
                {
                    btn.Enabled = false;
                }

            }
            else
            {
                //récupère les infos du boutons qui a déclanché la méthode
                Button clickedButton = (Button)sender;

                // obtient la couleur du bouton cliqué
                Color selectedColor = clickedButton.BackColor;

                // obtient le label correspondant dans la grille des essais (gridLabels)
                Label selectedLabel = gridLabels[toColorLabel, countRow];

                // remplit le label d'essai avec la couleur du bouton
                selectedLabel.BackColor = selectedColor;
                //incrémente le compteur pour la prochaine case d'essai
                toColorLabel++;

            }
            


        }

        /// <summary>
        /// Quitte l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitGame_Click(object sender, EventArgs e)
        {
            //Quitte l'application
            Application.Exit();
        }


        private void btnCheck_Click(object sender, EventArgs e)
        {

            //ré - active chaque boutons de couleurs
            foreach (Button btn in btnColor)
            {
                btn.Enabled = true;
            }

            //réinitialise la copie du code pour comparer correctement
            for (int i = 0; i < NB_COLORS; i++)
            {
                copySecretCode[i] = secretCode[i];
            }


            //Réinitialise le compteur de bonne couleurs au bon endroit
            GoodColorPlace = 0;

            //Parcour le tableau et compare les essais du joueur et le code secret
            for(int j = 0; j < NB_COLORS; j++)
            {
                //Compte le nombre de couleur juste au bon endroit, en comparant le code et l'essai de l'utilisateur
                if (gridLabels[j, countRow].BackColor == secretCode[j])
                {

                    //Affiche la couleur verte dans la case dont le joueur à trouvé la couleur
                    gridResultLabels[j, countRow].BackColor = Color.Green;
                    GoodColorPlace++;

                    //change la couleur de la copie de la liste
                    copySecretCode[j] = Color.DarkViolet;



                    //envoie un message de victoire si les 4 couleurs sont trouvées
                    if (GoodColorPlace == 4)
                    {
                        //cache cette form
                        this.Hide();

                        //crée une form de victoire
                        Form victoryForm = new Form();

                        //Change le nom de la form
                        victoryForm.Name = "FrmVictory";

                        //initialise la taille de la form
                        victoryForm.Size = new Size(700,400);

                        //Change la couleur du fond de la form
                        victoryForm.BackColor = Color.BurlyWood;

                        //Crée un label pour le message de victoire
                        Label victoryLabel = new Label();

                        //Change le nom du label
                        victoryLabel.Name = "lblVictory";

                        //Défini la taille du label
                        victoryLabel.Size = new Size(500, 100);

                        //Place le label dans la form
                        victoryLabel.Location = new Point(110, 100);

                        //Change la police du message et l'attribue a la form
                        victoryForm.Font = new Font("Stencil", 18, FontStyle.Regular);

                        //Affiche un message de victoire dans le texte du label
                        victoryLabel.Text = "Bravo tu as trouvé le code secret";

                        //Création du bouton retour pour rejouer
                        Button btnReplay = new Button();

                        //Change le nom du bouton pour rejouer
                        btnReplay.Name = "btnReplay";

                        //Change la taille du bouton
                        btnReplay.Size = new Size(138,55);

                        //Place le bouton
                        btnReplay.Location = new Point(110, 250);

                        //Associe le bouton à la form
                        victoryForm.Controls.Add(btnReplay);

                        //Création du bouton pour quitte sur la form de victoire
                        Button btnQuit = new Button();

                        //Change le nom du bouton pour quitter
                        btnQuit.Name = "btnQuit";

                        //Change la taille du bouton
                        btnQuit.Size = new Size(138, 55);

                        //Place le bouton
                        btnQuit.Location = new Point(350, 250);

                        //Associe le bouton à la form
                        victoryForm.Controls.Add(btnQuit);

                        //Associe le label à la form
                        victoryForm.Controls.Add(victoryLabel);

                        //Affiche la form
                        victoryForm.Show();


                    }

                }
            }


            //parcours le tableau
            for (int i = 0; i < NB_COLORS; i++)
            {
                for(int j = 0;j < NB_COLORS; j++)
                {
                    //si la couleur existe dans la copie du code
                    if (gridLabels[i, countRow].BackColor == copySecretCode[j] && i != j && gridResultLabels[i, countRow].BackColor != Color.Green)
                    {
                        //change la couleurs des labels de résultats
                        gridResultLabels[i, countRow].BackColor = Color.Turquoise;
                        break;
                    }
                }
            }

            countRow++;
        }

        /// <summary>
        /// Supprime la ligne d'essai en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //parcours la ligne d'essai
            for (int i = 0; i < NB_COLORS; i++)
            {
                //Remet la couleur blanche pour chaque label de la ligne d'essai actuelle
                gridLabels[i,countRow].BackColor = Color.White;

                //réinitialise la variable qui aide a placer les couleurs à la suite
                toColorLabel = 0;
            }
        }
            
    }
}