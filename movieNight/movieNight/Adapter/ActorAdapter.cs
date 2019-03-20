using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using movieNight.GetData;
using movieNight.Model;
using Square.Picasso;

namespace movieNight.Adapter
{
    public class ActorAdapter : BaseAdapter<PeopleDataModel>
    {
        List<PeopleDataModel> items;        
        Activity context;

        public ActorAdapter(Activity context, List<PeopleDataModel> items) : base()
        {
            this.context = context;            
            this.items = items;
        }        

        public override PeopleDataModel this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.SearchActorRow, null);

            ImageView Image = view.FindViewById<ImageView>(Resource.Id.ActorImage);
            Image.SetImageResource(Resource.Drawable.unknownperson2);
            if (items[position].imageUrl != null)
            {
                Picasso.With(context).Load("https://image.tmdb.org/t/p/w500" + items[position].imageUrl).Into(Image);
            }
            view.FindViewById<TextView>(Resource.Id.PersonName).Text = items[position].name;
            return view;
        }       
    }
}