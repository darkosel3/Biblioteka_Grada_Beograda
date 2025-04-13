using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [Serializable]
    public class Clan
    {
        private int clanID;
        private string ime;
        private string prezime;
        private string email;
        private string brojTelefona;
        private string adresa;

        public int ClanID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
    }
}
