using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NewBrokerApp.Droid;
using NewBrokerApp.Helpers;
using Plugin.CurrentActivity;
using System.Threading.Tasks;
using Xamarin.Forms;
[assembly: Dependency(typeof(LanguageManagers))]
namespace NewBrokerApp.Droid
{
    public partial class LanguageManagers : Java.Lang.Object, ILanguageManager
    {
        public Task ChangeLanguage(AppLanguage lang)
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            if (lang == AppLanguage.Arabic)
            {
                window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Rtl;
            }
            else
            {
                window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Ltr;
            }
            return Task.CompletedTask;
        }
    }
}