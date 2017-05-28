using MeetingManager.Salas.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeetingManager.Salas.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListagemPage : ContentPage
    {
        public ListagemViewModel ViewModel => BindingContext as ListagemViewModel;
        public ListagemPage()
        {
            InitializeComponent();
            BindingContext = new ListagemViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }

        private void OnSalaSelecionada(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.Editar.Execute(e.SelectedItem);
        }
    }
}