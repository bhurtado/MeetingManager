using System;
using System.Threading.Tasks;
using MeetingManager.Services;
using MeetingManager.Services.Interfaces;
using MeetingManager.ViewModels;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

[assembly:Dependency(typeof(NavService))]
namespace MeetingManager.Services
{
    public class NavService : INavService
    {
        private readonly bool Animated = true;
        private readonly IDictionary<Type, Type> _viewMapping = new Dictionary<Type, Type>();

        public INavigation Navigation { get; set; }

        public void RegisterViewMapping(Type viewModel, Type view) => _viewMapping.Add(viewModel, view);

        public async Task PreviousPage()
        {
            if (Navigation?.NavigationStack.Count > 0)
                await Navigation.PopAsync(Animated);
        }

        public async Task NavigationToViewModel<ViewModel, TParameter>(TParameter parameter) 
            where ViewModel : BaseViewModel
        {
            if(_viewMapping.TryGetValue(typeof(ViewModel), out Type viewType))
            {
                var constructor = viewType.GetTypeInfo()
                                          .DeclaredConstructors
                                          .FirstOrDefault(dc => !dc.GetParameters().Any());

                var view = constructor.Invoke(null) as Page;
                await Navigation.PushAsync(view, Animated);
            }

            var viewModel = Navigation.NavigationStack.Last().BindingContext as BaseViewModel<TParameter>;
            if (viewModel != null) await viewModel.Init(parameter);
        }

        public async Task BackToMainPage() => await Navigation.PopToRootAsync(Animated);

        public Task RemoveFromStack<TParameter>()
            where TParameter : Page
        {
            var page = Navigation.NavigationStack.FirstOrDefault(p => p is TParameter);
            if (page != null) Navigation.RemovePage(page);

            return Task.FromResult(0);
        }
    }
}
