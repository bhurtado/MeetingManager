using System;
using System.Threading.Tasks;
using MeetingManager.ViewModels;
using System.Collections.ObjectModel;
using MeetingManager.Databases;
using MeetingManager.Models.Mappings;

namespace MeetingManager.Salas.ViewModels
{
    public class ListagemReservasViewModel : BaseViewModel
    {
        public ObservableCollection<ReservaViewModel> Reservas { get; }

        public ListagemReservasViewModel()
        {
            Reservas = new ObservableCollection<ReservaViewModel>(InMemoryData.Reservas.MapToReservaViewModelList());
        }

        public override Task Init()
        {
            Title = "Listagem de Reservas";
            return Task.FromResult<object>(null);
        }
    }
}
