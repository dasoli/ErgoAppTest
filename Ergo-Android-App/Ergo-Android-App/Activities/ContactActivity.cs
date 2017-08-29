
using Android.App;
using Android.OS;
using Android.Widget;
using ErgoAndroidApp.Dataservices;
using Android.Content;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "ContactActivity")]
    public class ContactActivity : Activity
    {
        private ListView contactsList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Contacts);
            var database = AppDataStore.Database;
            this.contactsList = FindViewById<ListView>(Resource.Id.contact_list);

			FindViewById<Button>(Resource.Id.contacts_create_contact).Click += delegate
			{
				//if (FindViewById<EditText>(Resource.Id.input_password).Text == this.defaultPassword
				//&& FindViewById<EditText>(Resource.Id.input_username).Text == this.defaultUserName) {

				StartActivity(typeof(ContactAdd));
				//}
			};

			this.contactsList.ItemClick += (sender, e) => {
				var activity2 = new Intent(this, typeof(ContactDetailActivity));
				activity2.PutExtra("contact",
                                   database.GetItemsAsync().Result[e.Position].ID.ToString());

				StartActivity(activity2);
			};
        }

        protected override void OnResume()
        {
            base.OnResume();
            var database = AppDataStore.Database;

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, 
                                                                    Android.Resource.Layout.SimpleListItem1, 
                                                                    database.ConvertListToStringNames(database.GetItemsAsync().Result));

            this.contactsList = FindViewById<ListView>(Resource.Id.contact_list);

            this.contactsList.Adapter = adapter;

        }

    }
}
