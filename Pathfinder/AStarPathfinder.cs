using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;


namespace Pathfinder {
    static class AStarPathfinder {
        private class Pair {
            private int priority;
            private Point p;

            public int Priority {
                get { return priority; }
            }

            public Point P {
                get { return p; }
            }

            public Pair(int priority, Point p) {
                this.priority = priority;
                this.p = p;
            }
        }

        private class PairComparer : IComparer<Pair> {
            public int Compare(Pair x, Pair y) {
                return x.Priority - y.Priority;
            }
        }

        private static LinkedList<Point> AStar_Search(Point source, Point destination, Button[,] ButtonMatrix, ref int Expanded_nodes, int AnimationTime) {

            LinkedList<Point> Res = new LinkedList<Point>();
            Dictionary<Point, Point> Parrent = new Dictionary<Point, Point>();
            Dictionary<Point, int> G_values = new Dictionary<Point, int>();
            
            C5.IntervalHeap<Pair> PriorityQueue = new C5.IntervalHeap<Pair>(new PairComparer());

            Parrent[source] = new Point(-1, -1);
            G_values[source] = 0;

            Pair CurrentVertex;
            PriorityQueue.Add(new Pair(VertexUtilities.Heuristic(source, destination), source));

            while (PriorityQueue.Count != 0) {
                CurrentVertex = PriorityQueue.DeleteMin();

                if (G_values[CurrentVertex.P] < CurrentVertex.Priority - VertexUtilities.Heuristic(CurrentVertex.P, destination)) continue;

                else if (CurrentVertex.P != source) {
                    ButtonMatrix[CurrentVertex.P.X, CurrentVertex.P.Y].BackColor = Color.SlateBlue;
                    ButtonMatrix[CurrentVertex.P.X, CurrentVertex.P.Y].Refresh();
                    Thread.Sleep(AnimationTime);
                }

                LinkedList<Point> Succesors = VertexUtilities.GetSuccesors(CurrentVertex.P, ButtonMatrix);
                ++Expanded_nodes;

                foreach (Point s in Succesors) {
                    if(s == destination) {
                        Parrent[destination] = CurrentVertex.P;

                        for(Point p = destination; p.X != -1; p = Parrent[p]) {
                            Res.AddFirst(p);
                        }

                        return Res;
                    }

                    else if (!G_values.ContainsKey(s) || G_values[s] > G_values[CurrentVertex.P] + 1) {
                        Parrent[s] = CurrentVertex.P;
                        G_values[s] = G_values[CurrentVertex.P] + 1;
                        PriorityQueue.Add(new Pair(G_values[s] + VertexUtilities.Heuristic(s, destination), s));
                    }
                }
            }

            return Res;
        }

        public static LinkedList<Point> Pathfinder(Point source, Point destination, Button[,] ButtonMatrix, ref int Expanded_nodes, int AnimationTime) {
            return AStar_Search(source, destination, ButtonMatrix, ref Expanded_nodes, AnimationTime);
        }
    }
}
