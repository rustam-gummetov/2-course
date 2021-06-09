using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            if (r1.Left - r2.Right <= 0)
            {
                if (r1.Top - r2.Bottom <= 0 && r2.Top - r1.Bottom <= 0 && r2.Left - r1.Right <= 0)
                    return true;
            }             
            else if (r2.Left - r1.Right <= 0)
            {
                if (r1.Top - r2.Bottom <= 0 && r2.Top - r1.Bottom <= 0 && r1.Left - r2.Right <= 0)
                    return true;
            }             
            else if (r1.Top - r2.Bottom <= 0)
            {
                if (r2.Left - r1.Right <= 0 && r1.Left - r2.Right <= 0 && r2.Top - r1.Bottom <= 0)
                    return true;
            }   
            else if (r2.Top - r1.Bottom <= 0)
            {
                if (r2.Left - r1.Right <= 0 && r1.Left - r2.Right <= 0 && r1.Top - r2.Bottom <= 0)
                    return true;
            }
            return false;
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2))
            {
                int maxTop = Math.Max(r1.Top, r2.Top);
                int minBottom = Math.Min(r1.Bottom, r2.Bottom);
                int maxLeft = Math.Max(r1.Left, r2.Left);
                int minRight = Math.Min(r1.Right, r2.Right);
                int width = Math.Abs(maxLeft - minRight);
                int height = Math.Abs(maxTop - minBottom);
                return width * height;
            }
            return 0;
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            int betweenLeftR1 = r1.Left - r2.Left;
            int betweenRightR1 = r2.Right - r1.Right;
            int betweenBottomR1 = r2.Bottom - r1.Bottom;
            int betweenTopR1 = r1.Top - r2.Top;
            int betweenLeftR2 = r2.Left - r1.Left;
            int betweenRightR2 = r1.Right - r2.Right;
            int betweenBottomR2 = r1.Bottom - r2.Bottom;
            int betweenTopR2 = r2.Top - r1.Top;
            if (betweenLeftR1 >= 0 && betweenRightR1 >= 0 && betweenBottomR1 >= 0 && betweenTopR1 >= 0)
                return 0;
            if (betweenLeftR2 >= 0 && betweenRightR2 >= 0 && betweenBottomR2 >= 0 && betweenTopR2 >= 0)
                return 1;
            return -1;
        }
    }
}