using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            Validate();
            //var ViewGroup = (Android.Views.ViewGroup)Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;

            //var HeaderImage = new ImageView(this);
            //HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);
            //MainLayout.AddView(HeaderImage);

            //var UserNameTextView = new TextView(this);
            //UserNameTextView.Text = GetString(Resource.String.UserName);
            //MainLayout.AddView(UserNameTextView);


        }

        private async void Validate() {
            var ServiceClient = new SALLab08.ServiceClient();

            var textViewUsuario = FindViewById<TextView>(Resource.Id.textVUsuario);
            var textViewStatus = FindViewById<TextView>(Resource.Id.textVStatusR);
            var textViewToken = FindViewById<TextView>(Resource.Id.textVTokenR);

            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            string StudentEmail = "iot_93@hotmail.com";
            string Password = "Isaoroto15";

            var Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            try
            {
                textViewUsuario.Text = $"{Result.Fullname}";
                textViewStatus.Text = $"{Result.Status}";
                textViewToken.Text = $"{Result.Token}";
            }
            catch {

            }
        }
    }
}

