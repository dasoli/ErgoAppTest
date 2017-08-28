
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

			// contacts button
			FindViewById<Button>(Resource.Id.menuContactsButton).Click += delegate
			{
				StartActivity(typeof(ContactActivity));
			};

			// orders button
			FindViewById<Button>(Resource.Id.menuOrdersButton).Click += delegate
			{
                StartActivity(typeof(OrderOverviewActivity));
			};
        }
    }
}
