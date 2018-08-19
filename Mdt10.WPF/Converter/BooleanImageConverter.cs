using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Mdt10.WPF.Converter
{

    public class BooleanImageConverter : IValueConverter
    {
        private string imageDirectory = Directory.GetCurrentDirectory() + "\\Icones\\";
        public string ImageDirectory
        {
            get { return imageDirectory; }
            set { imageDirectory = value; }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if((bool)value)
            { 
            string imagePath = Path.Combine(ImageDirectory, "Ok.ico");
            return new BitmapImage(new Uri(imagePath));
            }
            else
            {
                string imagePath = Path.Combine(ImageDirectory, "Error.ico");
                return new BitmapImage(new Uri(imagePath));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("The method or operation is not implemented.");
        }
    }
}



