using Android.App;
using Android.OS;
using ErgoAndroidApp.Activities;
using ErgoAndroidApp.Dataservices;

namespace ErgoAndroidApp
{
    [Activity(Label = "Ergo-Android-App", MainLauncher = true, Icon = "@mipmap/icon")]

    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(LoginActivity));
        }
    }
}

