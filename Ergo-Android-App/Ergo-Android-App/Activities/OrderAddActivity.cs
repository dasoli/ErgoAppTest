
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
			FindViewById<Button>(Resource.Id.orderCreateButton).Click += delegate
			{
                if(ContactCreateDataService.currentSelectedContact != null) 
                {
					OrderModel order;
                    string orderName = string.Format("Auftrag: {0}", ContactCreateDataService.currentSelectedContact.Name);

					if (FindViewById<TextView>(Resource.Id.distanceFieldText).Text != ""
					   && FindViewById<TextView>(Resource.Id.distanceFieldText).Text != null)
					{
						string distance = FindViewById<TextView>(Resource.Id.distanceFieldText).Text;
						int numberDistance = int.Parse(distance.Split(' ')[0]);

						order = OrderModel.Create(orderName, 
                                                  ContactCreateDataService.currentSelectedContact.ID,
                                                  numberDistance,
                                                  FindViewById<TextView>(Resource.Id.editText1).Text);
					}
					else
					{
						order = OrderModel.Create(orderName,
                                                  ContactCreateDataService.currentSelectedContact.ID,
                                                  0,
                                                  FindViewById<TextView>(Resource.Id.editText1).Text);
					}

					AppDataStore.Database.SaveOrderAsync(order).Wait();
                    ContactCreateDataService.currentSelectedContact = null;
					this.Finish();
                } else {
                    Toast.MakeText(ApplicationContext, "Bitte wähle einen Kontakt", ToastLength.Long).Show();
                }

			};
        }

        protected override void OnResume()
        {
            base.OnResume();

            if(ContactCreateDataService.currentSelectedContact != null) 
            {
                FindViewById<Button>(Resource.Id.chooseContactButton).Text = ContactCreateDataService.currentSelectedContact.Name;

				JsonValue googleObject = GoogleNetworkService.TransformAdressToCoordinatesViaGoogleAsync(ContactCreateDataService.currentSelectedContact).Result;

                if (googleObject != null)
                {
                    var location = googleObject["results"][0]["geometry"]["location"];
                    if(location != null) {
						
						string locationFixed = string.Format("{0},{1}", location["lat"], location["lng"]);
						JsonValue distanceObject = GoogleNetworkService.GetDistanceBetweenCoordsAsync(AppDataStore.currentPos, locationFixed).Result;
						var value = distanceObject["rows"][0]["elements"][0]["distance"]["value"];
                        FindViewById<TextView>(Resource.Id.distanceFieldText).Text = (value / 1000).ToString() + " km";
                    }
                }
            }
        }
    }
}
