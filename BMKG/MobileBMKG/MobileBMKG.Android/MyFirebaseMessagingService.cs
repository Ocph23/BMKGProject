using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using Xamarin.Forms;

namespace MobileBMKG.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        global::Android.Net.Uri soundUri = global::Android.Net.Uri.Parse("android.resource://" + "com.ocph23.bmkg" + "/raw/alarm");

        public override void OnCreate()
        {
            base.OnCreate();
            if (MainActivity.IsBacground)
            {
                var powerManager = (PowerManager)GetSystemService(PowerService);
                var wakeLock = powerManager.NewWakeLock(WakeLockFlags.ScreenDim | WakeLockFlags.AcquireCausesWakeup, "Info Tsunami");
                wakeLock.Acquire();
                //Intent myIntent = new Intent(this, typeof(NotifyReceived));
                //myIntent.SetFlags(ActivityFlags.NewTask);
                //StartActivity(myIntent);
                AlarmManager manager = (AlarmManager)GetSystemService(Context.AlarmService);
                Intent myIntent = new Intent(this, typeof(NotifyBroadcastReceived));
                PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 0, myIntent, PendingIntentFlags.UpdateCurrent);
                myIntent.SetFlags(ActivityFlags.ClearTop);
                manager.Set(AlarmType.RtcWakeup, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), pendingIntent);
            }
        }


        private async void displayAlert(Context context, Intent intentx)
        {

            var bigStyle = new NotificationCompat.BigTextStyle().BigText("Telah Terjadi Tsunami ");
            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            // PendingIntent pendingIntent =  PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            // Instantiate the builder and set notification elements, including pending intent:
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context, MainActivity.CHANNEL_ID)
                //  .SetContentIntent(pendingIntent)
                .SetContentTitle("Sirene Tsunami")
                .SetContentText("Test")
                .SetAutoCancel(true)
                .SetStyle(bigStyle)
                .SetPriority(NotificationCompat.PriorityHigh)
                .SetSmallIcon(Resource.Drawable.xamarin_logo);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                builder.SetVisibility(NotificationCompat.VisibilityPublic);
            }

            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://inatews.bmkg.go.id/terkini.php"));
            PendingIntent pendingIntent = PendingIntent.GetActivity(context, 0, intent, 0);

            Intent buttonIntent = new Intent(context, typeof(MainActivity));
            //buttonIntent.putExtra("notificationId", NOTIFICATION_ID);
            PendingIntent dismissIntent = PendingIntent.GetBroadcast(context, 0, buttonIntent, 0);

            builder.AddAction(Resource.Drawable.abc_ic_menu_overflow_material, "VIEW", pendingIntent);
            builder.AddAction(Resource.Drawable.abc_ic_menu_cut_mtrl_alpha, "DISMISS", dismissIntent);
            NotificationManager notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            try
            {
                Ringtone r = RingtoneManager.GetRingtone(MainActivity.Instance, soundUri);
                r.Play();
            }
            catch (Exception e)
            {
                Log.Debug("Service", e.Data.ToString());
            }


            notificationManager.Notify(MainActivity.NOTIFICATION_ID, builder.Build());

        }


        public override void OnMessageReceived(RemoteMessage message)
        {
            foreach (var item in message.Data)
            {

            }
            base.OnMessageReceived(message);
          
            //SendNotification(message.GetNotification().Title, message.GetNotification().Body,message.Data);

        }

        void SendNotification(string title, string messageBody, IDictionary<string, string> data)
        {

            AlarmManager manager = (AlarmManager)GetSystemService(Context.AlarmService);
            Intent myIntent = new Intent(this, typeof(NotifyReceived));
            PendingIntent pendingIntent = PendingIntent.GetActivities(this, 0, new Intent[] { myIntent }, PendingIntentFlags.OneShot);
            manager.SetRepeating(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 3000, 60 * 1000, pendingIntent);





            global::Android.Net.Uri soundUri = global::Android.Net.Uri.Parse("android.resource://" + "com.ocph23.bmkg" + "/raw/alarm");

            //Intent intent = new Intent(this, typeof(MainActivity));

            //// Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            //const int pendingIntentId = 0;
            //PendingIntent pendingIntent =
            //    PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            //// Instantiate the builder and set notification elements, including pending intent:
            //NotificationCompat.Builder builder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
            //    .SetContentIntent(pendingIntent)
            //    .SetContentTitle(title)
            //    .SetContentText(messageBody)
            //    .SetSmallIcon(Resource.Drawable.xamarin_logo);

            //// Build the notification:
            //Notification notification = builder.Build();

            //// Get the notification manager:
            //NotificationManager notificationManager =
            //    GetSystemService(Context.NotificationService) as NotificationManager;

            //// Publish the notification:

            //try
            //{
            //    Ringtone r = RingtoneManager.GetRingtone(MainActivity.Instance, soundUri);
            //    r.Play();
            //}
            //catch (Exception e)
            //{
            //    Log.Debug("Service", e.Data.ToString());
            //}


            //notificationManager.Notify(MainActivity.NOTIFICATION_ID, notification);
            //Intent alarm = new Intent(this, typeof(MainActivity));
            //bool alarmRunning = (PendingIntent.GetBroadcast(this, 0, alarm, PendingIntentFlags.NoCreate) != null);
            //if (alarmRunning == false)
            //{
            //    PendingIntent pendingIntent1 = PendingIntent.GetBroadcast(this, 0, alarm, 0);
            //    AlarmManager alarmmanger = (AlarmManager)GetSystemService(Context.AlarmService);
            //    //alarmmanger.SetRepeating(AlarmType.RtcWakeup,SystemClock.ElapsedRealtime(), 1800000,pendingIntent);
            //    //alarmmanger.SetRepeating(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime(), 1000, pendingIntent);
            //    alarmmanger.SetInexactRepeating(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime(), 1000, pendingIntent1);
            //}

        }
    }
    
}