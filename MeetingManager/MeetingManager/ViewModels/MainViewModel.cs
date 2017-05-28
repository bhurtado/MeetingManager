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

        public MainViewModel()
        {
            GerenciarSalas = new Command(SalasListagemNavegar);
        }

        private void SalasListagemNavegar() => AppServices.NavService.NavigationToViewModel<ListagemViewModel, List<ManutencaoViewModel>>(InMemoryData.Salas.MapListTo());

        public async override Task Init()
        {
            await Task.Factory.StartNew(() =>
            {
                Title = "Home";
            });
        }
    }
}
