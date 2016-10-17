using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlymaskinenServer
{
    class By
    {
        public String Navn;
        public List<Rute> Ruteliste = new List<Rute>();
        public Boolean Visited = false;
        public int PrisFraStartBy = 0;
        public By SidsteBy = null;
        public By(String n)
        {
            Navn = n;
        }
    }
}
