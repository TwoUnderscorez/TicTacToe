using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponent();
            gameStatus = GameStatus.NotInGame;
        }
        private GameStatus _game_status;
        public GameStatus gameStatus
        {
            get
            {
                return _game_status;
            }
            set
            {
                _game_status = value;
                if (value == GameStatus.NotInGame)
                    Text = string.Format("{0} - Wait for the game to start...", TTT);
                else if (value == GameStatus.PCsTurn)
                    Text = string.Format("{0} - PCs turn...", TTT);
                else if (value == GameStatus.PCWon)
                    Text = string.Format("{0} - The computer won!", TTT);
                else if (value == GameStatus.PlayersTurn)
                    Text = string.Format("{0} - It's your turn!", TTT);
                else if (value == GameStatus.PlayerWon)
                    Text = string.Format("{0} - You won!", TTT);
                else if (value == GameStatus.TieGame)
                    Text = string.Format("{0} - Game ended in a tie.", TTT);
            }
        }
        private string TTT = "Tic Tac Toe";

        #region Event Handlers
        private void play_btn_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (play_btn.Text == "Play")
                MessageBox.Show("Re/Start the game.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (play_btn.Text == "Reset")
                MessageBox.Show("Stop current game and start a new one.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hlpevent.Handled = true;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Called when any of the tic tac toe buttons are pressed.
        /// </summary>
        /// <param name="sender">pressed PictureBox</param>
        /// <param name="e">EventArgs</param>
        private void TTTBox_Press(object sender, EventArgs e)
        {
            TTTBox pb = sender as TTTBox;
            if (pb == null)
            { MessageBox.Show("Invalid choice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (gameStatus != GameStatus.PlayersTurn || pb.State != TTTMove.Empty) return;
            if (Properties.Settings.Default.playerO)
            {
                pb.State = TTTMove.O;
                pb.Image = Properties.Resources.O;
            }
            else
            {
                pb.State = TTTMove.X;
                pb.Image = Properties.Resources.X;
            }
            int x = int.Parse(pb.Tag.ToString().Substring(0,1)), y = int.Parse(pb.Tag.ToString().Substring(1,1));
            TTTBoxes[x, y] = pb;
            TurnSwap();
        }

        private void TTTBox_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("This is the board which is devided into 9 boxes. Click on an empty box to make your move once it's your turn.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hlpevent.Handled = true;
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0x0);
        }

        private void exit_btn_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("This button closes the game.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hlpevent.Handled = true;
        }

        private void opt_btn_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("This button opens the game options dialog.\nTo learn more about each option, press the ? button then on any of the options.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private /*async*/ void opt_btn_Click(object sender, EventArgs e)
        {
            Enabled = false;
            EnableControls(false);
            optsUsrCtrl.LoadSettings();
            while (optsUsrCtrl.Top < 1)
            {
                optsUsrCtrl.Top += 4;
                //await Task.Delay(1);
            }
            Enabled = true;
            optsUsrCtrl.EnableControls(true);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            optsUsrCtrl.Location = new Point(
                Width / 2 - optsUsrCtrl.Width / 2, optsUsrCtrl.Top);
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            if (gameStatus == GameStatus.PlayersTurn || gameStatus == GameStatus.PCsTurn || gameStatus == GameStatus.TieGame)
                play_btn.Text = "Reset";
            ResetGame();
        }
        #endregion

        /// <summary>
        /// Clears the board
        /// </summary>
        private void ResetGame()
        {
            foreach (TTTBox box in TTTBoxes)
            {
                box.State = TTTMove.Empty;
                box.Image = Properties.Resources.Empty;
            }
            StartGame();
        }
        /// <summary>
        /// Starts the game.
        /// </summary>
        private void StartGame()
        {
            play_btn.Text = "Reset";
            if (Properties.Settings.Default.playerFirst)
                gameStatus = GameStatus.PlayersTurn;
            else
            {
                gameStatus = GameStatus.PCsTurn;
                PCPlay();
            }
        }
        /// <summary>
        /// Responsible for switching turns.
        /// </summary>
        private void TurnSwap()
        {
            if (CheckBoard())
                return;
            if (gameStatus == GameStatus.PCsTurn)
                gameStatus = GameStatus.PlayersTurn;
            else if (gameStatus == GameStatus.PlayersTurn)
            {
                gameStatus = GameStatus.PCsTurn;
                PCPlay();
            }
        }
        /// <summary>
        /// Checks the board for wins.
        /// </summary>
        /// <returns>bool win_detected</returns>
        private bool CheckBoard()
        {
            TTTMove winner_sign = CheckBoardForWinner(TTTBoxes);
            bool win_detected = winner_sign != TTTMove.Empty;
            if (win_detected)
            {
                if (winner_sign == TTTMove.O && Properties.Settings.Default.playerO
                || winner_sign == TTTMove.X && !Properties.Settings.Default.playerO)
                {
                    gameStatus = GameStatus.PlayerWon;
                }
                else
                {
                    gameStatus = GameStatus.PCWon;
                }
                play_btn.Text = "Play";
                return true;
            }
            if (IsBoardFull(TTTBoxes))
            {
                gameStatus = GameStatus.TieGame;
                return true;
            }

            return false;
        }
        /// <summary>
        /// Is the board full.
        /// </summary>
        /// <param name="gameBoard">Board to check</param>
        /// <returns>True if board is full, otherwise false</returns>
        private bool IsBoardFull(TTTBox[,] gameBoard)
        {
            foreach (TTTBox item in gameBoard)
                if (item.State == TTTMove.Empty)
                    return false;
            return true;
        }
        /// <summary>
        /// Is the game over.
        /// </summary>
        /// <param name="gameBoard">Board to check</param>
        /// <returns>Returns true if either a win has been detected or the board is full, otherwise false.</returns>
        private bool IsGameOver(TTTBox[,] gameBoard)
        {
            if (!IsBoardFull(gameBoard))
                if (CheckBoardForWinner(gameBoard) == TTTMove.Empty)
                    return false;
            return true;
        }
        /// <summary>
        /// Check Board For Winner
        /// </summary>
        /// <param name="gameBoard">Board to check</param>
        /// <returns>If a win has been detected, the winning symbol will be returned, otherwise empty.</returns>
        private TTTMove CheckBoardForWinner(TTTBox[,] gameBoard)
        {
            TTTMove winner_sign = TTTMove.Empty;
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 0].State != TTTMove.Empty && gameBoard[i, 0].State == gameBoard[i, 1].State && gameBoard[i, 1].State == gameBoard[i, 2].State)
                {
                    winner_sign = gameBoard[i, 0].State;
                    break;
                }
                else if (gameBoard[0, i].State != TTTMove.Empty && gameBoard[0, i].State == gameBoard[1, i].State && gameBoard[1, i].State == gameBoard[2, i].State)
                {
                    winner_sign = gameBoard[0, i].State;
                    break;
                }
            }
            if ((gameBoard[0, 2].State != TTTMove.Empty && gameBoard[0, 2].State == gameBoard[1, 1].State && gameBoard[1, 1].State == gameBoard[2, 0].State)
             || (gameBoard[0, 0].State != TTTMove.Empty && gameBoard[0, 0].State == gameBoard[1, 1].State && gameBoard[1, 1].State == gameBoard[2, 2].State))
            {
                winner_sign = gameBoard[1, 1].State;
            }
            return winner_sign;
        }
        /// <summary>
        /// Calculates the score for a line
        /// </summary>
        /// <param name="values">Line to calculate score for.</param>
        /// <param name="TurnForPlayerX">Is it X's turn?</param>
        /// <returns>Score</returns>
        int GetScoreForOneLine(TTTBox[] values, bool TurnForPlayerX, int difficulty)
        {
            //Count how many Xs or Os are in the line.
            int countX = 0, countO = 0;
            foreach (TTTBox v in values)
            {
                if (v.State == TTTMove.X)
                    countX++;
                else if (v.State == TTTMove.O)
                    countO++;
            }
            if (countO == 0) //If my oponent has 0 tiles on the line
                return countX * difficulty; //Then the more I have the better it is
            else if (countX == 0) //If I have no tiles on that line
                return -countO * difficulty; //Then it would be very bad if my oponent had some...
            else if (countX > 0 || countO > 0)
                return countX - countO;
            return 0;
        }
        /// <summary>
        /// Calculates the score for a board by summing all the scores of all the lines using GetScoreForOneLine.
        /// </summary>
        /// <param name="gameBoard">The board to calculate the score for</param>
        /// <param name="playerX">Is it X's turn</param>
        /// <returns></returns>
        private int CalcBoardScore(TTTBox[,] gameBoard, bool playerX)
        {
            int difficulty = Properties.Settings.Default.difficulty;
            int ret = 0;
            int[,] lines = { { 0, 1, 2 }, //List of indecies of 1d version of gameBoard
                             { 3, 4, 5 }, //that would make a valid line (i.e. horizontals 
                             { 6, 7, 8 }, //verticals and diagonals)
                             { 0, 3, 6 },
                             { 1, 4, 7 },
                             { 2, 5, 8 },
                             { 0, 4, 8 },
                             { 2, 4, 6 } };
            TTTBox[] Values = gameBoard.Cast<TTTBox>().Select(c => c).ToArray();
            //Get the score for each line, sum them all and return.
            for (int i = lines.GetLowerBound(0); i <= lines.GetUpperBound(0); i++)
                ret += GetScoreForOneLine(new TTTBox[] { Values[lines[i, 0]], Values[lines[i, 1]], Values[lines[i, 2]] }, playerX, difficulty);
            return ret;
        }
        /// <summary>
        /// Gets all posible moves for a player on a given board.
        /// </summary>
        /// <param name="gameBoard">The board</param>
        /// <param name="TurnForPlayerX">Is the player X?</param>
        /// <returns>List of boards (TTTBox[,])</returns>
        public IEnumerable<TTTBox[,]> GetPossibleMovesForGame(TTTBox[,] gameBoard, bool TurnForPlayerX)
        {
            TTTBox[] tmpValues;
            TTTBox[,] newValues;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j].State == TTTMove.Empty)
                    {
                        tmpValues = HCloner.DeepCopy<TTTBox[]>(gameBoard.Cast<TTTBox>().Select(a => a).ToArray());
                        newValues = new TTTBox[3, 3];
                        for (int a = 0; a < 3; a++)
                            for (int b = 0; b < 3; b++)
                                newValues[a, b] = tmpValues[b + a * 3];
                        tmpValues = null;
                        newValues[i, j].State = TurnForPlayerX ? TTTMove.X : TTTMove.O;
                        yield return newValues;
                    }
                }
        }
        /// <summary>
        /// Run MiniMax with Alpha-Beta pruning asynchronously
        /// </summary>
        /// <param name="gameBoard">Board for MiniMax</param>
        /// <param name="alpha">Alpha for Alpha-Beta pruning</param>
        /// <param name="beta">Beta Alpha-Beta pruning</param>
        /// <param name="depth">Depth for MiniMax</param>
        /// <param name="turnForPlayerX">Player sign for MiniMax</param>
        /// <returns>The board with the PC's move</returns>
        private /*async*/ TTTBox[,] MiniMaxAsync(TTTBox[,] gameBoard, int alpha, int beta, int depth, bool turnForPlayerX)
        {
            TTTBox[,] retGameBoar = null;
            /*await Task.Run(new Action(() =>
            {*/
            int score = MiniMax(gameBoard, alpha, beta, depth, turnForPlayerX, out retGameBoar);
            //}));
            return retGameBoar;
        }
        /// <summary>
        /// Run the MiniMax with Alpha-Beta pruning algorithm
        /// </summary>
        /// <param name="gameBoard">Board for MiniMax</param>
        /// <param name="alpha">Alpha for Alpha-Beta pruning</param>
        /// <param name="beta">Beta Alpha-Beta pruning</param>
        /// <param name="depth">Depth for MiniMax</param>
        /// <param name="turnForPlayerX">Player sign for MiniMax</param>
        /// <returns>The score of the node.</returns>
        private int MiniMax(TTTBox[,] gameBoard, int alpha, int beta, int depth, bool turnForPlayerX, out TTTBox[,] retGameBoard)
        {
            retGameBoard = null;
            int score;
            if (IsGameOver(gameBoard) || depth == 0)
            {
                retGameBoard = gameBoard;
                score = CalcBoardScore(gameBoard, turnForPlayerX);
                return score;
            }
            foreach (TTTBox[,] item in GetPossibleMovesForGame(gameBoard, turnForPlayerX))
            {
                TTTBox[,] dummy;
                score = MiniMax(item, alpha, beta, depth - 1, !turnForPlayerX, out  dummy);
                if (!turnForPlayerX)
                {
                    if (beta > score)
                    {
                        beta = score;
                        retGameBoard = item;
                        if (alpha >= beta)
                            break;
                    }
                }
                else
                {
                    if (alpha < score)
                    {
                        alpha = score;
                        retGameBoard = item;
                        if (alpha >= beta)
                            break;
                    }
                }
            }
            score = turnForPlayerX ? alpha : beta;
            return score;
        }
        /// <summary>
        /// Method for managing PC's turn
        /// </summary>
        private void PCPlay()
        {
            TTTBox[,] newGameBoard;
            Enabled = false;
            newGameBoard /*var worker*/ = MiniMaxAsync(TTTBoxes, int.MinValue + 1, int.MaxValue - 1, Properties.Settings.Default.difficulty, Properties.Settings.Default.playerO);
            /*worker.ContinueWith(t =>
            {*/
                //newGameBoard = t.Result;
                int difficulty = Properties.Settings.Default.difficulty;
                this.root_table.SuspendLayout();
                this.SuspendLayout();
                foreach (TTTBox item in TTTBoxes)
                {
                    root_table.Controls.Remove(item);
                    if (difficulty > 1) item.Dispose();
                }
                TTTBox pb;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        pb = newGameBoard[i, j];
                        pb.Dock = DockStyle.Fill;
                        pb.UpdateImage();
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = string.Format("{0}{1}", i, j);
                        pb.MouseClick += this.TTTBox_Press;
                        pb.HelpRequested += this.TTTBox_HelpRequested;
                        TTTBoxes[i, j] = pb;
                        this.root_table.Controls.Add(pb, i, j);
                    }
                this.root_table.ResumeLayout();
                this.ResumeLayout();
                TTTBoxes = newGameBoard;
                Enabled = true;
                TurnSwap();
                return;
            //}, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}


