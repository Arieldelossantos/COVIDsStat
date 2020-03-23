using System;
using COVIDsStat.Connectivity.Api;
using COVIDsStat.ViewModels;
using COVIDsStat.Views;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace COVIDsStat
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; protected set; }

        public AppBootstrapper()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            // IScreen 
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            //Services
            Locator.CurrentMutable.RegisterLazySingleton(() => new ApiService(), typeof(IApiService));
           
            // Views and ViewModels
            Locator.CurrentMutable.Register(() => new CountriesPage(), typeof(IViewFor<CountriesViewModel>));
           
        }

        public Page CreateMainPage()
        {
            var apiService = Locator.Current.GetService<IApiService>();
           
            NavigateToMainPage(apiService);

            return new ReactiveUI.XamForms.RoutedViewHost();
        }

        public void NavigateToMainPage(IApiService apiService)
        {
            Router = new RoutingState();

            Router
                .NavigateAndReset
                .Execute(new CountriesViewModel(apiService))
                .Subscribe();
        }
    }
}
