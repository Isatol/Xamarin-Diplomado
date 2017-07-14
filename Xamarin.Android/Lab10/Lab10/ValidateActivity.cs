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
using Android.Text;
using Android.Graphics.Drawables;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", Icon ="@drawable/icon")]
    public class ValidateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Validate);
            // Create your application here

            var EditTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
           
            var EditTextPass = FindViewById<EditText>(Resource.Id.editTextPassword);
            var ValidateButton = FindViewById<Button>(Resource.Id.btnValidar);
            var TextViewResult = FindViewById<TextView>(Resource.Id.textViewResult);


            ValidateButton.Click += async (s, e) =>
            {

                    
                    var ServiceClient = new SALLab10.ServiceClient();

                    string studentEmail = EditTextEmail.Text;
                    string studentPassword = EditTextPass.Text;
                    string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

                    var Result = await ServiceClient.ValidateAsync(studentEmail, studentPassword, myDevice);

                    TextViewResult.Text = $"{Result.Fullname}\n{Result.Status}\n{Result.Token}";
                                                
            };
        }
    }
}