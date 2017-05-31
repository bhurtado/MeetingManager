using MeetingManager.Databases;
using MeetingManager.Models.Mappings;
using MeetingManager.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace MeetingManager.Salas.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        public ObservableCollection<ManutencaoViewModel> Salas { get; }

        private ManutencaoViewModel _salaSelecionada;

        public ManutencaoViewModel SalaSelecionada
        {
            get { return _salaSelecionada; }
            set { SetValue(ref _salaSelecionada, value); }
        }

        public ICommand Cadastrar { get; }
        public ICommand Editar { get; }

        public ListagemViewModel()
        {
            Salas = new ObservableCollection<ManutencaoViewModel>(InMemoryData.Salas.MapToManutencaoViewModelList());

            Cadastrar = new Command(async () => await SalasCadastrarNavegar());
            Editar = new Command<ManutencaoViewModel>(async vm => await SalasEditarNavegar(vm));
        }

        private async Task SalasCadastrarNavegar()
        {
            await AppServices.NavService.NavigationToViewModel<ManutencaoViewModel, object>(null);
        }

        private async Task SalasEditarNavegar(ManutencaoViewModel viewModel)
        {
            await AppServices.NavService.NavigationToViewModel<ManutencaoViewModel, ManutencaoViewModel>(viewModel);
        }

        public override Task Init()
        {
            Title = "Listagem de Salas";
            return Task.FromResult<object>(null);
        }
    }
}
