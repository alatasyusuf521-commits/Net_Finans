namespace MuhasebeOtomasyonu.Forms
{
    partial class FormCariEkle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCariKodu = new System.Windows.Forms.Label();
            this.txtCariKodu = new System.Windows.Forms.TextBox();
            this.lblUnvan = new System.Windows.Forms.Label();
            this.txtUnvan = new System.Windows.Forms.TextBox();
            this.lblYetkili = new System.Windows.Forms.Label();
            this.txtYetkili = new System.Windows.Forms.TextBox();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.lblEposta = new System.Windows.Forms.Label();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblAylikUcret = new System.Windows.Forms.Label();
            this.numAylikUcret = new System.Windows.Forms.NumericUpDown();
            this.lblBorclanmaAySayisi = new System.Windows.Forms.Label();
            this.numBorclanmaAySayisi = new System.Windows.Forms.NumericUpDown();
            this.lblDevirBakiye = new System.Windows.Forms.Label();
            this.numDevirBakiye = new System.Windows.Forms.NumericUpDown();
            this.lblToplamBorc = new System.Windows.Forms.Label();
            this.numToplamBorc = new System.Windows.Forms.NumericUpDown();
            this.lblToplamTahsilat = new System.Windows.Forms.Label();
            this.numToplamTahsilat = new System.Windows.Forms.NumericUpDown();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnPasifeAl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAylikUcret)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorclanmaAySayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDevirBakiye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToplamBorc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToplamTahsilat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Yeni Cari Kartı Tanımı";
            // 
            // lblCariKodu
            // 
            this.lblCariKodu.AutoSize = true;
            this.lblCariKodu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCariKodu.Location = new System.Drawing.Point(22, 65);
            this.lblCariKodu.Name = "lblCariKodu";
            this.lblCariKodu.Size = new System.Drawing.Size(73, 17);
            this.lblCariKodu.TabIndex = 1;
            this.lblCariKodu.Text = "Cari Kodu:";
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCariKodu.Location = new System.Drawing.Point(170, 62);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.Size = new System.Drawing.Size(340, 25);
            this.txtCariKodu.TabIndex = 2;
            // 
            // lblUnvan
            // 
            this.lblUnvan.AutoSize = true;
            this.lblUnvan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUnvan.Location = new System.Drawing.Point(22, 105);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(102, 17);
            this.lblUnvan.TabIndex = 3;
            this.lblUnvan.Text = "Firma Ünvanı *:";
            // 
            // txtUnvan
            // 
            this.txtUnvan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUnvan.Location = new System.Drawing.Point(170, 102);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(340, 25);
            this.txtUnvan.TabIndex = 4;
            // 
            // lblYetkili
            // 
            this.lblYetkili.AutoSize = true;
            this.lblYetkili.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblYetkili.Location = new System.Drawing.Point(22, 145);
            this.lblYetkili.Name = "lblYetkili";
            this.lblYetkili.Size = new System.Drawing.Size(75, 17);
            this.lblYetkili.TabIndex = 5;
            this.lblYetkili.Text = "Yetkili Kişi:";
            // 
            // txtYetkili
            // 
            this.txtYetkili.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtYetkili.Location = new System.Drawing.Point(170, 142);
            this.txtYetkili.Name = "txtYetkili";
            this.txtYetkili.Size = new System.Drawing.Size(340, 25);
            this.txtYetkili.TabIndex = 6;
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTelefon.Location = new System.Drawing.Point(22, 185);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(58, 17);
            this.lblTelefon.TabIndex = 7;
            this.lblTelefon.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTelefon.Location = new System.Drawing.Point(170, 182);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(340, 25);
            this.txtTelefon.TabIndex = 8;
            // 
            // lblEposta
            // 
            this.lblEposta.AutoSize = true;
            this.lblEposta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEposta.Location = new System.Drawing.Point(22, 225);
            this.lblEposta.Name = "lblEposta";
            this.lblEposta.Size = new System.Drawing.Size(59, 17);
            this.lblEposta.TabIndex = 9;
            this.lblEposta.Text = "E-posta:";
            // 
            // txtEposta
            // 
            this.txtEposta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEposta.Location = new System.Drawing.Point(170, 222);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(340, 25);
            this.txtEposta.TabIndex = 10;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAdres.Location = new System.Drawing.Point(22, 265);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(47, 17);
            this.lblAdres.TabIndex = 11;
            this.lblAdres.Text = "Adres:";
            // 
            // txtAdres
            // 
            this.txtAdres.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAdres.Location = new System.Drawing.Point(170, 262);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(340, 60);
            this.txtAdres.TabIndex = 12;
            // 
            // lblAylikUcret
            // 
            this.lblAylikUcret.AutoSize = true;
            this.lblAylikUcret.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAylikUcret.Location = new System.Drawing.Point(22, 340);
            this.lblAylikUcret.Name = "lblAylikUcret";
            this.lblAylikUcret.Size = new System.Drawing.Size(111, 17);
            this.lblAylikUcret.TabIndex = 13;
            this.lblAylikUcret.Text = "Yıllık Ücret (TL):";
            // 
            // numAylikUcret
            // 
            this.numAylikUcret.DecimalPlaces = 2;
            this.numAylikUcret.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numAylikUcret.Location = new System.Drawing.Point(170, 337);
            this.numAylikUcret.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numAylikUcret.Name = "numAylikUcret";
            this.numAylikUcret.Size = new System.Drawing.Size(340, 25);
            this.numAylikUcret.TabIndex = 14;
            this.numAylikUcret.ThousandsSeparator = true;
            this.numAylikUcret.DoubleClick += new System.EventHandler(this.numAylikUcret_DoubleClick);
            // 
            // lblBorclanmaAySayisi
            // 
            this.lblBorclanmaAySayisi.AutoSize = true;
            this.lblBorclanmaAySayisi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBorclanmaAySayisi.Location = new System.Drawing.Point(22, 375);
            this.lblBorclanmaAySayisi.Name = "lblBorclanmaAySayisi";
            this.lblBorclanmaAySayisi.Size = new System.Drawing.Size(140, 17);
            this.lblBorclanmaAySayisi.TabIndex = 18;
            this.lblBorclanmaAySayisi.Text = "Borçlanma Ay Sayısı:";
            // 
            // numBorclanmaAySayisi
            // 
            this.numBorclanmaAySayisi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numBorclanmaAySayisi.Location = new System.Drawing.Point(170, 372);
            this.numBorclanmaAySayisi.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.numBorclanmaAySayisi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numBorclanmaAySayisi.Name = "numBorclanmaAySayisi";
            this.numBorclanmaAySayisi.Size = new System.Drawing.Size(340, 25);
            this.numBorclanmaAySayisi.TabIndex = 19;
            this.numBorclanmaAySayisi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDevirBakiye
            // 
            this.lblDevirBakiye.AutoSize = true;
            this.lblDevirBakiye.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDevirBakiye.Location = new System.Drawing.Point(22, 410);
            this.lblDevirBakiye.Name = "lblDevirBakiye";
            this.lblDevirBakiye.Size = new System.Drawing.Size(119, 17);
            this.lblDevirBakiye.TabIndex = 20;
            this.lblDevirBakiye.Text = "Devir Bakiye (TL):";
            // 
            // numDevirBakiye
            // 
            this.numDevirBakiye.DecimalPlaces = 2;
            this.numDevirBakiye.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numDevirBakiye.Location = new System.Drawing.Point(170, 407);
            this.numDevirBakiye.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numDevirBakiye.Name = "numDevirBakiye";
            this.numDevirBakiye.Size = new System.Drawing.Size(340, 25);
            this.numDevirBakiye.TabIndex = 21;
            this.numDevirBakiye.ThousandsSeparator = true;
            // 
            // lblToplamBorc
            // 
            this.lblToplamBorc.AutoSize = true;
            this.lblToplamBorc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblToplamBorc.Location = new System.Drawing.Point(22, 445);
            this.lblToplamBorc.Name = "lblToplamBorc";
            this.lblToplamBorc.Size = new System.Drawing.Size(121, 17);
            this.lblToplamBorc.TabIndex = 22;
            this.lblToplamBorc.Text = "Toplam Borç (TL):";
            // 
            // numToplamBorc
            // 
            this.numToplamBorc.DecimalPlaces = 2;
            this.numToplamBorc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numToplamBorc.Location = new System.Drawing.Point(170, 442);
            this.numToplamBorc.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            this.numToplamBorc.Name = "numToplamBorc";
            this.numToplamBorc.Size = new System.Drawing.Size(340, 25);
            this.numToplamBorc.TabIndex = 23;
            this.numToplamBorc.ThousandsSeparator = true;
            this.numToplamBorc.ReadOnly = false;
            this.numToplamBorc.BackColor = System.Drawing.Color.White;
            // 
            // lblToplamTahsilat
            // 
            this.lblToplamTahsilat.AutoSize = true;
            this.lblToplamTahsilat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblToplamTahsilat.Location = new System.Drawing.Point(22, 480);
            this.lblToplamTahsilat.Name = "lblToplamTahsilat";
            this.lblToplamTahsilat.Size = new System.Drawing.Size(141, 17);
            this.lblToplamTahsilat.TabIndex = 24;
            this.lblToplamTahsilat.Text = "Toplam Tahsilat (TL):";
            // 
            // numToplamTahsilat
            // 
            this.numToplamTahsilat.DecimalPlaces = 2;
            this.numToplamTahsilat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numToplamTahsilat.Location = new System.Drawing.Point(170, 477);
            this.numToplamTahsilat.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            this.numToplamTahsilat.Name = "numToplamTahsilat";
            this.numToplamTahsilat.Size = new System.Drawing.Size(340, 25);
            this.numToplamTahsilat.TabIndex = 25;
            this.numToplamTahsilat.ThousandsSeparator = true;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(315, 525);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(130, 38);
            this.btnKaydet.TabIndex = 26;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(205, 525);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(95, 38);
            this.btnIptal.TabIndex = 27;
            this.btnIptal.Text = "❌ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnPasifeAl
            // 
            this.btnPasifeAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnPasifeAl.FlatAppearance.BorderSize = 0;
            this.btnPasifeAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasifeAl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPasifeAl.ForeColor = System.Drawing.Color.White;
            this.btnPasifeAl.Location = new System.Drawing.Point(75, 525);
            this.btnPasifeAl.Name = "btnPasifeAl";
            this.btnPasifeAl.Size = new System.Drawing.Size(115, 38);
            this.btnPasifeAl.TabIndex = 28;
            this.btnPasifeAl.Text = "🗑️ Pasife Al";
            this.btnPasifeAl.UseVisualStyleBackColor = false;
            this.btnPasifeAl.Visible = false;
            this.btnPasifeAl.Click += new System.EventHandler(this.btnPasifeAl_Click);
            // 
            // FormCariEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 585);
            this.Controls.Add(this.btnPasifeAl);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.numToplamTahsilat);
            this.Controls.Add(this.lblToplamTahsilat);
            this.Controls.Add(this.numToplamBorc);
            this.Controls.Add(this.lblToplamBorc);
            this.Controls.Add(this.numDevirBakiye);
            this.Controls.Add(this.lblDevirBakiye);
            this.Controls.Add(this.numBorclanmaAySayisi);
            this.Controls.Add(this.lblBorclanmaAySayisi);
            this.Controls.Add(this.numAylikUcret);
            this.Controls.Add(this.lblAylikUcret);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.lblAdres);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.lblEposta);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.txtYetkili);
            this.Controls.Add(this.lblYetkili);
            this.Controls.Add(this.txtUnvan);
            this.Controls.Add(this.lblUnvan);
            this.Controls.Add(this.txtCariKodu);
            this.Controls.Add(this.lblCariKodu);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCariEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cari Tanımlama / Düzenleme";
            this.Load += new System.EventHandler(this.FormCariEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAylikUcret)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorclanmaAySayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDevirBakiye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToplamBorc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToplamTahsilat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCariKodu;
        private System.Windows.Forms.TextBox txtCariKodu;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.TextBox txtUnvan;
        private System.Windows.Forms.Label lblYetkili;
        private System.Windows.Forms.TextBox txtYetkili;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblEposta;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label lblAylikUcret;
        private System.Windows.Forms.NumericUpDown numAylikUcret;
        private System.Windows.Forms.Label lblBorclanmaAySayisi;
        private System.Windows.Forms.NumericUpDown numBorclanmaAySayisi;
        private System.Windows.Forms.Label lblDevirBakiye;
        private System.Windows.Forms.NumericUpDown numDevirBakiye;
        private System.Windows.Forms.Label lblToplamBorc;
        private System.Windows.Forms.NumericUpDown numToplamBorc;
        private System.Windows.Forms.Label lblToplamTahsilat;
        private System.Windows.Forms.NumericUpDown numToplamTahsilat;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnPasifeAl;
    }
}