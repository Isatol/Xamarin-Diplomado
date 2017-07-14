using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Lab11
{
    [Activity(Label = "Lab11", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Complex Data;
        ComplexResult DataResult;
        int Counter = 0;
        TextView txtResult;
        protected override void OnCreate(Bundle bundle)
        {
            Android.Util.Log.Debug("Lab11log", "Activity A - OnCreate");
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            Validate();
           

            FindViewById<Button>(Resource.Id.StartActivity).Click += (sender, e) => {
                var ActivityIntent = new Android.Content.Intent(this, typeof(SecondActivity));
                StartActivity(ActivityIntent);
            };

            //Utilizar FragmentManager para recuperar el Fragmento
            Data = (Complex)this.FragmentManager.FindFragmentByTag("Data");
            if (Data == null) {
                //No ha sido almacenado, agregar el fragmento a la Activity
                Data = new Complex();
                var FragmentTransaction = this.FragmentManager.BeginTransaction();
                FragmentTransaction.Add(Data, "Data");
                FragmentTransaction.Commit();
            }

            
            if (bundle != null) {
                
                Counter = bundle.GetInt("CounterValue", 0);
                Android.Util.Log.Debug("Lab11Log", "Activity A - Recovered Instance State");
            }
            var ClickCounter = FindViewById<Button>(Resource.Id.ClicksCounter);
            ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);
            ClickCounter.Text += $"\n{Data.ToString()}";
            ClickCounter.Click += (sender, e) => {
                Counter++;
                ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);

                //Modificar con cualquier valor solo para verificarla persistencia
                Data.Real++;
                Data.Imaginary++;
                //Mostrarel valor de los miembros
                ClickCounter.Text += $"\n{Data.ToString()}";
            };
        }

        private async void Validate() {
            //Utilizar FragmentManager para recuperar el Fragmento
            DataResult = (ComplexResult)this.FragmentManager.FindFragmentByTag("DataResult");
            if (DataResult == null)
            {
                //No ha sido almacenado, agregar el fragmento a la Activity
                DataResult = new ComplexResult();
                var FragmentTransaction = this.FragmentManager.BeginTransaction();
                FragmentTransaction.Add(DataResult, "DataResult");
                FragmentTransaction.Commit();

                var ServiceClient = new SALLab11.ServiceClient();
                string StudentEmail = "iot_93@hotmail.com";
                string Password = "Isaoroto15";
                string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

                DataResult.Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

                
            }
            txtResult = FindViewById<TextView>(Resource.Id.txtResult);

            txtResult.Text = $"{DataResult.ToString()}";
            
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("CounterValue", Counter);
            
            
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnSaveInstanceState");
            base.OnSaveInstanceState(outState);
        }

        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStart");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnResume");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnPause");
            base.OnPause();
        }

        protected override void OnStop()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStop");
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnRestart");
            base.OnRestart();
        }

    }
}

