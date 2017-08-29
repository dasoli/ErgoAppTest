
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ErgoAndroidApp.Dataservices;
using ErgoAndroidApp.NetworkServices;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "OrderAddActivity")]
    public class OrderAddActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderDetail);

			// ordercreate button
			FindViewById<Button>(Resource.Id.chooseContactButton).Click += delegate
			{
				StartActivity(typeof(OrderSelectActivity));
			};
			// create button
			FindViewById<Button>(Resource.Id.customerCreateButton).Click += delegate
			{
                
			};
        }

        protected override void OnResume()
        {
            base.OnResume();

            if(ContactCreateDataService.currentSelectedContact != null) 
            {
                FindViewById<Button>(Resource.Id.chooseContactButton).Text = ContactCreateDataService.currentSelectedContact.Name;
                JsonValue googleObject = GoogleNetworkService.TransformAdressToCoordinatesViaGoogle(ContactCreateDataService.currentSelectedContact).Result;
                var location = googleObject["results"][0]["geometry"]["location"];
                FindViewById<TextView>(Resource.Id.distanceFieldText).Text = string.Format("lat:{0} lon:{1}", location["lat"], location["lng"]);
            }
        }
    }
}
