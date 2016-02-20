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

namespace Samples.Droid.FayoutMenu
{
    [Activity(Label = "Боковок меню", ParentActivity = typeof (MainActivity))]
    public class FayoutMenuActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FlayoutMenuLayout);

            var menu = FindViewById<FlyOutContainer>(Resource.Id.FlyOutContainer);
            var menuButton = FindViewById(Resource.Id.MenuButton);
            var layoutContent = menu.FindViewById<FrameLayout>(Resource.Id.frameLayoutContent);
            layoutContent.RemoveAllViewsInLayout();
            layoutContent.AddView(LayoutInflater.Inflate(Resource.Layout.FlayoutMenuItemContent1Layout, null));

            var firstButton = menu.MenuView.FindViewById<Android.Widget.LinearLayout>(Resource.Id.linearLayout1);
            firstButton.Click += (sender, e) =>
            {
                menu.contentOffsetX = 0;
                layoutContent.RemoveAllViewsInLayout();
                menu.AnimatedOpened = !menu.AnimatedOpened;
                layoutContent.AddView(LayoutInflater.Inflate(Resource.Layout.FlayoutMenuItemContent1Layout, null));
            };

            var secondButton = menu.MenuView.FindViewById<Android.Widget.LinearLayout>(Resource.Id.linearLayout2);
            secondButton.Click += (sender, e) =>
            {
                menu.contentOffsetX = 0;
                layoutContent.RemoveAllViewsInLayout();
                menu.AnimatedOpened = !menu.AnimatedOpened;
                layoutContent.AddView(LayoutInflater.Inflate(Resource.Layout.FlayoutMenuItemContent2Layout, null));
            };

            menuButton.Click += (sender, e) => 
            {
                menu.AnimatedOpened = !menu.AnimatedOpened;
            };
        }
    }
}