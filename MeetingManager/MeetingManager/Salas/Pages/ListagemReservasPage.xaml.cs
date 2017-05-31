using MeetingManager.Salas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeetingManager.Salas.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListagemReservasPage : ContentPage
    {
        public ListagemReservasViewModel ViewModel => BindingContext as ListagemReservasViewModel;
        public ListagemReservasPage()
        {
            InitializeComponent();
            BindingContext = new ListagemReservasViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }
    }
}