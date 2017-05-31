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
    public partial class ReservarPage : ContentPage
    {
        public ReservarViewModel ViewModel => BindingContext as ReservarViewModel;
        public ReservarPage()
        {
            InitializeComponent();
            BindingContext = new ReservarViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }

        private void OnReservaSelecionada(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.Reservar.Execute(e.SelectedItem);
        }
    }
}