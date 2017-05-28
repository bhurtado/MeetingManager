using MeetingManager.Helpers;
using MeetingManager.Pages;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeetingManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {        
        ICommand loginCommand;
        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));        

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn) return Task.FromResult(true);
            return AppServices.AzureService.LoginAsync();
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync())) return;

            var mainPage = new MainPage();
            await AppServices.NavService.NavigationToViewModel<MainViewModel, object>(null);

            await AppServices.NavService.RemoveFromStack<LoginPage>();
        }

        public override Task Init()
        {
            Title = "Login";
            return Task.FromResult<object>(null);
        }
    }
}
