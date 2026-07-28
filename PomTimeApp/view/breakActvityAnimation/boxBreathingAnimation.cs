using PomTimeApp.model;
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

        boxBreathingModel boxModel;

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

            boxModel = new boxBreathingModel(this);
            this.DoubleBuffered = true;
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

        public void advanceDot(PointF dot)
        {
            currDotCord = dot;
            Refresh();
        }

        public PointF getCurrDot()
        {
            return currDotCord;
        }

        public PointF[] getCorners()
        {
            PointF[] sentCorner = (PointF[])corners.Clone();
            return sentCorner;
        }

        public void setCurrDotToTopLeft()
        {
            currDotCord = topLeft;
        }

        public int getSideLength()
        {
            return Convert.ToInt32(topRight.X - topLeft.X);
        }


        private void tester_Click(object sender, EventArgs e)
        {
            boxModel.startAnimation();
        }
    }
}
