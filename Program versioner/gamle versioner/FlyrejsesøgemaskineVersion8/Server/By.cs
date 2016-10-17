using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class By
    {
        public String navn;
        public List<Rute> ruteliste = new List<Rute>();
        public Boolean visited = false;
        public int PrisFraStartBy = 0;
        public By SidsteBy = null;
        public By(String n)
        {
            navn = n;
        }
    }
}
