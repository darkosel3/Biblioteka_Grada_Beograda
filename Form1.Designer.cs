namespace Biblioteka_Grada_Beograda
{
    partial class Form1
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
            this.dgwPozajmice = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.broj_kopija = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGodinaIzdavanja = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IDKnjige = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnNovaPozajmica = new System.Windows.Forms.Button();
            this.saveXML = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPozajmice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbKnjiga
            // 
            this.cbKnjiga.FormattingEnabled = true;
            this.cbKnjiga.Location = new System.Drawing.Point(190, 66);
            this.cbKnjiga.Name = "cbKnjiga";
            this.cbKnjiga.Size = new System.Drawing.Size(366, 24);
            this.cbKnjiga.TabIndex = 0;
            this.cbKnjiga.SelectedIndexChanged += new System.EventHandler(this.cbKnjiga_SelectedIndexChanged_1);
            // 
            // dgwPozajmice
            // 
            this.dgwPozajmice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPozajmice.Location = new System.Drawing.Point(37, 148);
            this.dgwPozajmice.Name = "dgwPozajmice";
            this.dgwPozajmice.RowHeadersWidth = 51;
            this.dgwPozajmice.RowTemplate.Height = 24;
            this.dgwPozajmice.Size = new System.Drawing.Size(1084, 312);
            this.dgwPozajmice.TabIndex = 1;
            this.dgwPozajmice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwPozajmice_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Knjiga";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(763, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Broj slobodnih kopija:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // broj_kopija
            // 
            this.broj_kopija.AutoSize = true;
            this.broj_kopija.Location = new System.Drawing.Point(897, 38);
            this.broj_kopija.Name = "broj_kopija";
            this.broj_kopija.Size = new System.Drawing.Size(74, 16);
            this.broj_kopija.TabIndex = 4;
            this.broj_kopija.Text = "broj_kopija";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(784, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Godina Izdavanja:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(858, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Autor:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtGodinaIzdavanja
            // 
            this.txtGodinaIzdavanja.Location = new System.Drawing.Point(904, 103);
            this.txtGodinaIzdavanja.Name = "txtGodinaIzdavanja";
            this.txtGodinaIzdavanja.Size = new System.Drawing.Size(217, 22);
            this.txtGodinaIzdavanja.TabIndex = 7;
            this.txtGodinaIzdavanja.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(904, 65);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(217, 22);
            this.txtAutor.TabIndex = 8;
            this.txtAutor.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID Knjige:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // IDKnjige
            // 
            this.IDKnjige.AutoSize = true;
            this.IDKnjige.Location = new System.Drawing.Point(257, 107);
            this.IDKnjige.Name = "IDKnjige";
            this.IDKnjige.Size = new System.Drawing.Size(18, 16);
            this.IDKnjige.TabIndex = 10;
            this.IDKnjige.Text = "id";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(953, 474);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(168, 45);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Izbrisi";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(774, 474);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(168, 45);
            this.btnIzmeni.TabIndex = 12;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnNovaPozajmica
            // 
            this.btnNovaPozajmica.Location = new System.Drawing.Point(597, 474);
            this.btnNovaPozajmica.Name = "btnNovaPozajmica";
            this.btnNovaPozajmica.Size = new System.Drawing.Size(168, 45);
            this.btnNovaPozajmica.TabIndex = 13;
            this.btnNovaPozajmica.Text = "Novi";
            this.btnNovaPozajmica.UseVisualStyleBackColor = true;
            this.btnNovaPozajmica.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveXML
            // 
            this.saveXML.Location = new System.Drawing.Point(37, 474);
            this.saveXML.Name = "saveXML";
            this.saveXML.Size = new System.Drawing.Size(171, 45);
            this.saveXML.TabIndex = 14;
            this.saveXML.Text = "Sacuvaj podatke (XML)";
            this.saveXML.UseVisualStyleBackColor = true;
            this.saveXML.Click += new System.EventHandler(this.saveXML_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(37, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 98);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 534);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.saveXML);
            this.Controls.Add(this.btnNovaPozajmica);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.IDKnjige);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtGodinaIzdavanja);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.broj_kopija);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwPozajmice);
            this.Controls.Add(this.cbKnjiga);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPozajmice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKnjiga;
        private System.Windows.Forms.DataGridView dgwPozajmice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label broj_kopija;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGodinaIzdavanja;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label IDKnjige;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnNovaPozajmica;
        private System.Windows.Forms.Button saveXML;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

