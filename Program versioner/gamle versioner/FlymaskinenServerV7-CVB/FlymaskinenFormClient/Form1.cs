using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace FlymaskinenFormClient
{
    public partial class Form1 : Form
    {
        public static object lockObject = new object();
        TCPLytter _tcpLytteren = new TCPLytter();

        private string rejse = "";
        private string afbud = "";
        private string fjerner = "";
        public string Her()
        {
            
            TcpClient tcp = new TcpClient();
            tcp.Connect("127.0.0.1", 15000);
            NetworkStream s = tcp.GetStream();
            BinaryReader reader = new BinaryReader(s);
            while (true)
            {
                string message = reader.ReadString();
                string[] parameters = message.Split(' ');
                if (parameters[0] == "defaultafbud" || parameters[0] == "AFBUD")
                {
                    Afbudsbox.Update();
                    if (message != afbud)
                    {
                        Afbudsbox.Text += "\n" + message;
                        afbud = message;
                    }                    
                    
                    Afbudsbox.Update();
                }
                else if (parameters[0] == "defaultfjerner" || parameters[0] == "NEDLAGT")
                {
                    Fjernetrejsebox.Update();
                    if (message != fjerner)
                    {
                        Fjernetrejsebox.Text += "\n" + message;
                        fjerner = message;
                    }
                    
                    Fjernetrejsebox.Update();
                }
                else if (parameters[0] == "REJSE")
                {
                    Rejsebox.Update();
                    if (rejse != message)
                    {
                        Rejsebox.Text = "\n" + message;
                        rejse = message;
                    }                    
                    Rejsebox.Update();
                }
                
            }
        }
        public Form1()
        {
            InitializeComponent();
           
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Rejsebox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Afbudsbox.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fjernetrejsebox.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Her();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Afbudsbox_TextChanged(object sender, EventArgs e)
        {

        }

    }
    class TCPLytter
    {
        
        


    }
}
