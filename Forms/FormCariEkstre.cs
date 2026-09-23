#nullable disable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using MuhasebeOtomasyonu.Models;
using MuhasebeOtomasyonu.Services;

namespace MuhasebeOtomasyonu.Forms
{
    public partial class FormCariEkstre : Form
    {
        private readonly CariService _cariService;
        private readonly MuhasebeService _muhasebeService;
        private readonly int _seciliCariId;
        private readonly int _aktifDonem;
        private List<CariHareket> _hareketler = new List<CariHareket>();
        private int _printRowIndex = 0; // çok sayfalı yazdırma için sayaç

        public FormCariEkstre(int seciliCariId, int aktifDonem)
        {
            InitializeComponent();
            _cariService = new CariService();
            _muhasebeService = new MuhasebeService();
            _seciliCariId = seciliCariId;
            _aktifDonem = aktifDonem;
        }

        public FormCariEkstre(int seciliCariId) : this(seciliCariId, DateTime.Now.Year)
        {
        }

        public FormCariEkstre() : this(0, DateTime.Now.Year)
        {
        }

        private void FormCariEkstre_Load(object sender, EventArgs e)
        {
            CarileriYukle();
        }

        private void CarileriYukle()
        {
            try
            {
                if (cmbCariler == null) return;

                var cariler = _cariService.Listele(_aktifDonem);
                if (cariler == null || cariler.Count == 0)
                {
                    MessageBox.Show("Ekstresi gösterilecek cari bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmbCariler.SelectedIndexChanged -= cmbCariler_SelectedIndexChanged;

                cmbCariler.DataSource = null;
                cmbCariler.DisplayMember = "Unvan";
                cmbCariler.ValueMember = "CariID";
                cmbCariler.DataSource = cariler;

                int yuklenecekCariId = 0;

                if (_seciliCariId > 0)
                {
                    cmbCariler.SelectedValue = _seciliCariId;
                }

                if (cmbCariler.SelectedValue == null && cariler.Count > 0)
                {
                    cmbCariler.SelectedIndex = 0;
                }

                cmbCariler.SelectedIndexChanged += cmbCariler_SelectedIndexChanged;

                if (cmbCariler.SelectedValue != null && int.TryParse(cmbCariler.SelectedValue.ToString(), out int comboId))
                {
                    yuklenecekCariId = comboId;
                }
                else if (_seciliCariId > 0)
                {
                    yuklenecekCariId = _seciliCariId;
                }

                if (yuklenecekCariId > 0)
                {
                    EkstreYukle(yuklenecekCariId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cariler yüklenirken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCariler != null && cmbCariler.SelectedValue != null && int.TryParse(cmbCariler.SelectedValue.ToString(), out int cariId))
            {
                EkstreYukle(cariId);
            }
        }

        private void EkstreYukle(int cariId)
        {
            try
            {
                _hareketler = _muhasebeService.CariEkstreGetir(cariId, _aktifDonem);
                dgvEkstre.DataSource = null;
                dgvEkstre.DataSource = _hareketler;

                if (dgvEkstre.Columns["HareketID"] != null) dgvEkstre.Columns["HareketID"].Visible = false;
                if (dgvEkstre.Columns["CariID"] != null) dgvEkstre.Columns["CariID"].Visible = false;
                if (dgvEkstre.Columns["CariUnvan"] != null) dgvEkstre.Columns["CariUnvan"].Visible = false;

                if (dgvEkstre.Columns["IslemTarihi"] != null)
                {
                    dgvEkstre.Columns["IslemTarihi"].HeaderText = "İşlem Tarihi";
                    dgvEkstre.Columns["IslemTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                    dgvEkstre.Columns["IslemTarihi"].Width = 140;
                }

                if (dgvEkstre.Columns["IslemTuru"] != null)
                {
                    dgvEkstre.Columns["IslemTuru"].HeaderText = "İşlem Türü";
                    dgvEkstre.Columns["IslemTuru"].Width = 150;
                }

                if (dgvEkstre.Columns["Aciklama"] != null)
                {
                    dgvEkstre.Columns["Aciklama"].HeaderText = "Açıklama";
                    dgvEkstre.Columns["Aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvEkstre.Columns["Borc"] != null)
                {
                    dgvEkstre.Columns["Borc"].HeaderText = "Borç (TL)";
                    dgvEkstre.Columns["Borc"].DefaultCellStyle.Format = "C2";
                    dgvEkstre.Columns["Borc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvEkstre.Columns["Borc"].DefaultCellStyle.ForeColor = Color.DarkRed;
                    dgvEkstre.Columns["Borc"].Width = 120;
                }

                if (dgvEkstre.Columns["Alacak"] != null)
                {
                    dgvEkstre.Columns["Alacak"].HeaderText = "Alacak (TL)";
                    dgvEkstre.Columns["Alacak"].DefaultCellStyle.Format = "C2";
                    dgvEkstre.Columns["Alacak"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvEkstre.Columns["Alacak"].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    dgvEkstre.Columns["Alacak"].Width = 120;
                }

                // ✅ Yürüyen Bakiye - DÜZELTİLDİ
                if (dgvEkstre.Columns["YuruyenBakiye"] != null)
                {
                    dgvEkstre.Columns["YuruyenBakiye"].HeaderText = "Yürüyen Bakiye";
                    dgvEkstre.Columns["YuruyenBakiye"].DefaultCellStyle.Format = "C2";
                    dgvEkstre.Columns["YuruyenBakiye"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvEkstre.Columns["YuruyenBakiye"].DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    dgvEkstre.Columns["YuruyenBakiye"].Width = 130;
                }

                if (dgvEkstre.Columns["KaydedenKullanici"] != null)
                {
                    dgvEkstre.Columns["KaydedenKullanici"].HeaderText = "İşlemi Yapan";
                    dgvEkstre.Columns["KaydedenKullanici"].Width = 120;
                }

                // ✅ Yürüyen Bakiye değerlerini kontrol et ve hesapla
                decimal yuruyenBakiye = 0m;
                foreach (DataGridViewRow row in dgvEkstre.Rows)
                {
                    if (row.DataBoundItem is CariHareket item)
                    {
                        yuruyenBakiye += (item.Borc - item.Alacak);
                        item.YuruyenBakiye = yuruyenBakiye;
                        
                        // Hücreyi güncelle
                        if (dgvEkstre.Columns["YuruyenBakiye"] != null)
                        {
                            row.Cells["YuruyenBakiye"].Value = yuruyenBakiye;
                        }
                    }
                }

                decimal topBorc = _hareketler.Sum(x => x.Borc);
                decimal topAlacak = _hareketler.Sum(x => x.Alacak);
                decimal netBakiye = topBorc - topAlacak;

                lblToplamBorc.Text = $"Toplam Tahakkuk (Borç): {topBorc:C2}";
                lblToplamAlacak.Text = $"Toplam Ödenen (Alacak): {topAlacak:C2}";
                lblNetBakiye.Text = $"Net Kalan Bakiye: {netBakiye:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari ekstre hareketleri yüklenirken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (_hareketler == null || _hareketler.Count == 0)
            {
                MessageBox.Show("Yazdırılacak ekstre hareketi bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _printRowIndex = 0; // her yazdırmada baştan başla

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = printDoc;
            printPreview.Width = 800;
            printPreview.Height = 600;
            printPreview.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fontHeader = new Font("Segoe UI", 14, FontStyle.Bold);
            Font fontSub   = new Font("Segoe UI", 10, FontStyle.Regular);
            Font fontCol   = new Font("Segoe UI",  9, FontStyle.Bold);
            Font fontRow   = new Font("Segoe UI",  9, FontStyle.Regular);

            // Sayfa alt sınırı — toplam satır için 60px bırakıyoruz
            float pageBottom = e.PageBounds.Height - 80f;
            float y = 40f;
            string unvan = cmbCariler != null ? cmbCariler.Text : string.Empty;

            // Başlık sadece ilk sayfada
            if (_printRowIndex == 0)
            {
                e.Graphics.DrawString("CARİ HESAP EKSTRESİ", fontHeader, Brushes.DarkBlue, 50, y);
                y += 30;
                e.Graphics.DrawString($"Müşteri / Cari: {unvan}", fontSub, Brushes.Black, 50, y);
                y += 20;
                e.Graphics.DrawString($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}", fontSub, Brushes.Gray, 50, y);
                y += 35;
            }

            // Kolon başlıkları her sayfada
            e.Graphics.DrawLine(Pens.Black, 50, y, 750, y);
            y += 10;
            e.Graphics.DrawString("Tarih",      fontCol, Brushes.Black, 50,  y);
            e.Graphics.DrawString("İşlem Türü", fontCol, Brushes.Black, 160, y);
            e.Graphics.DrawString("Açıklama",   fontCol, Brushes.Black, 280, y);
            e.Graphics.DrawString("Borç",       fontCol, Brushes.Black, 500, y);
            e.Graphics.DrawString("Alacak",     fontCol, Brushes.Black, 590, y);
            e.Graphics.DrawString("Bakiye",     fontCol, Brushes.Black, 680, y);
            y += 25;
            e.Graphics.DrawLine(Pens.Gray, 50, y, 750, y);
            y += 10;

            // Veri satırları — sayfa dolunca HasMorePages = true
            while (_printRowIndex < _hareketler.Count)
            {
                if (y + 22 > pageBottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                var item = _hareketler[_printRowIndex];

                e.Graphics.DrawString(item.IslemTarihi.ToString("dd.MM.yyyy"), fontRow, Brushes.Black, 50, y);
                e.Graphics.DrawString(item.IslemTuru, fontRow, Brushes.Black, 160, y);

                string aciklama = item.Aciklama ?? "";
                if (aciklama.Length > 25) aciklama = aciklama.Substring(0, 22) + "...";
                e.Graphics.DrawString(aciklama, fontRow, Brushes.Black, 280, y);

                e.Graphics.DrawString(item.Borc.ToString("N2"),           fontRow, Brushes.DarkRed,   500, y);
                e.Graphics.DrawString(item.Alacak.ToString("N2"),         fontRow, Brushes.DarkGreen, 590, y);
                e.Graphics.DrawString(item.YuruyenBakiye.ToString("N2"),  fontRow, Brushes.Black,     680, y);

                y += 22;
                _printRowIndex++;
            }

            // Toplam satırı — sadece son sayfada
            y += 15;
            e.Graphics.DrawLine(Pens.Black, 50, y, 750, y);
            y += 15;

            decimal topBorc   = _hareketler.Sum(x => x.Borc);
            decimal topAlacak = _hareketler.Sum(x => x.Alacak);
            decimal netBakiye = topBorc - topAlacak;

            e.Graphics.DrawString(
                $"Toplam Borç: {topBorc:C2}   |   Toplam Alacak: {topAlacak:C2}   |   Net Bakiye: {netBakiye:C2}",
                fontSub, Brushes.DarkBlue, 50, y);

            e.HasMorePages = false;
        }
    }
}