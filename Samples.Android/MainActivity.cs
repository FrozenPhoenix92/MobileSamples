using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Linq;
using Android.Content;
using Java.Lang;
using Samples.Droid.AutoComplete;
using Samples.Droid.CardViewDemonstration;
using Samples.Droid.CustomAnimation;
using Samples.Droid.DatePicker;
using Samples.Droid.Gallery;
using Samples.Droid.GridView;
using Samples.Droid.LinearLayout;
using Samples.Droid.ListDemonstration;
using Samples.Droid.PopupMenu;
using Samples.Droid.SignaturePad;
using Samples.Droid.TableLayout;
using Samples.Droid.TabsDemonstration;

namespace Samples.Droid
{
    [Activity(Label = "Главное меню", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private MenuItem[] _items; 


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Init();
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            try
            {
                var item = _items[position];
                Intent intent = null;
                switch (item.ItemName)
                {
                    case "listItem":
                        intent = new Intent(this, typeof (ListDemonstrationActivity));
                        break;
                    case "cardViewItem":
                        intent = new Intent(this, typeof (CardViewActivity));
                        break;
                    case "tabsItem":
                        intent = new Intent(this, typeof (TabsActivity));
                        break;
                    case "autoCompleteItem":
                        intent = new Intent(this, typeof (AutoCompleteActivity));
                        break;
                    case "datePickerItem":
                        intent = new Intent(this, typeof (DatePickerActivity));
                        break;
                    case "galleryItem":
                        intent = new Intent(this, typeof (GalleryActivity));
                        break; 
                    case "gridViewItem":
                        intent = new Intent(this, typeof(GridViewActivity));
                        break;
                    case "linearLayoutItem":
                        intent = new Intent(this, typeof(LinearLayoutActivity));
                        break;
                    case "tableLayoutItem":
                        intent = new Intent(this, typeof(TableLayoutActivity));
                        break;
                    case "popupMenuItem":
                        intent = new Intent(this, typeof(PopupMenuActivity));
                        break;
                    case "customAnimationItem":
                        intent = new Intent(this, typeof(CustomAnimationActivity));
                        break;
                    case "signaturePadItem":
                        intent = new Intent(this, typeof(SignaturePadActivity));
                        break;
                }
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void Init()
        {
            FillList();
        }

        private void FillList()
        {
            _items = GetItemsFromResources();
            ListAdapter = new MenuAdapter(_items, this);
        }

        private MenuItem[] GetItemsFromResources()
        {
            var names = Resources.GetStringArray(Resource.Array.MenuItemNames);
            var values = Resources.GetStringArray(Resource.Array.MenuItemValues);
            var result = new MenuItem[names.Length];
            for (var index = 0; index < names.Length; index++)
            {
                result[index] = new MenuItem
                {
                    ItemName = names[index],
                    Value = values[index]
                };
            }
            return result;
        }
    }
}

