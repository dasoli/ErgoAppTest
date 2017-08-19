using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ErgoAndroidApp.Activities
{
    [Activity(Label = "ContactDetailActivity")]
    public class ContactDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactDetail);

            string name = Intent.GetStringExtra("contact");
            FindViewById<TextView>(Resource.Id.contact_detail_name).Text = name;

			FindViewById<Button>(Resource.Id.contact_detail_button_showMaps).Click += delegate
			{
				// start map activity
			};
        }
    }
}
