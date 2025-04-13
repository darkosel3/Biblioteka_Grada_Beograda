using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [Serializable]
    public class Pozajmica
    {
        private int pozajmicaID;
        private int clanID;
        private int knjigaID;
        private int radnikID;
        private string imePrezimeClana;

        private string imePrezimeRadnika;
        private DateTime? datumPozajmice;
        private DateTime? datumIstekaPozajmice;
        private DateTime? datumVracanja;

        public int PozajmicaID { get; set; }
        public int ClanID { get; set; }
        public int KnjigaID { get; set; }
        public int RadnikID { get; set; }
        public string ImePrezimeClana { get; set; }
        public string ImePrezimeRadnika { get; set; }
        public DateTime? DatumPozajmice { get; set; }
        public DateTime? DatumIstekaPozajmice { get; set; }
        public DateTime? DatumVracanja { get; set; }  
    }
}
