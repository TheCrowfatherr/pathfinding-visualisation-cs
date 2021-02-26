using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Pathfinder {
    public partial class PathfinderForm : Form {
        // Width of button area window
        private int M;
        //Height of button area window
        private int N;

        // Source and destination vertex, their coordinates in the matrix are saved
        // Initially they are not known, and therefore we set coordinates to invalid values
        // If the box in which we but buttons is of dimensions M * N, then we can calculate the position on the screen for button on [i, j]
        // Namely (i, j) -> (j * l, i * l), where l is the length of the button square.
        private Point SourceVertex = new Point(-1, -1);
        private Point DestinationVertex = new Point(-1, -1);

        // Initial width and height of one button square is set to 20, we will se later what to do
        private int l = 30;
        private Button[,] ButtonMatrix = null;
        private int AnimationTime = 10;

        private int AnimationSpeedComboBoxSelectedIndex = 0;

        // Event handler for each button
        // Better variant is to assign EventHandler to one form, rather than to all of the buttons
        // I will improve that later
        private void Button_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) return;

            int userX = ((Button)sender).Location.Y / l;
            int userY = ((Button)sender).Location.X / l;
            Point userPoint = new Point(userX, userY);

            if (SourceRadioButton.Checked) {
                if (SourceVertex.X != -1) {
                    ButtonMatrix[SourceVertex.X, SourceVertex.Y].BackColor = BackColor;
                }

                SourceVertex.X = ((Button)sender).Location.Y / l;
                SourceVertex.Y = ((Button)sender).Location.X / l;
                ((Button)sender).BackColor = Color.Goldenrod;
            }

            else if (DestinationRadioButton.Checked) {
                if (DestinationVertex.X != -1) {
                    ButtonMatrix[DestinationVertex.X, DestinationVertex.Y].BackColor = BackColor;
                }

                DestinationVertex.X = ((Button)sender).Location.Y / l;
                DestinationVertex.Y = ((Button)sender).Location.X / l;
                ((Button)sender).BackColor = Color.DarkGreen;
            }

            else if (ObstacleRadioButton.Checked) {
                if (userPoint.Equals(SourceVertex)) {
                    SourceVertex = new Point(-1, -1);
                }

                else if (userPoint.Equals(DestinationVertex)) {
                    DestinationVertex = new Point(-1, -1);
                }

                ((Button)sender).BackColor = Color.Black;
            }
        }

        // Button matrix is initialized
        // TODO : Instead of adding independent mouse event handlers for all of the buttons,
        // try adding one global event handler to solve the issue.
        private void InitializeGrid() {

            if (ButtonMatrix != null) {
                for(int i = 0; i < ButtonMatrix.GetLength(0); i++) {
                    for(int j = 0; j < ButtonMatrix.GetLength(1); j++) {
                        ButtonBox.Controls.Remove(ButtonMatrix[i, j]);
                    }
                }
            }

            M = ButtonBox.Width;
            N = ButtonBox.Height;
            ButtonMatrix = new Button[N / l, M / l];
            

            for(int i = 0; i < ButtonMatrix.GetLength(0); i++) {
                for(int j = 0; j < ButtonMatrix.GetLength(1); j++) {
                    ButtonMatrix[i, j] = new Button {
                        Location = new Point(j * l, i * l),
                        Size = new Size(l, l)
                    };

                    ButtonMatrix[i, j].MouseDown += new MouseEventHandler(Button_MouseDown);
                    ButtonMatrix[i, j].MouseEnter += new EventHandler(Button_MouseEnter);
                    ButtonBox.Controls.Add(ButtonMatrix[i, j]);
                    ButtonMatrix[i, j].Refresh();
                }
            }
        }

        // Resets the grid to the original state
        private void ResetGrid(bool clearObstacles = false) {
            for (int i = 0; i < ButtonMatrix.GetLength(0); i++) {
                for (int j = 0; j < ButtonMatrix.GetLength(1); j++) {
                    // By adding this additional if, the process of cleaning the screen becomes faster
                    if (ButtonMatrix[i, j].BackColor == Color.SlateBlue || ButtonMatrix[i, j].BackColor == Color.Crimson || (ButtonMatrix[i, j].BackColor == Color.Black && clearObstacles)) {
                        ButtonMatrix[i, j].BackColor = BackColor;
                        ButtonMatrix[i, j].Refresh();
                    }
                }
            }
        }

        // ctor
        public PathfinderForm() {
            InitializeComponent();
            AnimationSpeedComboBox.SelectedIndex = AnimationSpeedComboBoxSelectedIndex;
            InitializeGrid();
        }

        // PathfinderButton click event handler
        /***
         * TODO : Find more elegant solution for visualising the path other than blocking the main thread.
         */
        private void PathfinderButton_MouseDown(object sender, MouseEventArgs e) {
            if(SourceVertex.X != -1 && SourceVertex.Y != -1 && DestinationVertex.X != -1 && DestinationVertex.Y != -1) {

                ResetGrid();
                ClearAllButton.Enabled = false;
                PathfinderButton.Enabled = false;
                LinkedList<Point> Path = null;
                int Expanded_nodes = 0;

                if (AlgorithmComboBox.Text == "BFS") {
                    Path = BFSPathfinder.Pathfinder(SourceVertex, DestinationVertex, ButtonMatrix, ref Expanded_nodes, AnimationTime);
                }

                else if(AlgorithmComboBox.Text == "DFS") {
                    Path = DFSPathfinder.Pathfinder(SourceVertex, DestinationVertex, ButtonMatrix, ref Expanded_nodes, AnimationTime);
                }

                else if(AlgorithmComboBox.Text == "A*") {
                    Path = AStarPathfinder.Pathfinder(SourceVertex, DestinationVertex, ButtonMatrix, ref Expanded_nodes, AnimationTime);
                }

                else if(AlgorithmComboBox.Text == "Uniform Cost Search") {
                    Path = UniformCostPathfinder.Pathfinder(SourceVertex, DestinationVertex, ButtonMatrix, ref Expanded_nodes, AnimationTime);
                }

                else if(AlgorithmComboBox.Text == "Greedy Search") {
                    Path = GreedyPathfinder.Pathfinder(SourceVertex, DestinationVertex, ButtonMatrix, ref Expanded_nodes, AnimationTime);
                }

                if (Path is null) {
                    ClearAllButton.Enabled = true;
                    PathfinderButton.Enabled = true;
                    return;
                }

                foreach(Point p in Path) {
                    if(p != SourceVertex && p != DestinationVertex) {
                        ButtonMatrix[p.X, p.Y].BackColor = Color.Crimson;
                        ButtonMatrix[p.X, p.Y].Refresh();
                        Thread.Sleep(AnimationTime);
                    }
                }

                String Output = String.Format("Expanded nodes: {0}\nPath length: {1}\n", Expanded_nodes, Path.Count);
                MessageBox.Show(Output, "Search Statistics");
               
                ClearAllButton.Enabled = true;
                PathfinderButton.Enabled = true;
            }
        }

        // ClearAllButton click event handler
        private void ClearAllButton_Click(object sender, EventArgs e) {
            ResetGrid(true);
        }

        private void Button_MouseEnter(object sender, EventArgs e) {

            Color PrevColor = ((Button)(sender)).BackColor;
            if (PrevColor == BackColor) return;

            if (ClearRadioButton.Checked) {
                ((Button)(sender)).BackColor = BackColor;

                if (PrevColor == Color.Goldenrod) {
                    SourceVertex.X = -1;
                    SourceVertex.Y = -1;
                }

                else if (PrevColor == Color.DarkGreen) {
                    DestinationVertex.X = -1;
                    DestinationVertex.Y = -1;
                }
            }
        }

        private void ClearRadioButton_CheckedChanged(object sender, EventArgs e) {
            bool Selected = ((RadioButton)(sender)).Checked;

            if(Selected) {
                ButtonBox.Cursor = Cursors.No;
            }

            else {
                ButtonBox.Cursor = Cursors.Hand;
            }
        }

        private void MazeGeneratorButton_Click(object sender, EventArgs e) {
            ResetGrid(true);

            if (SourceVertex.X != -1) {
                ButtonMatrix[SourceVertex.X, SourceVertex.Y].BackColor = BackColor;
                ButtonMatrix[SourceVertex.X, SourceVertex.Y].Refresh();
                SourceVertex = new Point(-1, -1);
            }

            if(DestinationVertex.X != -1) {
                ButtonMatrix[DestinationVertex.X, DestinationVertex.Y].BackColor = BackColor;
                ButtonMatrix[DestinationVertex.X, DestinationVertex.Y].Refresh();
                DestinationVertex = new Point(-1, -1);
            }

            MazeGenerator.RecursiveMazeGeneration(ButtonMatrix, BackColor, AnimationTime);
        }

        private void AnimationSpeedComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            AnimationTime = Convert.ToInt32(((ComboBox)(sender)).Text);
        }
    }
}
