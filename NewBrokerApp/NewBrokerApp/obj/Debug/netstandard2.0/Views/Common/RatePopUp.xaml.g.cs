//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("NewBrokerApp.Views.Common.RatePopUp.xaml", "Views/Common/RatePopUp.xaml", typeof(global::NewBrokerApp.Views.Common.RatePopUp))]

namespace NewBrokerApp.Views.Common {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\Common\\RatePopUp.xaml")]
    public partial class RatePopUp : global::Rg.Plugins.Popup.Pages.PopupPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::RatingBarControl.RatingBar rtControl;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(RatePopUp));
            rtControl = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::RatingBarControl.RatingBar>(this, "rtControl");
        }
    }
}