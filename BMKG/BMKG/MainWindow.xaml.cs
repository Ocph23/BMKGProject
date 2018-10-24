using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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

            Gettext();
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



        private void Gettext()
        {
            string URLString = "http://data.bmkg.go.id/pesan.txt";
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(URLString);

            httpRequest.Timeout = 10000;     // 10 secs
            httpRequest.UserAgent = "Code Sample Web Client";

            HttpWebResponse webResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());

            string content = responseStream.ReadToEnd();
        }
    }
}
