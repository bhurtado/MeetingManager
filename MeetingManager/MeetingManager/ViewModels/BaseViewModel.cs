using MeetingManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeetingManager.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly IAppServices AppServices;        

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetValue(ref _title, value); }
        }

        private bool _busy;
        public bool IsBusy
        {
            get { return _busy; }
            set { SetValue(ref _busy, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            AppServices = DependencyService.Get<IAppServices>();
        }

        public abstract Task Init();

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;

            backingField = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public abstract class BaseViewModel<TParam> : BaseViewModel
    {
        public override async Task Init()
        {
            await Init(default(TParam));
        }

        public abstract Task Init(TParam param);
    }
}
