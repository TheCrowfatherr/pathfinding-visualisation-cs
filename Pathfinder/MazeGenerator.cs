using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Threading;

public class MazeGenerator {
	private static Random rnd = new Random();
	public MazeGenerator () {}

	public static void RecursiveMazeGeneration(Button [,] ButtonMatrix, Color BackColor, int AnimationTime) {
		Point TopLeft = new Point(1, 1);
		Point BottomRight = new Point(ButtonMatrix.GetLength(0) - 2, ButtonMatrix.GetLength(1) - 2);

		for(int x = 0; x < ButtonMatrix.GetLength(0); x++) {
			ButtonMatrix[x, 0].BackColor = Color.Black;
			ButtonMatrix[x, 0].Refresh();
			ButtonMatrix[x, ButtonMatrix.GetLength(1) - 1].BackColor = Color.Black;
			ButtonMatrix[x, ButtonMatrix.GetLength(1) - 1].Refresh();
			Thread.Sleep(AnimationTime);
		}

		for(int y = 0; y < ButtonMatrix.GetLength(1); y++) {
			ButtonMatrix[0, y].BackColor = Color.Black;
			ButtonMatrix[0, y].Refresh();
			ButtonMatrix[ButtonMatrix.GetLength(0) - 1, y].BackColor = Color.Black;
			ButtonMatrix[ButtonMatrix.GetLength(0) - 1, y].Refresh();
			Thread.Sleep(AnimationTime);
		}

		RecursiveMazeGeneration(ButtonMatrix, BackColor, AnimationTime, TopLeft, BottomRight, new Point(-1, -1), new Point(-1, -1), new Point(-1, -1), new Point(-1 -1));
    }

