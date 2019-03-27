﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using movieNight.GetData;
using movieNight.Model;
using Context = System.Runtime.Remoting.Contexts.Context;
using Newtonsoft.Json;
using Java.IO;

namespace movieNight
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, Icon = "@drawable/movieIcon")]
    public class SplashActivity : AppCompatActivity
    {
        private string exception;
        public static List<MovieDataModel> Popular;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        async void SimulateStartup()
        {
            try
            {
                Popular = await GetPopular.GetPopularDataTask();
            }
            catch (Exception Message)
            {
                exception = Message.Message;
            }
            
            if(exception == null)
            {
                Intent intent = new Intent(Application.Context, typeof(MainActivity));
                StartActivity(intent);
            }
            else
            {
                Intent ExceptionIntent = new Intent(Application.Context, typeof(ExceptionActivity));
                var bundle = new Bundle();
                bundle.PutString("ExceptionMessage", exception.ToString());
                ExceptionIntent.PutExtras(bundle);
                StartActivity(ExceptionIntent);
            }
             
           
        }
    }
}