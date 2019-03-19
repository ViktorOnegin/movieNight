using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
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

            view.FindViewById<TextView>(Resource.Id.MovieName).Text = items[position].title;
            ImageView Image = view.FindViewById<ImageView>(Resource.Id.PosterView);
            Picasso.With(context).Load("https://image.tmdb.org/t/p/w500" + items[position].posterUrl).Into(Image);
            return view;
        }
    }
}