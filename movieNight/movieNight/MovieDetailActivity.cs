using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using movieNight.Adapter;
using movieNight.GetData;
using movieNight.Model;
using Square.Picasso;

namespace movieNight
{
    [Activity(Label = "MovieDetailActivity")]
    public class MovieDetailActivity : Activity
    {
        private static MovieDetailsDataModel MovieDetails = new MovieDetailsDataModel();
        private int MovieId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.MovieDetails);
            base.OnCreate(savedInstanceState);
            MovieId = Intent.GetIntExtra("MovieId", 0);

            GetMovieDetailsAsync(MovieId);
        }

        private async void GetMovieDetailsAsync(int movieId)
        {
            MovieDetails = await GetMovies.GetMovieDetailsDataTask(movieId);

            FindViewById<TextView>(Resource.Id.MovieName).Text = MovieDetails.title;
            FindViewById<TextView>(Resource.Id.MovieYear).Text = MovieDetails.release_date;
            FindViewById<TextView>(Resource.Id.Runtime).Text = MovieDetails.runtime.ToString() + "min";
            FindViewById<TextView>(Resource.Id.popularity).Text = MovieDetails.popularity;
            FindViewById<TextView>(Resource.Id.RevenueView).Text = "$" + MovieDetails.revenue.ToString();
            FindViewById<TextView>(Resource.Id.OriginalLanguage).Text = MovieDetails.original_language;
            FindViewById<TextView>(Resource.Id.Genres).Text = MovieDetails.genres;
            FindViewById<TextView>(Resource.Id.Status).Text = MovieDetails.status;
            FindViewById<TextView>(Resource.Id.AboutMovie).Text = MovieDetails.overview;

            ImageView Image = FindViewById<ImageView>(Resource.Id.Backdrop);
            Picasso.With(this).Load("https://image.tmdb.org/t/p/original" + MovieDetails.backdrop_path).Into(Image);
        }
    }
}