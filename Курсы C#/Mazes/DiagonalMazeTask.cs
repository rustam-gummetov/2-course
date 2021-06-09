namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			while (true)
				if (width > height)
				{
					MoveRight(robot, width, height);
					if (robot.Finished) break;
					MoveDown(robot, width, height);
					if (robot.Finished) break;
				}
				else
				{
					MoveDown(robot, width, height);
					if (robot.Finished) break;
					MoveRight(robot, width, height);
					if (robot.Finished) break;
				}
		}

		public static void MoveRight(Robot robot, int width, int height)
		{
			if (width > height)
				for (int i = 0; i < (width - 2) / (height - 2); i++)
					robot.MoveTo(Direction.Right);
			else
				robot.MoveTo(Direction.Right);
		}

		public static void MoveDown(Robot robot, int width, int height)
		{
			if (height > width)
				for (int i = 0; i < (height - 2) / (width - 2); i++)
					robot.MoveTo(Direction.Down);
			else
				robot.MoveTo(Direction.Down);
		}
	}
}