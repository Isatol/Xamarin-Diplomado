using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab13
{
    [Activity(Label = "Lab13", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var imageButton = FindViewById<ImageButton>(Resource.Id.imageButton1);
            imageButton.Click += ImageButton_ClickAsync;
        }

        private async void ImageButton_ClickAsync(object sender, System.EventArgs e)
        {
            var ServiceClient = new SALLab13.ServiceClient();

            string studentEmail = "iot_93@hotmail.com";
            string password = "Isaoroto15";


            var Result = await ServiceClient.ValidateAsync(this, studentEmail, password);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage($"{Result.Status}\n{Result.FullName}\n{Result.Token}");
            Alert.SetButton("Ok", (s, ev) => { });
            Alert.Show();
        }
    }
}

