using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using COVIDsStat.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace COVIDsStat.Views
{
    public partial class CountryPage : ReactiveContentPage<CountryViewModel>
    {
        public CountryPage()
        {
            InitializeComponent();
            this.WhenActivated(
               disposables =>
               {
                   this.OneWayBind(this.ViewModel,
                                   vm => vm.Title,
                                   v => v.countrypage.Title)
                        .DisposeWith(disposables);

               });
        }
    }
}
