using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Samples.Droid.PopupMenu
{
    [Activity(Label = "Демонстрация выпадающего списка", ParentActivity = typeof(MainActivity))]
    public class PopupMenuActivity : Activity
    {
        private Button _showPopupMenuButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PopupMenuLayout);

            InitComponents();
        }

        private void InitComponents()
        {
            _showPopupMenuButton = FindViewById<Button>(Resource.Id.showPopupMenuButton);
            _showPopupMenuButton.Click += showPopupMenuButton_Click;
        }

        private void showPopupMenuButton_Click(object sender, EventArgs e)
        {
            var popupMenu = new Android.Widget.PopupMenu(this, _showPopupMenuButton);
            popupMenu.Inflate(Resource.Menu.popup_menu);
            popupMenu.MenuItemClick += (s1, arg1) =>
            {
                Toast.MakeText(this, arg1.Item.TitleFormatted + " выбран", ToastLength.Short).Show();
            };
            
            popupMenu.DismissEvent += (s2, arg2) => {
                Toast.MakeText(this, "Меню свёрнуто", ToastLength.Short).Show();
            };

            popupMenu.Show();
        }
    }
}