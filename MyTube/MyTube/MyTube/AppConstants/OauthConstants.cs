using System;
using System.Collections.Generic;
using System.Text;

namespace MyTube.AppConstants
{
    class OauthConstants
    {
		public static string APP_NAME = "MyTube";

		// OAuth Client Ids
		public static string ANDROID_CLIENT_ID = "142480171629-5tnuosrs9q7r1pm70a05mugugk18bn86.apps.googleusercontent.com";
		public static string IOS_CLIENT_ID = "142480171629-t5e7v0oaridrhg04rfjbe181h0fv20kk.apps.googleusercontent.com";
		public static string UWP_CLIENT_ID = "142480171629-gcfeih5o2q5qguhf4decn24k89no5ko1.apps.googleusercontent.com";

		// These values do not need changing
		public static string AUTHORIZE_URL = "https://accounts.google.com/o/oauth2/auth";
		public static string ACCESS_TOKEN_URL = "https://www.googleapis.com/oauth2/v4/token";
		public static string USER_INFO_URL = "https://www.googleapis.com/oauth2/v2/userinfo";

		// Set these to reversed iOS client ids, with :/oauth2redirect appended
		public static string ANDROID_REDIRECT_URL = "com.googleusercontent.apps.142480171629-5tnuosrs9q7r1pm70a05mugugk18bn86:/oauth2redirect";
		public static string IOS_REDIRECT_URL = "com.googleusercontent.apps.142480171629-t5e7v0oaridrhg04rfjbe181h0fv20kk:/oauth2redirect";
		public static string UWP_REDIRECT_URL = "com.googleusercontent.apps.142480171629-gcfeih5o2q5qguhf4decn24k89no5ko1:/oauth2redirect";
	}
}
