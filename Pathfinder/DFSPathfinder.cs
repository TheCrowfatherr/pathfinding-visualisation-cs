using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Pathfinder {
    static class DFSPathfinder {

        // Recursive DFS Search. In the case of DFS, frontier is a stack.
        private static bool DFS_Search(Point parrent, Point source, Point destination, Dictionary<Point, Point> Parrent, Button[,] ButtonMatrix, ref int Expanded_nodes, int AnimationTime) {
            /**
             *      parrent - parrent vertex of the source vertex
             *      source - point that is being expanded currently
             *      destination - goal vertex
             *      Parrent - dictionary of parrent vertices
             *      ButtonMatrix - refference to the button grid from the main form
             */

            // If the node to be expanded is not the source node,
            // Visualise its expansion and pause the main program.
            // TODO: Thread.Sleep() is not an elegant way for this. Find another solution
            if (parrent.X != -1) {
                ButtonMatrix[source.X, source.Y].BackColor = Color.SlateBlue;
                ButtonMatrix[source.X, source.Y].Refresh();
                Thread.Sleep(AnimationTime);
            }

            ++Expanded_nodes;

            // Update the parrent pointer of the source vertex
            Parrent[source] = parrent;
            // Get the successors of the source vertex
            LinkedList<Point> Succesors = VertexUtilities.GetSuccesors(source, ButtonMatrix);

            foreach(Point s in Succesors) {
                // Consider each unvisited successor
                if (!Parrent.ContainsKey(s)) {

                    // If the source vertex is adjacent to destination vertex, path has been found.
                    // Update the parrent pointer and return true
                    if(s == destination) {
                        Parrent[s] = source;
                        return true;
                    }

                    // Try expanding the successor vertex recusrivley
                    else if (DFS_Search(source, s, destination, Parrent, ButtonMatrix, ref Expanded_nodes, AnimationTime)) return true;
                }
            }

            // Destination vertex cannot be reached
            return false;
        }


        // Calls the private DFS_Search
        public static LinkedList<Point> Pathfinder(Point source, Point destination, Button[,] ButtonMatrix, ref int Expanded_nodes, int AnimationTime) {
            LinkedList<Point> Res = new LinkedList<Point>();
            Dictionary<Point, Point> ParrentPoint = new Dictionary<Point, Point>();

            bool Reachable = DFS_Search(new Point(-1, -1), source, destination, ParrentPoint, ButtonMatrix, ref Expanded_nodes, AnimationTime);
            if (!Reachable) return Res;

            for(Point p = destination; p.X != -1 && p.Y != -1; p = ParrentPoint[p]) {
                Res.AddFirst(p);
            }

            return Res;
        }
    }
}
