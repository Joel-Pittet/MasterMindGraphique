using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        //Création du panel pour la zone des couleurs
        Panel pnlColors = new Panel();

        //Création du panel pour la zone d'essais
        Panel pnlResults = new Panel();

        //Création du panel pour la zone d'essais
        Panel pnlTries = new Panel();

        //tableau pour stocker les labels (essais du joueur)
        Label[,] gridLabels = new Label[NB_COLORS, MAX_TRIES];

        //copie le tableau qui stock les labels (essais du joueur) pour faciliter la comparaison (doublons)
        Label[,] copyGridLabels = new Label[NB_COLORS, MAX_TRIES];

        //tableau pour stocker les labels (resultats des essais du joueur)
        Label[,] gridResultLabels = new Label[NB_COLORS, MAX_TRIES];

        //
        Label lblCode = new Label();

        //
        int RandomColor;

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

        

        //pour compter le nombre de couleurs juste au bon endroit
        int GoodColorPlace = 0;

        //crée une form de victoire et de défaite
        Form victoryDefeatForm = new Form();

        //Création du bouton pour quitter sur la form de victoire/Défaite
        Button btnQuit = new Button();

        //Création du bouton retour pour rejouer
        Button btnReplay = new Button();

        //Crée un label pour le message de victoire
        Label victoryDefeatLabel = new Label();

        //pour remplir les cases de résutlat de gauche à droite
        int cptrResult = 0;
       
       /// <summary>
       /// 
       /// </summary>
        public void PlayGame()
        {
            //Place les labels de solution
            int x = 100;
            int y = 500;

            //Random pour le code secret
            Random RandomCode = new Random();

            //création du code secret en utilisant la liste des couleurs
            for (int i = 0; i < NB_COLORS; i++)
            {
                //choisi une couleur aléatoirement dans la liste de couleur
                RandomColor = RandomCode.Next(ColorList.Count);

                //Ajoute les couleurs à la liste du code secret
                secretCode.Add(ColorList[RandomColor]);

                //Ajoute les couleurs dans la copie de la liste du code secret
                copySecretCode.Add(ColorList[RandomColor]);

                //Affichage du code via des labels de couleurs
                lblCode = new Label();



                //Affichage code secret --> solution
                lblCode.Location = new Point(x, y);

                x = x + 40;

                lblCode.BackColor = ColorList[RandomColor];


                //Donne une bordure au label
                lblCode.BorderStyle = BorderStyle.FixedSingle;

                //Change la taille du label
                lblCode.Size = new Size(LBL_SIZE, LBL_SIZE);

                //association du label à la form
                Controls.Add(lblCode);
            }

           



            /***********************************Panel des labels d'essais***************************************/

           

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
                    //Crée un label et une copie pour la comparaison
                    Label colorLabels = new Label();
                    Label copyColorLabels = new Label();

                    //Ajoute le label au tableau
                    gridLabels[j, i] = colorLabels;

                    //ajoute le label dans la copie du tableau
                    copyGridLabels[j, i] = copyColorLabels;

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

            /********************************Affichage des labels de résultats**********************************/

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

                    //donne la couleur de fond bleue au label
                    resultLabels.BackColor = Color.PowderBlue;

                    //Donne une bordure au label
                    resultLabels.BorderStyle = BorderStyle.Fixed3D;

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
                btnColor[i] = new Button();

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
        /// Lance la form en initialisant les panels d'essais et de couleurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Load(object sender, EventArgs e)
        {
            PlayGame();
        }


        /// <summary>
        /// Affiche la couleur choisie dans la case des essais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colors_Click(object sender, EventArgs e)
        {
            //Réinitialise le compte de label de résultat, si il est a 4 donc que la ligne est pleine
            //retourne à 0 pour commencer dans la prochaine ligne à la première case
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
                foreach (Button btn in btnColor)
                {
                    btn.Enabled = false;

                }

                //désactive le bouton "Effacer"
                btnDelete.Enabled = false;

                //désactive le bouton "Quitter"
                btnQuitGame.Enabled = false;
            }
            else
            {
                //récupère les infos du boutons qui a déclanché la méthode
                Button clickedButton = (Button)sender;

                // obtient la couleur du bouton cliqué
                Color selectedColor = clickedButton.BackColor;

                // obtient le label correspondant dans la grille des essais (gridLabels)
                Label selectedLabel = gridLabels[toColorLabel, countRow];

                //obtient le label correspondant dans la grille des essais de la copie(copyGridLabels)
                Label copySelectedLabel = copyGridLabels[toColorLabel, countRow];

                // remplit le label d'essai avec la couleur du bouton
                selectedLabel.BackColor = selectedColor;

                //remplit le label d'essai de la copie avec la couleur du bouton
                copySelectedLabel.BackColor = selectedColor;

                //incrémente le compteur pour la prochaine case d'essai
                toColorLabel++;

            }

        }


        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnQuitGame.Enabled = true;

            //Remet à 0 l'index pour mettre la couleur dans le bon label
            toColorLabel = 0;

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

            //Réinitialise l'index de la case à remplir pour le résultat
            cptrResult = 0;

            //Parcour le tableau et compare les essais du joueur et le code secret
            for(int j = 0; j < NB_COLORS; j++)
            {
                //Compte le nombre de couleur juste au bon endroit, en comparant le code et l'essai de l'utilisateur
                if (gridLabels[j, countRow].BackColor == secretCode[j])
                {

                    //Affiche la couleur blanche dans la case dont le joueur à trouvé la couleur
                    gridResultLabels[cptrResult, countRow].BackColor = Color.White;
                    GoodColorPlace++;
                    cptrResult++;

                    //change la couleur de la copie de la liste
                    copySecretCode[j] = Color.DarkViolet;

                    //change la couleur de la copie de la liste
                    copyGridLabels[j,countRow].BackColor = Color.Turquoise;

                    /*********************************************************Message de Victoire********************************************/

                    //envoie un message de victoire si les 4 couleurs sont trouvées
                    if (GoodColorPlace == NB_COLORS && countRow < MAX_TRIES)
                    {
                        //cache cette form
                        this.Hide();

                        //Change le nom de la form
                        victoryDefeatForm.Name = "frmVictoryDefeat";

                        //Change le texte de la form
                        victoryDefeatForm.Text = "VICTORY !!";

                        //initialise la taille de la form
                        victoryDefeatForm.Size = new Size(700,400);

                        //Change la couleur du fond de la form
                        victoryDefeatForm.BackColor = Color.BurlyWood;

                        //Change le nom du label
                        victoryDefeatLabel.Name = "lblVictoryDefeat";

                        //Défini la taille du label
                        victoryDefeatLabel.Size = new Size(500, 100);

                        //Place le label dans la form
                        victoryDefeatLabel.Location = new Point(110, 100);

                        //Change la police du message et l'attribue a la form
                        victoryDefeatForm.Font = new Font("Stencil", 18, FontStyle.Regular);

                        //Affiche un message de victoire dans le texte du label
                        victoryDefeatLabel.Text = "Bravo !!\nTu as trouvé le code secret !!";

                        //Change la police du bouton Rejouer
                        btnReplay.Font = new Font("Tw Cen MT Condensed", 18, FontStyle.Bold);

                        //Change la couleur de fond du bouton Rejouer
                        btnReplay.BackColor = Color.Lime;

                        //Change le nom du bouton pour rejouer
                        btnReplay.Name = "btnReplay";

                        //Change le texte du bouton
                        btnReplay.Text = "Rejouer";

                        //Change la taille du bouton
                        btnReplay.Size = new Size(138,55);

                        //Place le bouton
                        btnReplay.Location = new Point(110, 250);

                        //Associe le bouton à la form
                        victoryDefeatForm.Controls.Add(btnReplay);                       

                        //Change la police du bouton Rejouer
                        btnQuit.Font = new Font("Tw Cen MT Condensed", 18, FontStyle.Bold);

                        //Change la couleur de fond du bouton Quitter
                        btnQuit.BackColor = Color.Red;

                        //Change le nom du bouton pour quitter
                        btnQuit.Name = "btnQuit";

                        //Change le texte du bouton
                        btnQuit.Text = "Quitter";

                        //Change la taille du bouton
                        btnQuit.Size = new Size(138, 55);

                        //Place le bouton
                        btnQuit.Location = new Point(400, 250);

                        //Associe la méthode pour quitter l'application au nouveau bouton quitter
                        btnQuit.Click += new EventHandler(btnExitGame_Click);

                        //Associe la méthode pour rejouer
                        btnReplay.Click += new EventHandler(btnReplay_Click);

                        //Associe le bouton à la form
                        victoryDefeatForm.Controls.Add(btnQuit);

                        //Associe le label à la form
                        victoryDefeatForm.Controls.Add(victoryDefeatLabel);

                        //Affiche la form
                        victoryDefeatForm.Show();
                    }

                }
            }

            

            //parcours le tableau
            for (int i = 0; i < NB_COLORS; i++)
            {
                for(int j = 0;j < NB_COLORS; j++)
                {
                    //si la couleur existe dans la copie du code
                    if (copyGridLabels[i, countRow].BackColor == copySecretCode[j] && i != j)
                    {
                        //change la couleurs des labels de résultats
                        gridResultLabels[cptrResult, countRow].BackColor = Color.Black;
                        cptrResult++;
                        break;
                    }
                }
            }

            //Ajoute 1 pour passer à la ligne suivante et compter les essais
            countRow++;

            /**************************************************Message de défaite********************************************/

            //Si le joueur à atteint le nombre max d'essai
            if (countRow == MAX_TRIES && GoodColorPlace < NB_COLORS)
            {
                //Affiche un message de défaite
                this.Hide();

                //Affiche la form pour le message de défaite
                victoryDefeatForm.Show();

                //Change le texte de la form
                victoryDefeatForm.Text = "DEFEAT !!";

                //initialise la taille de la form
                victoryDefeatForm.Size = new Size(700, 400);

                //Change la couleur du fond de la form
                victoryDefeatForm.BackColor = Color.BurlyWood;

                //Change le nom du label
                victoryDefeatLabel.Name = "lblVictoryDefeat";

                //Défini la taille du label
                victoryDefeatLabel.Size = new Size(500, 100);

                //Place le label dans la form
                victoryDefeatLabel.Location = new Point(110, 100);

                //Change la police du message et l'attribue a la form
                victoryDefeatForm.Font = new Font("Stencil", 18, FontStyle.Regular);

                //Change de le text en message de défaite
                victoryDefeatLabel.Text = "Malheureusement, tu as perdu :( \n" +
                    "Retente ta chance !!";

                //Change la police du bouton Rejouer
                btnReplay.Font = new Font("Tw Cen MT Condensed", 18, FontStyle.Bold);

                //Change la couleur de fond du bouton Rejouer
                btnReplay.BackColor = Color.Lime;

                //Change le nom du bouton pour rejouer
                btnReplay.Name = "btnReplay";

                //Change le texte du bouton
                btnReplay.Text = "Rejouer";

                //Change la taille du bouton
                btnReplay.Size = new Size(138, 55);

                //Place le bouton
                btnReplay.Location = new Point(110, 250);

                //Change la police du bouton Rejouer
                btnQuit.Font = new Font("Tw Cen MT Condensed", 18, FontStyle.Bold);

                //Change la couleur de fond du bouton Quitter
                btnQuit.BackColor = Color.Red;

                //Change le nom du bouton pour quitter
                btnQuit.Name = "btnQuit";

                //Change le texte du bouton
                btnQuit.Text = "Quitter";

                //Change la taille du bouton
                btnQuit.Size = new Size(138, 55);

                //Place le bouton
                btnQuit.Location = new Point(400, 250);

                //Associe la méthode pour quitter l'application au nouveau bouton quitter
                btnQuit.Click += new EventHandler(btnExitGame_Click);

                //Associe la méthode pour rejouer
                btnReplay.Click += new EventHandler(btnReplay_Click);

                //Associe le bouton à la form
                victoryDefeatForm.Controls.Add(btnReplay);

                //Associe le bouton à la form
                victoryDefeatForm.Controls.Add(btnQuit);

                //Associe le label à la form
                victoryDefeatForm.Controls.Add(victoryDefeatLabel);

                //Affiche la form
                victoryDefeatForm.Show();


            }
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
                gridLabels[i, countRow].BackColor = Color.White;

                //réinitialise la variable qui aide a placer les couleurs à la suite
                toColorLabel = 0;
            }
        }


        private void btnReplay_Click(object sender, EventArgs e)
        {
            //Affiche la form de jeu "PlayGame"
            this.Show();

            //Cache la form avec le message de fin
            victoryDefeatForm.Hide();

            //Vide les panels utilisé dans la partie précédente
            pnlColors.Controls.Clear();
            pnlResults.Controls.Clear();
            pnlTries.Controls.Clear();

            // Pour placement du panel de la zone d'essais
             
            panelTriesAxisX = 12;
            panelTriesAxisY = 36;

            //Pour placement du panel de la zone des couleurs
            panelColorsAxisX = 130;
            panelColorsAxisY = 300;

            //Remet les essais et la ligne actuelle a 0
            countRow = 0;

            //Vide la liste du code secret et sa copie
            secretCode.Clear();
            copySecretCode.Clear();

            //Lance une nouvelle partie
            PlayGame();
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
    }
}