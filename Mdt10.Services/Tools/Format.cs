using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Services.Tools
{
    public class Format
    {
        public static Boolean IsDate(String s)
        {
            try
            {
                DateTime dateValue = DateTime.Parse(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static Boolean IsDecimal(String s)
        {
            try
            {
                Decimal number = Decimal.Parse(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static Boolean IsInteger(String s)
        {
            try
            {
                Decimal number = int.Parse(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static int ToInteger(String s)
        {
            try
            {
                return int.Parse(s);
            }
            catch (FormatException)
            {
                return 0;
            }
        }



        public static DateTime? ToDate(String s)
        {
            try
            {
                return DateTime.Parse(s);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public static double ToMonetaire(String s)
        {
            try
            {
                return double.Parse(s);
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public static String ToString(DateTime? dt)
        {
            if (dt == null)
            {
                return "";
            }
            else
            {
                return ((DateTime)dt).ToShortDateString();
            }
        }

        public static String ToString(String s)
        {
            if (s == "")
            {
                return "";
            }
            else
            {
                return ToString(ToDate(s));
            }
        }
    }
}
