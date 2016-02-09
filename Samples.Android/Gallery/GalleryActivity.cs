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
    [Activity(Label = "Демонстрация галереи", ParentActivity = typeof (MainActivity))]
    public class GalleryActivity : Activity
    {
        private Android.Widget.Gallery _gallery;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GalleryLayout);

            InitComponents();
        }

        private void InitComponents()
        {
            _gallery = FindViewById<Android.Widget.Gallery>(Resource.Id.gallery);
            _gallery.Adapter = new ImageAdapter(this);
            _gallery.ItemClick += gallery_ItemClick;
        }

        private void gallery_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Short).Show();
        }
    }
}