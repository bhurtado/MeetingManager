using MeetingManager.Helpers;
using MeetingManager.Pages;
using MeetingManager.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeetingManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAppServices _appServices;

        ICommand loginCommand;
        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public LoginViewModel()
        {
            _appServices = DependencyService.Get<IAppServices>();
            Title = "Social Login";
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn) return Task.FromResult(true);
            return _appServices.AzureService.LoginAsync();
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync())) return;

            var mainPage = new MainPage();
            await _appServices.NavService.NavigationToViewModel<MainViewModel, object>(null);

            await _appServices.NavService.RemoveFromStack<LoginPage>();
        }

        public async override Task Init()
        {
            // TODO: 
            await Task.Factory.StartNew(() => { });
        }
    }
}
