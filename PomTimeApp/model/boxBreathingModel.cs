using PomTimeApp.view;
using System;
using System.Collections.Generic;
using System.Text;
using static PomTimeApp.view.boxBreathingAnimation;

namespace PomTimeApp.model;
public class boxBreathingModel
{
    int pixelMovedPerTick;
    System.Timers.Timer timerKeeper;
    TravelDirection travelDirection;
    PointF currDotCord;
    PointF topLeft;
    PointF topRight;
    PointF bottomRight;
    PointF bottomLeft;
    boxBreathingAnimation animation;
    public boxBreathingModel(boxBreathingAnimation animation)
    {
        this.animation = animation;

        animation.setCurrDotToTopLeft();

        currDotCord = animation.getCurrDot();

        PointF[] corners = animation.getCorners();

        travelDirection = TravelDirection.right;

        topLeft = corners[0];
        topRight = corners[1];
        bottomRight = corners[2];
        bottomLeft = corners[3];

        int distanceOfSide = animation.getSideLength();
        pixelMovedPerTick = distanceOfSide / 120;
        timerKeeper = new System.Timers.Timer(33);
        timerKeeper.Elapsed += advanceDot;
    }

    public enum TravelDirection
    {
        up,
        down,
        right,
        left
    }

    public void startAnimation()
    {
        timerKeeper.Start();
    }



    public void advanceDot(object? sender, EventArgs e)
    {
        if (travelDirection == TravelDirection.right)
        {
            if (currDotCord.X + pixelMovedPerTick >= topRight.X)
            {
                currDotCord.X = topRight.X;
                travelDirection = TravelDirection.down;
            }
            else
            {
                currDotCord.X += pixelMovedPerTick;
            }
        }
        else if (travelDirection == TravelDirection.down)
        {
            if (currDotCord.Y + pixelMovedPerTick >= bottomRight.Y)
            {
                currDotCord.Y = bottomRight.Y;
                travelDirection = TravelDirection.left;
            }
            else
            {
                currDotCord.Y += pixelMovedPerTick;
            }
        }
        else if (travelDirection == TravelDirection.left)
        {
            if (currDotCord.X - pixelMovedPerTick <= bottomLeft.X)
            {
                currDotCord.X = bottomLeft.X;
                travelDirection = TravelDirection.up;
            }
            else
            {
                currDotCord.X -= pixelMovedPerTick;
            }
        }
        else
        {
            if (currDotCord.Y - pixelMovedPerTick <= topRight.Y)
            {
                currDotCord.Y = topRight.Y;
                travelDirection = TravelDirection.right;
            }
            else
            {
                currDotCord.Y -= pixelMovedPerTick;
            }
        }

        if(animation.InvokeRequired)
        {
            animation.Invoke(() => animation.advanceDot(currDotCord));
        } else
        {
            animation.advanceDot(currDotCord);
        }
    }

    
}
