using System;
using System.Collections.Generic;
using System.Text;

//This class is a branch of the Button class used to make the button look
// prettier
namespace PomTimeApp.view
{
    internal class themeButton : Button
    {
        bool isPressed = false;

        //this function makes it so the fore color and back
        //color gets inverted whenever the button is disable
        //or when pressed down
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Color backColor = Enabled ? BackColor : ForeColor;
            Color foreColor = Enabled ? ForeColor : BackColor;

            if (isPressed)
            {
                backColor = Enabled ? ForeColor : BackColor;
                foreColor = Enabled ? BackColor : ForeColor;
            }

            pevent.Graphics.Clear(backColor);

            // basically make if there is a specified border
            // size it would redraw the button so it has a border
            if (FlatAppearance.BorderSize > 0)
            {
                using (Pen borderPen = new Pen(FlatAppearance.BorderColor, FlatAppearance.BorderSize))
                {
                    Rectangle borderRect = new Rectangle(1, 1, ClientSize.Width - FlatAppearance.BorderSize, ClientSize.Height - FlatAppearance.BorderSize);
                    pevent.Graphics.DrawRectangle(borderPen, borderRect);
                }
            }

            TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, foreColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // tracking when the mouse is pressed on the button
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            isPressed = true;
            Invalidate();
        }

        // tracking when the mouse is released on the button
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            Invalidate();
        }

        // erasing the default button and redrawing the button
        // when the the code for onPaint/
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }
    }
}
