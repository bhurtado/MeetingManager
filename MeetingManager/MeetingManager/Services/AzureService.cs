using MeetingManager.Helpers;
using MeetingManager.Services;
using MeetingManager.Social.Authentications;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]
namespace MeetingManager.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "https://paulokinjomaratonaxamarin.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if(!string.IsNullOrWhiteSpace(Settings.AuthToken) &&
               !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", "Problema ao efetuar o seu login, tente novamente!", "OK");
                });
                return false;
            }

            Settings.AuthToken = user.MobileServiceAuthenticationToken;
            Settings.UserId = user.UserId;

            return true;
        }
    }
}
