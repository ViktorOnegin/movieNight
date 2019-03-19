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
    public class MovieDataModel
    {
        public int id { get; set; }
        public string character { get; set; }
        public string posterUrl { get; set; }
        public string title { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string releaseDate { get; set; }
    }
}