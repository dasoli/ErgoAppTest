using System.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using ErgoAndroidApp.Dataservices;
using ErgoAndroidApp.NetworkServices;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "ContactDetailActivity")]
    public class ContactDetailActivity : Activity
    {
        private ContactModel contact;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactDetail);
            this.contact = AppDataStore.Database.GetItemAsync(int.Parse(Intent.GetStringExtra("contact"))).Result;

            string name = this.contact.Name;
            FindViewById<TextView>(Resource.Id.contact_detail_name).Text = name;

			FindViewById<Button>(Resource.Id.contact_detail_button_showMaps).Click += delegate
			{
				JsonValue googleObject = GoogleNetworkService.TransformAdressToCoordinatesViaGoogleAsync(this.contact).Result;
				var location = googleObject["results"][0]["geometry"]["location"];
                string locationFixed = string.Format("{0},{1}", location["lat"], location["lng"]);
                JsonValue distanceObject = GoogleNetworkService.GetDistanceBetweenCoordsAsync(AppDataStore.currentPos, locationFixed).Result;
                var value = distanceObject["rows"][0]["elements"][0]["distance"]["value"];
                FindViewById<Button>(Resource.Id.contact_detail_button_showMaps).Text = (value / 1000).ToString();
			};

			FindViewById<Button>(Resource.Id.contactDetailDeleteButton).Click += delegate
			{
                AppDataStore.Database.DeleteItemAsync(this.contact).Wait();
                this.contact = null;
                this.Finish();
			};


        }
    }
}
