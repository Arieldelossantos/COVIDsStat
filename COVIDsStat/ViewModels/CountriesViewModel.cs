using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
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

        [Reactive]
        public IEnumerable<CountryStat> _data { get; set; }

        public CountriesViewModel(IApiService apiService)
        {
            _apiService = apiService;
            _data = new List<CountryStat>();
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

            Countries = new ObservableCollection<CountryStat>();

            _data = await _apiService.COVIDApi.GetCountriesStatisticsAsync();

            await UpdateCountryListAsync(_data.Skip(1));            

            IsBusy = false;
        }

        private async Task UpdateCountryListAsync(IEnumerable<CountryStat> countryStat)
        {
            foreach (var item in countryStat)
            {
                try
                {
                    var result = await _apiService.CountryApi.GetCountryInfoAsync(item.Country);
                    item.CountryInfo = result.FirstOrDefault();
                    Countries.Add(item);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"---------- Error with the country: {item.Country}");
                }
            }
        }
    }
}
