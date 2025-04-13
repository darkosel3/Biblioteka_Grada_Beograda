using DL_Sloj_podataka;
using Poslovna_Logika;
using Shared;
using Sloj_podataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poslovna_Logika
{
    public class BL_XML_Export
    {
        private XMLExport export = new XMLExport();

        private static BL_XML_Export instance = null;

        public static BL_XML_Export Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BL_XML_Export();
                }
                return instance;
            }
        }

        public  bool XML_Export(string filename)
        {
            XMLExport.ExportAllToXml(filename);
            return true;
        }

    }
}