	private static void RecursiveMazeGeneration(Button [,] ButtonMatrix, Color BackColor, int AnimationTime, Point TopLeft, Point BottomRight, Point VerticalOpening1,
												Point VerticalOpening2, Point HorizontalOpening1, Point HorizontalOpening2) {
		if (BottomRight.X - TopLeft.X <= 2 || BottomRight.Y - TopLeft.Y <= 2 || TopLeft.X < 0 || TopLeft.Y < 0 || BottomRight.X < 0 || BottomRight.Y < 0) return;
		if (TopLeft.X > BottomRight.X || TopLeft.Y > BottomRight.Y) return;

		int VerticalWallY = rnd.Next(TopLeft.Y + 1, BottomRight.Y);

		// Avoid creating a wall that would close an opening that was made previously
		while (VerticalWallY == VerticalOpening1.Y || VerticalWallY == VerticalOpening2.Y) {
			VerticalWallY = rnd.Next(TopLeft.Y + 1, BottomRight.Y);
		}

		int HorizontalWallX = rnd.Next(TopLeft.X + 1, BottomRight.X);

		//Same logic
		while (HorizontalWallX == HorizontalOpening1.X || HorizontalWallX == HorizontalOpening2.X) {
			HorizontalWallX = rnd.Next(TopLeft.X + 1, BottomRight.X);
		}

		Point IntersectionPoint = new Point(HorizontalWallX, VerticalWallY);
		Dictionary<System.Int32, LinkedList<Point>> WallDictionary = new Dictionary<System.Int32, LinkedList<Point>>();

		LinkedList<Point> currentWall = new LinkedList<Point>();

		for(int x = TopLeft.X; x <= HorizontalWallX; x++) {
			currentWall.AddLast(new Point(x, VerticalWallY));
        }

		WallDictionary[0] = currentWall;
		currentWall = new LinkedList<Point>();

		for(int x = HorizontalWallX + 1; x <= BottomRight.X; x++) {
			currentWall.AddLast(new Point(x, VerticalWallY));
        }

		WallDictionary[1] = currentWall;
		currentWall = new LinkedList<Point>();

		for (int y = TopLeft.Y; y <= IntersectionPoint.Y; y++) {
			currentWall.AddLast(new Point(HorizontalWallX, y));
        }

		WallDictionary[2] = currentWall;
		currentWall = new LinkedList<Point>();

		for (int y = IntersectionPoint.Y + 1; y <= BottomRight.Y; y++) {
			currentWall.AddLast(new Point(HorizontalWallX, y));
        }

		WallDictionary[3] = currentWall;

		foreach(var item in WallDictionary) {
			foreach(Point p in item.Value) {
				ButtonMatrix[p.X, p.Y].BackColor = Color.Black;
				ButtonMatrix[p.X, p.Y].Refresh();
				Thread.Sleep(AnimationTime);
			}
        }

		LinkedList<System.Int32> WallIndexes = new LinkedList<System.Int32>();
		for(int i = 0; i < 3; i++) {

			int tmp = rnd.Next(0, 4);

			while(WallIndexes.Contains(tmp)) {
				tmp = rnd.Next(0, 4);
            }

			WallIndexes.AddLast(tmp);
        }

		Dictionary<System.Int32, Point> OpeningsDict = new Dictionary<int, Point>();

		for(int index = 0; index < 4; index++) {
			if(WallIndexes.Contains(index)) {
				currentWall = WallDictionary[index];

				if (currentWall.Count == 0) {
					OpeningsDict[index] = new Point(-1, -1);
					continue;
				}

				Point randomOpening = currentWall.ElementAt(rnd.Next(0, currentWall.Count));

				while (randomOpening.Equals(IntersectionPoint)) {
					randomOpening = currentWall.ElementAt(rnd.Next(0, currentWall.Count));
				}

				ButtonMatrix[randomOpening.X, randomOpening.Y].BackColor = BackColor;
				ButtonMatrix[randomOpening.X, randomOpening.Y].Refresh();
				// Thread.Sleep(AnimationTime);
				OpeningsDict[index] = randomOpening;
			}

			else {
				OpeningsDict[index] = new Point(-1, -1);
			}
		}

		Point TopLeftVerticalOpening1 = TopLeft.Y <= VerticalOpening1.Y && VerticalOpening1.Y <= IntersectionPoint.Y - 1 ? VerticalOpening1 : new Point(-1 - 1);
		Point TopLeftHorizontalOpening1 = TopLeft.X <= HorizontalOpening1.X && HorizontalOpening1.X <= IntersectionPoint.X - 1 ? HorizontalOpening1 : new Point(-1, -1);

		RecursiveMazeGeneration(ButtonMatrix, BackColor, AnimationTime, TopLeft, new Point(IntersectionPoint.X - 1, IntersectionPoint.Y - 1), TopLeftVerticalOpening1,
								OpeningsDict[2], TopLeftHorizontalOpening1, OpeningsDict[0]);

		Point BotLeftVerticalOpening2 = TopLeft.Y <= VerticalOpening2.Y && VerticalOpening2.Y <= IntersectionPoint.Y - 1 ? VerticalOpening2 : new Point(-1, -1);
		Point BotLeftHorizontalOpening1 = HorizontalWallX + 1 <= HorizontalOpening1.X && HorizontalOpening1.X <= BottomRight.X ? HorizontalOpening1 : new Point(-1, -1);

		RecursiveMazeGeneration(ButtonMatrix, BackColor, AnimationTime, new Point(HorizontalWallX + 1, TopLeft.Y), new Point(BottomRight.X, IntersectionPoint.Y - 1),
								OpeningsDict[2], BotLeftVerticalOpening2, BotLeftHorizontalOpening1, OpeningsDict[1]);

		Point BotRightVerticalOpening2 = IntersectionPoint.Y + 1 <= VerticalOpening2.Y && VerticalOpening2.Y <= BottomRight.Y ? VerticalOpening2 : new Point(-1, -1);
		Point BotRightHorizontalOpening2 = IntersectionPoint.X + 1 <= HorizontalOpening2.X && HorizontalOpening2.X <= BottomRight.X ? HorizontalOpening2 : new Point(-1, -1);

		RecursiveMazeGeneration(ButtonMatrix, BackColor, AnimationTime, new Point(IntersectionPoint.X + 1, IntersectionPoint.Y + 1), BottomRight, OpeningsDict[3], 
								BotRightVerticalOpening2, OpeningsDict[1], BotRightHorizontalOpening2);

		Point TopRightVerticalOpening1 = IntersectionPoint.Y + 1 <= VerticalOpening1.Y && VerticalOpening1.Y <= BottomRight.Y ? VerticalOpening1 : new Point(-1, -1);
		Point TopRightHorizontalOpening2 = TopLeft.X <= HorizontalOpening2.X && HorizontalOpening2.X <= IntersectionPoint.X - 1 ? HorizontalOpening2 : new Point(-1, -1);

		RecursiveMazeGeneration(ButtonMatrix, BackColor, AnimationTime, new Point(TopLeft.X, IntersectionPoint.Y + 1), new Point(IntersectionPoint.X - 1, BottomRight.Y), 
								TopRightVerticalOpening1, OpeningsDict[3], OpeningsDict[0], TopRightHorizontalOpening2);
    }
}
