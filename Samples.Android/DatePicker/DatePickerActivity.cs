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

namespace Samples.Droid.DatePicker
{
    [Activity(Label = "Домонстрация выбора даты", ParentActivity = typeof(MainActivity))]
    public class DatePickerActivity : Activity
    {
        private TextView _dateDisplayTextView;
        private Button _pickDateButton;
        private DateTime _date;

        private const int DateDialogId = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DatePickerLayout);

            InitComponents();
            _date = DateTime.Now;
        }

        private void InitComponents()
        {
            _dateDisplayTextView = FindViewById<TextView>(Resource.Id.dateDisplay);
            UpdateDisplayDate();

            _pickDateButton = FindViewById<Button>(Resource.Id.pickDate);
            _pickDateButton.Click += pickDateButton_Click;
        }

        private void pickDateButton_Click(object sender, EventArgs e)
        {
            (new DatePickerDialog(this, OnDateSet, _date.Year, _date.Month - 1, _date.Day)).Show();
        }

        private void UpdateDisplayDate()
        {
            _dateDisplayTextView.Text = _date.ToString("d");
        }

        private void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            _date = e.Date;
            UpdateDisplayDate();
        }
    }
}