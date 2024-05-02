using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Helpers
{
    public interface ILocSettings
    {
        void OpenSettings();

        bool isGpsAvailable();

        //url code https://www.anycodings.com/1questions/2064756/xamarin-forms-how-to-check-if-gps-is-on-or-off-in-xamarin-ios-app
    }
}
