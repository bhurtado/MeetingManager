﻿using MeetingManager.ViewModels;
using Xamarin.Forms;

namespace MeetingManager
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel => BindingContext as MainViewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }
    }
}
