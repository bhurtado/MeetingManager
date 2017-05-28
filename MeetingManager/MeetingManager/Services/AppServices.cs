using System;
using MeetingManager.Salas.Services.Interfaces;
using MeetingManager.Services;
using MeetingManager.Services.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppServices))]
namespace MeetingManager.Services
{
    public class AppServices : IAppServices
    {
        public INavService NavService => DependencyService.Get<INavService>();

        public AzureService AzureService => DependencyService.Get<AzureService>();

        public ISalaService Salas => DependencyService.Get<ISalaService>();
    }
}
