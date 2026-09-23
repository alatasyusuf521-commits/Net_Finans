using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MuhasebeOtomasyonu.Models;
using MuhasebeOtomasyonu.Services;

namespace MuhasebeOtomasyonu.Forms
{
    public partial class FormCopKutusu : Form
    {
        private readonly CariService _cariService;

        public FormCopKutusu()
        {
            InitializeComponent();
            _cariService = new CariService();
        }

        private void FormCopKutusu_Load(object sender, EventArgs e)
        {
            ListeyiYukle();
        }

        public void ListeyiYukle()
        {
            try
            {
                var liste = _cariService.CopKutusunuListele();
                DataGridGuncelle(liste);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çöp kutusu verileri yüklenirken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridGuncelle(List<CariCopKutusuView> liste)
        {
            dgvCopKutusu.DataSource = null;
            dgvCopKutusu.DataSource = liste;

            if (dgvCopKutusu.Columns["CariID"] != null) dgvCopKutusu.Columns["CariID"].Visible = false;
            if (dgvCopKutusu.Columns["SilinmeTarihi"] != null) dgvCopKutusu.Columns["SilinmeTarihi"].Visible = false;
            if (dgvCopKutusu.Columns["Donem"] != null) dgvCopKutusu.Columns["Donem"].Visible = false;
            if (dgvCopKutusu.Columns["AylikUcret"] != null) dgvCopKutusu.Columns["AylikUcret"].Visible = false;
            if (dgvCopKutusu.Columns["DevirBakiye"] != null) dgvCopKutusu.Columns["DevirBakiye"].Visible = false;
            if (dgvCopKutusu.Columns["ToplamBorc"] != null) dgvCopKutusu.Columns["ToplamBorc"].Visible = false;
            if (dgvCopKutusu.Columns["ToplamAlacak"] != null) dgvCopKutusu.Columns["ToplamAlacak"].Visible = false;
            if (dgvCopKutusu.Columns["Bakiye"] != null) dgvCopKutusu.Columns["Bakiye"].Visible = false;
            if (dgvCopKutusu.Columns["KalanGun"] != null) dgvCopKutusu.Columns["KalanGun"].Visible = false;

            if (dgvCopKutusu.Columns["CariKodu"] != null)
            {
                dgvCopKutusu.Columns["CariKodu"].HeaderText = "Cari Kodu";
                dgvCopKutusu.Columns["CariKodu"].Width = 110;
            }

            if (dgvCopKutusu.Columns["Unvan"] != null)
            {
                dgvCopKutusu.Columns["Unvan"].HeaderText = "Müşteri / Cari Ünvanı";
                dgvCopKutusu.Columns["Unvan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvCopKutusu.Columns["Telefon"] != null)
            {
                dgvCopKutusu.Columns["Telefon"].HeaderText = "Telefon";
                dgvCopKutusu.Columns["Telefon"].Width = 130;
            }

            if (dgvCopKutusu.Columns["SilinmeTarihiFormatli"] != null)
            {
                dgvCopKutusu.Columns["SilinmeTarihiFormatli"].HeaderText = "Silinme Tarihi";
                dgvCopKutusu.Columns["SilinmeTarihiFormatli"].Width = 140;
                dgvCopKutusu.Columns["SilinmeTarihiFormatli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvCopKutusu.Columns["KalanSureFormatli"] != null)
            {
                dgvCopKutusu.Columns["KalanSureFormatli"].HeaderText = "Otomatik Silinmeye Kalan";
                dgvCopKutusu.Columns["KalanSureFormatli"].Width = 160;
                dgvCopKutusu.Columns["KalanSureFormatli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCopKutusu.Columns["KalanSureFormatli"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvCopKutusu.Columns["KalanSureFormatli"].DefaultCellStyle.ForeColor = Color.FromArgb(211, 84, 0);
            }
        }

        private CariCopKutusuView? SeciliCariGetir()
        {
            if (dgvCopKutusu.CurrentRow == null) return null;
            return dgvCopKutusu.CurrentRow.DataBoundItem as CariCopKutusuView;
        }

        private void btnGeriYukle_Click(object sender, EventArgs e)
        {
            var cari = SeciliCariGetir();
            if (cari == null)
            {
                MessageBox.Show("Lütfen geri yüklemek istediğiniz cari hesabı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show(
                $"'{cari.Unvan}' isimli cari hesap geri yüklensin mi?\n\n" +
                $"📌 Cari hesap aktif cari listesine tekrar eklenecektir.",
                "Geri Yükleme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog != DialogResult.Yes) return;

            try
            {
                if (_cariService.GeriYukle(cari.CariID))
                {
                    MessageBox.Show("✅ Cari hesap başarıyla geri yüklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeyiYukle();
                }
                else
                {
                    MessageBox.Show("Geri yükleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Geri yükleme sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaliciSil_Click(object sender, EventArgs e)
        {
            var cari = SeciliCariGetir();
            if (cari == null)
            {
                MessageBox.Show("Lütfen kalıcı olarak silmek istediğiniz cari hesabı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show(
                $"⚠️ '{cari.Unvan}' isimli cari hesabı veritabanından KALICI OLARAK silinecektir!\n\n" +
                "❌ Bu işlem geri ALINAMAZ ve ilişkili tüm veriler silinecektir. Devam etmek istiyor musunuz?",
                "Kalıcı Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialog != DialogResult.Yes) return;

            try
            {
                if (_cariService.KaliciSil(cari.CariID))
                {
                    MessageBox.Show("✅ Cari hesap veritabanından kalıcı olarak silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeyiYukle();
                }
                else
                {
                    MessageBox.Show("Kalıcı silme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kalıcı silme sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBosalt_Click(object sender, EventArgs e)
        {
            int adet = _cariService.CopKutusuAdetGetir();
            if (adet == 0)
            {
                MessageBox.Show("Çöp kutusu zaten boş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialog = MessageBox.Show(
                $"⚠️ Çöp kutusundaki {adet} adet cari hesabı kalıcı olarak veritabanından silinecektir!\n\n" +
                "❌ Bu işlem GERİ ALINAMAZ! Çöp kutusunu boşaltmak istediğinize emin misiniz?",
                "Çöp Kutusunu Boşalt Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialog != DialogResult.Yes) return;

            try
            {
                int silinen = _cariService.CopKutusunuBosalt();
                MessageBox.Show($"✅ Çöp kutusu boşaltıldı. {silinen} adet kayıt veritabanından temizlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeyiYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çöp kutusu boşaltılırken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
