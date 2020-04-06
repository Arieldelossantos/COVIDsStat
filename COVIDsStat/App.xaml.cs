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

            SetExperimentalFlags();
        }

        private void SetExperimentalFlags()
        {
            Xamarin.Forms.Device.SetFlags(new[] {
                "CollectionView_Experimental"});
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
