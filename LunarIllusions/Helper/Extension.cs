using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarIllusions.Helper
{
    static class Extension
    {
        public static int Left(this Rectangle rect)
        {

            return rect.X;
        }
        public static int Right(this Rectangle rect)
        {

            return rect.X + rect.Width;
        }
        public static int Top(this Rectangle rect)
        {

            return rect.Y;
        }
        public static int Bottom(this Rectangle rect)
        {

            return rect.Y + rect.Height;
        }
        public static int SafeLeft(this Rectangle rect)
        {

            return rect.X - 1;
        }
        public static int SafeRight(this Rectangle rect)
        {

            return rect.X + rect.Width + 1;
        }
        public static int SafeTop(this Rectangle rect)
        {

            return rect.Y - 1;
        }
        public static int SafeBottom(this Rectangle rect)
        {

            return rect.Y + rect.Height + 1;
        }
        public static Vector2 TopLeft(this Rectangle rect)
        {

            return new Vector2(rect.Left, rect.Top);
        }
        public static Vector2 TopRight(this Rectangle rect)
        {

            return new Vector2(rect.Right,rect.Top);
        }
        public static Vector2 BottomLeft(this Rectangle rect)
        {

            return new Vector2(rect.Left, rect.Bottom);
        }
        public static Vector2 BottomRight(this Rectangle rect)
        {

            return new Vector2(rect.Right, rect.Bottom);
        }

    }
}
