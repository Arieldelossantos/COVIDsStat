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

                    this.Bind(this.ViewModel,
                                   vm => vm.IsBusy,
                                   v => v.activityIndicator.IsVisible)
                    .DisposeWith(disposables);

                    this.Bind(this.ViewModel,
                                   vm => vm.IsBusy,
                                   v => v.activityIndicator.IsRunning)
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
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.SelectedCountry = null;           
        }
    }
}
