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
    public class FormElements2TabFragment : Fragment
    {
        private View _view;
        private Context _context;

        private Spinner _spinner;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            _view = inflater.Inflate(Resource.Layout.Tab2, container, false);
            _context = container.Context;

            InitComponents();

            return _view;
        }

        private void InitComponents()
        {
            _spinner = _view.FindViewById<Spinner>(Resource.Id.spinner);
            var adapter = ArrayAdapter.CreateFromResource(_context, 
                Resource.Array.planetsArray, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner.Adapter = adapter;
            _spinner.ItemSelected += spinner_ItemSelected;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = (Spinner)sender;
            var toast = $"Планета {spinner.GetItemAtPosition(e.Position)}";
            Toast.MakeText(_context, toast, ToastLength.Long).Show();
        }
    }
}