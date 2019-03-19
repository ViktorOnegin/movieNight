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

namespace movieNight.Model
{
    public class PeopleDataModel
    {
        public int id { get; set; }
        public float popularity { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
    }
}