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

namespace movieNight
{
    [Activity(Label = "ExceptionActivity")]
    public class ExceptionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ExceptionLayout);
            Button Retry = FindViewById<Button>(Resource.Id.Retry);
            int drawableId;
            string errorMessage = "";
            if( this.Intent.Extras != null)
            {
                errorMessage = Intent.Extras.GetString("ExceptionMessage");
            }

            Retry.Click += Retry_Click;
            
            switch (errorMessage.ToString())
            {
                case "Unable to resolve host \"api.themoviedb.org\": No address associated with hostname":
                drawableId = (int)typeof(Resource.Drawable).GetField("NoInternet").GetValue(null);
                FindViewById<ImageView>(Resource.Id.ImageView1).SetImageResource(drawableId);
                FindViewById<TextView>(Resource.Id.BigText).Text = "Whoops!";
                FindViewById<TextView>(Resource.Id.SmallExceptionText).Text = "No Internet connection found. Check\n your connection or try again.";
                break;

                default:
                break;
            }
        }

        private void Retry_Click(object sender, EventArgs e)
        {
            var activity = new Intent(this, typeof(SplashActivity));
            StartActivity(activity);
        }
    }
} 