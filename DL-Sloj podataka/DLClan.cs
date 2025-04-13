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
    public class DLClan
    {
        private SqlConnection connection = new SqlConnection();
        private SqlDataAdapter daClan = new SqlDataAdapter();
        private DataTable dtClan= new DataTable();

        private static DLClan instance = null;

        public static DLClan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DLClan();
                }
                return instance;
            }
        }

        private DLClan()
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["BibliotekaGradBeograd"].ConnectionString;
            LoadMembers();
        }

        public DataTable ClanTable
        {
            get { return dtClan.Copy(); }
        }
        private void LoadMembers()
        {
            dtClan.Clear();

            var cmd = new SqlCommand("SELECT * FROM Administracija.Clanovi", connection);
            daClan.SelectCommand = cmd;
            SqlCommandBuilder cb = new SqlCommandBuilder(daClan);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            daClan.Fill(dtClan);
            daClan.UpdateCommand = cb.GetUpdateCommand();
            connection.Close();
        }

        public List<Clan> GetMembers()
        {
            return dtClan.AsEnumerable()
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
