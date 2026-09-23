namespace MuhasebeOtomasyonu.Forms
{
    partial class FormAylikUcretListesi
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

        private void InitializeComponent()
        {
            this.dgvAylar = new System.Windows.Forms.DataGridView();
            this.lblCariUnvan = new System.Windows.Forms.Label();
            this.lblToplam = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAylar)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAylar
            // 
            this.dgvAylar.AllowUserToAddRows = false;
            this.dgvAylar.AllowUserToDeleteRows = false;
            this.dgvAylar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAylar.BackgroundColor = System.Drawing.Color.White;
            this.dgvAylar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAylar.ColumnHeadersHeight = 35;
            this.dgvAylar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAylar.Location = new System.Drawing.Point(0, 80);
            this.dgvAylar.MultiSelect = false;
            this.dgvAylar.Name = "dgvAylar";
            this.dgvAylar.RowHeadersVisible = false;
            this.dgvAylar.RowTemplate.Height = 30;
            this.dgvAylar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAylar.Size = new System.Drawing.Size(520, 310);
            this.dgvAylar.TabIndex = 0;
            this.dgvAylar.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAylar_CellValueChanged);
            this.dgvAylar.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvAylar_CurrentCellDirtyStateChanged);
            this.dgvAylar.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAylar_EditingControlShowing);
            this.dgvAylar.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAylar_CellEndEdit);
            // 
            // lblCariUnvan
            // 
            this.lblCariUnvan.AutoSize = true;
            this.lblCariUnvan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCariUnvan.ForeColor = System.Drawing.Color.White;
            this.lblCariUnvan.Location = new System.Drawing.Point(12, 15);
            this.lblCariUnvan.Name = "lblCariUnvan";
            this.lblCariUnvan.Size = new System.Drawing.Size(100, 21);
            this.lblCariUnvan.TabIndex = 0;
            this.lblCariUnvan.Text = "Cari: ";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.LightGray;
            this.lblInfo.Location = new System.Drawing.Point(12, 45);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(260, 15);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "💡 Her ayın ücretini girin, toplam otomatik hesaplanır.";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlHeader.Controls.Add(this.lblCariUnvan);
            this.pnlHeader.Controls.Add(this.lblInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(520, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblToplam
            // 
            this.lblToplam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplam.ForeColor = System.Drawing.Color.DarkRed;
            this.lblToplam.Location = new System.Drawing.Point(12, 8);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(300, 30);
            this.lblToplam.TabIndex = 0;
            this.lblToplam.Text = "Yıllık Toplam: ₺0,00";
            this.lblToplam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(415, 8);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(90, 34);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(320, 8);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(85, 34);
            this.btnIptal.TabIndex = 2;
            this.btnIptal.Text = "❌ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlFooter.Controls.Add(this.lblToplam);
            this.pnlFooter.Controls.Add(this.btnIptal);
            this.pnlFooter.Controls.Add(this.btnKaydet);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 390);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(520, 50);
            this.pnlFooter.TabIndex = 2;
            // 
            // FormAylikUcretListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 440);
            this.Controls.Add(this.dgvAylar);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAylikUcretListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aylık Ücret Listesi";
            this.Load += new System.EventHandler(this.FormAylikUcretListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAylar)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvAylar;
        private System.Windows.Forms.Label lblCariUnvan;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblInfo;
    }
}