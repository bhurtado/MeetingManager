using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingManager.Salas.Models;
using MeetingManager.Salas.Services.Interfaces;
using Xamarin.Forms;
using MeetingManager.Salas.Services;
using MeetingManager.Salas.Repositories.Interfaces;

[assembly:Dependency(typeof(ReservaService))]
namespace MeetingManager.Salas.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;

        public ReservaService()
        {
            _repository = DependencyService.Get<IReservaRepository>();
        }

        public bool Reservar(Reserva novaReserva)
        {
            return _repository.Reservar(novaReserva);
        }
    }
}
