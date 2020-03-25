using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using COVIDsStat.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace COVIDsStat.Views
{
    public partial class CountriesPage : ReactiveContentPage<CountriesViewModel>
    {
        public CountriesPage()
        {
            InitializeComponent();
            this.WhenActivated(
                disposables =>
                {
                    this.OneWayBind(this.ViewModel,
                                  vm => vm.IsBusy,
                                  v => v.countriespage.IsBusy)
                    .DisposeWith(disposables);

                    this.OneWayBind(this.ViewModel,
                                   vm => vm.IsBusy,
                                   v => v.countriesList.IsRefreshing)
                    .DisposeWith(disposables);

                    this.OneWayBind(this.ViewModel,
                                    vm => vm.Title,
                                    v => v.countriespage.Title)
                    .DisposeWith(disposables);

                    this.OneWayBind(this.ViewModel,
                                    vm => vm.Countries,
                                    v => v.countriesList.ItemsSource)
                    .DisposeWith(disposables);

                    this.Bind(this.ViewModel,
                                    vm => vm.SelectedCountry,
                                    v => v.countriesList.SelectedItem)
                    .DisposeWith(disposables);

                });
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // This is to avoid the orange on selected background color on android
            if (e.SelectedItem == null) return;

            ((ListView)sender).SelectedItem = null;
        }
    }
}
