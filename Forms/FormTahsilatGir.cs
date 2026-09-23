using System;
using System.Drawing;
using System.Windows.Forms;
using MuhasebeOtomasyonu.Models;
using MuhasebeOtomasyonu.Services;

namespace MuhasebeOtomasyonu.Forms
{
    public partial class FormTahsilatGir : Form
    {
        private readonly CariService _cariService;
        private readonly MuhasebeService _muhasebeService;
        private readonly int _seciliCariId;
        private readonly int _aktifDonem;

        public FormTahsilatGir() : this(0, DateTime.Now.Year)
        {
        }

        public FormTahsilatGir(int seciliCariId) : this(seciliCariId, DateTime.Now.Year)
        {
        }

        public FormTahsilatGir(int seciliCariId, int aktifDonem)
        {
            InitializeComponent();
            _cariService = new CariService();
            _muhasebeService = new MuhasebeService();
            _seciliCariId = seciliCariId;
            _aktifDonem = aktifDonem;

            this.Load += FormTahsilatGir_Load;
        }

        private void FormTahsilatGir_Load(object? sender, EventArgs e)
        {
            if (cmbIslemTipi.Items.Count > 0)
            {
                cmbIslemTipi.SelectedIndex = 0;
            }

            cmbIslemTipi.SelectedIndexChanged += CmbIslemTipi_SelectedIndexChanged;
            CarileriYukle();
        }

        private void CmbIslemTipi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbIslemTipi.SelectedIndex == 1)
            {
                btnKaydet.Text = "📌 Borç Kaydet";
                btnKaydet.BackColor = Color.FromArgb(192, 57, 43);
                txtAciklama.Text = "Hizmet / Satış Borç Kaydı";
            }
            else
            {
                btnKaydet.Text = "💵 Tahsil Et";
                btnKaydet.BackColor = Color.FromArgb(39, 174, 96);
                txtAciklama.Text = "Banka Havalesi / Nakit Tahsilat";
            }
        }

        private void CarileriYukle()
        {
            try
            {
                var cariler = _cariService.Listele(_aktifDonem);

                if (cariler == null || cariler.Count == 0)
                {
                    MessageBox.Show("Sistemde işlem yapılacak cari bulunamadı. Lütfen önce 'Cari / Müşteri Ekle' ekranından cari oluşturun.", "Cari Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cmbCariler.DataSource = null;
                cmbCariler.DisplayMember = "Unvan";
                cmbCariler.ValueMember = "CariID";
                cmbCariler.DataSource = cariler;

                if (_seciliCariId > 0)
                {
                    cmbCariler.SelectedValue = _seciliCariId;
                }
                else if (cmbCariler.Items.Count > 0)
                {
                    cmbCariler.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cariler veritabanından çekilirken hata oluştu:\n{ex.Message}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbCariler.SelectedItem == null || cmbCariler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen geçerli bir cari seçiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numTutar.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numTutar.Focus();
                return;
            }

            dynamic seciliCari = cmbCariler.SelectedItem;
            int cariId = 0;

            try
            {
                cariId = Convert.ToInt32(seciliCari.CariID);
            }
            catch
            {
                if (cmbCariler.SelectedValue != null)
                    int.TryParse(cmbCariler.SelectedValue.ToString(), out cariId);
            }

            if (cariId == 0)
            {
                MessageBox.Show("Seçilen cariye ait ID alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal tutar = numTutar.Value;
            string aciklama = txtAciklama.Text.Trim();
            string kullanici = string.IsNullOrWhiteSpace(txtKullanici.Text) ? "Sistem" : txtKullanici.Text.Trim();

            bool isBorc = cmbIslemTipi.SelectedIndex == 1;

            try
            {
                if (isBorc)
                {
                    if (_muhasebeService.BorcEkle(cariId, tutar, string.IsNullOrWhiteSpace(aciklama) ? "Hizmet / Borç Kaydı" : aciklama, kullanici))
                    {
                        // ✅ Borç sonrası cari bilgilerini güncelle (Sadece ToplamBorc güncellenir, Bakiye otomatik hesaplanır)
                        var guncelCari = _cariService.GetById(cariId);
                        if (guncelCari != null)
                        {
                            guncelCari.ToplamBorc += tutar;
                            // ToplamTahsilat değişmedi, Bakiye otomatik hesaplanacak
                            _cariService.Guncelle(guncelCari);
                        }

                        MessageBox.Show($"Borç kaydı başarıyla oluşturuldu!\nTutar: {tutar:C2}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Borç kaydı oluşturulamadı. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (_muhasebeService.TahsilatEkle(cariId, tutar, string.IsNullOrWhiteSpace(aciklama) ? "Banka Havalesi / Nakit Tahsilat" : aciklama, kullanici))
                    {
                        // ✅ Tahsilat sonrası cari bilgilerini güncelle (Sadece ToplamTahsilat güncellenir, Bakiye otomatik hesaplanır)
                        var guncelCari = _cariService.GetById(cariId);
                        if (guncelCari != null)
                        {
                            guncelCari.ToplamTahsilat += tutar;
                            // ToplamBorc değişmedi, Bakiye otomatik hesaplanacak
                            _cariService.Guncelle(guncelCari);
                        }

                        MessageBox.Show($"Tahsilat başarıyla kaydedildi!\nTutar: {tutar:C2}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Tahsilat kaydedilemedi. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}