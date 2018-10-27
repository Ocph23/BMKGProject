using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace BMKG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            GetCuaca();
            //StringBuilder sb = new StringBuilder();
            //string URLString = "http://data.bmkg.go.id/pesan.txt";
            //XmlTextReader reader = new XmlTextReader(URLString);
            //while (reader.Read())
            //{
            //    switch (reader.NodeType)
            //    {
            //        case XmlNodeType.Element: // The node is an element.
            //            console.AppendText("<" + reader.Name);

            //            while (reader.MoveToNextAttribute()) // Read the attributes.
            //                console.AppendText(" " + reader.Name + "='" + reader.Value + "'");
            //            console.AppendText(">");
            //            console.AppendText(">");
            //            break;
            //        case XmlNodeType.Text: //Display the text in each element.
            //            console.AppendText(reader.Value);
            //            break;
            //        case XmlNodeType.EndElement: //Display the end of the element.
            //            console.AppendText("</" + reader.Name);
            //            console.AppendText(">");
            //            break;
            //    }
            //    console.AppendText("\r");
            //}
         
        }

        class cuaca
        {
            public string Nama { get; internal set; }
            public string Suhu { get; internal set; }
            public string Kondisi { get; internal set; }
            public string SuhuTerendah { get; internal set; }
            public string Tertinggi { get; internal set; }
            public string Kelembaban { get; internal set; }
        }

        class DataCuaca
        {
           public List<cuaca> Datas { get; set; } = new List<cuaca>();
            public string Tanggal { get; internal set; }
        }

        private void GetCuaca()
        {
            try
            {
                string URLString = "http://data.bmkg.go.id/pesan.txt";
                string input = new WebClient().DownloadString(@"http://www.bmkg.go.id/cuaca/prakiraan-cuaca.bmkg?Kota=Jayapura&AreaID=501447&Prov=24");
                var doc = new HtmlDocument();
                doc.LoadHtml(input);
                List<DataCuaca> listData = new List<DataCuaca>();


                for (var i =2;i<=3;i++)
                {

                    var Data = new DataCuaca();
                    HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//div[@id='TabPaneCuaca"+i+"'] //div[@class='service-block clearfix']").ToArray();

                    
                    var tanggals = doc.DocumentNode.SelectNodes("//a[@href='#TabPaneCuaca" + i + "']").FirstOrDefault();
                    Data.Tanggal = tanggals.InnerText;
                    foreach (var item in nodes)
                    {
                        var har = item.Descendants("h2").Select(x => x.InnerText.Trim()).ToArray();
                        var result = item.Descendants("div").Select(x => x.InnerText.Trim()).ToArray();
                        var data = result[1].Split('\n').Select(x => x.Trim()).ToArray()[1].Split("&deg;C".ToArray()).Where(x => !string.IsNullOrEmpty(x)).ToArray();

                        var hari = new cuaca();
                        hari.Nama = har[0];
                        hari.Kondisi = result[0];
                        hari.SuhuTerendah = data[0];
                        hari.Tertinggi = data[1];
                        hari.Kelembaban = data[2];
                        hari.Suhu = har[1].Split("&deg;C".ToArray()).Where(x => !string.IsNullOrEmpty(x)).FirstOrDefault();
                        Data.Datas.Add(hari);

                    }

                    listData.Add(Data);
                }

                          



            }
            catch (Exception ex)
            {

               
            }
        }
    }


    class cuaca
    {
        public string Nama { get; internal set; }
        public string Suhu { get; internal set; }
        public string Kondisi { get; internal set; }
        public string SuhuTerendah { get; internal set; }
        public string Tertinggi { get; internal set; }
        public string Kelembaban { get; internal set; }
    }

    class DataCuaca
    {
        public List<cuaca> Datas { get; set; } = new List<cuaca>();
        public string Tanggal { get; internal set; }
    }
}
