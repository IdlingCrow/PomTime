using System;
using System.Collections.Generic;
using System.Text;

namespace PomTimeApp.model
{
    public class ThemeModel
    {
        public ThemeModel()
        {

        }
        public Color[] selectTheme(int colorTheme)
        {
            if(colorTheme == 1)
            {
                return [Color.FromArgb(167, 199, 231),Color.White];
            } 
            else if(colorTheme == 2)
            {
                return [Color.FromArgb(38, 38, 38), Color.FromArgb(212, 165, 165)];
            }
            else // else if colorTheme == 3
            {
                return [Color.FromArgb(58, 74, 94), Color.FromArgb(224, 172, 148)];
            }
        }
    }
}
