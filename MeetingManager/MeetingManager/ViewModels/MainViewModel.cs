using MeetingManager.Helpers;
using System;
using System.Threading.Tasks;

namespace MeetingManager.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set { SetValue(ref _userId, value); }
        }

        private string _token;
        public string Token
        {
            get { return _token; }
            set { SetValue(ref _token, value); }
        }

        public async override Task Init()
        {
            await Task.Factory.StartNew(() =>
            {
                UserId = Settings.UserId;
                Token = Settings.AuthToken;
            });
        }
    }
}
