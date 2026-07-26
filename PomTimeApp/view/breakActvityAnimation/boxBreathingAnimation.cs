using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace PomTimeApp.view
{
    public partial class boxBreathingAnimation : UserControl
    {
        int spacingFromEdge;
        int dotSize;
        int squareOutLineSize;

        TravelDirection travelDirection;
        PointF currDotCord;
        PointF topLeft;
        PointF topRight;
        PointF bottomRight;
        PointF bottomLeft;
        PointF[] corners;

        public boxBreathingAnimation()
        {
            InitializeComponent();
            dotSize = 30;
            if (Size.Width < 20)
            {
                spacingFromEdge = 0;
                squareOutLineSize = 1;
            }
            else
            {
                spacingFromEdge = 20;
                squareOutLineSize = 5;
            }
            travelDirection = TravelDirection.right;


            this.topLeft = new PointF(spacingFromEdge, spacingFromEdge);
            this.topRight = new PointF(Size.Height - spacingFromEdge, spacingFromEdge);
            this.bottomLeft = new PointF(spacingFromEdge, Size.Width - spacingFromEdge); ;
            this.bottomRight = new PointF(Size.Height - spacingFromEdge, Size.Width - spacingFromEdge);
            corners = [topLeft, topRight, bottomRight, bottomLeft];
            currDotCord = topLeft;
            this.Paint += DrawRectangleUsingFourCord;
            this.Paint += DrawDot;
        }

        public enum TravelDirection
        {
            up,
            down,
            right,
            left
        }

        private void DrawRectangleUsingFourCord(object? sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, squareOutLineSize))
            {
                e.Graphics.DrawPolygon(pen, corners);
            }

        }

        private void DrawDot(object? sender, PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                e.Graphics.FillEllipse(brush, currDotCord.X - (dotSize / 2), currDotCord.Y - (dotSize / 2), dotSize, dotSize);
            }
        }

        public void advanceDot(int pixels)
        {
            if (travelDirection == TravelDirection.right)
            {
                if (currDotCord.X + pixels >= topRight.X)
                {
                    currDotCord.X = topRight.X;
                    travelDirection = TravelDirection.down;
                }
                else
                {
                    currDotCord.X += pixels;
                }
            }
            else if (travelDirection == TravelDirection.down)
            {
                if (currDotCord.Y + pixels >= bottomRight.Y)
                {
                    currDotCord.Y = bottomRight.Y;
                    travelDirection = TravelDirection.left;
                }
                else
                {
                    currDotCord.Y += pixels;
                }
            }
            else if (travelDirection == TravelDirection.left)
            {
                if (currDotCord.X - pixels <= bottomLeft.X)
                {
                    currDotCord.X = bottomLeft.X;
                    travelDirection = TravelDirection.up;
                }
                else
                {
                    currDotCord.X -= pixels;
                }
            }
            else
            {
                if (currDotCord.Y - pixels <= topRight.Y)
                {
                    currDotCord.Y = topRight.Y;
                    travelDirection = TravelDirection.right;
                }
                else
                {
                    currDotCord.Y -= pixels;
                }
            }
            Refresh();
        }


        private void tester_Click(object sender, EventArgs e)
        {
            advanceDot(100);
        }
    }
}
