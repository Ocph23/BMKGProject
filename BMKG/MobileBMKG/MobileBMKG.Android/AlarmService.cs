using System;
using Android.Media;
using MobileBMKG.Droid;
using MobileBMKG.Services;



[assembly: Xamarin.Forms.Dependency(typeof(AlarmService))]
namespace MobileBMKG.Droid
{
    public class AlarmService  : IAlarmService
    {
        private MediaPlayer _mediaPlayer;

        public void PlaySound()
        {

            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.alarm);

            _mediaPlayer.Start();


            //var duration = 100;
            //var sampleRate = 8000;
            //var numSamples = duration * sampleRate;
            //var sample = new double[numSamples];
            //var freqOfTone = 1900;
            //byte[] generatedSnd = new byte[2 * numSamples];

            //for (int i = 0; i < numSamples; ++i)
            //{
            //    sample[i] = Math.Sin(2 * Math.PI * i / (sampleRate / freqOfTone));
            //}

            //int idx = 0;
            //foreach (double dVal in sample)
            //{
            //    short val = (short)(dVal * 32767);
            //    generatedSnd[idx++] = (byte)(val & 0x00ff);
            //    generatedSnd[idx++] = (byte)((val & 0xff00) >> 8);
            //}

            //var track = new AudioTrack(global::Android.Media.Stream.Music, sampleRate, ChannelOut.Mono, Android.Media.Encoding.Pcm16bit, numSamples, AudioTrackMode.Static);
            //track.Write(generatedSnd, 0, numSamples);
            //track.Play();
        }
    }
}