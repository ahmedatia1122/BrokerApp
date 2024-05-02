using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace NewBrokerApp.Helpers
{
    public class CustomPin : Pin
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string PinLabel { get; set; }
        public string PinIcon { get; set; }
    }
}
