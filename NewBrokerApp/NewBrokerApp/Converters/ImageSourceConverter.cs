using NewBrokerApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace NewBrokerApp.Converters
{
    public class ImageSourceConverter : IValueConverter
    {
        static WebClient httpClient = new WebClient();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null ||string.IsNullOrEmpty(value.ToString()))
                return null;

          
            var byteArray = httpClient.DownloadData(value.ToString());
            return ImageSource.FromStream(() => new MemoryStream(byteArray));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
