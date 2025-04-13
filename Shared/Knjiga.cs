using System;

namespace Shared
{
    [Serializable]
    public class Knjiga
    {
        private int knjigaID;
        private string naziv;
        private string autor;
        private int godinaIzdavanja; 
        private int dostupneKopije;

        public int KnjigaID { get; set; }
        public String Naziv { get; set; }
        public String Autor { get; set; }
        public int GodinaIzdavanja { get; set; }
        public int DostupneKopije { get; set; }
    }
}
