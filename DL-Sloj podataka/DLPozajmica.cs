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
    public class DLPozajmica
    {
        private SqlConnection connection = new SqlConnection();
        private SqlDataAdapter daPozajmica = new SqlDataAdapter();
        private DataTable dtPozajmica = new DataTable();

        private static DLPozajmica instance = null;

        public static DLPozajmica Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DLPozajmica();
                }
                return instance;
            }
        }
        private DLPozajmica()
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["BibliotekaGradBeograd"].ConnectionString;
            LoadLoans();

        }

        public DataTable PozajmicaTable
        {
            get { return dtPozajmica.Copy(); }
        }

        public void LoadLoans()
        {
            dtPozajmica.Clear();
            var cmd = new SqlCommand("SELECT * FROM Administracija.PozajmiceView", connection);
            daPozajmica.SelectCommand = cmd;
            daPozajmica.UpdateCommand = new SqlCommand("UpdatePozajmica", connection);
            daPozajmica.UpdateCommand.CommandType = CommandType.StoredProcedure;
            daPozajmica.UpdateCommand.Parameters.Add("@PozajmicaID", SqlDbType.Int, 0, "PozajmicaID");
            daPozajmica.UpdateCommand.Parameters.Add("@ClanID", SqlDbType.Int, 0, "ClanID");
            daPozajmica.UpdateCommand.Parameters.Add("@KnjigaID", SqlDbType.Int, 0, "KnjigaID");
            daPozajmica.UpdateCommand.Parameters.Add("@RadnikID", SqlDbType.Int, 0, "RadnikID");
            daPozajmica.UpdateCommand.Parameters.Add("@DatumPozajmice", SqlDbType.DateTime, 0, "DatumPozajmice");
            daPozajmica.UpdateCommand.Parameters.Add("@DatumIstekaPozajmice", SqlDbType.DateTime, 0, "DatumIstekaPozajmice");
            daPozajmica.UpdateCommand.Parameters.Add("@DatumVracanja", SqlDbType.DateTime, 0, "DatumVracanja");

            daPozajmica.InsertCommand = new SqlCommand("InsertPozajmica", connection);
            daPozajmica.InsertCommand.CommandType = CommandType.StoredProcedure;
            daPozajmica.InsertCommand.Parameters.Add("@ClanID", SqlDbType.Int, 0, "ClanID");
            daPozajmica.InsertCommand.Parameters.Add("@KnjigaID", SqlDbType.Int, 0, "KnjigaID");
            daPozajmica.InsertCommand.Parameters.Add("@RadnikID", SqlDbType.Int, 0, "RadnikID");
            daPozajmica.InsertCommand.Parameters.Add("@DatumPozajmice", SqlDbType.DateTime, 0, "DatumPozajmice");
            daPozajmica.InsertCommand.Parameters.Add("@DatumIstekaPozajmice", SqlDbType.DateTime, 0, "DatumIstekaPozajmice");
            daPozajmica.InsertCommand.Parameters.Add("@DatumVracanja", SqlDbType.DateTime, 0, "DatumVracanja");

            daPozajmica.DeleteCommand = new SqlCommand("DeletePozajmica", connection);
            daPozajmica.DeleteCommand.CommandType = CommandType.StoredProcedure;
            daPozajmica.DeleteCommand.Parameters.Add("@PozajmicaID", SqlDbType.Int, 0, "PozajmicaID");


            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            daPozajmica.Fill(dtPozajmica);
            connection.Close();
        }

        public List<Pozajmica> GetPozajmicas(int knjigaIdFilter)
        {

                return dtPozajmica.AsEnumerable()
                        .Where(row => row.Field<int>("KnjigaID") == knjigaIdFilter)
                        .Select(row => new Pozajmica
                        {
                            PozajmicaID = row.Field<int>("PozajmicaID"),
                            KnjigaID = row.Field<int>("KnjigaID"),
                            RadnikID = row.Field<int>("RadnikID"),
                            ClanID = row.Field<int>("ClanID"),
                            ImePrezimeClana = row["ImePrezimeClana"].ToString(),
                            ImePrezimeRadnika = row["ImePrezimeRadnika"].ToString(),
                            DatumPozajmice = row.Field<DateTime?>("DatumPozajmice"),
                            DatumIstekaPozajmice = row.Field<DateTime?>("DatumIstekaPozajmice"),
                            DatumVracanja = row.Field<DateTime?>("DatumVracanja")
                        }).ToList();
         
                
        }
        public Pozajmica GetPozajmica(int pozajmicaID)
        {
            DataRow dr = dtPozajmica.Select("PozajmicaID = " + pozajmicaID.ToString())[0];
            Pozajmica pozajmica = new Pozajmica();
            pozajmica.PozajmicaID = dr.Field<int>("PozajmicaID");
            pozajmica.ClanID = dr.Field<int>("ClanID");
            pozajmica.KnjigaID = dr.Field<int>("KnjigaID"); 
            pozajmica.RadnikID = dr.Field<int>("RadnikID"); 
            pozajmica.ImePrezimeClana = dr["ImePrezimeClana"].ToString();
            pozajmica.ImePrezimeRadnika = dr["ImePrezimeRadnika"].ToString();   
            pozajmica.DatumPozajmice = dr.Field<DateTime?>("DatumPozajmice");   
            pozajmica.DatumVracanja = dr.Field<DateTime?>("DatumVracanja");
            pozajmica.DatumIstekaPozajmice = dr.Field<DateTime?>("DatumIstekaPozajmice");
            return pozajmica;

        }
        public List<Pozajmica> GetWorkers()
        {
            return dtPozajmica.AsEnumerable()
                .Select(row => new Pozajmica
                {
                    RadnikID = row.Field<int>("RadnikID"),
                    ImePrezimeRadnika = row["ImePrezimeRadnika"].ToString()
                })
                .GroupBy(p => p.RadnikID)
                .Select(g => g.First())
                .ToList();
        }
        public List<Pozajmica> GetMembers()
        {
            return dtPozajmica.AsEnumerable()
                .Select(row => new Pozajmica
                {
                    ClanID = row.Field<int>("ClanID"),
                    ImePrezimeClana = row["ImePrezimeClana"].ToString()
                })
                .GroupBy(p => p.ClanID)
                .Select(g => g.First())
                .ToList();
        }
        public void ChangeDatumVracanja(int PozajmicaID, DateTime DatumVracanja)
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var cmd = new SqlCommand("UpdateDatumPozajmica", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PozajmicaID", PozajmicaID);
            cmd.Parameters.AddWithValue("@DatumVracanja", DatumVracanja);
            var brojIzmenjenih = cmd.ExecuteNonQuery();

            var row = dtPozajmica.AsEnumerable()
                .Where(r => r.Field<int>("PozajmicaID") == PozajmicaID)
                .FirstOrDefault();
            if(row != null)
            {
                row.SetField("DatumVracanja", DatumVracanja);
            }
            connection.Close();
            MessageBox.Show($"Broj izmenjenih redova: {brojIzmenjenih}");
        }
        private void Update() { 
            daPozajmica.Update(dtPozajmica);
            LoadLoans();
        }

        public bool Insert(Pozajmica pozajmica)
        {
            // Start transaction on the DataAdapter's connection
            daPozajmica.InsertCommand.Connection.Open();
            SqlTransaction transaction = daPozajmica.InsertCommand.Connection.BeginTransaction();

            try
            {
                // Assign transaction to all DataAdapter commands
                if (daPozajmica.InsertCommand != null)
                    daPozajmica.InsertCommand.Transaction = transaction;

                
                DataRow dr = dtPozajmica.NewRow();
                dr["PozajmicaID"] = pozajmica.PozajmicaID;
                dr["ClanID"] = pozajmica.ClanID;
                dr["KnjigaID"] = pozajmica.KnjigaID;
                dr["RadnikID"] = pozajmica.RadnikID;
                dr["DatumPozajmice"] = pozajmica.DatumPozajmice;
                dr["DatumIstekaPozajmice"] = pozajmica.DatumIstekaPozajmice;
                dtPozajmica.Rows.Add(dr);

                int izmenjeniRedovi = daPozajmica.Update(dtPozajmica);

                transaction.Commit();
                LoadLoans(); 

                return izmenjeniRedovi > 0;
            }
            catch (Exception ex)
            {
                try
                {
                    // Probaj rollback
                    transaction.Rollback();
                    dtPozajmica.RejectChanges(); // Revert DataTable changes
                }
                catch (Exception rollbackEx)
                {
                    // Log rollback error
                    MessageBox.Show($"Rollback neuspesan: {rollbackEx.Message}");
                }

                // Log original error
                MessageBox.Show($"Insert neuspesan: {ex.Message}");
                return false;
            }
            finally
            {
                // Ensure connection is closed
                if (daPozajmica.InsertCommand.Connection.State == ConnectionState.Open)
                    daPozajmica.InsertCommand.Connection.Close();
            }
        }
        public bool Update(Pozajmica pozajmica) { 
        DataRow dr = dtPozajmica.Select("PozajmicaID = " + pozajmica.PozajmicaID.ToString())[0];
            dr["PozajmicaID"] = pozajmica.PozajmicaID.ToString();
            dr["ClanID"] = pozajmica.ClanID;
            dr["KnjigaID"] = pozajmica.KnjigaID;
            dr["RadnikID"] = pozajmica.RadnikID;
            dr["DatumPozajmice"] = pozajmica.DatumPozajmice;
            dr["DatumIstekaPozajmice"] = pozajmica.DatumIstekaPozajmice;
            dr["DatumVracanja"] = pozajmica.DatumVracanja;

            Update();

            return true;
        }
        public bool Delete(int pozajmicaid)
        {
            DataRow dr = dtPozajmica.Select("PozajmicaID = " + pozajmicaid.ToString())[0];
            dr.Delete();
            Update();
            return true;
        }

        public List<Pozajmica> GetAllPozajmica()
        {

            return dtPozajmica.AsEnumerable()
                    .Select(row => new Pozajmica
                    {
                        PozajmicaID = row.Field<int>("PozajmicaID"),
                        KnjigaID = row.Field<int>("KnjigaID"),
                        RadnikID = row.Field<int>("RadnikID"),
                        ClanID = row.Field<int>("ClanID"),
                        ImePrezimeClana = row["ImePrezimeClana"].ToString(),
                        ImePrezimeRadnika = row["ImePrezimeRadnika"].ToString(),
                        DatumPozajmice = row.Field<DateTime?>("DatumPozajmice"),
                        DatumIstekaPozajmice = row.Field<DateTime?>("DatumIstekaPozajmice"),
                        DatumVracanja = row.Field<DateTime?>("DatumVracanja")
                    }).ToList();


        }
    }
}

