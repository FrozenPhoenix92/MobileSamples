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
using SignaturePad;

namespace Samples.Droid.SignaturePad
{
    [Activity(Label = "Демонстрация SignaturePad", ParentActivity = typeof (MainActivity))]
    public class SignaturePadActivity : Activity
    {
        private SignaturePadView _signaturePadView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            InitComponents();
        }

        private void InitComponents()
        {
            _signaturePadView = new SignaturePadView(this);
            AddContentView(_signaturePadView,
                new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 
                ViewGroup.LayoutParams.MatchParent));
        }
    }
}