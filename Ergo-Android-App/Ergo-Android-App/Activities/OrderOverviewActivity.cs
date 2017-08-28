
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
    [Activity(Label = "OrderOverviewActivity")]
    public class OrderOverviewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderOverview);

			// ordercreate button
			FindViewById<Button>(Resource.Id.ordersCreateButton).Click += delegate
			{
                StartActivity(typeof(OrderAddActivity));
			};
        }
    }
}
