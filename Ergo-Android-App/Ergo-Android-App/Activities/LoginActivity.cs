using Android.App;
using Android.Widget;
using Android.OS;
using System;
using ErgoAndroidApp.Activities;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private string defaultUserName;
        private string defaultPassword;

        public LoginActivity()
        {
            this.defaultPassword = "123456";
            this.defaultUserName = "guenther";
        }

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Login);

			FindViewById<Button>(Resource.Id.login_button).Click += delegate
			{
                //if (FindViewById<EditText>(Resource.Id.input_password).Text == this.defaultPassword
                    //&& FindViewById<EditText>(Resource.Id.input_username).Text == this.defaultUserName) {

                    StartActivity(typeof(ContactActivity));
                //}
			};


		}
    }
}

