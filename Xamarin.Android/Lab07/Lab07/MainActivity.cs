using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab07
{
    [Activity(Label = "Lab07", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            var textEmail =  FindViewById<EditText>(Resource.Id.textEmail);
            var textPass = FindViewById<EditText>(Resource.Id.textPass);
            var btnValidar = FindViewById<Button>(Resource.Id.btnValidar);
            var textVValidar = FindViewById<TextView>(Resource.Id.textVValidar);

            btnValidar.Click += async (sender, e) => {
                var ServiceClient = new SALLab07.ServiceClient();

                string StudentEmail = textEmail.Text;
                string Password = textPass.Text;

                string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

                var Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

                if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
                    try
                    {
                        var Builder = new Notification.Builder(this);
                        Builder.SetContentTitle("Validación de actividad");
                        Builder.SetContentText($"{Result.Status} {Result.Fullname} {Result.Token}");
                        Builder.SetSmallIcon(Resource.Drawable.Icon);

                        Builder.SetCategory(Notification.CategoryMessage);

                        var ObjectNotification = Builder.Build();
                        var Manager = GetSystemService(Android.Content.Context.NotificationService) as NotificationManager;
                        Manager.Notify(0, ObjectNotification);
                    }
                    catch {

                    }

                }

                else{
                    textVValidar.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
                }
            };
        }

        
    }
}

