using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MuhasebeOtomasyonu.Models;
using MuhasebeOtomasyonu.Services;

namespace MuhasebeOtomasyonu.Forms
{
    public partial class FormMain : Form
    {
        private readonly CariService _cariService;
        private readonly MuhasebeService _muhasebeService;
        private List<CariBakiyeView> _cariListesi = new List<CariBakiyeView>();
        private int _aktifDonem = 2026;

        private readonly Color COLOR_ACTIVE_MENU = Color.FromArgb(41, 128, 185);
        private readonly Color COLOR_INACTIVE_MENU = Color.Transparent;
        private readonly Color COLOR_ACTIVE_TEXT = Color.White;
        private readonly Color COLOR_INACTIVE_TEXT = Color.FromArgb(189, 195, 199);

        public FormMain()
        {
            InitializeComponent();
            try
            {
                var icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                if (icon != null) this.Icon = icon;
            }
            catch { }
            _cariService = new CariService();
            _muhasebeService = new MuhasebeService();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AylariYukle();
            
            bool devirYapilmis = _cariService.DevirYapilmisMi();
            
            if (devirYapilmis)
            {
                cmbDonem.SelectedIndex = 1;
                _aktifDonem = 2027;
            }
            else
            {
                cmbDonem.SelectedIndex = 0;
                _aktifDonem = 2026;
            }
            
            ListeyiYukle(_aktifDonem);
            AktifModulDegistir(isCariKartlar: true);
            
            DonemeGoreButonlariGuncelle(_aktifDonem);
            YilSonuDevirKontrol();

            _cariService.OtomatikCopKutusuTemizle();
            CopKutusuRozetGuncelle();
        }

        private void cmbDonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDonem.SelectedItem == null) return;
            
            int secilenYil = Convert.ToInt32(cmbDonem.SelectedItem.ToString());
            _aktifDonem = secilenYil;
            
