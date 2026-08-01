using System;
using System.Collections.Generic;
using System.Text;

namespace PomTimeApp.view
{
    internal class themeButton : Button
    {
        bool isPressed = false;
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

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            isPressed = true;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            Invalidate();
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }
    }
}
