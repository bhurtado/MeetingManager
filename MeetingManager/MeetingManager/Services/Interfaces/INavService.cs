using MeetingManager.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeetingManager.Services.Interfaces
{
    public interface INavService
    {
        Task PreviousPage();
        Task BackToMainPage();
        Task NavigationToViewModel<ViewModel, TParameter>(TParameter parameter)
            where ViewModel : BaseViewModel;
        Task RemoveFromStack<TParameter>()
            where TParameter : Page;
    }
}
