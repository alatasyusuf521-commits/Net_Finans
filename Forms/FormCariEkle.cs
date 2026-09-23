using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MuhasebeOtomasyonu.Models;
using MuhasebeOtomasyonu.Services;

namespace MuhasebeOtomasyonu.Forms
{
    public partial class FormCariEkle : Form
    {
        private readonly CariService _cariService;
        private readonly MuhasebeService _muhasebeService;
        private int _cariId;
        private Cari? _existingCari;

        public FormCariEkle(int cariId = 0)
        {
            InitializeComponent();
            _cariService = new CariService();
            _muhasebeService = new MuhasebeService();
            _cariId = cariId;
        }

        private void FormCariEkle_Load(object sender, EventArgs e)
        {
            if (_cariId > 0)
            {
                lblTitle.Text = "Cari Bilgilerini Düzenle";
                btnPasifeAl.Visible = true;
                CariBilgileriniYukle();
            }
            else
            {
                lblTitle.Text = "Yeni Cari Kartı Tanımı";
                btnPasifeAl.Visible = false;
                txtCariKodu.Text = _cariService.OtomatikCariKoduUret();
            }
        }

        private void numAylikUcret_DoubleClick(object sender, EventArgs e)
        {
            if (_cariId <= 0)
            {
                MessageBox.Show(
                    "Önce cariyi kaydedin, sonra Yıllık Ücret'e çift tıklayarak aylık ücretleri girin.",
                    "Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (var frm = new FormAylikUcretListesi(_cariId, txtUnvan.Text.Trim()))
            {
                frm.Owner = this;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var cari = _cariService.GetById(_cariId);
                    if (cari != null)
                    {
                        numAylikUcret.Value = cari.AylikUcret;
                        MessageBox.Show(
                            $"Yıllık ücret güncellendi: {cari.AylikUcret:C2}",
                            "Bilgi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void CariBilgileriniYukle()
        {
            try
            {
                _existingCari = _cariService.GetById(_cariId);
                if (_existingCari != null)
                {
                    txtCariKodu.Text = _existingCari.CariKodu;
                    txtCariKodu.ReadOnly = true;
                    txtUnvan.Text = _existingCari.Unvan;
                    txtYetkili.Text = _existingCari.YetkiliKisi;
                    txtTelefon.Text = _existingCari.Telefon;
                    txtEposta.Text = _existingCari.Eposta;
                    txtAdres.Text = _existingCari.Adres;

                    numAylikUcret.Value = _existingCari.AylikUcret;
                    numDevirBakiye.Value = _existingCari.DevirBakiye;
                    numToplamBorc.Value = _existingCari.ToplamBorc;
                    numToplamTahsilat.Value = _existingCari.ToplamTahsilat;
                    numBorclanmaAySayisi.Value = _existingCari.BorclanmaAySayisi > 0 ? _existingCari.BorclanmaAySayisi : 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari bilgileri yüklenirken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void AylikUcretleriOtomatikGuncelle()
        {
            if (_cariId <= 0 || numAylikUcret.Value <= 0) return;

            try
            {
                var mevcutAylikUcretler = _cariService.AylikUcretleriGetir(_cariId);
                decimal aylikToplam = mevcutAylikUcretler.Sum();

                if (aylikToplam != numAylikUcret.Value)
                {
                    decimal aylikTutar = Math.Round(numAylikUcret.Value / 12, 2);
                    string[] aylar = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", 
                                        "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };

                    var aylikUcretler = new List<AylikUcret>();
                    decimal toplam = 0;

                    for (int i = 0; i < 12; i++)
                    {
                        decimal ucret = aylikTutar;
                        if (i == 11)
                        {
                            ucret = numAylikUcret.Value - toplam;
                        }

                        aylikUcretler.Add(new AylikUcret
                        {
                            AyIndex = i + 1,
                            AyAdi = aylar[i],
                            Ucret = Math.Round(ucret, 2)
                        });

                        toplam += ucret;
                    }

                    _cariService.AylikUcretleriGuncelle(_cariId, aylikUcretler);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Aylık ücret otomatik güncelleme hatası: {ex.Message}");
            }
        }

        private bool Kaydet()
        {
            if (string.IsNullOrWhiteSpace(txtUnvan.Text))
            {
                MessageBox.Show("Lütfen müşteri/firma ünvanını giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnvan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCariKodu.Text))
            {
                MessageBox.Show("Lütfen cari kodunu giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCariKodu.Focus();
                return false;
            }

            try
            {
                if (_cariId > 0 && _existingCari != null)
                {
                    _existingCari.Unvan = txtUnvan.Text.Trim();
                    _existingCari.YetkiliKisi = txtYetkili.Text.Trim();
                    _existingCari.Telefon = txtTelefon.Text.Trim();
                    _existingCari.Eposta = txtEposta.Text.Trim();
                    _existingCari.Adres = txtAdres.Text.Trim();
                    _existingCari.AylikUcret = numAylikUcret.Value;
                    _existingCari.BorclanmaAySayisi = (int)numBorclanmaAySayisi.Value;
                    _existingCari.DevirBakiye = numDevirBakiye.Value;
                    _existingCari.ToplamBorc = numToplamBorc.Value;
                    _existingCari.ToplamTahsilat = numToplamTahsilat.Value;

                    if (_cariService.Guncelle(_existingCari))
                    {
                        AylikUcretleriOtomatikGuncelle();
                        return true;
                    }
                    return false;
                }
                else
                {
                    var yeniCari = new Cari
                    {
                        CariKodu = txtCariKodu.Text.Trim(),
                        Unvan = txtUnvan.Text.Trim(),
                        YetkiliKisi = txtYetkili.Text.Trim(),
                        Telefon = txtTelefon.Text.Trim(),
                        Eposta = txtEposta.Text.Trim(),
                        Adres = txtAdres.Text.Trim(),
                        AylikUcret = numAylikUcret.Value,
                        BorclanmaAySayisi = (int)numBorclanmaAySayisi.Value,
                        DevirBakiye = numDevirBakiye.Value,
                        ToplamBorc = numToplamBorc.Value,
                        ToplamTahsilat = numToplamTahsilat.Value
                    };

                    if (_cariService.Ekle(yeniCari))
                    {
                        _cariId = yeniCari.CariID;
                        _existingCari = yeniCari;
                        AylikUcretleriOtomatikGuncelle();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaydetme işlemi sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Kaydet())
            {
                MessageBox.Show("Cari bilgileri başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnPasifeAl_Click(object sender, EventArgs e)
        {
            if (_cariId <= 0) return;

            var result = MessageBox.Show(
                "Bu cariyi pasife almak istediğinizden emin misiniz?",
                "Cari Pasife Alma Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_cariService.PasifeAl(_cariId))
                    {
                        MessageBox.Show("Cari başarıyla pasife alındı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"İşlem sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}