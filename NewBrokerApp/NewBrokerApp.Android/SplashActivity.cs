
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Airbnb.Lottie;
using System.Threading.Tasks;
using NewBrokerApp.Helpers;
using NewBrokerApp.ViewModels;

namespace NewBrokerApp.Droid {
    [Activity(Theme = "@style/Theme.Splash", //Indicates the theme to use for this activity/          
        MainLauncher = true, //Set it as boot activity
            NoHistory = true)] //Doesn't place it in back stack

    public class SplashActivity : Activity
        , Animator.IAnimatorListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
           
            string action = Intent.Action;
            string strLink = Intent.DataString;
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
            //if (Intent.Extras != null)
            //{
            //    intent.PutExtras(Intent);
            //}

            //if (Android.Content.Intent.ActionView == action && !string.IsNullOrWhiteSpace(strLink))
            //{
            //    intent.SetAction(Intent.ActionView);
            //    intent.SetData(Intent.Data);
            //}

            StartActivity(intent);
        }
        // private LottieAnimationView animationView;
        //protected override void OnCreate(Bundle bundle)
        //{
            
        
        //    base.OnCreate(bundle);
        //    // SetContentView(Resource.Layout.main);
        //    //animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);
        // //   animationView.AddAnimatorListener(this);
        //}

        public void OnAnimationCancel(Animator animation)
        {
        }

        public void OnAnimationEnd(Animator animation)
        {
            string action = Intent.Action;
            string strLink = Intent.DataString;
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
            if (Intent.Extras != null)
            {
                intent.PutExtras(Intent);
            }

            if (Android.Content.Intent.ActionView == action && !string.IsNullOrWhiteSpace(strLink))
            {
                intent.SetAction(Intent.ActionView);
                intent.SetData(Intent.Data);
            }
            StartActivity(intent);
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }
    }
}