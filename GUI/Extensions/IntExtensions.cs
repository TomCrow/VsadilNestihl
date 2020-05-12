using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.Extensions
{
    public static class IntExtensions
    {
        public static string ToThousandsSpacedString(this int integer)
        {
            var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";
            return integer.ToString("#,0.00", nfi);
        }
    }
}
