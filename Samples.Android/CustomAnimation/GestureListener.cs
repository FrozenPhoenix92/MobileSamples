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
    public class GestureListener : GestureDetector.SimpleOnGestureListener
    {
        private readonly CustomAnimationActivity _parentActivity;
        private View _lastView;

        public GestureListener(CustomAnimationActivity parentActivity)
        {
            _parentActivity = parentActivity;
        }

        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            if (Math.Abs(velocityX) < 500) return false;
            _lastView = _parentActivity.LastView;
            var animationSet = new AnimationSet(true)
            {
                Interpolator = new AccelerateDecelerateInterpolator(),
                Duration = 300,
                FillAfter = true
            };
            var animationRotate = new RotateAnimation(0, Math.Sign(velocityX)*15);
            var animationTranslate = new TranslateAnimation(0, Math.Sign(velocityX)*400, 
                0, 10);
            var animationAlpha = new AlphaAnimation(1, 0);
            animationSet.AddAnimation(animationRotate);
            animationSet.AddAnimation(animationTranslate);
            animationSet.AddAnimation(animationAlpha);
            animationSet.AnimationEnd += AnimationSet_AnimationEnd;
            _lastView.StartAnimation(animationSet);
            return true;
        }

        private void AnimationSet_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
            _parentActivity.Views.Remove(_lastView);
            //_parentActivity.RelativeLayout.RemoveView(_lastView);
            _lastView.Dispose();
            _parentActivity.SelectedViewIndex = -1;
        }
    }
}