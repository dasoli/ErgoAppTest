
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
using ErgoAndroidApp.Dataservices;
using Newtonsoft.Json.Linq;
using Java.Lang;
using ErgoAndroidApp.NetworkServices;
using System.Json;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "ContactAdd")]
    public class ContactAdd : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ContactAddDetail);


            // add button
            FindViewById<Button>(Resource.Id.button_create_contact).Click += delegate
            {
                string name = FindViewById<EditText>(Resource.Id.contacts_input_name).Text;
                string street = FindViewById<EditText>(Resource.Id.contacts_input_street).Text;
                string housenumber = FindViewById<EditText>(Resource.Id.contacts_input_housenumber).Text;
                string city = FindViewById<EditText>(Resource.Id.contacts_input_city).Text;
                string zip = FindViewById<EditText>(Resource.Id.contacts_input_zip).Text;

                ContactModel contactModel = ContactModel.CreateContact(name, street, housenumber, city, zip);

                ContactDataService.AddContact();
            };

            // geocode button
			FindViewById<Button>(Resource.Id.button_createContacts_geocode).Click += delegate
			{
				string street = FindViewById<EditText>(Resource.Id.contacts_input_street).Text;
				string housenumber = FindViewById<EditText>(Resource.Id.contacts_input_housenumber).Text;
				string city = FindViewById<EditText>(Resource.Id.contacts_input_city).Text;
				string zip = FindViewById<EditText>(Resource.Id.contacts_input_zip).Text;

                JsonValue googleObject = GoogleNetworkService.TransformAdressToCoordinatesViaGoogle(ContactModel.CreateContact("tester", street, housenumber, city, zip)).Result;

                if(googleObject != null) {
					//Console.WriteLine(responseFromServer);
					var location = googleObject["results"][0]["geometry"]["location"];
					FindViewById<TextView>(Resource.Id.contacts_add_geocode_dates).Text = string.Format("lat:{0} lon:{1}", location["lat"], location["lng"]);
                }

			};

        }
    }
}
