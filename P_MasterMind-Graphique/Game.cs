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

        //maximum de couleurs dans le code secret et dans les essais
        const int NB_COLORS = 4;

        //nombre maximum d'essais
        const int MAX_TRIES = 10;

        //Liste pour récuperer le code secret
        List<string> returnedRandomCode = new List<string>();

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
        /// Affiche la couleur choisie dans la case des essais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colors_Click(object sender, EventArgs e)
        {
            //recommence à la première case si la ligne est pleine pour pouvoir recommencer une autre ligne
            if (toColorLabel == 4)
            {

                toColorLabel = 0;

            }

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

                x = x +40;

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
                panelTriesAxisY =+ i * LBL_SIZE;

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
                Button btnColor = new Button();

                //Affiche la couleur dans le boutons
                btnColor.BackColor = ColorList[i];

                if(i == 0)
                {
                    //Affiche le bouton tout à gauche dans le panel
                    btnColor.Location = new Point(btnColorAxisX, btnColorAxisY);
                }
                else
                {
                    //Affiche le bouton dans le panel
                    btnColor.Location = new Point(btnColorAxisX + i*SPACE_BETWEEN_BUTTON + i*BTN_COLOR_SIZE, btnColorAxisY);
                }
                

                //Change la taille du bouton
                btnColor.Size = new Size(BTN_COLOR_SIZE, BTN_COLOR_SIZE + 1);

                //Change le nom de boutons
                btnColor.Name = "btn" + ColorList[i];

                //Attribue la méthode au bouton
                btnColor.Click += new EventHandler(colors_Click);

                //Associe les boutons au panel des couleurs
                pnlColors.Controls.Add(btnColor);


            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

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
                        //Affiche une fenêtre avec un message de victoire
                        MessageBox.Show("Bravo tu as trouvé le code secret");
                    }

                }
            }

                       Console.WriteLine($"{secretCode[0].ToString()}, {secretCode[1].ToString()}, {secretCode[2].ToString()}, { secretCode[3].ToString()}");
            //parcours le tableau
            for (int i = 0; i < NB_COLORS; i++)
            {
                for(int j = 0;j < NB_COLORS; j++)
                {
                    //si la couleur existe dans la copie du code
                    if (gridLabels[j, countRow].BackColor == copySecretCode[i] && i != j)
                    {
                        //change la couleurs dans le code secret
                        gridResultLabels[j, countRow].BackColor = Color.Turquoise;

                    }
                }
            }
             //ATTention réinitialisation car la boucle des doublons se fait juste au 1er essai mais pas au reste

            countRow++;
        }
    }
}
