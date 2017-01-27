using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System;

namespace CalculatorXamarin
{
    [Activity(Label = "CalculatorXamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button btnCalc = FindViewById<Button>(Resource.Id.calc);
            EditText a = FindViewById<EditText>(Resource.Id.aInput);
            EditText b = FindViewById<EditText>(Resource.Id.bInput);
            EditText res = FindViewById<EditText>(Resource.Id.res);
            EditText op = FindViewById<EditText>(Resource.Id.op);

            btnCalc.Click += delegate
            {
                int n1 = Convert.ToInt32(a.Text);
                int n2 = Convert.ToInt32(b.Text);
                string operation = op.Text;

                Calculation c = new Calculation();
                res.Text = Convert.ToString(c.Calculate(n1, n2, operation));

            };
        }
    }
}

