using System;
using COVIDsStat.Connectivity.Api;
using COVIDsStat.Models;
using ReactiveUI.Fody.Helpers;

namespace COVIDsStat.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        [Reactive]
        public CountryStat Country { get; set; }

        public CountryViewModel(CountryStat _country)
        {
            Country = _country;

            SetNavigationPageTitle("Statistics");
        }
    }
}
