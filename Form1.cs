using System;
using Poslovna_Logika;
using Shared;
using System.Windows.Forms;
using System.Linq;
using BL_Poslovna_Logika;
using System.IO;
using System.Drawing;


namespace Biblioteka_Grada_Beograda
{
    public partial class Form1: Form
    {

        BLKnjiga BLKnjiga = BLKnjiga.Instance;
        BLPozajmica BLPozajmica = BLPozajmica.Instance;
        BL_XML_Export BL_XML_Export = BL_XML_Export.Instance;

        public Form1()
        {
            InitializeComponent();
            Configure();
        }

        private void Configure()
        {
            LoadLogo();
            cbKnjiga.Items.Clear();
            var knjige = BLKnjiga.GetKnjigas();
            cbKnjiga.DisplayMember = "Naziv";
            cbKnjiga.ValueMember = "KnjigaID";
            cbKnjiga.DataSource = knjige;
            cbKnjiga.SelectedIndexChanged += CbKnjiga_SelectedIndexChanged; // Povezuje događaj SelectedIndexChanged sa metodom CbKnjiga_SelectedIndexChanged
            if (cbKnjiga.Items.Count > 0) //Proverava da li je combo box popunjen
            {
                cbKnjiga.SelectedIndex = 0;
                Knjiga pocetnaKnjiga = (Knjiga)cbKnjiga.SelectedItem;
                broj_kopija.Text = $" {pocetnaKnjiga.DostupneKopije}";
                txtAutor.Text = pocetnaKnjiga.Autor;
                txtAutor.ReadOnly = true; // Autor je samo za čitanje
                txtGodinaIzdavanja.Text = pocetnaKnjiga.GodinaIzdavanja.ToString();
                txtGodinaIzdavanja.ReadOnly = true; // Autor je samo za čitanje
                IDKnjige.Text = pocetnaKnjiga.KnjigaID.ToString();
                ConfiguredgwPozajmice(pocetnaKnjiga.KnjigaID);
            }

        }

