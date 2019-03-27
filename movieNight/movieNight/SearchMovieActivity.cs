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
using movieNight.Adapter;
using movieNight.GetData;
using movieNight.Model;

namespace movieNight
{
    [Activity(Theme = "@style/AppTheme", Label = "")]
    public class SearchMovieActivity : Activity
    {
        private static List<MovieDataModel> Movies;
        private ListView List;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SearchMovie);

            List = FindViewById<ListView>(Resource.Id.PeopleView);
            SearchView SearchView = FindViewById<SearchView>(Resource.Id.searchView1);

            SearchView.QueryTextSubmit += SearchView_QueryTextSubmit;
        }

        private void SearchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            SearchView SearchView = FindViewById<SearchView>(Resource.Id.searchView1);
            GetMoviesAsync(SearchView.Query);
        }

        private async void GetMoviesAsync(string query)
        {
            Movies = await GetMovies.GetMoviesDataTask(query);

            if (Movies != null)
            {
                List.Adapter = new MovieAdapter(this, Movies);
            }
        }
    }
}