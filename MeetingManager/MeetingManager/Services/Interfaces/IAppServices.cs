using MeetingManager.Salas.Services.Interfaces;

namespace MeetingManager.Services.Interfaces
{
    public interface IAppServices
    {
        INavService NavService { get; }
        AzureService AzureService { get; }
        ISalaService Salas { get; }
    }
}
