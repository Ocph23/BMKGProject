//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Plugin.CurrentActivity;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Plugin.FirebasePushNotification;
//using Plugin.FirebasePushNotification.Abstractions;
//using Android.Media;

//namespace MobileBMKG.Droid
//{
//    [Application]

//    public class MainApplication : Application, Application.IActivityLifecycleCallbacks

//    {

//        public MainApplication(IntPtr handle, JniHandleOwnership transer)

//          : base(handle, transer)

//        {

//        }



//        public override void OnCreate()

//        {

//            base.OnCreate();

//            RegisterActivityLifecycleCallbacks(this);





//            //Set the default notification channel for your app when running Android Oreo

//            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)

//            {

//                //Change for your default notification channel id here

//                FirebasePushNotificationManager.DefaultNotificationChannelId = "DefaultChannel";



//                //Change for your default notification channel name here

//                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";

//            }





//            //If debug you should reset the token each time.

//#if DEBUG

//            FirebasePushNotificationManager.Initialize(this, new NotificationUserCategory[]

//            {

//            new NotificationUserCategory("message",new List<NotificationUserAction> {

//                new NotificationUserAction("Reply","Reply",NotificationActionType.Foreground),

//                new NotificationUserAction("Forward","Forward",NotificationActionType.Foreground)



//            }),

//            new NotificationUserCategory("request",new List<NotificationUserAction> {

//                new NotificationUserAction("Accept","Accept",NotificationActionType.Default,"check"),

//                new NotificationUserAction("Reject","Reject",NotificationActionType.Default,"cancel")

//            })



//            }, true);

//#else

//	            FirebasePushNotificationManager.Initialize(this,new NotificationUserCategory[]

//		    {

//			new NotificationUserCategory("message",new List<NotificationUserAction> {

//			    new NotificationUserAction("Reply","Reply",NotificationActionType.Foreground),

//			    new NotificationUserAction("Forward","Forward",NotificationActionType.Foreground)



//			}),

//			new NotificationUserCategory("request",new List<NotificationUserAction> {

//			    new NotificationUserAction("Accept","Accept",NotificationActionType.Default,"check"),

//			    new NotificationUserAction("Reject","Reject",NotificationActionType.Default,"cancel")

//			})



//		    },false);

//#endif



//            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>

//            {

//                System.Diagnostics.Debug.WriteLine("NOTIFICATION RECEIVED", p.Data);
//                var title = p.Data["title"];
//                var message = p.Data["body"];
//                SeTOneTimeTimer(title.ToString(), message.ToString());

//            };







//        }

//        public void SeTOneTimeTimer(string title, string message)
//        {
//            var alarmIntent = new Intent(this, typeof(AlarmReceiver));
//            alarmIntent.PutExtra("title", title);
//            alarmIntent.PutExtra("message",message);

//            var pending = PendingIntent.GetBroadcast(this, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);

//            var alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();
//            alarmManager.SetRepeating(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 3000,10*1000, pending);


//        }

//        public override void OnTerminate()

//        {

//            base.OnTerminate();

//            UnregisterActivityLifecycleCallbacks(this);

//        }



//        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)

//        {

//            CrossCurrentActivity.Current.Activity = activity;

//        }



//        public void OnActivityDestroyed(Activity activity)

//        {

//        }



//        public void OnActivityPaused(Activity activity)

//        {

//        }



//        public void OnActivityResumed(Activity activity)

//        {

//            CrossCurrentActivity.Current.Activity = activity;

//        }



//        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)

//        {

//        }



//        public void OnActivityStarted(Activity activity)

//        {

//            CrossCurrentActivity.Current.Activity = activity;

//        }



//        public void OnActivityStopped(Activity activity)

//        {

//        }

//    }




//    [BroadcastReceiver]
//    public class AlarmReceiver : BroadcastReceiver
//    {
//        public override void OnReceive(Context context, Intent intent)
//        {
//                                            var uri = RingtoneManager.GetDefaultUri(RingtoneType.Ringtone);
//            using (Ringtone r = RingtoneManager.GetRingtone(context,uri) )
//            {
//                      if(r!=null)
//                        r.Play();
//            }

//            var message = intent.GetStringExtra("message");
//            var title = intent.GetStringExtra("title");
//            Toast.MakeText(context, message, ToastLength.Long).Show();
            
//        }

        
//    }
//}