using System;

namespace MeetingManager.Salas.Models
{
    public class Reserva
    {
        public Sala Sala { get; set; }
        public DateTime Data { get; set; }
        public int Duracao { get; set; }
    }
}
