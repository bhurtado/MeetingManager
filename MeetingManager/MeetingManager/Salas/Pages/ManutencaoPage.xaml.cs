using MeetingManager.Salas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeetingManager.Salas.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManutencaoPage : ContentPage
    {
        public ManutencaoViewModel ViewModel => BindingContext as ManutencaoViewModel;
        public ManutencaoPage()
        {
            InitializeComponent();
            BindingContext = new ManutencaoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }
    }
}