
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

                ContactDataService.AddContact(new ContactModel(name, street, housenumber, city, zip));
            };

            // geocode button
			FindViewById<Button>(Resource.Id.button_createContacts_geocode).Click += delegate
			{
				string street = FindViewById<EditText>(Resource.Id.contacts_input_street).Text;
				string housenumber = FindViewById<EditText>(Resource.Id.contacts_input_housenumber).Text;
				string city = FindViewById<EditText>(Resource.Id.contacts_input_city).Text;
				string zip = FindViewById<EditText>(Resource.Id.contacts_input_zip).Text;

                string completeStreet = string.Format("{0}+{1}",street, housenumber);

                string geocodeUrl = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}+{1}+{2},{3}&key={4}",
                                                  completeStreet, city, zip, "germany", AppDataStore.googleGeoCodeApiKey);

				// Create a request for the URL. 
				WebRequest request = WebRequest.Create(geocodeUrl);
				// If required by the server, set the credentials.
				request.Credentials = CredentialCache.DefaultCredentials;
				// Get the response.
				WebResponse response = request.GetResponse();
				// Display the status.
				Console.WriteLine(((HttpWebResponse)response).StatusDescription);
				// Get the stream containing content returned by the server.
				Stream dataStream = response.GetResponseStream();
				// Open the stream using a StreamReader for easy access.
				StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                // Display the content.
                var returnString = reader.ReadToEnd();
                var code = JObject.Parse(returnString);
                //Console.WriteLine(responseFromServer);
                var location = code["results"][0]["geometry"]["location"];
                FindViewById<TextView>(Resource.Id.contacts_add_geocode_dates).Text = string.Format("lat:{0} lon:{1}",location["lat"],location["lng"]);
				// Clean up the streams and the response.
				reader.Close();
				response.Close();
			};

        }
    }
}
