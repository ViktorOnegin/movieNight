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

namespace movieNight.Model
{
    public class MovieDetailsDataModel
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; } = "x";
        public int budget { get; set; }
        //public List<string> genres { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }

        public int runtime { get; set; } = 0;
        public string poster_path { get; set; } = "x";
        public string release_date { get; set; }
        public int revenue { get; set; }
        public string tagline { get; set; }
        public string status { get; set; }
        public string original_language { get; set; }
        public string popularity { get; set; }
        public string genres { get; set; }
    }
}