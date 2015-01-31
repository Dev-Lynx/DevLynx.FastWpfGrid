﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Media.Imaging
{
    public struct IntRect
    {
        public int Left, Top, Right, Bottom;

        public int Width
        {
            get { return Right - Left + 1; }
            set { Right = Left + value - 1; }
        }

        public int Height
        {
            get { return Bottom - Top + 1; }
            set { Bottom = Top + value - 1; }
        }

        public IntPoint TopLeft
        {
            get { return new IntPoint(Left, Top); }
            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }

        public IntPoint BottomRight
        {
            get { return new IntPoint(Right, Bottom); }
            set
            {
                Right = value.X;
                Bottom = value.Y;
            }
        }

        public IntSize Size
        {
            get { return new IntSize(Width, Height); }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public IntRect(IntPoint topLeft, IntSize size)
        {
            Left = topLeft.X;
            Top = topLeft.Y;
            Right = topLeft.X + size.Width - 1;
            Bottom = topLeft.Y + size.Height- 1;
        }

        public IntRect(IntPoint topLeft, IntPoint bottomRight)
        {
            Left = topLeft.X;
            Top = topLeft.Y;
            Right = bottomRight.X;
            Bottom = bottomRight.Y;
        }
    }

    public struct IntPoint
    {
        public int X, Y;

        public IntPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public struct IntSize
    {
        public int Width, Height;

        public IntSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    static partial class WriteableBitmapExtensions
    {
        public static void FillRectangle(this WriteableBitmap bmp, IntRect rect, Color color)
        {
            var col = ConvertColor(color);
            bmp.FillRectangle(rect.Left, rect.Top, rect.Right, rect.Bottom, col);
        }

        public static void DrawRectangle(this WriteableBitmap bmp, IntRect rect, Color color)
        {
            var col = ConvertColor(color);
            bmp.DrawRectangle(rect.Left, rect.Top, rect.Right, rect.Bottom, col);
        }
    }
}
