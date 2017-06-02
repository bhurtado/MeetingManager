using MeetingManager.Databases;
using MeetingManager.Models.Mappings;
using MeetingManager.Salas.Models;
using MeetingManager.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeetingManager.Salas.ViewModels
{
    //public class ReservarManutencaoViewModel : BaseViewModel<>
    //{

    //}
        public class ReservarViewModel : BaseViewModel
    {
        public ObservableCollection<Sala> Salas { get; }

        private Sala _salaSelecionada;
        public Sala SalaSelecionada
        {
            get { return _salaSelecionada; }
            set { SetValue(ref _salaSelecionada, value); }
        }        

        public ICommand Reservar { get; }

        public ReservarViewModel()
        {
            Salas = new ObservableCollection<Sala>(InMemoryData.Salas.ToList());
            Reservar = new Command<Sala>(reserva => ReservarSalas(reserva));
        }

        private void ReservarSalas(Sala reservada)
        {
            var reserva = new ReservaViewModel{Sala = reservada};
            AppServices.Reservas.Reservar(reserva.MapToReserva());
            Salas.Remove(reservada);
        }

        public override Task Init()
        {
            Title = "Reserva de Salas";
            return Task.FromResult<object>(null);
        }
    }
}
