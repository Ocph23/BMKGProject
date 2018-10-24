using MobileBMKG.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileBMKG.Models
{
    public class InfoGempa 
    {
        public List<Gempa> Gempas { get; set; }
    }

    public class Gempa : BaseViewModel
    {
        private string tanggal;
        private string wilayah;
        private string wilayah1;
        private string wilayah2;
        private string wilayah3;
        private string wilayah4;
        private string wilayah5;
        private string jam;
        private string lintang;
        private point _point;
        private string bujur;
        private string magnitude;
        private string kedalaman;

        public string Tanggal { get => tanggal; set=>SetProperty(ref tanggal,value); }

        public string Jam { get => jam; set=>SetProperty(ref jam,value); }

        public string Lintang { get => lintang; set=>SetProperty(ref lintang,value); }

        public point Point { get => _point; set=>SetProperty(ref _point,value); }

        public string Bujur { get => bujur; set=>SetProperty(ref bujur,value); }

        public string Magnitude { get => magnitude; set=>SetProperty(ref magnitude,value); }

        public string Kedalaman { get => kedalaman; set=>SetProperty(ref kedalaman,value); }

        public string Wilayah { get => wilayah; set=>SetProperty(ref wilayah, value); }

        public string Wilayah1 { get => wilayah1; set=>SetProperty(ref wilayah1, value); }

        public string Wilayah2 { get => wilayah2; set=>SetProperty(ref wilayah2, value); }

        public string Wilayah3 { get => wilayah3; set=>SetProperty(ref wilayah3, value); }

        public string Wilayah4 { get => wilayah4; set=>SetProperty(ref wilayah4, value); }

        public string Wilayah5 { get => wilayah5; set=>SetProperty(ref wilayah5, value); }

        public string LastUpdatedBy { get => tanggal; set=>SetProperty(ref tanggal,value); }
    }

    public class point:BaseViewModel
    {
        private string _cordinat;

        public string coordinates { get => _cordinat; set=>SetProperty(ref _cordinat,value); }
    }
}
