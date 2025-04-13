using Sloj_podataka;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace DL_Sloj_podataka
{
    public class XMLExport
    {
        /// Preuzima DataTable‑ove iz svih DAL klasa, kreira DataSet, dodaje relacije, i serijalizuje šemu i podatke
        public static bool ExportAllToXml(string fileName)
        {
            try
            {
                // Kreiranje DataSet‑a
                DataSet ds = new DataSet("BibliotekaDataSet");

                // Dodajemo tabele (preko javnih svojstava koje smo dodali)
                DataTable dtRadnik = DLRadnik.Instance.RadnikTable;
                dtRadnik.TableName = "Radnik";
                ds.Tables.Add(dtRadnik);

                DataTable dtPozajmica = DLPozajmica.Instance.PozajmicaTable;
                dtPozajmica.TableName = "Pozajmica";
                ds.Tables.Add(dtPozajmica);

                DataTable dtKnjiga = DLKnjiga.Instance.KnjigaTable;
                dtKnjiga.TableName = "Knjiga";
                ds.Tables.Add(dtKnjiga);

                DataTable dtClan = DLClan.Instance.ClanTable;
                dtClan.TableName = "Clan";
                ds.Tables.Add(dtClan);

                // Dodavanje relacija (primer: Radnik -> Pozajmica)
                // Proveri da li kolone postoji u odgovarajućim tabelama
                if (ds.Tables["Radnik"].Columns.Contains("RadnikID") &&
                    ds.Tables["Pozajmica"].Columns.Contains("RadnikID"))
                {
                    ds.Relations.Add("RadnikPozajmica",
                        ds.Tables["Radnik"].Columns["RadnikID"],
                        ds.Tables["Pozajmica"].Columns["RadnikID"], false);
                }

                // Dodavanje drugih relacija po potrebi (npr. Clan -> Pozajmica, Knjiga -> Pozajmica)
                if (ds.Tables["Clan"].Columns.Contains("ClanID") &&
                    ds.Tables["Pozajmica"].Columns.Contains("ClanID"))
                {
                    ds.Relations.Add("ClanPozajmica",
                        ds.Tables["Clan"].Columns["ClanID"],
                        ds.Tables["Pozajmica"].Columns["ClanID"], false);
                }

                if (ds.Tables["Knjiga"].Columns.Contains("KnjigaID") &&
                    ds.Tables["Pozajmica"].Columns.Contains("KnjigaID"))
                {
                    ds.Relations.Add("KnjigaPozajmica",
                        ds.Tables["Knjiga"].Columns["KnjigaID"],
                        ds.Tables["Pozajmica"].Columns["KnjigaID"], false);
                }

                // Putanje za čuvanje datoteka na desktopu
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string schemaPath = Path.Combine(desktopPath, fileName + "_schema.xml");
                string dataPath = Path.Combine(desktopPath, fileName + "_data.xml");

                // Čuvanje šeme
                using (XmlWriter schemaWriter = XmlWriter.Create(schemaPath, new XmlWriterSettings { Indent = true }))
                {
                    ds.WriteXmlSchema(schemaWriter);
                }

                // Čuvanje podataka
                using (XmlWriter dataWriter = XmlWriter.Create(dataPath, new XmlWriterSettings { Indent = true }))
                {
                    ds.WriteXml(dataWriter, XmlWriteMode.IgnoreSchema);
                }

                MessageBox.Show("Podaci i šema su uspešno sačuvani u XML datoteke:\n" +
                    schemaPath + "\n" + dataPath, "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom izvoza u XML: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
