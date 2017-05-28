using MeetingManager.Models.Enums;
using MeetingManager.Salas.Models;
using System;
using System.Collections.Generic;

namespace MeetingManager.Databases
{
    public static class InMemoryData
    {
        public static List<Sala> Salas { get; set; } = new List<Sala>();

        static InMemoryData()
        {
            Salas.Add(new Sala
            {
                Nome = "Sala de Reunião 1",
                Descricao = "Sala de reunião com 6 cadeiras e uma mesa central",
                Tipo = SalaTipo.Reuniao,
                IsProjetor = false,
                IsTelefone = true,
            });
        }
    }
}
