using MeetingManager.Models.Enums;
using MeetingManager.Models.Mappings;
using MeetingManager.Salas.Pages;
using MeetingManager.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace MeetingManager.Salas.ViewModels
{
    public class ManutencaoViewModel : BaseViewModel<ManutencaoViewModel>
    {
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetValue(ref _nome, value); }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { SetValue(ref _descricao, value); }
        }

        private bool _isProjetor;
        public bool IsProjetor
        {
            get { return _isProjetor; }
            set { SetValue(ref _isProjetor, value); }
        }

        private bool _isTelefone;
        public bool IsTelefone
        {
            get { return _isTelefone; }
            set { SetValue(ref _isTelefone, value); }
        }

        private SalaTipo _tipo;
        public SalaTipo Tipo
        {
            get { return _tipo; }
            set { SetValue(ref _tipo, value); }
        }

        private string _horaInicial;
        public string HoraInicial
        {
            get { return _horaInicial; }
            set { SetValue(ref _horaInicial, value); }
        }

        private string _horaFinal;
        public string HoraFinal
        {
            get { return _horaFinal; }
            set { SetValue(ref _horaFinal, value); }
        }

        public string Horario { get { return $"Tipo: {Tipo} {_horaInicial} ~ {_horaFinal}"; } }

        public ICommand Salvar { get; }

        public ManutencaoViewModel()
        {
            Salvar = new Command(async () => await SalvarAsync());
        }

        private async Task SalvarAsync()
        {
            var sala = this.MapToSala();
            AppServices.Salas.Salvar(sala);
            await AppServices.NavService.RemoveFromStack<ListagemPage>();
            await AppServices.NavService.NavigationToViewModel<ListagemViewModel, object>(null);
            await AppServices.NavService.RemoveFromStack<ManutencaoPage>();
        }

        public override Task Init(ManutencaoViewModel viewModel)
        {
            Title = "Manutenção de Salas";

            if (viewModel != null)
            {
                Nome = viewModel.Nome;
                Descricao = viewModel.Descricao;
                IsProjetor = viewModel.IsProjetor;
                IsTelefone = viewModel.IsTelefone;
                Tipo = viewModel.Tipo;
                HoraInicial = viewModel.HoraInicial;
                HoraFinal = viewModel.HoraFinal;
            }
            return Task.FromResult<object>(null);
        }
    }
}
