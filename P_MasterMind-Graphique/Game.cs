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
        int countLabel = 1;

        //Liste pour stocker les couleurs disponibles
        List<string> ColorList = new List<string>();

        //Liste pour stocker le code secret
        List<string> secretCode = new List<string>();

        //maximum de couleurs dans le code secret et dans les essais
        const int NB_COLORS = 4;

        //Liste pour récuperer le code secret
        List<string> returnedRandomCode = new List<string>();


        /// <summary>
        /// Crée le code secret
        /// </summary>
        /// <returns></returns>
        List<string> RandomCode()
        {

            //Ajout des couleurs dans la liste
            ColorList.Add("rouge");
            ColorList.Add("vert");
            ColorList.Add("bleu");
            ColorList.Add("orange");
            ColorList.Add("jaune");
            ColorList.Add("violet");
            ColorList.Add("rose");

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
        private void colors_Click(object sender, EventArgs e)
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

        }

        /// <summary>
        /// Efface l'essai en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteTry_Click(object sender, EventArgs e)
        {
            //Remet la couleur de base dans les labels
            lblColor1.BackColor = Color.White;
            lblColor2.BackColor = Color.White;
            lblColor3.BackColor = Color.White;
            lblColor4.BackColor = Color.White;

            //Réinitialise le compteur de couleurs placée à 1
            countLabel = 1;
        }

        /// <summary>
        /// Quitte l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
