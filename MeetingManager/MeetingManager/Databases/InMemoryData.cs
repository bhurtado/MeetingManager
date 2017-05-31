using MeetingManager.Models.Enums;
using MeetingManager.Salas.Models;
using System;
using System.Collections.Generic;

namespace MeetingManager.Databases
{
    public static class InMemoryData
    {
        public static List<Sala> Salas { get; set; } = new List<Sala>();
        public static List<Reserva> Reservas { get; set; } = new List<Reserva>();

        static InMemoryData()
        {
            var sala =
                new Sala
                {
                    Nome = "Sala de Reunião 1",
                    Descricao = "Sala de reunião com 6 cadeiras e uma mesa central",
                    Tipo = SalaTipo.Reuniao,
                    IsProjetor = false,
                    IsTelefone = true,
                    HoraInicial = "08:00:00",
                    HoraFinal = "10:00:00"
                };
            Salas.Add(sala);

            //Reservas.Add(new Reserva
            //{
            //    Sala = sala,
            //    Data = DateTime.Now.AddDays(1),
            //    Duracao = 2,
            //});
        }
    }
}
