using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Shared;
using System.Windows.Forms;

namespace Sloj_podataka
{
    public class DLKnjiga
    {

        private SqlConnection connection = new SqlConnection();
        private SqlDataAdapter daKnjiga = new SqlDataAdapter();
        private DataTable dtKnjiga = new DataTable();

        private static DLKnjiga instance = null;

        public static DLKnjiga Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DLKnjiga();
                }
                return instance;
            }
        }

        private DLKnjiga()
        {
          connection.ConnectionString = ConfigurationManager.ConnectionStrings["BibliotekaGradBeograd"].ConnectionString;
            LoadBooks();
        }
        private void LoadBooks()
        {
            dtKnjiga.Clear();

            var cmd = new SqlCommand("SELECT * FROM Biblioteka.Knjige", connection);
            daKnjiga.SelectCommand = cmd;
            SqlCommandBuilder cb = new SqlCommandBuilder(daKnjiga);

            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            daKnjiga.Fill(dtKnjiga);
            daKnjiga.UpdateCommand = cb.GetUpdateCommand();
            connection.Close();
        }

        public DataTable KnjigaTable
        {
            get { return dtKnjiga.Copy(); }
        }



        public List<Knjiga> GetKnjigas()
        {
            return dtKnjiga.AsEnumerable()
            .Select(row => new Knjiga
            {
               KnjigaID = row.Field<int>("KnjigaID"),
               Naziv = row["Naziv"].ToString(),
               Autor = row["Autor"].ToString(),
               GodinaIzdavanja = row.Field<int>("GodinaIzdavanja"),
               DostupneKopije = row.Field<int>("DostupneKopije")
            }).ToList();
        }
        

    }
}
