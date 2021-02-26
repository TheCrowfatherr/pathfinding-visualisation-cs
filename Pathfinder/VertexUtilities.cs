using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pathfinder {
    // Utility class usder for vertex operations
    static class VertexUtilities {

        // Representing possible movements from a field
        private static readonly int[] DeltaX = { -1, -1, 0, 1, 1, 1, 0, -1 };
        private static readonly int[] DeltaY = { 0, -1, -1, -1, 0, 1, 1, 1 };

        // Returns the list of succesors for a given vertex
        public static LinkedList<Point> GetSuccesors(Point point, Button[,] ButtonMatrix) {
            LinkedList<Point> Res = new LinkedList<Point>();

            int NewX, NewY;

            for (int i = 0; i < 8; i++) {
                NewX = point.X + DeltaX[i];
                NewY = point.Y + DeltaY[i];

                if (0 <= NewX && NewX < ButtonMatrix.GetLength(0) && 0 <= NewY && NewY < ButtonMatrix.GetLength(1) && ButtonMatrix[NewX, NewY].BackColor != Color.Black) {
                    Res.AddLast(new Point(NewX, NewY));
                }
            }

            return Res;
        }

        // Chebyshev heuristic has been used, since diagonal moves are allowed
        public static int Heuristic(Point source, Point destination) {
            return System.Math.Max(System.Math.Abs(source.X - destination.X), System.Math.Abs(source.Y - destination.Y));
        }
    }
}