        private void CbKnjiga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKnjiga.SelectedItem is Knjiga izabranaKnjiga)
            {
                broj_kopija.Text = $" {izabranaKnjiga.DostupneKopije}";
                txtAutor.Text = izabranaKnjiga.Autor;
                txtGodinaIzdavanja.Text = izabranaKnjiga.GodinaIzdavanja.ToString();
                IDKnjige.Text = izabranaKnjiga.KnjigaID.ToString(); 
            }
            ConfiguredgwPozajmice(((Knjiga)cbKnjiga.SelectedItem).KnjigaID);

        }
        private void dgwPozajmice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int pozajmicaID = (int)dgwPozajmice.Rows[e.RowIndex].Cells["PozajmicaID"].Value;
            var vrednostDatuma = dgwPozajmice.Rows[e.RowIndex].Cells["DatumVracanja"].Value;

            // Proveravamo da li je datum vraćanja unet i da li je redni broj veći od nule
            if (e.RowIndex >= 0 && dgwPozajmice.Columns[e.ColumnIndex].Name == "DatumVracanja" && vrednostDatuma != null) // da li je datum null
            {
                if (DateTime.TryParse(vrednostDatuma.ToString(), out DateTime datumVracanja)) // da li je datum dobrog formata
                {
                    BLPozajmica.ChangeDatumVracanja(pozajmicaID, (DateTime)datumVracanja);
                    dgwPozajmice.Columns.Clear();
                    dgwPozajmice.DataSource = BLPozajmica.GetPozajmicas(((Knjiga)cbKnjiga.SelectedItem).KnjigaID);
                }
                else
                {
                    MessageBox.Show("Greska prilikom unosa datuma vraćanja, on nije u dobrom formatu!(MM/dd/yyyy,mm-dd-yyyy,(mm,dd,yyyy))");
                }
            }
            
        }



        //Dugme za kreiranje nove pozajmice
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Pozajmica pozajmica = new Pozajmica();

            pozajmica.KnjigaID = ((Knjiga)cbKnjiga.SelectedItem).KnjigaID;

            form2.Pozajmica = pozajmica;

            DialogResult result = form2.ShowDialog();

            if(result != DialogResult.OK){
                return;
            }
            else { 
            if (BLPozajmica.InsertPozajmica(pozajmica))
            {
                MessageBox.Show("Uspesno ste dodali novu pozajmicu");
            }
            else
            {
                MessageBox.Show("Doslo je do greske prilikom dodavanja nove pozajmice");
            }
            ConfiguredgwPozajmice(pozajmica.KnjigaID);
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgwPozajmice.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite red koji želite da izmenite.", "Upozorenje",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Daj mi red koji je selektovan i uzmi ID pozajmice
            DataGridViewRow selectedRow = dgwPozajmice.SelectedRows[0];
            int IzabranaPozajmicaID = (int)selectedRow.Cells["PozajmicaID"].Value;

            Form2 form2 = new Form2();
            Pozajmica pozajmica = new Pozajmica();
            pozajmica = BLPozajmica.GetPozajmica(IzabranaPozajmicaID);

            form2.Pozajmica = pozajmica;

            DialogResult result = form2.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                if (BLPozajmica.UpdatePozajmica(pozajmica))
                {
                    MessageBox.Show("Uspesno ste izmenili pozajmicu");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske prilikom izmene pozajmice");
                }
                dgwPozajmice.DataSource = BLPozajmica.GetPozajmicas(((Knjiga)cbKnjiga.SelectedItem).KnjigaID);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgwPozajmice.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite pozajmicu koju zelite da izbrisete!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = dgwPozajmice.SelectedRows[0];
            int IzabranaPozajmicaID = (int)selectedRow.Cells["PozajmicaID"].Value;

            DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da izbrisete pozajmicu?", "Confirm Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            //Ukoliko su potrvrdili brisanje brisemo pozajmicu i ponovo konfigurisemo DataGridView
            if (result == DialogResult.Yes && BLPozajmica.DeletePozajmica(IzabranaPozajmicaID))
            {
                MessageBox.Show("Uspesno ste izbrisali pozajmicu");
                ConfiguredgwPozajmice(((Knjiga)cbKnjiga.SelectedItem).KnjigaID);
            }
        }
        private void LoadLogo() { 
            string logoPath = Path.Combine(Application.StartupPath,"Images", "bbl-logo.png");
            if (File.Exists(logoPath))
            {
                pictureBox1.Image = Image.FromFile(logoPath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                MessageBox.Show($"Logo not found at: {logoPath}\nCurrent directory: {Application.StartupPath}");
            }
        }
        private void ConfiguredgwPozajmice(int knjigaID)
        {
            dgwPozajmice.Columns.Clear();
            dgwPozajmice.DataSource = BLPozajmica.GetPozajmicas(knjigaID);

            //Popunjavanje Datuma Vracanja bez klika na Izmeni dugme
            dgwPozajmice.Columns["DatumVracanja"].DefaultCellStyle.Format = "MM/dd/yyyy";
            //Dodavanje funkcije na dogadjaj CellEndEdit
            dgwPozajmice.CellEndEdit += dgwPozajmice_CellEndEdit;

            //Popuni prostor horizontalno 
            dgwPozajmice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            //Kako bi klik na kolonu selektovao ceo red i omogucio nam da izaberemo id
            dgwPozajmice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwPozajmice.MultiSelect = false;

            //Menjamo Imena header-a
            dgwPozajmice.Columns["PozajmicaID"].HeaderText = "ID";
            dgwPozajmice.Columns["ImePrezimeClana"].HeaderText = "Član";
            dgwPozajmice.Columns["ImePrezimeRadnika"].HeaderText = "Radnik";
            dgwPozajmice.Columns["DatumPozajmice"].HeaderText = "Datum pozajmice";
            dgwPozajmice.Columns["DatumIstekaPozajmice"].HeaderText = "Ističe";
            dgwPozajmice.Columns["DatumVracanja"].HeaderText = "Datum vraćanja";
            foreach (DataGridViewColumn column in dgwPozajmice.Columns)
            {
                if (column.Name.ToUpper().EndsWith("ID", StringComparison.OrdinalIgnoreCase) && column.Name != "PozajmicaID")
                {
                    column.Visible = false;
                }
                if (column.Name != "DatumVracanja")
                {
                    column.ReadOnly = true;  // Sve kolone su read-only osim Datum Vracanja
                }
            }
        }
        private void saveXML_Click(object sender, EventArgs e)
        {
            if (BL_XML_Export.XML_Export("ExportBiblioteka"))
            {
                MessageBox.Show("Uspešno eksportovano!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Greška pri eksportovanju!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgwPozajmice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwPozajmice_CellContentEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbKnjiga_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
