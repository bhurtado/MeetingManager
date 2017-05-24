namespace MeetingManager.Services.Interfaces
{
    public interface IAppServices
    {
        INavService NavService { get; }
        AzureService AzureService { get; }
    }
}
