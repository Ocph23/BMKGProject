using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileBMKG.Views;
using MobileBMKG.Models;

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
            SignalRConnection.StartListening();
            
            MainPage = new Home();
        }

        private void SignalRConnection_NewReceived(object sender, Gempa e)
        {
            var view = MainPage.BindingContext as HomeViewModel;
            view.SetValues(e);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
