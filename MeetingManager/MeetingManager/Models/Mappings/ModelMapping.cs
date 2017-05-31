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
                Tipo = viewModel.Tipo,
                HoraInicial = viewModel.HoraInicial,
                HoraFinal = viewModel.HoraFinal
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
                Tipo = model.Tipo,
                HoraInicial = model.HoraInicial,
                HoraFinal = model.HoraFinal
            };
        }

        public static List<ManutencaoViewModel> MapToManutencaoViewModelList(this List<Sala> salas)
        {
            var list = new List<ManutencaoViewModel>();

            foreach (var sala in salas)
            {
                list.Add(sala.MapToManutencaoViewModel());
            }

            return list;
        }

        public static List<ReservaViewModel> MapToReservaViewModelList(this List<Reserva> reservas)
        {
            var list = new List<ReservaViewModel>();

            foreach (var reserva in reservas)
            {
                list.Add(reserva.MapToReservaViewModel());
            }

            return list;
        }

        public static ReservaViewModel MapToReservaViewModel(this Reserva model)
        {
            return new ReservaViewModel
            {
                Sala = model.Sala,
                Data = model.Data,
                Duracao = model.Duracao,
            };
        }

        public static Reserva MapToReserva(this ReservaViewModel viewModel)
        {
            return new Reserva
            {
                Sala = viewModel.Sala,
                Duracao = viewModel.Duracao,
                Data = viewModel.Data
            };
        }
    }
}
