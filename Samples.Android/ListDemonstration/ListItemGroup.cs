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
    public class ListItemGroup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<ListItem> Items { get; set; }
    }
}