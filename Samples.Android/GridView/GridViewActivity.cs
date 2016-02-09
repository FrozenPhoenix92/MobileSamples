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

namespace Samples.Droid.GridView
{
    [Activity(Label = "GridViewActivity", ParentActivity = typeof (MainActivity))]
    public class GridViewActivity : Activity
    {
        private Android.Widget.GridView _gridView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GridViewLayout);

            InitComponents();
        }

        private void InitComponents()
        {
            _gridView = FindViewById<Android.Widget.GridView>(Resource.Id.gridView);
            _gridView.Adapter = new ImageAdapter(this);
            _gridView.ItemClick += gridView_ItemClick;
        }

        private void gridView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Short).Show();
        }
    }
}