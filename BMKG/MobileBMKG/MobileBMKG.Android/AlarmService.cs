using System;
using System.Threading.Tasks;
using Android.App;
using Android.Media;

using Android.Widget;
using MobileBMKG.Droid;
using MobileBMKG.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AlarmService))]
namespace MobileBMKG.Droid
{
    public class AlarmService  : IAlarmService
    {
        private MediaPlayer _mediaPlayer;

        public void PlaySound()
        {
            _mediaPlayer = MediaPlayer.Create(Android.App.Application.Context, Resource.Raw.alarm);
            _mediaPlayer.Start();
        }
    }
}