using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MuhasebeOtomasyonu.Models;
using MuhasebeOtomasyonu.Services;

namespace MuhasebeOtomasyonu.Forms
{
    public partial class FormAylikUcretListesi : Form
    {
        private readonly int _cariId;
        private readonly string _cariUnvan;
        private List<AylikUcret> _aylikUcretler = new List<AylikUcret>();
        private readonly CariService _cariService;
        private decimal _toplamUcret = 0;

        public FormAylikUcretListesi(int cariId, string cariUnvan)
        {
            InitializeComponent();
            _cariId = cariId;
            _cariUnvan = cariUnvan;
            _cariService = new CariService();
            this.Text = $"📅 Aylık Ücret Listesi - {_cariUnvan}";

            // ✅ DataError olayını bağla
            this.dgvAylar.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAylar_DataError);
        }

        private void FormAylikUcretListesi_Load(object sender, EventArgs e)
        {
            AylariYukle();
            lblCariUnvan.Text = $"Cari: {_cariUnvan}";
        }

        // ✅ DataError olayı - Format hatalarını görmezden gel
        private void dgvAylar_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                e.ThrowException = false;
                e.Cancel = true;
            }
            else
            {
                MessageBox.Show($"Bir hata oluştu:\n{e.Exception?.Message ?? "Bilinmeyen hata"}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ThrowException = false;
                e.Cancel = true;
            }
        }

        private void AylariYukle()
        {
            string[] aylar = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
            
            List<decimal> mevcutAylikUcretler = new List<decimal>();
            
            if (_cariId > 0)
            {
                mevcutAylikUcretler = _cariService.AylikUcretleriGetir(_cariId);
            }
            else
            {
                for (int i = 0; i < 12; i++)
                    mevcutAylikUcretler.Add(0);
            }
            
            for (int i = 0; i < 12; i++)
            {
                decimal ucret = 0;
                if (mevcutAylikUcretler != null && i < mevcutAylikUcretler.Count)
                {
                    ucret = mevcutAylikUcretler[i];
                }
                
                _aylikUcretler.Add(new AylikUcret
                {
                    AyIndex = i + 1,
                    AyAdi = aylar[i],
                    Ucret = ucret
                });
            }

            dgvAylar.DataSource = null;
            dgvAylar.DataSource = _aylikUcretler;

            if (dgvAylar.Columns["AyIndex"] != null) 
                dgvAylar.Columns["AyIndex"].Visible = false;
            
            if (dgvAylar.Columns["AyAdi"] != null)
            {
                dgvAylar.Columns["AyAdi"].HeaderText = "Ay";
                dgvAylar.Columns["AyAdi"].Width = 120;
                dgvAylar.Columns["AyAdi"].ReadOnly = true;
            }

            if (dgvAylar.Columns["Ucret"] != null)
            {
                dgvAylar.Columns["Ucret"].HeaderText = "Aylık Ücret (TL)";
                dgvAylar.Columns["Ucret"].DefaultCellStyle.Format = "N2";
                dgvAylar.Columns["Ucret"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvAylar.Columns["Ucret"].Width = 150;
            }

            ToplamHesapla();
        }

        private void ToplamHesapla()
        {
            _toplamUcret = _aylikUcretler.Sum(x => x.Ucret);
            lblToplam.Text = $"Yıllık Toplam: {_toplamUcret:C2}";
            
            if (_toplamUcret == 0)
                lblToplam.ForeColor = System.Drawing.Color.Gray;
            else
                lblToplam.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // DataGridView'den güncel değerleri al
            for (int i = 0; i < dgvAylar.Rows.Count; i++)
            {
                var row = dgvAylar.Rows[i];
                if (row.Cells["Ucret"].Value != null)
                {
                    if (decimal.TryParse(row.Cells["Ucret"].Value.ToString(), out decimal val))
                    {
                        if (i < _aylikUcretler.Count)
                            _aylikUcretler[i].Ucret = val;
                    }
                    else
                    {
                        if (i < _aylikUcretler.Count)
                            _aylikUcretler[i].Ucret = 0;
                    }
                }
            }
            ToplamHesapla();

            if (_cariId <= 0)
            {
                MessageBox.Show("Önce cariyi kaydedin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool sonuc = _cariService.AylikUcretleriGuncelle(_cariId, _aylikUcretler);
                if (sonuc)
                {
                    MessageBox.Show(
                        $"✅ Aylık ücretler başarıyla kaydedildi!\n\n📊 Yıllık Toplam: {_toplamUcret:C2}",
                        "Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("❌ Kayıt başarısız. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dgvAylar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                for (int i = 0; i < dgvAylar.Rows.Count; i++)
                {
                    var row = dgvAylar.Rows[i];
                    if (row.Cells["Ucret"].Value != null)
                    {
                        if (decimal.TryParse(row.Cells["Ucret"].Value.ToString(), out decimal val))
                        {
                            if (i < _aylikUcretler.Count)
                                _aylikUcretler[i].Ucret = val;
                        }
                    }
                }
                ToplamHesapla();
            }
        }

        private void dgvAylar_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAylar.IsCurrentCellDirty)
                dgvAylar.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvAylar_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Sadece Ucret sütununda çalışsın
            if (dgvAylar.CurrentCell != null && dgvAylar.Columns[dgvAylar.CurrentCell.ColumnIndex].Name == "Ucret")
            {
                if (e.Control is TextBox tb)
                {
                    // Önceki event handler'ları temizle (tekrar ekleme önlenir)
                    tb.KeyPress -= UcretHucresi_KeyPress;
                    tb.KeyPress += UcretHucresi_KeyPress;

                    // Hücreye girerken varsa formatlanmış değeri düz sayı olarak göster
                    if (decimal.TryParse(tb.Text, System.Globalization.NumberStyles.Any, 
                        new System.Globalization.CultureInfo("tr-TR"), out decimal val))
                    {
                        // Ondalık kısmı varsa göster, yoksa sadece tam sayı
                        tb.Text = val % 1 == 0 ? val.ToString("0") : val.ToString("0.##");
                    }
                }
            }
        }

        private void UcretHucresi_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Sadece rakam, virgül (ondalık ayırıcı) ve kontrol tuşları (backspace vb.) izin ver
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Birden fazla virgül girilmesini engelle
            if (e.KeyChar == ',')
            {
                if (sender is TextBox tb && tb.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvAylar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAylar.Columns[e.ColumnIndex].Name == "Ucret")
            {
                var cell = dgvAylar.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string rawText = cell.Value?.ToString() ?? "0";

                // Kullanıcının girdiği değeri parse et
                // Noktaları binlik ayırıcı olarak kaldır, virgülü ondalık olarak kullan
                rawText = rawText.Replace(".", "").Replace(" ", "");

                if (decimal.TryParse(rawText, System.Globalization.NumberStyles.Any,
                    new System.Globalization.CultureInfo("tr-TR"), out decimal val))
                {
                    if (e.RowIndex < _aylikUcretler.Count)
                        _aylikUcretler[e.RowIndex].Ucret = val;

                    cell.Value = val;
                }
                else
                {
                    if (e.RowIndex < _aylikUcretler.Count)
                        _aylikUcretler[e.RowIndex].Ucret = 0;
                    cell.Value = 0m;
                }

                ToplamHesapla();
            }
        }
    }
}