namespace MuhasebeOtomasyonu.Forms
{
    partial class FormCopKutusu
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCopKutusu = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnBosalt = new System.Windows.Forms.Button();
            this.btnKaliciSil = new System.Windows.Forms.Button();
            this.btnGeriYukle = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopKutusu)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(780, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblSubTitle.Location = new System.Drawing.Point(16, 43);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(534, 15);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "📌 Silinen cari hesaplar 30 gün saklanır. 30 gün sonunda otomatik olarak kalıcı silinecektir.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🗑️ Çöp Kutusu (Geri Dönüşüm)";
            // 
            // dgvCopKutusu
            // 
            this.dgvCopKutusu.AllowUserToAddRows = false;
            this.dgvCopKutusu.AllowUserToDeleteRows = false;
            this.dgvCopKutusu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCopKutusu.BackgroundColor = System.Drawing.Color.White;
            this.dgvCopKutusu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCopKutusu.ColumnHeadersHeight = 35;
            this.dgvCopKutusu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCopKutusu.Location = new System.Drawing.Point(0, 75);
            this.dgvCopKutusu.MultiSelect = false;
            this.dgvCopKutusu.Name = "dgvCopKutusu";
            this.dgvCopKutusu.ReadOnly = true;
            this.dgvCopKutusu.RowHeadersVisible = false;
            this.dgvCopKutusu.RowTemplate.Height = 32;
            this.dgvCopKutusu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCopKutusu.Size = new System.Drawing.Size(780, 345);
            this.dgvCopKutusu.TabIndex = 1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlFooter.Controls.Add(this.btnKapat);
            this.pnlFooter.Controls.Add(this.btnBosalt);
            this.pnlFooter.Controls.Add(this.btnKaliciSil);
            this.pnlFooter.Controls.Add(this.btnGeriYukle);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 420);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(780, 60);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(673, 12);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(95, 36);
            this.btnKapat.TabIndex = 3;
            this.btnKapat.Text = "✖️ Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnBosalt
            // 
            this.btnBosalt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnBosalt.FlatAppearance.BorderSize = 0;
            this.btnBosalt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBosalt.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBosalt.ForeColor = System.Drawing.Color.White;
            this.btnBosalt.Location = new System.Drawing.Point(295, 12);
            this.btnBosalt.Name = "btnBosalt";
            this.btnBosalt.Size = new System.Drawing.Size(185, 36);
            this.btnBosalt.TabIndex = 2;
            this.btnBosalt.Text = "🧹 Çöp Kutusunu Boşalt";
            this.btnBosalt.UseVisualStyleBackColor = false;
            this.btnBosalt.Click += new System.EventHandler(this.btnBosalt_Click);
            // 
            // btnKaliciSil
            // 
            this.btnKaliciSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnKaliciSil.FlatAppearance.BorderSize = 0;
            this.btnKaliciSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaliciSil.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnKaliciSil.ForeColor = System.Drawing.Color.White;
            this.btnKaliciSil.Location = new System.Drawing.Point(135, 12);
            this.btnKaliciSil.Name = "btnKaliciSil";
            this.btnKaliciSil.Size = new System.Drawing.Size(152, 36);
            this.btnKaliciSil.TabIndex = 1;
            this.btnKaliciSil.Text = "❌ Kalıcı Olarak Sil";
            this.btnKaliciSil.UseVisualStyleBackColor = false;
            this.btnKaliciSil.Click += new System.EventHandler(this.btnKaliciSil_Click);
            // 
            // btnGeriYukle
            // 
            this.btnGeriYukle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGeriYukle.FlatAppearance.BorderSize = 0;
            this.btnGeriYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeriYukle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGeriYukle.ForeColor = System.Drawing.Color.White;
            this.btnGeriYukle.Location = new System.Drawing.Point(12, 12);
            this.btnGeriYukle.Name = "btnGeriYukle";
            this.btnGeriYukle.Size = new System.Drawing.Size(115, 36);
            this.btnGeriYukle.TabIndex = 0;
            this.btnGeriYukle.Text = "🔄 Geri Yükle";
            this.btnGeriYukle.UseVisualStyleBackColor = false;
            this.btnGeriYukle.Click += new System.EventHandler(this.btnGeriYukle_Click);
            // 
            // FormCopKutusu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 480);
            this.Controls.Add(this.dgvCopKutusu);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCopKutusu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "🗑️ Çöp Kutusu";
            this.Load += new System.EventHandler(this.FormCopKutusu_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopKutusu)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.DataGridView dgvCopKutusu;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnGeriYukle;
        private System.Windows.Forms.Button btnKaliciSil;
        private System.Windows.Forms.Button btnBosalt;
        private System.Windows.Forms.Button btnKapat;
    }
}
