using Android.App;
using Android.Widget;
using Android.OS;

namespace TrucosAgeOEmp
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);


            var ButtonRecursos = FindViewById<Button>(Resource.Id.btnRecursos);
            ButtonRecursos.Click += ButtonRecursos_Click;
        }

        private void ButtonRecursos_Click(object sender, System.EventArgs e)
        {
            var IntentRecursos = new Android.Content.Intent(this, typeof(RecursosActivity));
            StartActivity(IntentRecursos);
        }
    }
}

