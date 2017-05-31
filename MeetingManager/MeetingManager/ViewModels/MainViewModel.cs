using MeetingManager.Databases;
using MeetingManager.Helpers;
using MeetingManager.Models.Mappings;
using MeetingManager.Salas.Models;
using MeetingManager.Salas.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeetingManager.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set { SetValue(ref _userId, value); }
        }

        private string _token;
        public string Token
        {
            get { return _token; }
            set { SetValue(ref _token, value); }
        }

        public ICommand GerenciarSalas { get; }
        public ICommand ReservarSalas { get; }
        public ICommand ListarReservas { get; }

        public MainViewModel()
        {
            GerenciarSalas = new Command(SalasListagemNavegar);
            ReservarSalas = new Command(SalasReservarNavegar);
            ListarReservas = new Command(SalasListarReservasNavegar);
        }

        private void SalasListarReservasNavegar() => AppServices.NavService.NavigationToViewModel<ListagemReservasViewModel, object>(null);

        private void SalasReservarNavegar() => AppServices.NavService.NavigationToViewModel<ReservarViewModel, object>(null);

        private void SalasListagemNavegar() => AppServices.NavService.NavigationToViewModel<ListagemViewModel, object>(null);

        public async override Task Init()
        {
            await Task.Factory.StartNew(() =>
            {
                Title = "Home";
            });
        }
    }
}
