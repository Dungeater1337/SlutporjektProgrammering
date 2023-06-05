namespace SlutporjektProgrammering
{
    public partial class Form2 : Form
    {
        private int playerscore;
        private int cpuscore;
        Random rnd = new Random();
        private string lastWinner;
        private bool isLabelColorWhite = true;

        public Form2()
        {
            InitializeComponent();
            rnd = new Random();
            playerscore = 0;
            cpuscore = 0;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button4.Enabled = true;

            cpuscore += DrawCard();
            lb1cpuScore.Text = "Datorn: " + cpuscore;

            if (cpuscore > 21)
            {
                MessageBox.Show("Datorn har överstigit 21 och har förlorat (Användaren vann)");
                lastWinner = "Användaren";
                EndGame();
            }

            else if (cpuscore == 21)
            {
                MessageBox.Show("Datorn landar Blackjack! (Datorn vann)");
                lastWinner = "Datorn";
                EndGame();
            }

            else if (cpuscore > playerscore)
            {
                MessageBox.Show("Datorn har mer poäng närmare 21 (Datorn vann)");
                lastWinner = "Datorn";
                EndGame();
            }

            else if (playerscore > cpuscore)
            {
                MessageBox.Show("Användaren har mer poäng närmare 21 (Användaren vann)");
                lastWinner = "Användaren";
                EndGame();
            }

            else if (playerscore == cpuscore)
            {
                MessageBox.Show("Dödläge (ingen vann)");
                lastWinner = "Ingen";
                EndGame();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            playerscore += DrawCard();
            cpuscore += DrawCard();

            lb1cpuScore.Text = "Datorn: " + cpuscore;
            lb1playerScore.Text = "Användare: " + playerscore;

            if (playerscore > 21)
            {
                MessageBox.Show("Användaren har överstigit 21 och har förlorat (Datorn Vann)");
                lastWinner = "Datorn";
                EndGame();
            }

            else if (cpuscore > 21)
            {
                MessageBox.Show("Datorn har överstigit 21 och har förlorat (Användaren vann)");
                lastWinner = "Användaren";
                EndGame();
            }

            else if (playerscore == 21)
            {
                MessageBox.Show("Användaren landar Blackjack! (Användaren vann)");
                lastWinner = "Användaren";
                EndGame();
            }

            else if (cpuscore == 21)
            {
                MessageBox.Show("Datorn landar Blackjack! (Datorn vann)");
                lastWinner = "Datorn";
                EndGame();

            }

            else if (playerscore == 21 || cpuscore == 21)
            {
                MessageBox.Show("Båda landar BlackJack! Lika (Ingen vann).");
                lastWinner = "Ingen";
                EndGame();
  
            }
        }         
        private int DrawCard()
        {
            int cardValue = rnd.Next(1, 12);
            return cardValue;
        }

        private void EndGame()
        {
            playerscore = 0;
            cpuscore = 0;
            lb1playerScore.Text = "Användare: ";
            lb1cpuScore.Text = "Dator: ";
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();

            DialogResult result = MessageBox.Show("Vill du fortsätta?", "Välj Alternativ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                f1.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lastWinner == null)
            {
                MessageBox.Show("Okänd Vinnare");
            }

            else
            {
                MessageBox.Show("Senase Vinnaren är: " + lastWinner);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isLabelColorWhite)
            {
                label2.ForeColor = Color.White;
                label1.ForeColor = Color.White;
            }
            else
            {
                label2.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
            }

            isLabelColorWhite = !isLabelColorWhite; 
        }
    }
}
