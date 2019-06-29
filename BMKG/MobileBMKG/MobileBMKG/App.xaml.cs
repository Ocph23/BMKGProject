using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileBMKG.Views;
using MobileBMKG.Models;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Distribute;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using MobileBMKG.Services;
using Microsoft.AppCenter.Push;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileBMKG
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
          //  SignalRConnection = new SignalRClientConnection();
           // SignalRConnection.NewReceived += SignalRConnection_NewReceived;
            MainPage = new MainPage();
            MessagingCenter.Subscribe<MessagingCenterAlert>(this, "message", async (message) =>
            {
                await Current.MainPage.DisplayAlert(message.Title, message.Message, message.Cancel);

            });

        
        }

        //private void SignalRConnection_NewReceived(object sender, Gempa e)
        //{
        //    var view = MainPage.BindingContext as HomeViewModel;
        //    view.SetValues(e);
        //}

        protected  override void OnStart()
        {
            //if (!AppCenter.Configured)
            //{
            //    //Push.PushNotificationReceived += (sender, e) =>
            //    //{
            //    //    // Add the notification message and title to the message
            //    //    //if (e.Message != null)
            //    //    //{

            //    //    //    var message = new MessagingCenterAlert() { Message = e.Message, Title = e.Title, Cancel = "OK" };
            //    //    //    MessagingCenter.Send(message, "message");
            //    //    //}
            //    //    //var a = e.CustomData;
            //    //    //var summary = a.ToString();

            //    //    //// If there is custom data associated with the notification,
            //    //    //// print the entries
            //    //    //if (e.CustomData != null)
            //    //    //{
            //    //    //    summary += "\n\tCustom data:\n";
            //    //    //    foreach (var key in e.CustomData.Keys)
            //    //    //    {
            //    //    //        summary += $"\t\t{key} : {e.CustomData[key]}\n";
            //    //    //    }
            //    //    //}

            //    //    //// Send the notification summary to debug output
            //    //    //System.Diagnostics.Debug.WriteLine(summary);


            //    //};
            //}
            AppCenter.Start("058d09ee-6088-4bdc-83b0-f5b6dd9cda79", typeof(Push));
           // AppCenter.Start("android=bdcdf782-fe9b-4198-a50f-552a56f3df06", typeof(Push),typeof(Crashes), typeof(Analytics));
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

    public class MessagingCenterAlert
    {
        /// <summary>
        /// Init this instance.
        /// </summary>
        public static void Init()
        {
            var time = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance cancel/OK text.
        /// </summary>
        /// <value><c>true</c> if this instance cancel; otherwise, <c>false</c>.</value>
        public string Cancel { get; set; }

        /// <summary>
        /// Gets or sets the OnCompleted Action.
        /// </summary>
        /// <value>The OnCompleted Action.</value>
        public Action OnCompleted { get; set; }
    }
}
