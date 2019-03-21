using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Views;
using Android.Widget;
using movieNight.Model;
using Square.Picasso;

namespace movieNight.Adapter
{
    public class MovieAdapter : BaseAdapter<MovieDataModel>
    {
        List<MovieDataModel> items;
        Activity context;

        public MovieAdapter(Activity context, List<MovieDataModel> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override MovieDataModel this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.GetMoviesRow, null);
            Random rnd = new Random();
            string overview;
            if(items[position].overview.Length <= 210)
            {
                var remainingString = 210 - items[position].overview.Length;
                var repeatString = new String(' ', remainingString);
                overview = items[position].overview + repeatString;
            }
            else if (items[position].overview.Length > 210)
            {
                overview = items[position].overview.Substring(0, 210) + "...";
            }
            else
            {
                overview = "Overview";
            }
            view.FindViewById<TextView>(Resource.Id.MovieName).Text = items[position].title;
            view.FindViewById<TextView>(Resource.Id.MovieYear).Text = rnd.Next(0, 30) + "." + rnd.Next(0,12) + "." + rnd.Next(1995,2019);
            view.FindViewById<TextView>(Resource.Id.AboutMovie).Text = overview;
            
            ImageView Image = view.FindViewById<ImageView>(Resource.Id.PosterView);
            Picasso.With(context).Load("https://image.tmdb.org/t/p/w500" + items[position].posterUrl).Into(Image);
            return view;
        }
    }
}