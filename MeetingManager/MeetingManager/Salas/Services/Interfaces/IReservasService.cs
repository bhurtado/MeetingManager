using MeetingManager.Salas.Models;

namespace MeetingManager.Salas.Services.Interfaces
{
    public interface IReservaService
    {
        bool Reservar(Reserva novaReserva);
    }
}
