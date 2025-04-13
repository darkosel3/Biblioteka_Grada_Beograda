using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [Serializable]
    public class Radnik
    {
        private int radnikID;
        private string ime;
        private string prezime;
        private string pozicija;

        public int RadnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pozicija { get; set; }
    }
}