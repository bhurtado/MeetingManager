using MeetingManager.Salas.Models;
using MeetingManager.Salas.ViewModels;
using System.Collections.Generic;

namespace MeetingManager.Models.Mappings
{
    public static class ModelMapping
    {
        public static Sala MapToSala(this ManutencaoViewModel viewModel)
        {
            return new Sala
            {
                Nome = viewModel.Nome,
                Descricao = viewModel.Descricao,
                IsProjetor = viewModel.IsProjetor,
                IsTelefone = viewModel.IsTelefone,
                Tipo = viewModel.Tipo
            };
        }

        public static ManutencaoViewModel MapToManutencaoViewModel(this Sala model)
        {
            return new ManutencaoViewModel
            {
                Nome = model.Nome,
                Descricao = model.Descricao,
                IsProjetor = model.IsProjetor,
                IsTelefone = model.IsTelefone,
                Tipo = model.Tipo
            };
        }

        public static List<ManutencaoViewModel> MapListTo(this List<Sala> salas)
        {
            var list = new List<ManutencaoViewModel>();

            foreach (var sala in salas)
            {
                list.Add(sala.MapToManutencaoViewModel());
            }

            return list;
        }
    }
}
