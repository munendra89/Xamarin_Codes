using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MyTube.Helpers.OAuth;

namespace MyTube.Droid
{
	[Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
	[IntentFilter(
	new[] { Intent.ActionView },
	Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
	DataSchemes = new[] { "com.googleusercontent.apps.142480171629-5tnuosrs9q7r1pm70a05mugugk18bn86" },
	DataPath = "/oauth2redirect")]
	public class CustomUrlSchemeInterceptorActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			global::Android.Net.Uri uri_android = Intent.Data;
			// Convert Android.Net.Url to Uri
			var uri = new Uri(Intent.Data.ToString());
			// Load redirectUrl page
			AuthenticationState.Authenticator.OnPageLoading(uri);
			var intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
			this.Finish();
		}
	}
}