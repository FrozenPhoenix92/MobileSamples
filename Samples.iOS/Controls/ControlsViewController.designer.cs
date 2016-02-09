// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Samples.iOS
{
	[Register ("ControlsViewController")]
	partial class ControlsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton Button1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton Button2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton Button3 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton Button4 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton Button5 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView ControlsView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView Image { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Label1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Label2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISlider Slider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch Switch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField TextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView TextView { get; set; }

		[Action ("button2_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void button2_TouchUpInside (UIButton sender);

		[Action ("button3_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void button3_TouchUpInside (UIButton sender);

		[Action ("button4_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void button4_TouchUpInside (UIButton sender);

		[Action ("slider1_valueChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void slider1_valueChanged (UISlider sender);

		void ReleaseDesignerOutlets ()
		{
			if (Button1 != null) {
				Button1.Dispose ();
				Button1 = null;
			}
			if (Button2 != null) {
				Button2.Dispose ();
				Button2 = null;
			}
			if (Button3 != null) {
				Button3.Dispose ();
				Button3 = null;
			}
			if (Button4 != null) {
				Button4.Dispose ();
				Button4 = null;
			}
			if (Button5 != null) {
				Button5.Dispose ();
				Button5 = null;
			}
			if (ControlsView != null) {
				ControlsView.Dispose ();
				ControlsView = null;
			}
			if (Image != null) {
				Image.Dispose ();
				Image = null;
			}
			if (Label1 != null) {
				Label1.Dispose ();
				Label1 = null;
			}
			if (Label2 != null) {
				Label2.Dispose ();
				Label2 = null;
			}
			if (Slider != null) {
				Slider.Dispose ();
				Slider = null;
			}
			if (Switch != null) {
				Switch.Dispose ();
				Switch = null;
			}
			if (TextField != null) {
				TextField.Dispose ();
				TextField = null;
			}
			if (TextView != null) {
				TextView.Dispose ();
				TextView = null;
			}
		}
	}
}
