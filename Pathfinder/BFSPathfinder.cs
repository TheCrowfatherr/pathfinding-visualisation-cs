using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Pathfinder {
    static class BFSPathfinder {
        private static LinkedList<Point> BFS_Search(Point source, Point destination, Button[,] ButtonMatrix, ref int Expanded_nodes, int AnimationTime) {
            /**
             * Returns a list which represents a path from source to destination, or an empty list if the path does not exist.
             *      source - starting vertex
             *      destination - goal vertex
             *      ButtonMatrix - refference to the button grid from the main form
             */

            //Resulting list
            LinkedList<Point> Res = new LinkedList<Point>();

            // Frontier, in the case of BFS a queue
            Queue<Point> queue = new Queue<Point>();

            // Dictionary of parrent vertices
            Dictionary<Point, Point> ParrentPoint = new Dictionary<Point, Point>();

            // Set an invalid point as a parrent vertex to the source vertex
            ParrentPoint[source] = new Point(-1, -1);
            // Add the source vertex to the frontier
            queue.Enqueue(source);

            // Point to be expanded
            Point CurrentPoint;
            // Succesors of the point currently being expanded
            LinkedList<Point> Succesors;

            while(queue.Count != 0) {
                CurrentPoint = queue.Dequeue();
    
                // If the node to be expanded is not the source node,
                // Visualise its expansion and pause the main program.
                // TODO: Thread.Sleep() is not an elegant way for this. Find another solution
                // Also, try to not pass ButtonMatrix refference.
                if(CurrentPoint != source) {
                    ButtonMatrix[CurrentPoint.X, CurrentPoint.Y].BackColor = Color.SlateBlue;
                    ButtonMatrix[CurrentPoint.X, CurrentPoint.Y].Refresh();
                    Thread.Sleep(AnimationTime);
                }

                Succesors = VertexUtilities.GetSuccesors(CurrentPoint, ButtonMatrix);
                ++Expanded_nodes;

                foreach (Point s in Succesors) {
                    // Consider unvisited succesor nodes
                    if(!ParrentPoint.ContainsKey(s)) {
                        ParrentPoint[s] = CurrentPoint;

                        // If the destination node is a succesor of the current node, construct the path and return it.
                        if (s == destination) {
                            for (Point p = destination; p.X != -1 && p.Y != -1; p = ParrentPoint[p]) {
                                Res.AddFirst(p);
                            }
                            return Res;
                        }

                        // Else add the successor the the frontier.
                        else {
                            queue.Enqueue(s);
                        }
                    }
                }
            }

            // Search unsuccessfull, return an empty list
            return Res;
        }

        // Calls the private BFS_Search function
        public static LinkedList<Point> Pathfinder(Point source, Point destination, Button [,] ButtonMatrix, ref int Expanded_nodes, int AnimationTime) {
            return BFS_Search(source, destination, ButtonMatrix, ref Expanded_nodes, AnimationTime);
        }
    }
}
