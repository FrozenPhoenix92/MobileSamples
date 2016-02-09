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

namespace Samples.Droid
{
    class MenuAdapter : BaseAdapter<string>
    {
        private readonly MenuItem[] _items;
        private readonly ListActivity _context;

        public MenuAdapter(MenuItem[] items, ListActivity context)
        {
            _items = items;
            _context = context;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position] => _items[position].Value;

        public override int Count => _items.Length;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView 
                ?? _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = _items[position].Value;

            return view;
        }
    }
}