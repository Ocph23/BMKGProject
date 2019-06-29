using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MobileBMKG.Droid
{
    [BroadcastReceiver]
    public class NotifyBroadcastReceived : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {

            //Toast.MakeText(context, "Received intent!", ToastLength.Long).Show();
            // displayAlert(context, intent);
            Handler mHandler = new Handler();
            LayoutInflater inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            var toas = new Toast(context);
            toas.SetGravity(GravityFlags.Center, 0, 0);
            toas.Duration = ToastLength.Long;
            toas.View = inflater.Inflate(Resource.Layout.custom_toast, null);
            TextView txt = (TextView)toas.View.FindViewById(Resource.Id.textView1);
            txt.Text = "ini adalah Text";
            toas.Show();
            displayAlert(context, intent);
        }


        global::Android.Net.Uri soundUri = global::Android.Net.Uri.Parse("android.resource://" + "com.ocph23.bmkg" + "/raw/alarm");
        private async void displayAlert(Context context, Intent intentx)
        {
                


            var bigStyle = new NotificationCompat.BigTextStyle().BigText("Unlike the other notification styles, MediaStyle allows you to also modify the collapsed-size content view by specifying three action buttons that should also appear in the collapsed view. To do so, provide the action button indices to ");
            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            // PendingIntent pendingIntent =  PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            // Instantiate the builder and set notification elements, including pending intent:
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context, MainActivity.CHANNEL_ID)
                //  .SetContentIntent(pendingIntent)
                .SetContentTitle("Judul")
                .SetContentText("Test")
                .SetAutoCancel(true)
                .SetStyle(bigStyle)
                .SetPriority(NotificationCompat.PriorityHigh)
                .SetSmallIcon(Resource.Drawable.xamarin_logo);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                builder.SetVisibility(NotificationCompat.VisibilityPublic);
            }

            Intent intent = new Intent(Intent.ActionView,Android.Net.Uri.Parse("https://www.journaldev.com/15126/swift-function"));
            PendingIntent pendingIntent = PendingIntent.GetActivity(context, 0, intent, 0);

            Intent buttonIntent = new Intent(context,typeof(MainActivity));
        //buttonIntent.putExtra("notificationId", NOTIFICATION_ID);
        PendingIntent dismissIntent = PendingIntent.GetBroadcast(context, 0, buttonIntent, 0);

        builder.AddAction(Resource.Drawable.abc_ic_menu_overflow_material, "VIEW", pendingIntent);
        builder.AddAction(Resource.Drawable.abc_ic_menu_cut_mtrl_alpha, "DISMISS", dismissIntent);

            
            NotificationManager notificationManager =context.GetSystemService(Context.NotificationService) as NotificationManager;


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



























            //var title = intent.GetStringExtra("title");
            //var message = intent.GetStringExtra("message");
            //Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(new ContextThemeWrapper(context, Resource.Style.AlertDialogCustom));
            //AlertDialog alert = dialog.Create();
            //alert.SetInverseBackgroundForced(true);
            //alert.SetTitle("Title");
            //alert.SetMessage("Simple Alert");
            //alert.SetCancelable(true);

            //alert.SetButton("OK", (c, ev) =>
            //{
            //   // context.Finish();
            //});
            //alert.Show();
            //await Task.Delay(TimeSpan.FromSeconds(2));
            //if (alert.IsShowing)
            //{
            //    alert.Dismiss();
            //}

        }
    }
}