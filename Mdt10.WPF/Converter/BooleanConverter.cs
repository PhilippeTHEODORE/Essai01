using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Mdt10.WPF.Converter
{

    // Custom class implements the IValueConverter interface.
    public class BooleanConverter : IValueConverter
    {

        #region IValueConverter Members



        // Define the Convert method to change a DateTime object to 
        // a month string.
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo language)
        {
            if ((bool)value)
                return "OK";
            else
                return "KO";
        }

        // ConvertBack is not implemented for a OneWay binding.
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }




}
