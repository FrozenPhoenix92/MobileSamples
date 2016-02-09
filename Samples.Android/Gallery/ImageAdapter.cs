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

namespace Samples.Droid.Gallery
{
    public class ImageAdapter : BaseAdapter
    {
        readonly Context _context;

        public ImageAdapter(Context c)
        {
            _context = c;
        }

        public override int Count => _thumbIds.Length;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var i = new ImageView(_context);

            i.SetImageResource(_thumbIds[position]);
            i.LayoutParameters = new Android.Widget.Gallery.LayoutParams(350, 300);
            i.SetScaleType(ImageView.ScaleType.FitXy);

            return i;
        }

        // references to our images
        readonly int[] _thumbIds = {
            Resource.Drawable.sample_1,
            Resource.Drawable.sample_2,
            Resource.Drawable.sample_3,
            Resource.Drawable.sample_4,
            Resource.Drawable.sample_5,
            Resource.Drawable.sample_6,
            Resource.Drawable.sample_7
     };
    }
}