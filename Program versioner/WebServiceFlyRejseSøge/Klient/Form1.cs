using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Klient
{
    public partial class Form1 : Form
    {
        private WebClient _webClient = new WebClient();

        private XNamespace xmlNamespace = XNamespace.Get(
            "http://schemas.microsoft.com/2003/10/Serialization/");

        public Form1()
        {
            InitializeComponent();

            
             _webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(FindRute);   
        }

        private void FindRute (object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null) //Hvis der ikke er nogen fejl
            {
                XDocument xmlResponse = XDocument.Parse(e.Result);

                string answer = xmlResponse.Element(xmlNamespace + "string").Value;

                RICHTXTrutepris.Text = answer;
            }
        }

        private void BUTFindRejse_Click(object sender, EventArgs e)
        {
            _webClient.DownloadStringAsync(new Uri("http://localhost:37742/Service1.svc/FindRejse/" 
                + COMBOafrejse.Text + "/" + COMBOdestination.Text));
        }
    }
}
