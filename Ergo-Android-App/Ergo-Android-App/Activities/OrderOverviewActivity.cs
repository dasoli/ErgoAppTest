
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
using ErgoAndroidApp.Dataservices;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "OrderOverviewActivity")]
    public class OrderOverviewActivity : Activity
    {
        private ListView ordersList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderOverview);

			var database = AppDataStore.Database;
			this.ordersList = FindViewById<ListView>(Resource.Id.orders_list);

			// ordercreate button
			FindViewById<Button>(Resource.Id.ordersCreateButton).Click += delegate
			{
                StartActivity(typeof(OrderAddActivity));
			};

            // if something was selected
			this.ordersList.ItemClick += (sender, e) => {
                ContactCreateDataService.currentSelectedOrder = database.GetOrdersAsync().Result[e.Position];

                StartActivity(typeof(OrderSuperDetailActivity));
			};
        }

        protected override void OnResume() 
        {
            base.OnResume();

			var database = AppDataStore.Database;
            var results = database.GetOrdersAsync().Result;
            int total = 0;

			foreach (OrderModel order in results)
			{
                total += order.Distance;
			}

            FindViewById<TextView>(Resource.Id.distanceTotal).Text = string.Format("Total km: {0}", total.ToString());

			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this,
																	Android.Resource.Layout.SimpleListItem1,
                                                                    database.ConvertOrdersListToStringNames(results));

			
            this.ordersList = FindViewById<ListView>(Resource.Id.orders_list);

            this.ordersList.Adapter = adapter;

		}
    }
}
