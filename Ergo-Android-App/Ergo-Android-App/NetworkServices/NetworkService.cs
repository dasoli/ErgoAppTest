using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ErgoAndroidApp.Dataservices;
using Newtonsoft.Json.Linq;
using System.Json;

namespace ErgoAndroidApp.NetworkServices
{
    public class GoogleNetworkService
    {
		// Gets weather data from the passed URL.
        public static async Task<JsonValue> TransformAdressToCoordinatesViaGoogle(ContactModel _contact)
		{
            string completeStreet = string.Format("{0}+{1}", _contact.Street, _contact.Housenumber);
			string geocodeUrl = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}+{1}+{2},{3}&key={4}",
                                              completeStreet, _contact.City, _contact.Zip, "germany", AppDataStore.googleGeoCodeApiKey);
            
			// Create an HTTP web request using the URL:
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(geocodeUrl));
			request.ContentType = "application/json";
            request.Accept = "application/json";
			request.Method = "GET";

            try{
                WebResponse response = request.GetResponseAsync().Result;

				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream())
				{
					// Use this stream to build a JSON document object:
                    JsonValue jsonDoc = Task.Run(() => JsonObject.Load(stream)).Result;
					Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

					// Return the JSON document:
					return jsonDoc;
				}
            } catch (Exception e) {
                return null;
            }
		}
    }
}
