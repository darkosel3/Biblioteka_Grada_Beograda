using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sloj_podataka;
using Shared;

namespace Poslovna_Logika
{
    public class BLKnjiga
    {
        private DLKnjiga dlKnjiga = DLKnjiga.Instance;
        
        private static BLKnjiga instance = null;
        
        public static  BLKnjiga Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLKnjiga();
                }
                return instance;
            }
        }

        public List<Knjiga> GetKnjigas()
        {
            return dlKnjiga.GetKnjigas();
        }

        

    }
}
