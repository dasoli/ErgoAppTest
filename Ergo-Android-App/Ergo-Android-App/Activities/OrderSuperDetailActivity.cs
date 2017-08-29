
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
    [Activity(Label = "OrderSuperDetailActivity")]
    public class OrderSuperDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderSuperDetail);

            FindViewById<TextView>(Resource.Id.textName).Text = ContactCreateDataService.currentSelectedOrder.OrderName;
            FindViewById<TextView>(Resource.Id.textDistance).Text = ContactCreateDataService.currentSelectedOrder.Distance.ToString();
            FindViewById<TextView>(Resource.Id.textWhatDone).Text = ContactCreateDataService.currentSelectedOrder.OrderText;
                          
        }

        protected override void OnDestroy()
        {
            ContactCreateDataService.currentSelectedOrder = null;
            base.OnDestroy();
        }
    }
}
