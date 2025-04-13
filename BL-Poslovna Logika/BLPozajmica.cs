using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sloj_podataka;
using Shared;
using System.Data.SqlClient;
using System.Data;

namespace Poslovna_Logika
{
    public class BLPozajmica
    {
        private DLPozajmica dlPozajmica = DLPozajmica.Instance;

        private static BLPozajmica instance = null;

        public static BLPozajmica Instance
        {
            get
            {
                if (instance == null)
                {
                   instance = new BLPozajmica();
                }
                return instance;
            }
        }

        public List<Pozajmica> GetPozajmicas(int knjigaId)
        {
            return dlPozajmica.GetPozajmicas(knjigaId);
        }

        public List<Pozajmica> GetWorkers()
        {
            return dlPozajmica.GetWorkers();
        }

        public List<Pozajmica> GetMembers()
        {
            return dlPozajmica.GetMembers();
        }

        public void ChangeDatumVracanja(int PozajmicaID, DateTime DatumVracanja)
        {
            dlPozajmica.ChangeDatumVracanja(PozajmicaID, DatumVracanja);
        }

        public bool InsertPozajmica(Pozajmica pozajmica)
        {
            dlPozajmica.Insert(pozajmica);
            return true;
        }
        public bool UpdatePozajmica(Pozajmica pozajmica)
        {
            dlPozajmica.Update(pozajmica);
            return true;
        }
        public bool DeletePozajmica(int pozajmicaID)
        {
            dlPozajmica.Delete(pozajmicaID);
            return true;
        }
        public Pozajmica GetPozajmica(int pozajmicaID)
        {
            return dlPozajmica.GetPozajmica(pozajmicaID);
        }   




    }
}
