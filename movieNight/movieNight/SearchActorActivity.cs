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
using movieNight.Adapter;
using movieNight.GetData;
using movieNight.Model;

namespace movieNight
{
    [Activity(Theme = "@style/AppTheme", Label ="")]
    public class SearchActorActivity : AppCompatActivity
    {
        private List<PeopleDataModel> Actors;
        private ListView List;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SearchActor);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            
            List = FindViewById<ListView>(Resource.Id.PeopleView);
            SearchView SearchView = FindViewById<SearchView>(Resource.Id.searchView1);

            SearchView.QueryTextSubmit += SearchView_QueryTextSubmit;
            List.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                var x = Actors.ElementAt(position.Position);
                Intent intent = new Intent(this, typeof(MovieActivity));
                intent.PutExtra("ActorId", x.id);
                StartActivity(intent);
            };
        }

        private void SearchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            SearchView SearchView = FindViewById<SearchView>(Resource.Id.searchView1);
            GetActors(SearchView.Query);
        }

        private async void GetActors(string Query)
        {
            Actors = await GetPeople.GetPeopleDataTask(Query.ToString());
            if (Actors != null)
            {
                List.Adapter = new ActorAdapter(this, Actors);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.SearchActorToolbar, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.back)
            {
                var activity = new Intent(this, typeof(MainActivity));
                StartActivity(activity);
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}