using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flymaskinenForms
{
    class TcpLytter
    {
        
       private BinaryReader reader;
    private Form1 form;
    
 
    public TcpLytter(BinaryReader r, Form1 f)
    {
      reader = r;
      this.form = f;
    }
 
    public void Listening()
    {
        
      try
      {
        while (true)
        {

           string m = reader.ReadString();
          form.sendMsgToForm(m);
            
        }
      }
      catch (Exception exc) { Console.WriteLine(exc); }
    }
    }
}
