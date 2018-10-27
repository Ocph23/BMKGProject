using MobileBMKG.Models;
using MobileBMKG.Services;
using MobileBMKG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileBMKG.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
            this.BindingContext = new HomeViewModel();
		}
	}


    public class HomeViewModel : Gempa
    {
        public void SetValues(Gempa value)
        {
            this.Kedalaman = value.Kedalaman;
            this.Bujur = value.Bujur;
            this.Tanggal = value.Tanggal;
            this.Jam = value.Jam;
            this.Magnitude = value.Magnitude;
            this.Wilayah1 = value.Wilayah1;
            playSound();
        }




        public  void playSound()
        {
            DependencyService.Get<IAlarmService>().PlaySound();
        }
    }
}