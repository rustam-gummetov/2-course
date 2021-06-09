namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			FullCycle(robot, width, height);
			MoveRight(robot, width);
			MoveDown(robot);
			MoveLeft(robot, width);
		}
		public static void MoveRight(Robot robot, int width)
		{
			for (int i = 0; i < width - 3; i++)
				robot.MoveTo(Direction.Right);
		}
		public static void MoveDown(Robot robot)
		{
			for (int i = 0; i < 2; i++)
				robot.MoveTo(Direction.Down);
		}
		public static void MoveLeft(Robot robot, int width)
		{
			for (int i = 0; i < width - 3; i++)
				robot.MoveTo(Direction.Left);
		}
		public static void FullCycle(Robot robot, int width, int height)
		{
			for (int i = 0; i < (height - 3) / 4; i++)
			{
				MoveRight(robot, width);
				MoveDown(robot);
				MoveLeft(robot, width);
				MoveDown(robot);
			}
		}
	}
}