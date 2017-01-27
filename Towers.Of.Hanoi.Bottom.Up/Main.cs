using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Towers.Of.Hanoi.Bottom.Up
{
    public partial class Main : Form
    {
        // For holding the GUI visualization with a limit ..
        public int numberOfSteps = 0;
        public int advanceCounter = 0;
        
        // These were taken with measurments .. 
        public int FirstColFromX = 380, SecondColFromX = 235, ThirdColFromX = 90, MaxColBase = 90, MinColBase = 320, ColMaxHeight = 250, maxPlateWidth = 120, maxPlateHeight = 20;

        // This will hold the states of the board .. each state is a move with a description to that move
        public List<KeyValuePair<int[], string>> States = new List<KeyValuePair<int[], string>>();

        public Main()
        {
            InitializeComponent();
        }

        private void Advance_BTN(object sender, EventArgs e)
        {
            if (NumberOfPlates.Text == "")
            {
                MessageBox.Show("Enter a valid value.");
            }

            else
            {
                // For each time .. 
                Graphics g = MainPanel.CreateGraphics();
                // It's the first time to advance -> draw the N plates then apply the algorithm -> init the states list
                if (advanceCounter == 0)
                {
                    Steps.Items.Add("Game Started with " + NumberOfPlates.Text + " Plates");

                    for (int i = 0; i < Convert.ToInt32(NumberOfPlates.Text); i++)
                    {
                        Board.Columns[0].addPlate();
                    }
                    
                    // This solves the problem and initalizes the states list ..
                    Solve(Convert.ToInt32(NumberOfPlates.Text));

                    g.Clear(Color.White);
                    InitalizePanel();
                }

                else
                {
                    if (advanceCounter <= States.Count)
                    {
                        g.Clear(Color.White);
                        InitalizePanel();
                        Board.updateState(States[advanceCounter - 1].Key);
                        Steps.Items.Add(States[advanceCounter - 1].Value);
                    }

                    else
                    {
                        MessageBox.Show("Game finished with " + States.Count + " steps. \n Memoization Feed: " + Solver.memoizationCounter);
                    }
                }
                reDrawPlates();
                advanceCounter++;
            }
        }

        public void reDrawPlates()
        {
            Graphics PlatesPlotter = MainPanel.CreateGraphics();
            for (int i = 0; i < Board.Columns.Count; i++)
            {
                for (int j = 0; j < Board.Columns[i].Plates.Count; j++)
                {
                    Plate temp = Board.Columns[i].Plates[j];
                    PlatesPlotter.FillRectangle(new SolidBrush(Color.Red), new Rectangle(temp.getXCoord(), temp.getYCoord(), temp.getWidth(), temp.getHeight()));
                }
            }
        }

        public void InitalizePanel()
        {
            Graphics MainGraphicsManipulator = MainPanel.CreateGraphics();

            // This is a border for the columns ..
            MainGraphicsManipulator.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, MainPanel.Height - 2, MainPanel.Width, 2));

            // These are the 3 columns of the board .. 
            MainGraphicsManipulator.FillRectangle(new SolidBrush(Color.Black), new Rectangle(MainPanel.Width - FirstColFromX, MaxColBase, 2, ColMaxHeight));
            MainGraphicsManipulator.FillRectangle(new SolidBrush(Color.Black), new Rectangle(MainPanel.Width - SecondColFromX, MaxColBase, 2, ColMaxHeight));
            MainGraphicsManipulator.FillRectangle(new SolidBrush(Color.Black), new Rectangle(MainPanel.Width - ThirdColFromX, MaxColBase, 2, ColMaxHeight));
        }

        public void setBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Board.Columns.Add(new Column());
            }
            Board.Columns[0].ColBorderFromX = MainPanel.Width - FirstColFromX;
            Board.Columns[1].ColBorderFromX = MainPanel.Width - SecondColFromX;
            Board.Columns[2].ColBorderFromX = MainPanel.Width - ThirdColFromX;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            setBoard();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            InitalizePanel();
        }

        public void Solve(int N)
        {
            // Initializing the memo table .. 
            for (int i = 0; i < N; i++)
            {
                Solver.memo.Add(new List<List<KeyValuePair<int[], string>>>());
                for (int j = 0; j < 6; j++)
                {
                    Solver.memo[i].Add(new List<KeyValuePair<int[], string>>());
                }
            }

            // Solve the problem ..
            Solver.TowersOfHanoiTopDownMemo(N, 1, 3, 2);

            // Fill the states list to draw it .. 
            for (int i = 0; i < Solver.memo[N - 1][0].Count; i++)
            { 
                States.Add(Solver.memo[N-1][0][i]);
            }
        }
    }
}