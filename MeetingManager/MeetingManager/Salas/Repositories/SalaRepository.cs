using MeetingManager.Databases;
using MeetingManager.Salas.Models;
using MeetingManager.Salas.Repositories;
using MeetingManager.Salas.Repositories.Interfaces;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(SalaRepository))]
namespace MeetingManager.Salas.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        public bool Salvar(Sala sala)
        {
            var salaAntiga = InMemoryData.Salas.FirstOrDefault(s => s.Nome == sala.Nome);
            if (salaAntiga == null)
            {
                InMemoryData.Salas.Add(sala);
            } else
            {
                salaAntiga.Descricao = sala.Descricao;
                salaAntiga.IsProjetor = sala.IsProjetor;
                salaAntiga.IsTelefone = sala.IsTelefone;
                salaAntiga.Tipo = sala.Tipo;
                salaAntiga.HoraInicial = sala.HoraInicial;
                salaAntiga.HoraFinal = sala.HoraFinal;
            }
            return true;
        }
    }
}
