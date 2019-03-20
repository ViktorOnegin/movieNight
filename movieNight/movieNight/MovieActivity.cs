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
    [Activity(Label = "MovieActivity")]
    public class MovieActivity : Activity
    {
        private ListView List;
        private int ActorId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GetMovies);
            List = FindViewById<ListView>(Resource.Id.MovieView);

            ActorId = Intent.GetIntExtra("ActorId", 0);
            GetMoviesAsync(ActorId);
        }

        private async void GetMoviesAsync(int id)
        {
            List<MovieDataModel> Movies = await GetMovies.GetMovieDataTask(ActorId);
            if (Movies != null)
            {
                List.Adapter = new MovieAdapter(this, Movies);
            }
        }
    }
}