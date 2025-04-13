using Poslovna_Logika;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka_Grada_Beograda
{
    public partial class Form2: Form
    {
        BLPozajmica BLPozajmica = BLPozajmica.Instance;
        BLKnjiga BLKnjiga = BLKnjiga.Instance;

        public Pozajmica Pozajmica;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Pozajmica == null)
            {
                MessageBox.Show("Došlo je do greške: Pozajmica nije inicijalizovana.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            CBFill();
            dtpDatumPozajmice.Format = DateTimePickerFormat.Custom;
            dtpDatumPozajmice.CustomFormat = "MM/dd/yyyy";
            dtpDatumIstekaPozajmice.Format = DateTimePickerFormat.Custom;
            dtpDatumIstekaPozajmice.CustomFormat = "MM/dd/yyyy";
            dtpDatumVracanja.Format = DateTimePickerFormat.Custom;
            dtpDatumVracanja.CustomFormat = "MM/dd/yyyy";
            dtpDatumVracanja.ShowCheckBox = true; // Show checkbox to enable/disable date

            if (this.Pozajmica.PozajmicaID != 0)
            { //Kad je ID razlicit od nule, znaci da menjamo postojecu pozajmicu
                lblDPozajmice.Text = "ID Pozajmice: " + Pozajmica.PozajmicaID.ToString();
                cbClan.SelectedValue = this.Pozajmica.ClanID;
                cbRadnik.SelectedValue = this.Pozajmica.RadnikID;
                cbKnjiga.SelectedValue = this.Pozajmica.KnjigaID;
                dtpDatumPozajmice.Value = this.Pozajmica.DatumPozajmice.Value;
                dtpDatumIstekaPozajmice.Value = this.Pozajmica.DatumIstekaPozajmice.Value;

                if (this.Pozajmica.DatumVracanja.HasValue)
                {
                    dtpDatumVracanja.Value = this.Pozajmica.DatumVracanja.Value;
                    dtpDatumVracanja.Checked = true;
                    dtpDatumVracanja.CustomFormat = "MM/dd/yyyy"; 
                }
                else
                {
                    dtpDatumVracanja.Checked = false;
                }
                    btnSaveEdit.Text = "Izmeni";
                MessageBox.Show(Pozajmica.ToString());
            }
            else
            {
           
                cbKnjiga.SelectedValue = Pozajmica.KnjigaID;
                //txtDatumPozajmice.Text = DateTime.Now.Date.ToString("MM/dd/yyyy");
                //txtDatumIstekaPozajmice.Text = DateTime.Now.AddDays(30).ToString("MM/dd/yyyy");
                dtpDatumPozajmice.Value = DateTime.Now.Date;
                dtpDatumIstekaPozajmice.Value = DateTime.Now.AddDays(30);

                //Datum vracanja ne postoji kada dodajemo novu pozajmicu
                //Zbog toga unos nije moguc i label i DateTimePicker su nevidljivi
                lblDatumVracanja.Visible = false;
                dtpDatumVracanja.Visible = false;
                btnSaveEdit.Text = "Dodaj";
            }
        }


        private void CBFill()
        {
            cbRadnik.Items.Clear();
            var radnici = BLPozajmica.GetWorkers();
            radnici.Insert(0, new Pozajmica() { RadnikID = 0, ImePrezimeRadnika = "Izaberi radnika" });
            cbRadnik.DataSource = radnici;
            cbRadnik.DisplayMember = "ImePrezimeRadnika";
            cbRadnik.ValueMember = "RadnikID";

            cbClan.Items.Clear();
            var clanovi = BLPozajmica.GetMembers();
            clanovi.Insert(0, new Pozajmica() { ClanID = 0, ImePrezimeClana = "Izaberi clana" });
            cbClan.DataSource = clanovi;
            cbClan.DisplayMember = "ImePrezimeClana";
            cbClan.ValueMember = "ClanID";
            
            cbKnjiga.Items.Clear();
            var knjige = BLKnjiga.GetKnjigas();
            cbKnjiga.DataSource = BLKnjiga.GetKnjigas();
            cbKnjiga.DisplayMember = "Naziv";
            cbKnjiga.ValueMember = "KnjigaID";
            cbKnjiga.Enabled = false;
        }


        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            // Radnik nije izabran u combo boxu
            if (dtpDatumVracanja.Checked)
            {
                Pozajmica.DatumVracanja = dtpDatumVracanja.Value;
            }
            else
            {
                Pozajmica.DatumVracanja = null;
            }
            if (cbRadnik.SelectedIndex <= 0)
            {
                MessageBox.Show("Morate izabrati radnika!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbRadnik.Focus();
                return;
            }

            // Clan nije izabran u combo 
            if (cbClan.SelectedIndex <= 0)
            {
                MessageBox.Show("Morate izabrati člana!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbClan.Focus();
                return;
            }

            // Neispravan datumPozajmice
            if (!DateTime.TryParse(dtpDatumPozajmice.Text, out DateTime datumPozajmice))
            {
                MessageBox.Show("Neispravan format datuma pozajmice!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDatumPozajmice.Focus();
                return;
            }
            // Neispravan datum Isteka
            if (!DateTime.TryParse(dtpDatumIstekaPozajmice.Text, out DateTime datumIsteka))
            {
                MessageBox.Show("Neispravan format datuma isteka pozajmice!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDatumIstekaPozajmice.Focus();
                return;
            }

            // Datum isteka mora biti posle datuma pozajmice
            if (datumIsteka <= datumPozajmice)
            {
                MessageBox.Show("Datum isteka mora biti posle datuma pozajmice!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDatumIstekaPozajmice.Focus();
                return;
            }

            //Validacija Datum-a Vraćanja ukoliko postoji
            if (this.Pozajmica.PozajmicaID != 0 && !string.IsNullOrEmpty(dtpDatumVracanja.Text))
            {
                if (!DateTime.TryParse(dtpDatumVracanja.Text, out DateTime datumVracanja))
                {
                    MessageBox.Show("Neispravan format datuma vraćanja!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDatumVracanja.Focus();
                    return;
                }

                if (datumVracanja < datumPozajmice)
                {
                    MessageBox.Show("Datum vraćanja ne može biti pre datuma pozajmice!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDatumVracanja.Focus();
                    return;
                }
            }


            this.DialogResult =  DialogResult.OK;
            try
            {
                if (this.Pozajmica.PozajmicaID != 0)
                {
                    Pozajmica.ClanID = (int)cbClan.SelectedValue;
                    Pozajmica.RadnikID = (int)cbRadnik.SelectedValue;
                    Pozajmica.KnjigaID = (int)cbKnjiga.SelectedValue;
                    Pozajmica.DatumPozajmice = DateTime.Parse(dtpDatumPozajmice.Text);
                    Pozajmica.DatumIstekaPozajmice = DateTime.Parse(dtpDatumIstekaPozajmice.Text);
                    Pozajmica.DatumVracanja = DateTime.Parse(dtpDatumVracanja.Text);
                    //BLPozajmica.UpdatePozajmice(Pozajmica);
                }
                else
                {
                    Pozajmica.ClanID = (int)cbClan.SelectedValue;
                    Pozajmica.RadnikID = (int)cbRadnik.SelectedValue;
                    Pozajmica.KnjigaID = (int)cbKnjiga.SelectedValue;
                    Pozajmica.DatumPozajmice = DateTime.Parse(dtpDatumPozajmice.Text);
                    Pozajmica.DatumIstekaPozajmice = DateTime.Parse(dtpDatumIstekaPozajmice.Text);

                }
                this.Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom čuvanja pozajmice: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtpDatumIstekaPozajmice_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
