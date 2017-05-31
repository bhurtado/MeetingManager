using MeetingManager.Models.Enums;
using System;

namespace MeetingManager.Salas.Models
{
    public class Sala
    {
        public string Nome { get; internal set; }
        public string Descricao { get; internal set; }
        public bool IsProjetor { get; internal set; }
        public bool IsTelefone { get; internal set; }
        public SalaTipo Tipo { get; internal set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }

        public string Detail { get { return $"{HoraInicial} ~ {HoraFinal}"; } }
    }
}
