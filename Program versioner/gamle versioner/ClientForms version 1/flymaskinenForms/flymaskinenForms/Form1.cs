using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flymaskinenForms
{
    public partial class Form1 : Form
    {

        private TcpClient tcpclient;
        private BinaryReader r;
        private BinaryWriter w;
        private NetworkStream s; 

        public Form1()
        {
           
            InitializeComponent();
            
        }

     

       

        private void btnFindrejse_Click(object sender, EventArgs e)
        {
          
             ConnectToServer();
            if (comboBoxBy1.Text != comboBoxBy2.Text)
            {
                w.Write("FINDREJSE " + comboBoxBy1.Text + " " + comboBoxBy2.Text);
                textBoxResultat.Text = r.ReadString();
               
            }
            else
                MessageBox.Show("Du kan ikke vælge de 2 samme byer prøv igen");
        }


        public delegate void AddToCombo(string msg);


        public void sendMsgToForm(string msg)
        {
            if (richTextUdskrivRejse.InvokeRequired || richTextTilbudsrejse.InvokeRequired)
                Invoke(new AddToCombo(this.sendMsgToForm), new object[] {msg});

            else
            {
                string rejse = "";
                string afbud = "";
                string fjerner = "";
//..... listBox1.Items.Add(msg);

           
                string[] parameters = msg.Split(' ');
                if (parameters[0] == "defaultafbud" || parameters[0] == "AFBUD")
                {
                  
                    if (msg != afbud)
                    {
                        richTextTilbudsrejse.Text += "\n" + msg;
                        afbud = msg;
                    }

          
                }
                else if (parameters[0] == "defaultfjerner" || parameters[0] == "NEDLAGT")
                {
              
                    if (msg != fjerner)
                    {
                        richTextFjernrejse.Text += "\n" + msg;
                        fjerner = msg;
                    }

                 
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void Listener()
        {   //read from server to display on clientform
            for (int i = 0; i < 10; i++)
            {
                ConnectToServer();

                w.Write("TILBUDSREJSE " + " " + " " + " ");
                richTextTilbudsrejse.Text = r.ReadString();


                w.Write("FJERNREJSER " + " " + " " + " ");
                richTextFjernrejse.Text += r.ReadString();
                
            }
        }

        private void btnUdskrivRejser_Click(object sender, EventArgs e)
        {
           ConnectToServer();
            w.Write("FINDRUTER " + " " + " " + " ");
            richTextUdskrivRejse.Text = r.ReadString();
            
        }

        private void BtnTilbudsrejse_Click(object sender, EventArgs e)
        {
            ConnectToServer();
            w.Write("TILBUDSREJSE " + " " + " " + " ");
            richTextTilbudsrejse.Text += r.ReadString();
           
        }

        //public void TraadTilbudsrejser()
        //{
        //    ConnectToServer();
        //    w.Write("TILBUDSREJSE " + " " + " " + " ");
        //    richTextTilbudsrejse.Text += r.ReadString();

        //}

       

        private void Form1_Load(object sender, EventArgs e)
        {
            TcpLytter lytter = new TcpLytter(r,this);
          Thread lytteThread = new Thread(lytter.Listening);
            lytteThread.Start();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            ConnectToServer();
            w.Write("FJERNREJSER " + " " + " " + " ");
            richTextFjernrejse.Text += r.ReadString();
           


            
        }

        public void ConnectToServer()
        {
            TcpClient tcpclient = new TcpClient();
            tcpclient.Connect("127.0.0.1", 15000);
             s = tcpclient.GetStream();
             r = new BinaryReader(s);
             w = new BinaryWriter(s);
        }

        private void btnLuk_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

       
       

    
      
    }
}
