using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace NewBrokerApp.Helpers
{
    public class BorderlessEntry : Entry
    {
      
            public BorderlessEntry()
            {
                this.HeightRequest = 50;
            this.FontFamily = "Regular";
            this.FontSize = 12;
            //this.Margin = new Thickness(0,3,0,0);
          
            }
        
    }
}
