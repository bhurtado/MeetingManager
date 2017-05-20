using MeetingManager.Helpers;
using MeetingManager.Pages;
using MeetingManager.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeetingManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;

        ICommand loginCommand;
        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;

            Title = "Social Login";
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn) return Task.FromResult(true);
            return azureService.LoginAsync();
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync())) return;

            var mainPage = new MainPage();
            await navigation.PushAsync(mainPage);

            RemovePageFromStack();
        }

        private void RemovePageFromStack()
        {
            var loginPage = navigation.NavigationStack.FirstOrDefault(p => p is LoginPage);
            if (loginPage == null) return;

            navigation.RemovePage(loginPage);
        }

        public override Task Init()
        {
            throw new NotImplementedException();
        }
    }
}
