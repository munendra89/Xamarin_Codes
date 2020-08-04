using MyTube.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyTube.ViewModels
{
    public class UserInfoViewModel: BaseViewModel
    {
        private string  _userName;
        private string _userImageUrl;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string UserImageUrl {
            get => _userImageUrl;
            set
            {
                _userImageUrl = value;
                OnPropertyChanged("UserImageUrl");
            }
        }

        public UserInfoViewModel()
        {
            GetUserInfoFromSecureStorage();
        }

        private async void GetUserInfoFromSecureStorage()
        {
            string userJson = await SecureStorage.GetAsync("USER_INFO");
            var user = JsonConvert.DeserializeObject<UserInfo>(userJson);
            UserImageUrl = user.Picture.ToString();
            UserName = user.Name;
        }

        public Command PageClose => new Command(PageClosing);

        private void PageClosing()
        {
            Application.Current.MainPage.Navigation.PopModalAsync(true);
        }
    }
}
