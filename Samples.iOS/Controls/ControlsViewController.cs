
using System;
using System.Drawing;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Samples.iOS
{
    public partial class ControlsViewController : UIViewController
    {
        public ControlsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Label1.Text = "Новая надпись";
            View.Add(Label1);

            //			new System.Threading.Thread (new System.Threading.ThreadStart (() => {
            //				InvokeOnMainThread (() => {
            //					Label1.Text = "updated in thread";
            //				});
            //			})).Start ();

            Button1.TouchUpInside += (sender, e) => {
                Label1.Text = "Кнопка 1 нажата";

                // SIMPLE ALERT
                //				UIAlertView alert = new UIAlertView ("Title", "The message", null, "OK", null);
                //				alert.Show();

                // TWO BUTTON ALERT
                //				UIAlertView alert = new UIAlertView ("Alert Title", "Choose from two buttons", null, "OK", new string[] {"Cancel"});
                //				alert.Clicked += (s, b) => {
                //					Label1.Text = "Button " + b.ButtonIndex.ToString () + " clicked";
                //					Console.WriteLine ("Button " + b.ButtonIndex.ToString () + " clicked");
                //				};
                //				alert.Show();

                // THREE BUTTON ALERT
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Пользовательская кнопка нажата",
                    Message = "Это окно содержит пользовательские кнопки"
                };
                alert.AddButton("OK");
                alert.AddButton("Пользовательская кнопка");
                alert.AddButton("Отмена");
                // last button added is the 'cancel' button (index of '2')
                alert.Clicked += delegate (object a, UIButtonEventArgs b) {
                    Console.WriteLine("Кнопка " + b.ButtonIndex.ToString() + " нажата");
                };
                alert.Show();

                TextField.ResignFirstResponder();
                TextView.ResignFirstResponder();
            };

            // SLIDER
            Slider.MinValue = -1;
            Slider.MaxValue = 2;
            Slider.Value = 0.5f;

            // customize
            //			Slider.MinimumTrackTintColor = UIColor.Gray;
            //			Slider.MaximumTrackTintColor = UIColor.Green;

            // BOOLEAN
            Switch.On = true;

            //DISMISS KEYBOARD ON RETURN BUTTON PRESS.
            this.TextField.ShouldReturn += (textField) => {
                textField.ResignFirstResponder();
                return true;
            };

            // LAYOUT OPTIONS
            Label1.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            TextField.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
        }

        partial void slider1_valueChanged(UISlider sender)
        {
            Label2.Text = ((UISlider)sender).Value.ToString();
        }

        partial void button2_TouchUpInside(UIButton sender)
        {
            TextField.ResignFirstResponder();
            TextView.ResignFirstResponder();

            new UIAlertView("Кнопка 2 нажата", "Этот метод создан, как событие",
                null, "Отмена", null)
                .Show();
        }

        //
        // Async/Await example
        //
        async partial void button3_TouchUpInside(UIButton sender)
        {
            TextField.ResignFirstResponder();
            TextView.ResignFirstResponder();

            Label1.Text = "Асинхронный метод запущен";

            await Task.Delay(1000);

            Label1.Text = "1 секунда прошла";

            await Task.Delay(2000);

            Label1.Text = "Ещё 2 секунды прошло";

            await Task.Delay(1000);

            new UIAlertView("Асинхронный метод выполнен", "Этот метод содержит логику асинхронного выполнения",
                null, "Отмена", null)
                .Show();

            Label1.Text = "Асинхронный метод завершён";
        }

        partial void button4_TouchUpInside(UIButton sender)
        {
            //One Button Alert
            UIAlertView alert = new UIAlertView("Загловок", "Сообщение", null, "OK", null);
            alert.Show();

            //Two button Alert
            //			UIAlertView alert = new UIAlertView ("Alert Title", "Choose from two buttons", null, "OK", new string[] {"Cancel"});
            //			alert.Clicked += (s, b) => {
            //				Label1.Text = "Button " + b.ButtonIndex.ToString () + " clicked";
            //				Console.WriteLine ("Button " + b.ButtonIndex.ToString () + " clicked");
            //			};
            //			alert.Show();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}