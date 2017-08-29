using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using ErgoAndroidApp.Dataservices;

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
				// start map activity
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
