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

namespace Samples.Droid.TabsDemonstration
{
    [Activity(Label = "Демонстрация вкладок", ParentActivity = typeof(MainActivity))]
    public class TabsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TabsLayout);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Вкладка 1", Resource.Drawable.ic_tab_white, new FormElementsTabFragment());
            AddTab("Вкладка 2", Resource.Drawable.ic_tab_white, new FormElements2TabFragment());

            if (savedInstanceState != null)
                ActionBar.SelectTab(ActionBar.GetTabAt(savedInstanceState.GetInt("tab")));
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", ActionBar.SelectedNavigationIndex);

            base.OnSaveInstanceState(outState);
        }

        private void AddTab(string text, int resourceIconId, Fragment view)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(text);
            tab.SetIcon(resourceIconId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };
            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Remove(view);
            };
            ActionBar.AddTab(tab);
        }
    }
}