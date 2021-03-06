﻿using System;
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
    [Activity(Label = "")]
    public class MovieActivity : Activity
    {
        private List<MovieDataModel> Movies;
        private ListView List;
        private int ActorId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GetMovies);
            List = FindViewById<ListView>(Resource.Id.MovieView);

            ActorId = Intent.GetIntExtra("ActorId", 0);
            GetMoviesAsync(ActorId);
            List.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                var movie = Movies.ElementAt(position.Position);
                Intent intent = new Intent(this, typeof(MovieDetailActivity));
                intent.PutExtra("MovieId", movie.id);
                StartActivity(intent);
            };
        }

        private async void GetMoviesAsync(int id)
        {
            Movies = await GetMovies.GetMovieByIdDataTask(ActorId, this);
            if (Movies != null)
            {
                List.Adapter = new MovieAdapter(this, Movies);
            }
        }
    }
}