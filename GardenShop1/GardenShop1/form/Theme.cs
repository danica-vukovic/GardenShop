using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.form
{
    public class Theme
    {
        public string Font { get; set; }
        public Color Light { get; set; }
        public Color Dark { get; set; }
        public Color Medium { get; set; }

        public static Theme pickedTheme = null;

        public static void setTheme(int theme)
        {
            pickedTheme = new Theme();
            if (theme == 1) { 
                pickedTheme.Font = "Cambria";
                pickedTheme.Light = Color.FromArgb(235, 227, 213);
                pickedTheme.Dark =  Color.FromArgb(144, 136, 123);
                pickedTheme.Medium =Color.FromArgb(207, 195, 176);
            }
            else if (theme == 2)
            {
                pickedTheme.Font = "Microsoft JhengHei";
                pickedTheme.Light = Color.FromArgb(230, 217, 223);
                pickedTheme.Medium = Color.FromArgb(207, 181, 192);
                pickedTheme.Dark = Color.FromArgb(169, 123, 143);
            }
            else if(theme == 3)
            {
                pickedTheme.Font = "Arial";
                pickedTheme.Light = Color.FromArgb(211, 228, 205);
                pickedTheme.Dark = Color.FromArgb(113, 131, 113);
                pickedTheme.Medium = Color.FromArgb(173, 194, 169);
            }else if(theme == 4)
            {
                pickedTheme.Font = "Arial";
                pickedTheme.Light = Color.FromArgb(251, 237, 232);
                pickedTheme.Dark = Color.FromArgb(228, 156, 140);
                pickedTheme.Medium = Color.FromArgb(243, 203, 189);
            }
        }
    }
}
