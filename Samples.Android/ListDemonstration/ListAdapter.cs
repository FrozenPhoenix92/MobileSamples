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
    class ListAdapter : BaseAdapter<string>, ISectionIndexer
    {
        private readonly ListActivity _context;
        private readonly List<ListItemGroup> _groupedItems;
        private readonly List<ListItem> _allItems;

        public ListAdapter(List<ListItemGroup> items, ListActivity context)
        {
            _context = context;
            _groupedItems = items;
            _allItems = items.Aggregate(new List<ListItem>(), (cur, next) => cur.Concat(next.Items).ToList());
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override string this[int position] => _allItems[position].Value;

        public override int Count => _allItems.Count;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _allItems[position];
            var view = _context.LayoutInflater.Inflate(Resource.Layout.CustomListView, null);
            view.FindViewById<TextView>(Resource.Id.Text).Text = item.Value;
            view.FindViewById<TextView>(Resource.Id.SubHeading).Text = item.SubHeading;
            if (item.ImageResourceId != -1)
                view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;
        }

        public int GetPositionForSection(int section)
        {
            return _allItems.FindIndex(elem => elem.GroupId == _groupedItems[section].Id);
        }

        public int GetSectionForPosition(int position)
        {
            return _groupedItems.FindIndex(elem => elem.Items.Contains(_allItems[position]));
        }

        public Java.Lang.Object[] GetSections()
        {
            var javaStrings = _groupedItems.Select(
                elem => (Java.Lang.Object)(new Java.Lang.String(elem.Title))).ToArray();
            return javaStrings;
        }
    }
}