using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace COVIDsStat.Droid
{
    [Activity(Label = "COVID Stats", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();
        }

    }
}
