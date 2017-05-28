using MeetingManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeetingManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel ViewModel => BindingContext as LoginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }
    }
}