using MeetingManager.Databases;
using MeetingManager.Salas.Models;
using MeetingManager.Salas.Repositories;
using MeetingManager.Salas.Repositories.Interfaces;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(ReservaRepository))]
namespace MeetingManager.Salas.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        public bool Reservar(Reserva novaReserva)
        {
            novaReserva.Data = DateTime.Now;
            novaReserva.Duracao = 1;
            InMemoryData.Reservas.Add(novaReserva);
            return true;
        }
    }
}
