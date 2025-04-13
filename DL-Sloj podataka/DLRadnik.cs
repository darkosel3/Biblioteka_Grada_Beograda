using Sloj_podataka;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DL_Sloj_podataka
{
    public class DLRadnik
    {
        private SqlConnection connection = new SqlConnection();
        private SqlDataAdapter daRadnik = new SqlDataAdapter();
        private DataTable dtRadnik = new DataTable();

        private static DLRadnik instance = null;

        public static DLRadnik Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DLRadnik();
                }
                return instance;
            }
        }

        private DLRadnik()
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["BibliotekaGradBeograd"].ConnectionString;
            LoadWorkers();
        }

        public DataTable RadnikTable
        {
            get { return dtRadnik.Copy(); }
        }

        private void LoadWorkers()
        {
            dtRadnik.Clear();

            var cmd = new SqlCommand("SELECT * FROM Administracija.Radnici", connection);
            daRadnik.SelectCommand = cmd;
            SqlCommandBuilder cb = new SqlCommandBuilder(daRadnik);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            daRadnik.Fill(dtRadnik);
            daRadnik.UpdateCommand = cb.GetUpdateCommand();
            connection.Close();
        }

        public List<Clan> GetWorkers()
        {
            return dtRadnik.AsEnumerable()
                        .Select(row => new Clan
                        {
                            ClanID = row.Field<int>("ClanID"),
                            Ime = row["Ime"].ToString(),
                            Prezime = row["Prezime"].ToString(),
                            Email = row["Email"].ToString(),
                            BrojTelefona = row["BrojTelefona"].ToString(),
                            Adresa = row["BrojTelefona"].ToString()
                        }).ToList();

        }
    }
}