            DonemeGoreButonlariGuncelle(secilenYil);
            ListeyiYukle(secilenYil);
        }

        private void DonemeGoreButonlariGuncelle(int yil)
        {
            btnYeniCari.Enabled = true;
            btnYeniCari.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            
            btnTahsilatGir.Enabled = true;
            btnTahsilatGir.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            
            btnSil.Enabled = true;
            btnSil.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            
            btnYenile.Enabled = true;
            btnEkstre.Enabled = true;
            
            bool oYilinDevriYapilmis = _cariService.BuYilDevirYapilmisMi(yil);
            
            if (oYilinDevriYapilmis)
            {
                btnYilSonuDevir.Enabled = false;
                btnYilSonuDevir.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                btnYilSonuDevir.Enabled = true;
                btnYilSonuDevir.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            }
            btnYilSonuDevir.Text = "📅 Yıl Sonu Devir";
            
            lblTitleCari.Text = $"📅 {yil} Dönemi";
            lblTitleCari.ForeColor = Color.White;
            
            bool herhangiBirDevirVarMi = _cariService.DevirYapilmisMi();
            btnDevirGeriAl.Visible = true;
            btnDevirGeriAl.Enabled = herhangiBirDevirVarMi;
            btnDevirGeriAl.BackColor = herhangiBirDevirVarMi
                ? System.Drawing.Color.FromArgb(243, 156, 18)
                : System.Drawing.Color.Gray;
        }

        private void YilSonuDevirKontrol()
        {
            if (DateTime.Now.Month == 12)
            {
                var sonDevir = _cariService.SonDevirTarihiKontrol();
                
                if (!sonDevir.HasValue || sonDevir.Value.Year < DateTime.Now.Year)
                {
                    var result = MessageBox.Show(
                        "📅 Yıl sonu yaklaşıyor!\n\n" +
                        $"{DateTime.Now.Year} yılı hesaplarını {DateTime.Now.Year + 1} yılına devretmek için 'Yıl Sonu Devir' işlemini yapmanız önerilir.\n\n" +
                        "Şimdi devir işlemini yapmak ister misiniz?",
                        "Yıl Sonu Devir Uyarısı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        btnYilSonuDevir_Click(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void DonemEkle(int yil)
        {
            if (cmbDonem == null) return;
            
            foreach (var item in cmbDonem.Items)
            {
                if (item.ToString() == yil.ToString())
                    return;
            }
            
            cmbDonem.Items.Add(yil.ToString());
            
            var yillar = new List<int>();
            foreach (var item in cmbDonem.Items)
            {
                yillar.Add(Convert.ToInt32(item));
            }
            yillar.Sort();
            
            cmbDonem.Items.Clear();
            foreach (var y in yillar)
            {
                cmbDonem.Items.Add(y.ToString());
            }
        }

        private void AylariYukle()
        {
            if (clbAylar == null) return;

            clbAylar.ItemCheck -= clbAylar_ItemCheck;
            clbAylar.Items.Clear();

            string[] aylar = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
            clbAylar.Items.AddRange(aylar);

            int mevcutAyIndex = DateTime.Now.Month - 1;
            if (mevcutAyIndex >= 0 && mevcutAyIndex < 12)
            {
                clbAylar.SetItemChecked(mevcutAyIndex, true);
            }

            clbAylar.ItemCheck += clbAylar_ItemCheck;
        }

        private void clbAylar_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            if (clbAylar == null) return;

            int anlikSeciliSayi = clbAylar.CheckedItems.Count;

            if (e.NewValue == CheckState.Checked && e.CurrentValue != CheckState.Checked)
            {
                anlikSeciliSayi++;
            }
            else if (e.NewValue == CheckState.Unchecked && e.CurrentValue == CheckState.Checked)
            {
                anlikSeciliSayi--;
            }

            ListeyiAySayisinaGoreYukle(anlikSeciliSayi);
        }

        private void ListeyiAySayisinaGoreYukle(int aySayisi)
        {
            try
            {
                var tumListe = _cariService.Listele(_aktifDonem);
                DataGridGuncelle(tumListe);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ListeyiYukle(int yil)
        {
            try
            {
                _cariListesi = _cariService.Listele(yil);
                DataGridGuncelle(_cariListesi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ListeyiYukle()
        {
            ListeyiYukle(_aktifDonem);
        }

        private void DataGridGuncelle(List<CariBakiyeView> liste)
        {
            dgvCariler.DataSource = null;
            dgvCariler.DataSource = liste;

            if (dgvCariler.Columns["CariID"] != null) dgvCariler.Columns["CariID"].Visible = false;
            if (dgvCariler.Columns["Durum"] != null) dgvCariler.Columns["Durum"].Visible = false;
            if (dgvCariler.Columns["KayitTarihi"] != null) dgvCariler.Columns["KayitTarihi"].Visible = false;
            if (dgvCariler.Columns["YetkiliKisi"] != null) dgvCariler.Columns["YetkiliKisi"].Visible = false;
            if (dgvCariler.Columns["Eposta"] != null) dgvCariler.Columns["Eposta"].Visible = false;
            if (dgvCariler.Columns["Adres"] != null) dgvCariler.Columns["Adres"].Visible = false;
            if (dgvCariler.Columns["BorclanmaAySayisi"] != null) dgvCariler.Columns["BorclanmaAySayisi"].Visible = false;
            if (dgvCariler.Columns["ToplamBorc"] != null) dgvCariler.Columns["ToplamBorc"].Visible = false;

            if (dgvCariler.Columns["CariKodu"] != null)
            {
                dgvCariler.Columns["CariKodu"].HeaderText = "Cari Kodu";
                dgvCariler.Columns["CariKodu"].Width = 120;
            }

            if (dgvCariler.Columns["Unvan"] != null)
            {
                dgvCariler.Columns["Unvan"].HeaderText = "Müşteri / Cari Ünvanı";
                dgvCariler.Columns["Unvan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvCariler.Columns["Telefon"] != null)
            {
                dgvCariler.Columns["Telefon"].HeaderText = "Telefon";
                dgvCariler.Columns["Telefon"].Width = 130;
            }

            if (dgvCariler.Columns["AylikUcret"] != null)
            {
                dgvCariler.Columns["AylikUcret"].HeaderText = "Yıllık Ücret";
                dgvCariler.Columns["AylikUcret"].DefaultCellStyle.Format = "C2";
                dgvCariler.Columns["AylikUcret"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCariler.Columns["AylikUcret"].Width = 120;
            }

            if (dgvCariler.Columns["DevirBakiye"] != null)
            {
                dgvCariler.Columns["DevirBakiye"].HeaderText = "Devir Bakiye";
                dgvCariler.Columns["DevirBakiye"].DefaultCellStyle.Format = "C2";
                dgvCariler.Columns["DevirBakiye"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCariler.Columns["DevirBakiye"].DefaultCellStyle.ForeColor = Color.FromArgb(230, 126, 34);
                dgvCariler.Columns["DevirBakiye"].Width = 120;
            }

            if (dgvCariler.Columns["ToplamBorcDevirli"] != null)
            {
                dgvCariler.Columns["ToplamBorcDevirli"].HeaderText = "Toplam Borç";
                dgvCariler.Columns["ToplamBorcDevirli"].DefaultCellStyle.Format = "C2";
                dgvCariler.Columns["ToplamBorcDevirli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCariler.Columns["ToplamBorcDevirli"].DefaultCellStyle.ForeColor = Color.DarkRed;
                dgvCariler.Columns["ToplamBorcDevirli"].Width = 130;
                
                foreach (DataGridViewRow row in dgvCariler.Rows)
                {
                    if (row.DataBoundItem is CariBakiyeView item)
                    {
                        row.Cells["ToplamBorcDevirli"].Value = item.AylikUcret + item.DevirBakiye;
                    }
                }
            }

            if (dgvCariler.Columns["ToplamAlacak"] != null)
            {
                dgvCariler.Columns["ToplamAlacak"].HeaderText = "Toplam Tahsilat";
                dgvCariler.Columns["ToplamAlacak"].DefaultCellStyle.Format = "C2";
                dgvCariler.Columns["ToplamAlacak"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCariler.Columns["ToplamAlacak"].DefaultCellStyle.ForeColor = Color.DarkGreen;
                dgvCariler.Columns["ToplamAlacak"].Width = 130;
            }

            if (dgvCariler.Columns["Bakiye"] != null)
            {
                dgvCariler.Columns["Bakiye"].HeaderText = "Bakiye (Kalan)";
                dgvCariler.Columns["Bakiye"].DefaultCellStyle.Format = "C2";
                dgvCariler.Columns["Bakiye"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCariler.Columns["Bakiye"].DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                dgvCariler.Columns["Bakiye"].Width = 140;
                
                foreach (DataGridViewRow row in dgvCariler.Rows)
                {
                    if (row.DataBoundItem is CariBakiyeView item)
                    {
                        row.Cells["Bakiye"].Value = (item.AylikUcret + item.DevirBakiye) - item.ToplamAlacak;
                    }
                }
            }

            AltToplamlariGuncelle(liste);
        }

        private void AltToplamlariGuncelle(List<CariBakiyeView> liste)
        {
            decimal genelBorc = liste.Sum(x => x.AylikUcret + x.DevirBakiye);
            decimal genelTahsilat = liste.Sum(x => x.ToplamAlacak);
            decimal genelBakiye = genelBorc - genelTahsilat;

            if (lblGenelBorc != null) lblGenelBorc.Text = genelBorc.ToString("C2");
            if (lblGenelAlacak != null) lblGenelAlacak.Text = genelTahsilat.ToString("C2");
            if (lblGenelBakiye != null) lblGenelBakiye.Text = genelBakiye.ToString("C2");

            if (lblGenelBorc != null) lblGenelBorc.Text = genelBorc.ToString("C2");
            if (lblGenelAlacak != null) lblGenelAlacak.Text = genelTahsilat.ToString("C2");
            if (lblGenelBakiye != null) lblGenelBakiye.Text = genelBakiye.ToString("C2");

            if (pnlCardBakiye != null)
            {
                pnlCardBakiye.BackColor = genelBakiye > 0
                    ? Color.FromArgb(192, 57, 43)
                    : Color.FromArgb(39, 174, 96);
            }
        }

        #region Navigasyon ve Menü Değişimi

        private void btnMenuCari_Click(object sender, EventArgs e)
        {
            AktifModulDegistir(isCariKartlar: true);
        }

        private void btnMenuMuhasebe_Click(object sender, EventArgs e)
        {
            AktifModulDegistir(isCariKartlar: false);
        }

        private void AktifModulDegistir(bool isCariKartlar)
        {
            pnlCariKartlarModul.Visible = isCariKartlar;
            pnlMuhasebeModul.Visible = !isCariKartlar;

            if (isCariKartlar)
            {
                btnMenuCari.BackColor = COLOR_ACTIVE_MENU;
                btnMenuCari.ForeColor = COLOR_ACTIVE_TEXT;

                btnMenuMuhasebe.BackColor = COLOR_INACTIVE_MENU;
                btnMenuMuhasebe.ForeColor = COLOR_INACTIVE_TEXT;

                pnlCariKartlarModul.BringToFront();
            }
            else
            {
                btnMenuMuhasebe.BackColor = COLOR_ACTIVE_MENU;
                btnMenuMuhasebe.ForeColor = COLOR_ACTIVE_TEXT;

                btnMenuCari.BackColor = COLOR_INACTIVE_MENU;
                btnMenuCari.ForeColor = COLOR_INACTIVE_TEXT;

                pnlMuhasebeModul.BringToFront();
            }
        }

        private void btnMenuCikis_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion

        #region İşlem Butonları

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string arama = txtArama.Text.Trim();
                if (string.IsNullOrEmpty(arama))
                {
                    ListeyiYukle();
                }
                else
                {
                    var filtrelenmis = _cariService.AramaYap(arama, _aktifDonem);
                    DataGridGuncelle(filtrelenmis);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYeniCari_Click(object sender, EventArgs e)
        {
            using (var frm = new FormCariEkle())
            {
                frm.Owner = this;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ListeyiYukle();
                }
            }
        }

        private void btnTahsilatGir_Click(object sender, EventArgs e)
        {
            int seciliCariId = GetSeciliCariId();

            if (seciliCariId <= 0)
            {
                MessageBox.Show("Lütfen tahsilat yapmak istediğiniz cariyi tablodan seçiniz.", "Cari Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new FormTahsilatGir(seciliCariId, _aktifDonem))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ListeyiYukle();
                }
            }
        }

        private void btnEkstre_Click(object sender, EventArgs e)
        {
            int seciliCariId = GetSeciliCariId();
            if (seciliCariId <= 0)
            {
                MessageBox.Show("Lütfen ekstresini görmek istediğiniz cariyi tablodan seçiniz.", "Cari Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new FormCariEkstre(seciliCariId, _aktifDonem))
            {
                frm.ShowDialog();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            ListeyiYukle();
        }

        private void btnYilSonuDevir_Click(object sender, EventArgs e)
        {
            bool oYilinDevriYapilmis = _cariService.BuYilDevirYapilmisMi(_aktifDonem);
            
            if (oYilinDevriYapilmis)
            {
                MessageBox.Show(
                    $"{_aktifDonem} yılı devir işlemi zaten yapılmıştır.\n\n" +
                    $"Devir yapmak için önce 'Devir Geri Al' butonuna tıklayarak devri geri almalısınız.", 
                    "Uyarı", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            int kaynakYil = _aktifDonem;
            int hedefYil = _aktifDonem + 1;

            var result = MessageBox.Show(
                $"{kaynakYil} yılı sonu devir işlemi yapılacaktır.\n\n" +
                $"📌 Tüm carilerin kalan bakiyeleri {hedefYil} yılına Devir Bakiye olarak aktarılacaktır.\n\n" +
                "⚠️ Bu işlem GERİ ALINAMAZ! Devam etmek istediğinize emin misiniz?",
                "Yıl Sonu Devir Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                int islenenSayi = _cariService.YilSonuDevir(kaynakYil, hedefYil);
                
                btnDevirGeriAl.Enabled = true;
                btnDevirGeriAl.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
                
                DonemEkle(hedefYil);
                
                MessageBox.Show(
                    $"✅ Yıl sonu devir işlemi başarıyla tamamlandı!\n\n" +
                    $"📊 {islenenSayi} cari hesabı {hedefYil} yılına devredildi.\n\n" +
                    $"📌 Ekran otomatik olarak {hedefYil} dönemine geçirilmiştir.",
                    "Devir Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Otomatik olarak yeni devredilen döneme geç
                if (cmbDonem.Items.Contains(hedefYil.ToString()))
                {
                    cmbDonem.SelectedItem = hedefYil.ToString();
                }
                else
                {
                    DonemeGoreButonlariGuncelle(_aktifDonem);
                    ListeyiYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Devir işlemi sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDevirGeriAl_Click(object sender, EventArgs e)
        {
            bool devirYapilmis = _cariService.DevirYapilmisMi();
            
            if (!devirYapilmis)
            {
                MessageBox.Show(
                    "Sistemde yapılmış bir devir işlemi bulunamadı.\n\n" +
                    "Devir geri almak için önce 'Yıl Sonu Devir' yapmalısınız.",
                    "Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                
                btnDevirGeriAl.Enabled = false;
                btnDevirGeriAl.BackColor = System.Drawing.Color.Gray;
                return;
            }

            var result = MessageBox.Show(
                "⚠️ DİKKAT!\n\n" +
                "Son yapılan 'Yıl Sonu Devir' işlemi geri alınacaktır.\n\n" +
                "📌 Tüm cariler devir öncesi hallerine dönecektir.\n" +
                "📌 Hareketler ve arşiv kayıtları KORUNACAKTIR.\n\n" +
                "Bu işlemi gerçekleştirmek istediğinize emin misiniz?",
                "Devir Geri Alma Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                int geriAlinanSayi = _cariService.DevirGeriAl();
                
                bool devirKaldiMi = _cariService.DevirYapilmisMi();
                btnDevirGeriAl.Enabled = devirKaldiMi;
                btnDevirGeriAl.BackColor = devirKaldiMi ? System.Drawing.Color.FromArgb(243, 156, 18) : System.Drawing.Color.Gray;
                
                // Geri alınan yılı dinamik bul — cmbDonem'deki en küçük yıl
                int eskiYil = cmbDonem.Items.Count > 0
                    ? cmbDonem.Items.Cast<object>()
                        .Select(i => Convert.ToInt32(i.ToString()))
                        .Min()
                    : DateTime.Now.Year;

                MessageBox.Show(
                    $"✅ Devir geri alma işlemi başarıyla tamamlandı!\n\n" +
                    $"📊 {geriAlinanSayi} cari hesabı devir öncesi durumuna döndürüldü.\n\n" +
                    $"📌 Tüm cariler artık {eskiYil} yılı durumundadır.\n" +
                    $"📌 'Dönem' seçiciden {eskiYil + 1}'i seçerek tekrar devir yapabilirsiniz.",
                    "Devir Geri Alındı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                cmbDonem.SelectedIndex = 0;
                _aktifDonem = eskiYil;
                DonemeGoreButonlariGuncelle(eskiYil);
                ListeyiYukle(eskiYil);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Devir geri alma işlemi sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int seciliCariId = GetSeciliCariId();
            
            if (seciliCariId <= 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz cariyi tablodan seçiniz.", "Cari Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string unvan = "";
            if (dgvCariler.CurrentRow != null && dgvCariler.CurrentRow.Cells["Unvan"] != null)
            {
                unvan = dgvCariler.CurrentRow.Cells["Unvan"].Value?.ToString() ?? "";
            }

            var result = MessageBox.Show(
                $"'{unvan}' isimli cari hesap Çöp Kutusuna taşınacaktır.\n\n" +
                $"📌 Çöp kutusundaki cari hesaplar 30 gün boyunca saklanır ve istenildiği an 'Çöp Kutusu' menüsünden geri yüklenebilir.\n\n" +
                $"Devam etmek istiyor musunuz?",
                "Çöp Kutusuna Taşıma Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                if (_cariService.Sil(seciliCariId))
                {
                    MessageBox.Show($"✅ '{unvan}' Çöp Kutusuna taşındı.\n30 gün boyunca Çöp Kutusundan geri yükleyebilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeyiYukle();
                    CopKutusuRozetGuncelle();
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız oldu. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopKutusu_Click(object sender, EventArgs e)
        {
            using (var form = new FormCopKutusu())
            {
                form.ShowDialog(this);
            }
            ListeyiYukle();
            CopKutusuRozetGuncelle();
        }

        private void CopKutusuRozetGuncelle()
        {
            try
            {
                int adet = _cariService.CopKutusuAdetGetir();
                if (btnCopKutusu != null)
                {
                    btnCopKutusu.Text = adet > 0 ? $"🗑️ Çöp Kutusu ({adet})" : "🗑️ Çöp Kutusu";
                }
            }
            catch { }
        }

        private void dgvCariler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int seciliCariId = GetSeciliCariId();
                if (seciliCariId > 0)
                {
                    using (var frm = new FormCariEkle(seciliCariId))
                    {
                        frm.Owner = this;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            ListeyiYukle();
                        }
                    }
                }
            }
        }

        private int GetSeciliCariId()
        {
            if (dgvCariler.CurrentRow != null && dgvCariler.CurrentRow.Cells["CariID"] != null)
            {
                var value = dgvCariler.CurrentRow.Cells["CariID"].Value;
                if (value != null && value != DBNull.Value)
                {
                    return Convert.ToInt32(value);
                }
            }
            return 0;
        }

        #endregion
    }
}