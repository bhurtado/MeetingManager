using MeetingManager.Salas.Models;

namespace MeetingManager.Salas.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        bool Reservar(Reserva novaReserva);
    }
}
