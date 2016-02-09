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
    public class FormElementsTabFragment : Fragment
    {
        private View _view;
        private Context _context;

        private Button _customButton;
        private CheckBox _checkBox;
        private EditText _editText;
        private RadioButton _radioRed;
        private RadioButton _radioBlue;
        private ToggleButton _toggleButton;
        private Switch _switch;
        private RatingBar _ratingBar;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            _view = inflater.Inflate(Resource.Layout.Tab, container, false);
            _context = container.Context;

            InitComponents();

            return _view;
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutBoolean("CheckBox", _checkBox.Enabled);
            outState.PutString("EditText", _editText.Text);

            base.OnSaveInstanceState(outState);
        }

        private void InitComponents()
        {
            _customButton = _view.FindViewById<Button>(Resource.Id.customButton);
            _customButton.Click += customButton_Click;

            _checkBox = _view.FindViewById<CheckBox>(Resource.Id.checkBox);
            _checkBox.Click += checkBox_Click;

            _editText = _view.FindViewById<EditText>(Resource.Id.editText);
            _editText.KeyPress += editText_KeyPress;

            _radioRed = _view.FindViewById<RadioButton>(Resource.Id.radio_red);
            _radioRed.Click += RadioButton_Click;
            _radioBlue = _view.FindViewById<RadioButton>(Resource.Id.radio_blue);
            _radioBlue.Click += RadioButton_Click;

            _toggleButton = _view.FindViewById<ToggleButton>(Resource.Id.toggleButton);
            _toggleButton.Click += toggleSwitchButtons_Click;
            _switch = _view.FindViewById<Switch>(Resource.Id.switchButton);
            _switch.Click += toggleSwitchButtons_Click;

            _ratingBar = _view.FindViewById<RatingBar>(Resource.Id.ratingBar);
            _ratingBar.RatingBarChange += ratingBar_RatingBarChange;
        }

        private void customButton_Click(object sender, EventArgs e)
        {
            Toast.MakeText(_context, "Пользовательская кнопка нажата", ToastLength.Short).Show();
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            Toast.MakeText(_context, 
                _checkBox.Checked ? "Галочка поставлена" : "Галочка не поставлена", ToastLength.Short).Show();
        }

        private void editText_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action != KeyEventActions.Down || e.KeyCode != Keycode.Enter) return;
            Toast.MakeText(_context, _editText.Text, ToastLength.Short).Show();
            e.Handled = true;
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            Toast.MakeText(_context, rb.Text, ToastLength.Short).Show();
        }

        private void toggleSwitchButtons_Click(object sender, EventArgs e)
        {
            var button = (ICheckable)sender;
            if (button.Checked)
                Toast.MakeText(_context, "Вкл", ToastLength.Short).Show();
            else
                Toast.MakeText(_context, "Выкл", ToastLength.Short).Show();
        }

        private void ratingBar_RatingBarChange(object sender, RatingBar.RatingBarChangeEventArgs e)
        {
            Toast.MakeText(_context, "Новый рейтинг: " + _ratingBar.Rating, ToastLength.Short).Show();
        }
    }
}