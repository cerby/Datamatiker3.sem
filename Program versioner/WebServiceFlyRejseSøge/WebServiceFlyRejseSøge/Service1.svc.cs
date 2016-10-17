using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebServiceFlyRejseSøge
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string FindRejse(string by1, string by2)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("10.140.81.41", 15000);

            NetworkStream s = tcpClient.GetStream();
            BinaryReader r = new BinaryReader(s);
            BinaryWriter w = new BinaryWriter(s);
            w.Write("Findrejse" + " " + by1 + " " + by2);
            
            return r.ReadString();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
