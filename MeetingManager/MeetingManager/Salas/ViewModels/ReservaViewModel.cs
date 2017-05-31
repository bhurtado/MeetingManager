using MeetingManager.Salas.Models;
using MeetingManager.ViewModels;
using System;
using System.Threading.Tasks;

namespace MeetingManager.Salas.ViewModels
{
    public class ReservaViewModel : BaseViewModel
    {
        private Sala _sala;
        public Sala Sala
        {
            get { return _sala; }
            set { SetValue(ref _sala, value); }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { SetValue(ref _data, value); }
        }

        private int _duracao;
        public int Duracao
        {
            get { return _duracao; }
            set { SetValue(ref _duracao, value); }
        }

        public string Descricao { get { return $"{_sala.Nome} / {_sala.Tipo}"; } }
        public string Detalhe { get { return $"{_sala.HoraInicial} - {_data.ToString("dd/MM/yyyy")} Duração: {_duracao} hora(s)"; } }

        public override Task Init()
        {
            throw new NotImplementedException();
        }
    }
}
