using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace Samples.Droid.CustomAnimation
{
    [Activity(Label = "ƒемонстраци€ пользовательской анимации", ParentActivity = typeof (MainActivity))]
    public class CustomAnimationActivity : Activity
    {
        private Button _addButton;
        private Button _showAllButton;
        internal RelativeLayout RelativeLayout;

        internal List<View> Views;
        internal View LastView;
        internal int SelectedViewIndex;
        private int _selectedViewTop;
        private int _selectedViewLeft;
        public GestureDetector GestureDetector;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomAnimationLayout);

            InitComponents();

            Views = new List<View>();
            GestureDetector = new GestureDetector(this, new GestureListener(this));
            SelectedViewIndex = -1;
        }

        private void InitComponents()
        {
            _addButton = FindViewById<Button>(Resource.Id.buttonAdd);
            _addButton.Click += addButton_Click;

            _showAllButton = FindViewById<Button>(Resource.Id.buttonShowAll);
            _showAllButton.Click += showAllButton_Click;

            RelativeLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayout);
            RelativeLayout.SetClipChildren(false);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (SelectedViewIndex != -1)
                ShowAll();

            var view = LayoutInflater.Inflate(Resource.Layout.PageLayout, RelativeLayout, false);
            view.Touch += View_Touch;
            Views.Add(view);

            var textView = view.FindViewById<TextView>(Resource.Id.textViewContent);
            textView.Text = Views.Count + " fsdfsdfsdfsfs";
            var layoutParameters = new RelativeLayout.LayoutParams((int)(RelativeLayout.Width*0.8),
                (int)(RelativeLayout.Height*0.8))
            {
                LeftMargin = (int)(RelativeLayout.Width * 0.1),
                TopMargin = _addButton.Height + 50 * Views.Count
            };
            RelativeLayout.AddView(view, layoutParameters);
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            _showAllButton.Enabled = false;
            ShowAll();
        }

        private void View_Touch(object sender, View.TouchEventArgs e)
        {
            if (SelectedViewIndex != -1) return;
            var view = sender as View;
            for (var index = 0; index < Views.Count; index++)
                if (Views[index] == view)
                {
                    LastView = Views[index];
                    SelectedViewIndex = index;
                }
            if (LastView == null) return;
            var flingResult = GestureDetector.OnTouchEvent(e.Event);
            if (!flingResult)
            {
                if (e.Event.Action != MotionEventActions.Up)
                {
                    SelectedViewIndex = -1;
                    LastView = null;
                    return;
                }
            }
            else return;
            for (var index = 0; index < Views.Count; index++)
            {
                if (Views[index] != LastView)
                    MinimizeView(Views[index]);
                else
                {
                    SelectedViewIndex = index;
                    MaximizeView(Views[index]);
                }
            }
            _showAllButton.Enabled = true;
        }

        private void ShowAll()
        {
            for (var index = 0; index < Views.Count; index++)
            {
                if (index != SelectedViewIndex)
                    ExpandMinimizedView(Views[index]);
                else
                    CollapseSelectedView(Views[index]);
            }
            SelectedViewIndex = -1;
        }

        private void MaximizeView(View view)
        {
            var animationSet = new AnimationSet(true)
            {
                Interpolator = new AccelerateDecelerateInterpolator(),
                Duration = 500,
                FillAfter = true
            };
            var scaleAnimation = new ScaleAnimation(1f, 1.25f, 1f, 1.25f, Dimension.RelativeToSelf, 0f,
                Dimension.RelativeToSelf, 0f);
            _selectedViewTop = view.Top;
            _selectedViewLeft = view.Left;
            var translateAnimation = new TranslateAnimation(Dimension.RelativeToSelf, 0, Dimension.Absolute, -view.Left,
                Dimension.RelativeToSelf, 0, Dimension.Absolute, -view.Top + _addButton.Height);
            animationSet.AddAnimation(scaleAnimation);
            animationSet.AddAnimation(translateAnimation);
            
            view.StartAnimation(animationSet);
        }

        private void MinimizeView(View view)
        {
            view.Visibility = ViewStates.Invisible;
        }

        private void ExpandMinimizedView(View view)
        {
            view.Visibility = ViewStates.Visible;
        }

        private void CollapseSelectedView(View view)
        {
            /*var scaleAnimation = new ScaleAnimation(1.25f, 1f, 1.25f, 1f, Dimension.RelativeToSelf, 0f,
                Dimension.RelativeToSelf, 0f);

            view.StartAnimation(scaleAnimation);*/
            view.ClearAnimation();
        }
    }
}