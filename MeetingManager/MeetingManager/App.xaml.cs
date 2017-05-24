
using MeetingManager.Pages;
using MeetingManager.Services;
using MeetingManager.Services.Interfaces;
using MeetingManager.ViewModels;
using Xamarin.Forms;

namespace MeetingManager
{
    public partial class App : Application
    {
        private NavigationPage _startPage;
        public App()
        {
            InitializeComponent();
            _startPage = new NavigationPage(new LoginPage());
            MainPage = _startPage;
        }

        protected override void OnStart()
        {
            var services = DependencyService.Get<IAppServices>();

            var navService = services.NavService as NavService;
            navService.Navigation = _startPage.Navigation;

            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(LoginViewModel), typeof(LoginPage));
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
