using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flymaskinenForms
{
    public partial class Form1 : Form
    {

        private byte[] encrypted;
        private TcpClient tcpclient;
        private BinaryReader r;
        private BinaryWriter w;
        private NetworkStream s;
        string afbud = "";
        string fjerner = "";
        public Form1()
        {
           
            InitializeComponent();

           
            ConnectToServer();
            TcpLytter lytter = new TcpLytter(r,this);
            Thread lytteThread = new Thread(lytter.Listening);
            lytteThread.Start();
        }
        public void Encrypt()
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            TripleDESCryptoServiceProvider tDES = new TripleDESCryptoServiceProvider();
            tDES.Key = md5.ComputeHash(utf8.GetBytes("password"));
            tDES.Mode = CipherMode.ECB;
            tDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform trans = tDES.CreateEncryptor();
            encrypted = trans.TransformFinalBlock(utf8.GetBytes(comboBoxStartby.Text), 0,
                utf8.GetBytes(comboBoxStartby.Text).Length);
        }

        public void Decrypt()
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            TripleDESCryptoServiceProvider tDES = new TripleDESCryptoServiceProvider();

            tDES.Key = md5.ComputeHash(utf8.GetBytes(textBoxPassword.Text));

            tDES.Mode = CipherMode.ECB;
            tDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform trans = tDES.CreateDecryptor();
           
            comboBoxStartby.Text =utf8.GetString(trans.TransformFinalBlock(encrypted, 0, encrypted.Length));

        }

        private void btnFindrejse_Click(object sender, EventArgs e)
        {
            try
            {

                Encrypt();
                Decrypt();


                ConnectToServer();

                if (comboBoxStartby.Text != comboBoxSlutby.Text)
                {
                    w.Write("FINDREJSE " + comboBoxStartby.Text + " " + comboBoxSlutby.Text);
                    textBoxResultat.Text = r.ReadString();

                }
                else
                    MessageBox.Show("Du kan ikke vælge de 2 samme byer prøv igen");
            }
            catch (Exception eve)
            {
                MessageBox.Show("Dit password er forkert");

            }
          
        }
        
        public delegate void AddToListBoxCallback(string text);

        
        public void sendMsgToForm(string msg)
        {
            if (listBoxFjernrejser.InvokeRequired || listBoxTilbudsrejser.InvokeRequired)
                Invoke(new AddToListBoxCallback(this.sendMsgToForm), new object[] { msg });

            else
            {
             
                
                //..... listBox1.Items.Add(msg);

                string[] parameters = msg.Split(' ');
                if (parameters[0] == "defaultafbud" || parameters[0] == "AFBUD")
                {
                    // richTextTilbudsrejse.Update();
                    if (msg != afbud)
                    {
                        
                        listBoxTilbudsrejser.Items.Add(msg);
                        afbud = msg;
                    }
                   
                }
                else if (parameters[0] == "defaultfjerner" || parameters[0] == "NEDLAGT")
                {

                    if (msg != fjerner)
                    {
                        listBoxFjernrejser.Items.Add(msg); // += "\n" + msg;
                        fjerner = msg;
                    }


                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
   
        private void btnUdskrivRejser_Click(object sender, EventArgs e)
        {
           ConnectToServer();
            w.Write("FINDRUTER " + " " + " " + " ");
            richTextUdskrivRejse.Text = r.ReadString();
            
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "http://www.sportenrejser.dk/images/fly.jpg";
           
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

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
        
        }
    }
}
