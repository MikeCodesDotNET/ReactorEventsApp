using System;
using UIKit;

namespace ReactorTodayContainer.Helpers
{
    public static class ColorExtensions
    {
        public static UIColor ToUIColor(this string hex)
        {
            int r = 0, g = 0, b = 0, a = 0;

            if (hex.Contains("#"))
                hex = hex.Replace("#", "");

            switch (hex.Length)
            {
                case 2:
                    r = int.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier);
                    g = int.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier);
                    b = int.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier);
                    a = 255;
                    break;
                case 3:
                    r = int.Parse(hex.Substring(0, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                    g = int.Parse(hex.Substring(1, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                    b = int.Parse(hex.Substring(2, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                    a = 255;
                    break;
                case 4:
                    r = int.Parse(hex.Substring(0, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                    g = int.Parse(hex.Substring(1, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                    b = int.Parse(hex.Substring(2, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                    a = int.Parse(hex.Substring(3, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                    break;
                case 6:
                    r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    a = 255;
                    break;
                case 8:
                    r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    a = int.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    break;
            }

            return UIColor.FromRGBA(r, g, b, a);
        }

        public static UIColor Darken(this UIColor color, int steps)
        {
            int modifier = 16 * steps;

            nfloat rF, gF, bF, aF;

            color.GetRGBA(out rF, out gF, out bF, out aF);

            int r, g, b, a;
            r = (int)Math.Ceiling(rF * 255);
            g = (int)Math.Ceiling(gF * 255);
            b = (int)Math.Ceiling(bF * 255);
            a = (int)Math.Ceiling(aF * 255);

            r -= modifier;
            g -= modifier;
            b -= modifier;
            // leave 'a' alone?

            r = r < 0 ? 0 : r;
            g = g < 0 ? 0 : g;
            b = b < 0 ? 0 : b;

            return UIColor.FromRGBA(r, g, b, a);
        }
    }
}
