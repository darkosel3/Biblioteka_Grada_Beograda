namespace Biblioteka_Grada_Beograda
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbKnjiga = new System.Windows.Forms.ComboBox();
            this.cbRadnik = new System.Windows.Forms.ComboBox();
            this.cbClan = new System.Windows.Forms.ComboBox();
            this.lblDPozajmice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDatumVracanja = new System.Windows.Forms.Label();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.dtpDatumPozajmice = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumIstekaPozajmice = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumVracanja = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cbKnjiga
            // 
            this.cbKnjiga.FormattingEnabled = true;
            this.cbKnjiga.Location = new System.Drawing.Point(27, 54);
            this.cbKnjiga.Name = "cbKnjiga";
            this.cbKnjiga.Size = new System.Drawing.Size(354, 24);
            this.cbKnjiga.TabIndex = 0;
            // 
            // cbRadnik
            // 
            this.cbRadnik.FormattingEnabled = true;
            this.cbRadnik.Location = new System.Drawing.Point(27, 110);
            this.cbRadnik.Name = "cbRadnik";
            this.cbRadnik.Size = new System.Drawing.Size(354, 24);
            this.cbRadnik.TabIndex = 1;
            // 
            // cbClan
            // 
            this.cbClan.FormattingEnabled = true;
            this.cbClan.Location = new System.Drawing.Point(27, 169);
            this.cbClan.Name = "cbClan";
            this.cbClan.Size = new System.Drawing.Size(354, 24);
            this.cbClan.TabIndex = 2;
            // 
            // lblDPozajmice
            // 
            this.lblDPozajmice.AutoSize = true;
            this.lblDPozajmice.Location = new System.Drawing.Point(24, 32);
            this.lblDPozajmice.Name = "lblDPozajmice";
            this.lblDPozajmice.Size = new System.Drawing.Size(0, 16);
            this.lblDPozajmice.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Radnik";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Knjiga:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Clan:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Datum Pozajmice:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Datum Isteka Pozajmice";
            // 
            // lblDatumVracanja
            // 
            this.lblDatumVracanja.AutoSize = true;
            this.lblDatumVracanja.Location = new System.Drawing.Point(221, 213);
            this.lblDatumVracanja.Name = "lblDatumVracanja";
            this.lblDatumVracanja.Size = new System.Drawing.Size(106, 16);
            this.lblDatumVracanja.TabIndex = 12;
            this.lblDatumVracanja.Text = "Datum Vracanja:";
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Location = new System.Drawing.Point(216, 279);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(165, 29);
            this.btnSaveEdit.TabIndex = 13;
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // dtpDatumPozajmice
            // 
            this.dtpDatumPozajmice.Location = new System.Drawing.Point(27, 232);
            this.dtpDatumPozajmice.Name = "dtpDatumPozajmice";
            this.dtpDatumPozajmice.Size = new System.Drawing.Size(165, 22);
            this.dtpDatumPozajmice.TabIndex = 14;
            // 
            // dtpDatumIstekaPozajmice
            // 
            this.dtpDatumIstekaPozajmice.Location = new System.Drawing.Point(26, 286);
            this.dtpDatumIstekaPozajmice.Name = "dtpDatumIstekaPozajmice";
            this.dtpDatumIstekaPozajmice.Size = new System.Drawing.Size(166, 22);
            this.dtpDatumIstekaPozajmice.TabIndex = 15;
            this.dtpDatumIstekaPozajmice.ValueChanged += new System.EventHandler(this.dtpDatumIstekaPozajmice_ValueChanged);
            // 
            // dtpDatumVracanja
            // 
            this.dtpDatumVracanja.Location = new System.Drawing.Point(216, 232);
            this.dtpDatumVracanja.Name = "dtpDatumVracanja";
            this.dtpDatumVracanja.Size = new System.Drawing.Size(165, 22);
            this.dtpDatumVracanja.TabIndex = 16;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 331);
            this.Controls.Add(this.dtpDatumVracanja);
            this.Controls.Add(this.dtpDatumIstekaPozajmice);
            this.Controls.Add(this.dtpDatumPozajmice);
            this.Controls.Add(this.btnSaveEdit);
            this.Controls.Add(this.lblDatumVracanja);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDPozajmice);
            this.Controls.Add(this.cbClan);
            this.Controls.Add(this.cbRadnik);
            this.Controls.Add(this.cbKnjiga);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKnjiga;
        private System.Windows.Forms.ComboBox cbRadnik;
        private System.Windows.Forms.ComboBox cbClan;
        private System.Windows.Forms.Label lblDPozajmice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDatumVracanja;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.DateTimePicker dtpDatumPozajmice;
        private System.Windows.Forms.DateTimePicker dtpDatumIstekaPozajmice;
        private System.Windows.Forms.DateTimePicker dtpDatumVracanja;
    }
}