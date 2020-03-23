using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COVIDsStat
{
    public partial class App : Application
    {
        AppBootstrapper bootstrapper;
        public App()
        {
            InitializeComponent();

           
        }

        protected override void OnStart()
        {
            bootstrapper = new AppBootstrapper();

            MainPage = bootstrapper.CreateMainPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
