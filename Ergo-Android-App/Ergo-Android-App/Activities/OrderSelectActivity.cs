
using Android.App;
using Android.OS;
using Android.Widget;
using ErgoAndroidApp.Dataservices;
using Android.Content;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "OrderSelectActivity")]
    public class OrderSelectActivity : Activity
    {
		private ListView contactsList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CustomerSelect);

            this.contactsList = FindViewById<ListView>(Resource.Id.contact_list_select);

			var database = AppDataStore.Database;

			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this,
																	Android.Resource.Layout.SimpleListItem1,
																	database.ConvertListToStringNames(database.GetItemsAsync().Result));

			var results = database.ConvertListToStringNames(database.GetItemsAsync().Result);

			this.contactsList.Adapter = adapter;

			this.contactsList.ItemClick += (sender, e) => {
                ContactCreateDataService.currentSelectedContact = database.GetItemsAsync().Result[e.Position];
                this.Finish();
			};
        }
    }
}
