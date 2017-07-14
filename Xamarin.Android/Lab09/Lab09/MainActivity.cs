using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab09
{
    [Activity(Label = "Lab09", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            Validate();
        }

        private async void Validate() {

            var ServiceClient = new SALLab09.ServiceClient();

            var textVUsuarioR = FindViewById<TextView>(Resource.Id.textVUsuarioR);
            var textVEstatusR = FindViewById<TextView>(Resource.Id.textVEstatusR);
            var textVTokenR = FindViewById<TextView>(Resource.Id.textVTokenR);

            string StudentEmail = "iot_93@hotmail.com";
            string Password = "Isaoroto15";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            textVUsuarioR.Text = $"{Result.Fullname}";
            textVEstatusR.Text = $"{Result.Status}";
            textVTokenR.Text = $"{Result.Token}";
        }
    }
}

