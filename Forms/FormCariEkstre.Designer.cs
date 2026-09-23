namespace MuhasebeOtomasyonu.Forms
{
    partial class FormCariEkstre
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.lblCariSec = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblNetBakiye = new System.Windows.Forms.Label();
            this.lblToplamAlacak = new System.Windows.Forms.Label();
            this.lblToplamBorc = new System.Windows.Forms.Label();
            this.dgvEkstre = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEkstre)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.pnlHeader.Controls.Add(this.btnYazdir);
            this.pnlHeader.Controls.Add(this.cmbCariler);
            this.pnlHeader.Controls.Add(this.lblCariSec);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(944, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnYazdir
            // 
            this.btnYazdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnYazdir.FlatAppearance.BorderSize = 0;
            this.btnYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYazdir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnYazdir.ForeColor = System.Drawing.Color.White;
            this.btnYazdir.Location = new System.Drawing.Point(824, 18);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(105, 36);
            this.btnYazdir.TabIndex = 3;
            this.btnYazdir.Text = "🖨️ Yazdır / Rapor";
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // cmbCariler
            // 
            this.cmbCariler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariler.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(440, 23);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(360, 25);
            this.cmbCariler.TabIndex = 2;
            this.cmbCariler.SelectedIndexChanged += new System.EventHandler(this.cmbCariler_SelectedIndexChanged);
            // 
            // lblCariSec
            // 
            this.lblCariSec.AutoSize = true;
            this.lblCariSec.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCariSec.ForeColor = System.Drawing.Color.White;
            this.lblCariSec.Location = new System.Drawing.Point(345, 26);
            this.lblCariSec.Name = "lblCariSec";
            this.lblCariSec.Size = new System.Drawing.Size(89, 19);
            this.lblCariSec.TabIndex = 1;
            this.lblCariSec.Text = "Cari Seçiniz:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(242, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cari Ekstre / Hesap Dökümü";
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlSummary.Controls.Add(this.lblNetBakiye);
            this.pnlSummary.Controls.Add(this.lblToplamAlacak);
            this.pnlSummary.Controls.Add(this.lblToplamBorc);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Location = new System.Drawing.Point(0, 501);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(944, 60);
            this.pnlSummary.TabIndex = 1;
            // 
            // lblNetBakiye
            // 
            this.lblNetBakiye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetBakiye.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNetBakiye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblNetBakiye.Location = new System.Drawing.Point(620, 18);
            this.lblNetBakiye.Name = "lblNetBakiye";
            this.lblNetBakiye.Size = new System.Drawing.Size(300, 25);
            this.lblNetBakiye.TabIndex = 2;
            this.lblNetBakiye.Text = "Net Kalan Bakiye: ₺0,00";
            this.lblNetBakiye.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToplamAlacak
            // 
            this.lblToplamAlacak.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblToplamAlacak.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblToplamAlacak.Location = new System.Drawing.Point(320, 18);
            this.lblToplamAlacak.Name = "lblToplamAlacak";
            this.lblToplamAlacak.Size = new System.Drawing.Size(280, 25);
            this.lblToplamAlacak.TabIndex = 1;
            this.lblToplamAlacak.Text = "Toplam Ödenen (Alacak): ₺0,00";
            this.lblToplamAlacak.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToplamBorc
            // 
            this.lblToplamBorc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblToplamBorc.ForeColor = System.Drawing.Color.DarkRed;
            this.lblToplamBorc.Location = new System.Drawing.Point(16, 18);
            this.lblToplamBorc.Name = "lblToplamBorc";
            this.lblToplamBorc.Size = new System.Drawing.Size(280, 25);
            this.lblToplamBorc.TabIndex = 0;
            this.lblToplamBorc.Text = "Toplam Tahakkuk (Borç): ₺0,00";
            this.lblToplamBorc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvEkstre
            // 
            this.dgvEkstre.AllowUserToAddRows = false;
            this.dgvEkstre.AllowUserToDeleteRows = false;
            this.dgvEkstre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEkstre.BackgroundColor = System.Drawing.Color.White;
            this.dgvEkstre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEkstre.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEkstre.ColumnHeadersHeight = 35;
            this.dgvEkstre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEkstre.EnableHeadersVisualStyles = false;
            this.dgvEkstre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvEkstre.Location = new System.Drawing.Point(0, 70);
            this.dgvEkstre.MultiSelect = false;
            this.dgvEkstre.Name = "dgvEkstre";
            this.dgvEkstre.ReadOnly = true;
            this.dgvEkstre.RowHeadersVisible = false;
            this.dgvEkstre.RowTemplate.Height = 28;
            this.dgvEkstre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEkstre.Size = new System.Drawing.Size(944, 431);
            this.dgvEkstre.TabIndex = 2;
            // 
            // FormCariEkstre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.dgvEkstre);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormCariEkstre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cari Ekstre Raporu";
            this.Load += new System.EventHandler(this.FormCariEkstre_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEkstre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.Label lblCariSec;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblToplamBorc;
        private System.Windows.Forms.Label lblToplamAlacak;
        private System.Windows.Forms.Label lblNetBakiye;
        private System.Windows.Forms.DataGridView dgvEkstre;
    }
}
