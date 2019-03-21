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

namespace movieNight
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, Icon = "@drawable/movieIcon")]
    public class SplashActivity : AppCompatActivity
    {
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
            List<PeopleDataModel> People = await GetPeople.GetPeopleDataTask("Kaspar");
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}