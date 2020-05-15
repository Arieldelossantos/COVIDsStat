using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace COVIDsStat.Controls
{
    public partial class CountryStatCard : ContentView
    {
        public string TitleStatName
        {
            get { return (string)GetValue(TitleStatProperty); }
            set { SetValue(TitleStatProperty, value); }
        }

        public static readonly BindableProperty TitleStatProperty =
            BindableProperty.Create("TitleStatName", typeof(string), typeof(CountryStatCard), string.Empty, propertyChanged: OnTitleStatNameChanged);

        public string StatValue
        {
            get { return (string)GetValue(StatValueProperty); }
            set { SetValue(StatValueProperty, value); }
        }

        public static readonly BindableProperty StatValueProperty =
            BindableProperty.Create("StatValue", typeof(string), typeof(CountryStatCard), "0", propertyChanged: OnStatValueChanged);

        public CountryStatCard()
        {
            InitializeComponent();
        }

        private static void OnTitleStatNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CountryStatCard)bindable;

            if (newValue != null)
                control.title.Text = (string)newValue;
        }

        private static void OnStatValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CountryStatCard)bindable;

            int statValue = 0;

            if(!string.IsNullOrEmpty((string)newValue))
            {
                statValue = int.Parse((string)newValue);
            }

            control.info.Text = statValue.ToString("N0");
        }
    }
}
