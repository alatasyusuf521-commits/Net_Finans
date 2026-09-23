namespace MuhasebeOtomasyonu.Forms
{
    partial class FormTahsilatGir
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
            this.lblIslemTipi = new System.Windows.Forms.Label();
            this.cmbIslemTipi = new System.Windows.Forms.ComboBox();
            this.lblCariSec = new System.Windows.Forms.Label();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.lblTutar = new System.Windows.Forms.Label();
            this.numTutar = new System.Windows.Forms.NumericUpDown();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.txtKullanici = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTutar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(217, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tahsilat / Ödeme Girişi";
            // 
            // lblIslemTipi
            // 
            this.lblIslemTipi.AutoSize = true;
            this.lblIslemTipi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIslemTipi.Location = new System.Drawing.Point(22, 58);
            this.lblIslemTipi.Name = "lblIslemTipi";
            this.lblIslemTipi.Size = new System.Drawing.Size(76, 17);
            this.lblIslemTipi.TabIndex = 11;
            this.lblIslemTipi.Text = "İşlem Türü:";
            // 
            // cmbIslemTipi
            // 
            this.cmbIslemTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemTipi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbIslemTipi.FormattingEnabled = true;
            this.cmbIslemTipi.Items.AddRange(new object[] {
            "Tahsilat (Ödeme Alındı)",
            "Borç Ekle (Hizmet/Satış)"});
            this.cmbIslemTipi.Location = new System.Drawing.Point(145, 55);
            this.cmbIslemTipi.Name = "cmbIslemTipi";
            this.cmbIslemTipi.Size = new System.Drawing.Size(300, 25);
            this.cmbIslemTipi.TabIndex = 12;
            // 
            // lblCariSec
            // 
            this.lblCariSec.AutoSize = true;
            this.lblCariSec.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCariSec.Location = new System.Drawing.Point(22, 98);
            this.lblCariSec.Name = "lblCariSec";
            this.lblCariSec.Size = new System.Drawing.Size(97, 17);
            this.lblCariSec.TabIndex = 1;
            this.lblCariSec.Text = "Müşteri (Cari):";
            // 
            // cmbCariler
            // 
            this.cmbCariler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariler.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(145, 95);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(300, 25);
            this.cmbCariler.TabIndex = 2;
            // 
            // lblTutar
            // 
            this.lblTutar.AutoSize = true;
            this.lblTutar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTutar.Location = new System.Drawing.Point(22, 138);
            this.lblTutar.Name = "lblTutar";
            this.lblTutar.Size = new System.Drawing.Size(117, 17);
            this.lblTutar.TabIndex = 3;
            this.lblTutar.Text = "Alınan Tutar (TL):";
            // 
            // numTutar
            // 
            this.numTutar.DecimalPlaces = 2;
            this.numTutar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numTutar.ForeColor = System.Drawing.Color.DarkGreen;
            this.numTutar.Location = new System.Drawing.Point(145, 135);
            this.numTutar.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numTutar.Name = "numTutar";
            this.numTutar.Size = new System.Drawing.Size(300, 27);
            this.numTutar.TabIndex = 4;
            this.numTutar.ThousandsSeparator = true;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAciklama.Location = new System.Drawing.Point(22, 178);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(68, 17);
            this.lblAciklama.TabIndex = 5;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAciklama.Location = new System.Drawing.Point(145, 175);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(300, 55);
            this.txtAciklama.TabIndex = 6;
            this.txtAciklama.Text = "Banka Havalesi / Nakit Tahsilat";
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKullanici.Location = new System.Drawing.Point(22, 245);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(73, 17);
            this.lblKullanici.TabIndex = 7;
            this.lblKullanici.Text = "İşlemi Yapan:";
            // 
            // txtKullanici
            // 
            this.txtKullanici.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtKullanici.Location = new System.Drawing.Point(145, 242);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(300, 25);
            this.txtKullanici.TabIndex = 8;
            this.txtKullanici.Text = "Ofis Kullanıcısı";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(325, 285);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(120, 38);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "💵 Kaydet";
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
            this.btnIptal.Location = new System.Drawing.Point(220, 285);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(95, 38);
            this.btnIptal.TabIndex = 10;
            this.btnIptal.Text = "❌ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // FormTahsilatGir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 345);
            this.Controls.Add(this.cmbIslemTipi);
            this.Controls.Add(this.lblIslemTipi);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtKullanici);
            this.Controls.Add(this.lblKullanici);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.numTutar);
            this.Controls.Add(this.lblTutar);
            this.Controls.Add(this.cmbCariler);
            this.Controls.Add(this.lblCariSec);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTahsilatGir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tahsilat / Borç Ekleme Ekranı";
            ((System.ComponentModel.ISupportInitialize)(this.numTutar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIslemTipi;
        private System.Windows.Forms.ComboBox cmbIslemTipi;
        private System.Windows.Forms.Label lblCariSec;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.Label lblTutar;
        private System.Windows.Forms.NumericUpDown numTutar;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.TextBox txtKullanici;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}