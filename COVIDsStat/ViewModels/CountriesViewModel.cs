using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using COVIDsStat.Connectivity.Api;
using COVIDsStat.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace COVIDsStat.ViewModels
{
    public class CountriesViewModel: BaseViewModel
    {
        private readonly IApiService _apiService;

        [Reactive]
        public CountryStat SelectedCountry { get; set; }

        [Reactive]
        public ObservableCollection<CountryStat> Countries { get; set; } 

        public CountriesViewModel(IApiService apiService)
        {
            _apiService = apiService;

            RegisterEvents();
            LoadData();
        }

        private void RegisterEvents()
        {
            this.WhenAnyValue(x => x.SelectedCountry)
                .Where(x => x != null)
                .Subscribe(NavigateToCountryPage);
        }

        private void NavigateToCountryPage(CountryStat country) => NavigateToPage(new CountryViewModel(SelectedCountry));

        private async void LoadData()
        {
            SetNavigationPageTitle("Countries");

            IsBusy = true;

            var _data = await _apiService.COVIDApi.GetCountriesStatisticsAsync();

            Countries = new ObservableCollection<CountryStat>(_data.OrderBy(x=>x.Country));

            IsBusy = false;

        }

    }
}
