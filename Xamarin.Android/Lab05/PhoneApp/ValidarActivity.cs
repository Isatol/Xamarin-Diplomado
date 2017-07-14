using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhoneApp
{
    [Activity(Label = "Validar Actividad", Icon = "@drawable/Icon")]
    public class ValidarActivity : Activity
    {

       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Validar);
            // Create your application here

            var editEmailText = FindViewById<EditText>(Resource.Id.editTextEmail);
            var passText = FindViewById<EditText>(Resource.Id.editTxtPass);
            var btnValidar = FindViewById<Button>(Resource.Id.btnValidarActividad);
            var txtValidar = FindViewById<TextView>(Resource.Id.textViewValidar);

            btnValidar.Click += async(sender, e) =>
            {
                
                    var ServiceClient = new SALLab06.ServiceClient();

                    string StudentEmail = editEmailText.Text;
                    string Password = passText.Text;

                    string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

                    var ResultV = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);
                                    
                    txtValidar.Text = $"{ResultV.Status}\n{ResultV.Fullname}\n{ResultV.Token}";

            };


        }

       
    }
}