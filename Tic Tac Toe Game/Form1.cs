using System;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {

        // Player is X, CPU is O
        public enum Player
        {
            X, O
        }

        //Integers and lists
        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;
        List<Button> buttons;

        //Initialize game
        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }
        //Click button
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Load game
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //CPU turn
        private void CPUmove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTimer.Stop();
            }
        }
        //Player turn and disabling buttons
        private async void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.BackColor = Color.Cyan;
            buttons.Remove(button);
            button.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            CheckGame();
            CPUTimer.Start();
            await Task.Delay(2000);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            if (button1.Text == "O" || button1.Text == "X")
            {
                button1.Enabled = false;
            }
            if (button2.Text == "O" || button2.Text == "X")
            {
                button2.Enabled = false;
            }
            if (button3.Text == "O" || button3.Text == "X")
            {
                button3.Enabled = false;
            }
            if (button4.Text == "O" || button4.Text == "X")
            {
                button4.Enabled = false;
            }
            if (button5.Text == "O" || button5.Text == "X")
            {
                button5.Enabled = false;
            }
            if (button6.Text == "O" || button6.Text == "X")
            {
                button6.Enabled = false;
            }
            if (button7.Text == "O" || button7.Text =="X")
            {
                button7.Enabled = false;
            }
            if (button8.Text == "O" || button8.Text == "X")
            {
                button8.Enabled = false;
            }
            if (button9.Text == "O" || button9.Text == "X")
            {
                button9.Enabled = false;

            }
           
        }
        //Restart game
        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }
        //When 3 squares are the same letter, end game and show a message box indicating the winner
        private void CheckGame()
        {

            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                )
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins");
                playerWinCount++;
                label1.Text = "Player Wins: " + playerWinCount;
                RestartGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU Wins");
                CPUWinCount++;
                label1.Text = "Player Wins: " + playerWinCount;
                RestartGame();
            }

        }
        //Game board and restart button
        private void RestartGame()
        {
            buttons = new List<Button> { button7, button8, button9, button6, button5, button4,
             button3, button2, button1};

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }

        }
    }
}