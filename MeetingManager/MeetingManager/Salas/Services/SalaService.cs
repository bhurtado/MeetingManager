using System;
using MeetingManager.Salas.Models;
using MeetingManager.Salas.Services;
using MeetingManager.Salas.Services.Interfaces;
using Xamarin.Forms;
using MeetingManager.Salas.Repositories.Interfaces;

[assembly: Dependency(typeof(SalaService))]
namespace MeetingManager.Salas.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _repository;

        public SalaService()
        {
            _repository = DependencyService.Get<ISalaRepository>();
        }

        public bool Cadastrar(Sala sala) => _repository.Salvar(sala);
    }
}
