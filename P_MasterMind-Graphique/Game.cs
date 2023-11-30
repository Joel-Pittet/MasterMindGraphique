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

        //compteur pour placer les couleurs dans le bon label
        //int countLabel = 1;

        //Liste pour stocker les couleurs disponibles
        List<Color> ColorList = new List<Color>() 
        {Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Yellow, Color.Purple, Color.Pink};

        //Liste pour stocker le code secret
        List<Color> secretCode = new List<Color>();

        //maximum de couleurs dans le code secret et dans les essais
        const int NB_COLORS = 4;

        //nombre maximum d'essais
        const int MAX_TRIES = 10;

        //Liste pour récuperer le code secret
        List<string> returnedRandomCode = new List<string>();

        //tableau pour stocker les labels (essais du joueur)
        Label[,] gridLabels = new Label[NB_COLORS, MAX_TRIES];

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
        /// <summary>
        /// Crée le code secret
        /// </summary>
        /// <returns></returns>
        List<Color> RandomCode()
        {
            //Ajout des couleurs dans la liste
            ColorList.Add(Color.Red);
            ColorList.Add(Color.Green);
            ColorList.Add(Color.Blue);
            ColorList.Add(Color.Orange);
            ColorList.Add(Color.Yellow);
            ColorList.Add(Color.Purple);
            ColorList.Add(Color.Pink);

            //création du code secret en utilisant la liste des couleurs
            for (int i = 0; i < NB_COLORS; i++)
            {
                Random RandomCode = new Random();
                int RandomColor = RandomCode.Next(ColorList.Count);

                //Ajoute les couleurs à la liste du code secret
                secretCode.Add(ColorList[RandomColor]);
            }

            return secretCode;
        }

        /// <summary>
        /// Affiche la couleur choisie dans la case des essais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void colors_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            switch (countLabel)
            {
                case 1:
                    lblColor1.BackColor = clickedButton.BackColor;
                    countLabel++;
                    break;
                case 2:
                    lblColor2.BackColor = clickedButton.BackColor;
                    countLabel++;
                    break;
                case 3:
                    lblColor3.BackColor = clickedButton.BackColor;
                    countLabel++;
                    break;
                case 4:
                    lblColor4.BackColor = clickedButton.BackColor;
                    countLabel++;
                    break;
                default:
                    MessageBox.Show("La ligne d'essai est remplie");
                    break;
            }

        }*/

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


            /***************************************Panel pour zone de couleurs*********************************/

            //Création du panel pour la zone des couleurs
            Panel pnlColors = new Panel();

            //Placement du panel de la zone des couleurs dans la Form
            pnlColors.Location = new Point(panelColorsAxisX, panelColorsAxisY);

            //Initialisation de la hauteur du panel de la zone des couleurs
            pnlColors.Height = BTN_COLOR_SIZE + 3;

            //Initialisation de la largeur du panel de la zone des couleurs
            pnlColors.Width = (ColorList.Count + 1) * BTN_COLOR_SIZE;

            //Donne une bordure au panel de la zone des couleurs
            pnlColors.BorderStyle = BorderStyle.FixedSingle;

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

                    //Change la taille du labe¨l
                    colorLabels.Size = new Size(LBL_SIZE, LBL_SIZE);

                    //Change le texte du label
                    //colorLabels.Text = "";

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

            /*********************************Affichage des boutons de la zone des couleurs***************************/

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

                //Associe les boutons au panel des couleurs
                pnlColors.Controls.Add(btnColor);


            }
        }
    }
}
