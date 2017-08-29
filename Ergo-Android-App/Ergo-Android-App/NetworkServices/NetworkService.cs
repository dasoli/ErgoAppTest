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
        public static async Task<JsonValue> TransformAdressToCoordinatesViaGoogleAsync(ContactModel _contact)
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

					// Return the JSON document:
					return jsonDoc;
				}
            } catch (Exception e) {
                return null;
            }
		}

        public static async Task<JsonValue> GetDistanceBetweenCoordsAsync(string _start, string _end)
		{
			string geocodeUrl = string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins={0}&destinations={1}&key={2}",
											  _start, _end, AppDataStore.googleGeoCodeApiKey);

			// Create an HTTP web request using the URL:
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(geocodeUrl));
			request.ContentType = "application/json";
			request.Accept = "application/json";
			request.Method = "GET";

			try
			{
				WebResponse response = request.GetResponseAsync().Result;

				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream())
				{
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = Task.Run(() => JsonObject.Load(stream)).Result;

					// Return the JSON document:
					return jsonDoc;
				}
			}
			catch (Exception e)
			{
				return null;
			}
		}


    }
}
