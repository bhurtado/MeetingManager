using System;
using MeetingManager.Models.Enums;

namespace MeetingManager.Salas.Models
{
    public class Sala
    {
        public string Nome { get; internal set; }
        public string Descricao { get; internal set; }
        public bool IsProjetor { get; internal set; }
        public bool IsTelefone { get; internal set; }
        public SalaTipo Tipo { get; internal set; }
    }
}
