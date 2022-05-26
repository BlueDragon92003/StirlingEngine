using System;
using System.Collections.Generic;
using System.Text;

namespace StirlingEngine.Framework
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class DirectionExtention
    {
        public static bool IsPerpendicular(this Direction a, Direction b)
        {
            return
                a == Direction.Up    && b == Direction.Down  ||
                a == Direction.Down  && b == Direction.Up    ||
                a == Direction.Left  && b == Direction.Right ||
                a == Direction.Right && b == Direction.Left;
        }
    }
}
