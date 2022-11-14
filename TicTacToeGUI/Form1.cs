using System.ComponentModel;

namespace TicTacToeGUI
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Alin Iluca");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clickButton(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            CheckWin();

        }

        private void CheckWin()
        {
            
            //horizontal
            bool win = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                win= true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                win = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                win = true;

            //vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                win = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                win = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                win = true;
            //diagonal
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                win = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                win = true;

            if (win)
            {
                disableButtons();
                String winner = "";
                if (turn)
                    winner = "O";
                else 
                    winner = "X";

                MessageBox.Show(winner + "Won!");
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Draw!");
            }
        }
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }

            }
            catch { };
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }

            }
            catch { };
        }
    }
}
