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

namespace Samples.Droid.ListDemonstration
{
    public class ListItem
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public string Value { get; set; }

        public string SubHeading { get; set; }

        public int ImageResourceId { get; set; }
    }
}