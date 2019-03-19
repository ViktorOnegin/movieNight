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
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using System.Threading;

namespace movieNight
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class SearchActorActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SearchActor);
            //Thread.Sleep(5000);
            //var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetActionBar(toolbar);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //Android.Support.V7.Widget.SearchView search = FindViewById<Android.Support.V7.Widget.SearchView>(Resource.Id.PeopleView);            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.SearchActorToolbar, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.back:
                    {
                        var activity = new Intent(this, typeof(MainActivity));
                        StartActivity(activity);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            //int id = item.ItemId;
            //if (id == Resource.Id.home)
            //{
            //    var activity = new Intent(this, typeof(MainActivity));
            //    StartActivity(activity);
            //    return true;
            //}
            //else if (id == Resource.Id.back)
            //{
            //    var activity = new Intent(this, typeof(MainActivity));
            //    StartActivity(activity);
            //    return true;
            //}

            return base.OnOptionsItemSelected(item);
        }
    }
}