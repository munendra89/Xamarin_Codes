using System;
using Xamarin.Auth;
using Xamarin.Forms;
using System.Diagnostics;
using MyTube.Helpers;
using Xamarin.Essentials;
using Newtonsoft.Json;
using MyTube.AppConstants;
using MyTube.DataModel;
using MyTube.Views;
using MyTube.Helpers.OAuth;
using Xamarin.Auth.Presenters;

namespace MyTube.ViewModels
{
    class LoginPageViewModel
    {
        OAuth2Authenticator oAuth2Authenticator;

        private void Authenticate()
        {
            oAuth2Authenticator = OAuthAuthenticatorHelper.CreateOAuth2();
            oAuth2Authenticator.Completed += OAuth2Authenticator_Completed;
            oAuth2Authenticator.Error += OAuth2Authenticator_Error;
            var presenter = new OAuthLoginPresenter();
            AuthenticationState.Authenticator = oAuth2Authenticator;
            presenter.Login(oAuth2Authenticator);
        }
        

        #region COMMANDS
     
        public Command GoogleClickedCommand => new Command(GoogleClicked);
       

        #endregion

        #region AUTH COMPLETED

        private async void OAuth2Authenticator_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            OAuth2Authenticator authenticator = (OAuth2Authenticator)sender;
            if (authenticator != null)
            {
                authenticator.Completed -= OAuth2Authenticator_Completed;
                authenticator.Error -= OAuth2Authenticator_Error;
            }
            UserInfo user = null;
            if (e.IsAuthenticated)
            {
                try
                {
                    await SecureStorage.SetAsync("Token", JsonConvert.SerializeObject(e.Account.Properties));
                    var request = new OAuth2Request("GET", new Uri(OauthConstants.USER_INFO_URL), null, e.Account);
                    var response = await request.GetResponseAsync();
                    if (response != null)
                    {
                        // Deserialize the data and store it in the account store
                        string userJson = await response.GetResponseTextAsync();
                        user = JsonConvert.DeserializeObject<UserInfo>(userJson);
                        await SecureStorage.SetAsync("USER_INFO",userJson);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                await Application.Current.MainPage.Navigation.PushAsync(new VideoHomePage());
            }
            else
            {
                oAuth2Authenticator.OnCancelled();
                oAuth2Authenticator = default;
            }
        }

        #endregion

        #region AUTH ERRORS

        private async void OAuth2Authenticator_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            OAuth2Authenticator authenticator = (OAuth2Authenticator)sender;
            if (authenticator != null)
            {
                authenticator.Completed -= OAuth2Authenticator_Completed;
                authenticator.Error -= OAuth2Authenticator_Error;
            }

            string title = "Authentication Error";
            string msg = e.Message;

            Debug.WriteLine($"Error authenticating ! Message: {e.Message}");
            await Application.Current.MainPage.DisplayAlert(title, msg, "OK");
        }

        #endregion

        #region METHODS

        private void GoogleClicked()
        {
            Authenticate();
        }

        #endregion
    }
}

