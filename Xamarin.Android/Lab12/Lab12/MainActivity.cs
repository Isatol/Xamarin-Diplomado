using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab12
{
    [Activity(Label = "Lab12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            Validate();

            var ListColors = FindViewById<ListView>(Resource.Id.listView1);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(this, Resource.Layout.ListItem, Resource.Id.textView1, 
                Resource.Id.textView2, Resource.Id.imageView1);

        }

        private async void Validate() {
            var ServiceClient = new SALLab12.ServiceClient();

            string StudentEmail = "iot_93@hotmail.com";
            string Password = "Isaoroto15";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var txtValidar = FindViewById<TextView>(Resource.Id.txtValidar);

            var Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);
            txtValidar.Text = $"{Result.FullName}\n{Result.Status}\n{Result.Token}";
        }
    }
}

