using System;
using System.Collections.ObjectModel;
using System.Linq;
using COVIDsStat.Connectivity.Api;
using COVIDsStat.Models;
using ReactiveUI.Fody.Helpers;

namespace COVIDsStat.ViewModels
{
    public class CountriesViewModel: BaseViewModel
    {
        private readonly IApiService _apiService;

        [Reactive]
        public ObservableCollection<CountryStat> Countries { get; set; } 

        public CountriesViewModel(IApiService apiService)
        {
            _apiService = apiService;

            LoadData();
        }

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
