using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileBMKG.Views;
using MobileBMKG.Models;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileBMKG
{
    public partial class App : Application
    {
        private SignalRClientConnection SignalRConnection;
        public App()
        {
            InitializeComponent();
            SignalRConnection = new SignalRClientConnection();
            SignalRConnection.NewReceived += SignalRConnection_NewReceived;
            
            MainPage = new Home();
        }

        private void SignalRConnection_NewReceived(object sender, Gempa e)
        {
            var view = MainPage.BindingContext as HomeViewModel;
            view.SetValues(e);
        }

        protected override void OnStart()
        {
          //  SignalRConnection.StartListening();

            AppCenter.Start("android=bdcdf782-fe9b-4198-a50f-552a56f3df06;", typeof(Analytics), typeof(Crashes),typeof(Push));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
