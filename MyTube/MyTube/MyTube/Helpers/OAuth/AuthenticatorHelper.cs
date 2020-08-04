using Google.Apis.Oauth2.v2;
using Google.Apis.YouTube.v3;
using MyTube.AppConstants;
using MyTube.Helpers.OAuth;
using System;
using Xamarin.Auth;
using Xamarin.Forms;

namespace MyTube.Helpers
{
    public static class OAuthAuthenticatorHelper
    {
        public static readonly string[] GoogleAPIScopes =
        {
            YouTubeService.Scope.Youtube,
            Oauth2Service.Scope.UserinfoProfile

        };
        private static OAuth2Authenticator oAuth2Authenticator;
        /// <summary>
        /// This method return Oauth2Authenticator instace.
        /// </summary>
        /// <param name="loginProvider"></param>
        /// <returns></returns>
        public static OAuth2Authenticator CreateOAuth2()
        {
            string clientId = null;
            string redirectUri = null;
            GetPlatformCilentId(ref clientId, ref redirectUri);

            

        oAuth2Authenticator = new OAuth2Authenticator(
                clientId: clientId,
                clientSecret: null,
                scope: string.Join(" ",GoogleAPIScopes),
                authorizeUrl: new Uri(OauthConstants.AUTHORIZE_URL),
                redirectUrl: new Uri(redirectUri),
                accessTokenUrl: new Uri(OauthConstants.ACCESS_TOKEN_URL),
                getUsernameAsync: null,
                isUsingNativeUI: true)
            {
                AllowCancel = true,
                ShowErrors = false,
                ClearCookiesBeforeLogin = true
            };

            AuthenticationState.Authenticator = oAuth2Authenticator;
            return oAuth2Authenticator;

        }

        /// <summary>
        /// This function return clientId and redirecuri based on device runtime platform
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="redirectUri"></param>
        private static void GetPlatformCilentId(ref string clientId, ref string redirectUri)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = OauthConstants.IOS_CLIENT_ID;
                    redirectUri = OauthConstants.IOS_REDIRECT_URL;
                    break;

                case Device.Android:
                    clientId = OauthConstants.ANDROID_CLIENT_ID;
                    redirectUri = OauthConstants.ANDROID_REDIRECT_URL;
                    break;
                case Device.UWP:
                    clientId = OauthConstants.UWP_CLIENT_ID;
                    redirectUri = OauthConstants.UWP_REDIRECT_URL;
                    break;
            }
        }
    }
}
