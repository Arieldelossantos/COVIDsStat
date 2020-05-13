using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using COVIDsStat.Connectivity.Api;
using COVIDsStat.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace COVIDsStat.ViewModels
{
    public class CountriesViewModel : BaseViewModel
    {
        [Reactive]
        public CountryStat SelectedCountry { get; set; }

        [Reactive]
        public ObservableCollection<CountryStat> Countries { get; set; }

        [Reactive]
        public int ItemTreshold { get; set; }

        [Reactive]
        public bool LoadingMore { get; set; }

        [Reactive]
        public ReactiveCommand<Unit, Unit> ItemTresholdReachedCommand { get; set; }

        private readonly IApiService _apiService;
        private IEnumerable<CountryStat> _countryData;
        private IEnumerable<CountryStat> _temp;
        private int LoadLimit;
        public CountriesViewModel(IApiService apiService)
        {
            _apiService = apiService;

            Countries = new ObservableCollection<CountryStat>();
            Xamarin.Forms.BindingBase.EnableCollectionSynchronization(Countries, null, ObservableCollectionCallback);

            RegisterEvents();
            LoadData();
        }

        private void RegisterEvents()
        {
            ItemTresholdReachedCommand = ReactiveCommand.CreateFromTask(ItemsTresholdReached);

            ItemTresholdReachedCommand.Subscribe();

            this.WhenAnyValue(x => x.ItemTreshold)
                .Where(x => x > 0)
                .Subscribe(_ => ItemTresholdReachedCommand.Execute());

            this.WhenAnyValue(x => x.SelectedCountry)
                .Where(x => x != null)
                .Subscribe(NavigateToCountryPage);
        }

        private void NavigateToCountryPage(CountryStat country) => NavigateToPage(new CountryViewModel(SelectedCountry));

        private async void LoadData()
        {
            SetNavigationPageTitle("Countries");
            ItemTreshold = 1;
            LoadLimit = 20;
            _countryData = new List<CountryStat>();

            IsBusy = true;

            _countryData = await _apiService.COVIDApi.GetCountriesStatisticsAsync();

            _temp = await GetCountryDataAsync();

            await UpdateWithFlagCountryListAsync(_temp);

            IsBusy = false;
        }

        private async Task ItemsTresholdReached()
        {
            if (IsBusy)
                return;

            LoadingMore = true;

            try
            {
                var nextIndex = Countries.Count+1;
                var items = await GetCountryDataAsync(nextIndex);

                await UpdateWithFlagCountryListAsync(items);
                var listItemsCount = items.Count();

                
                if (listItemsCount < LoadLimit)
                {
                    ItemTreshold = -1;
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                LoadingMore = false;
            }
        }

        private async Task UpdateWithFlagCountryListAsync(IEnumerable<CountryStat> countryStat)
        {
            foreach (var item in countryStat)
            {
                try
                {
                    var result = await _apiService.CountryApi.GetCountryInfoAsync(item.Country);
                    item.CountryInfo = result.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"---------- Error with the country: {item.StrCountry}");
                }
                finally
                {
                    if (!string.IsNullOrEmpty(item.StrCountry))
                        Countries.Add(item);
                }
            }
        }

        public async Task<IEnumerable<CountryStat>> GetCountryDataAsync(int lastIndex = 0)
        {
            return await Task.FromResult(_countryData.Skip(lastIndex).Take(LoadLimit));
        }

        private void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            // `lock` ensures that only one thread access the collection at a time
            lock (collection)
            {
                accessMethod?.Invoke();
            }
        }
    }
}
