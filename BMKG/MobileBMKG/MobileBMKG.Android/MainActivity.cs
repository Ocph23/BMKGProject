using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Microsoft.AppCenter.Push;

namespace MobileBMKG.Droid
{
    [Activity(Label = "MobileBMKG", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           // FirebasePushNotificationManager.ProcessIntent(this, Intent);

            LoadApplication(new App());
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            Push.CheckLaunchedFromNotification(this, intent);

        }


    }
}