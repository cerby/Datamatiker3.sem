using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlymaskinenServer
{
    class By
    {
        public String navn;
        public List<Rute> ruteliste = new List<Rute>();
        public Boolean visited = false;
        public int lengthFromStartVertex = 0;
        public By previousVertex = null;
        public By(String n)
        {
            navn = n;
        }
    }
}
