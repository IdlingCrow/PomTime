using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// this is used to store color theme in the future it will scan a text file to get
/// the color
/// </summary>
namespace PomTimeApp.model
{
    public class ThemeModel
    {
        public ThemeModel()
        {

        }

        //Purpose: used to store some default theme
        //and spit out those theme after putting in
        //a number
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
