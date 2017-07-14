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

namespace TrucosAgeOEmp
{
    [Activity(Label = "@string/ButtonRecursos", Icon="@drawable/Icon")]
    public class RecursosActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Recursos);
            // Create your application here

        }
    }
}