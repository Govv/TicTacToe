using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TICTACTOEEEEE
{
    public partial class Form1 : Form
    {
        bool giro = true; //true = turno di X, false = turno di O
        int conta = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, MouseEventArgs e)
        {
            conta++;
            Button b = (Button)sender;
            if (giro == true)
                b.Text = "X";
            else
                b.Text = "O";
            giro = !giro;
            b.Enabled = false;
            controllo();
        }

        private void controllo()
        {
            bool vincitore = false;

            //controllo orizzontale
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled))
                vincitore = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
                vincitore = true;
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
                vincitore = true;

            //controllo verticale
            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
                vincitore = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
                vincitore = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
                vincitore = true;

            //controllo diagonale
            else if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
                vincitore = true;
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!a3.Enabled))
                vincitore = true;
            
            if (vincitore == true)
            {
                disabilita();
                string chi;
                if (giro == true)
                    chi = "O";
                else
                    chi = "X";
                MessageBox.Show(chi + " ha vinto!!!", "Partita Terminata");
            }
            else
            {
                if (conta==9)
                    MessageBox.Show("Pareggio", "Partita Terminata");
            }

            //if (conta == 9)
              //  MessageBox.Show("Pareggio;L;L", "Partita Terminata");
        }

        //disabilitare bottoni dopo una vittoria
        private void disabilita()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        //menu informazioni
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creato da \nSimone Governatori\nFrancesco Coppola");
        }

        //menu uscita
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //menu nuova partita: abilita bottoni, cancella X e O, azzera contatore, ripristina il giro
        private void nuovaPartitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giro = true;
            conta = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }

        
    }
}
