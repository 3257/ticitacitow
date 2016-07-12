using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private bool turn = true; // true equals X turn, false equals Y turn
        private int turnCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"A little game of 'Morski Shah' by DiDo :)", @"About the game");
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            var b = (Button) sender;
            b.Text = turn ? "X" : "O";

            turn = !turn;
            b.Enabled = false;
            turnCounter++;
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            var weHaveAWinner = false;

            //horizontal checks for winner

            if (((A1.Text == A2.Text) && (A2.Text == A3.Text)) && (!A1.Enabled))
            {
                weHaveAWinner = true;
            }
            else if (((B1.Text == B2.Text) && (B2.Text == B3.Text)) && (!B1.Enabled))
            {
                weHaveAWinner = true;
            }
            else if (((C1.Text == C2.Text) && (C2.Text == C3.Text)) && (!C1.Enabled))
            {
                weHaveAWinner = true;
            }

            //vertical checks for winner
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                weHaveAWinner = true;
            }
            else if (((A2.Text == B2.Text) && (B2.Text == C2.Text)) && (!A2.Enabled))
            {
                weHaveAWinner = true;
            }

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                weHaveAWinner = true;
            }
            //Diagonal checks for winner

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                weHaveAWinner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                weHaveAWinner = true;
            }

            if (weHaveAWinner)
            {
                DisableButtonsAfterGameOver();

                String winner = null;
                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }
                MessageBox.Show(winner + @" Wins!", @"Good Job!");
            }
            else
            {
                if (turnCounter == 9)
                {
                    MessageBox.Show(@"Nobody Wins!", @"Not Good Job!");
                }
            }
        }

        private void DisableButtonsAfterGameOver()
        {
            try
            {
                foreach (var c in Controls)
                {
                    Button b = (Button) c;
                    b.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void nEWGAMEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            turn = true;
            turnCounter = 0;

            try
            {
                foreach (var c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {
            }
        }
    }
}