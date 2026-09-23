namespace MuhasebeOtomasyonu.Forms
{
    partial class FormMain
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnMenuMuhasebe = new System.Windows.Forms.Button();
            this.btnMenuCari = new System.Windows.Forms.Button();
            this.pnlCikisWrapper = new System.Windows.Forms.Panel();
            this.btnMenuCikis = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogoSubtitle = new System.Windows.Forms.Label();
            this.lblLogoTitle = new System.Windows.Forms.Label();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlCariKartlarModul = new System.Windows.Forms.Panel();
            this.dgvCariler = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlCardBakiye = new System.Windows.Forms.Panel();
            this.lblGenelBakiye = new System.Windows.Forms.Label();
            this.lblTitleBakiye = new System.Windows.Forms.Label();
            this.pnlCardAlacak = new System.Windows.Forms.Panel();
            this.lblGenelAlacak = new System.Windows.Forms.Label();
            this.lblTitleAlacak = new System.Windows.Forms.Label();
            this.pnlCardBorc = new System.Windows.Forms.Panel();
            this.lblGenelBorc = new System.Windows.Forms.Label();
            this.lblTitleBorc = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.clbAylar = new System.Windows.Forms.CheckedListBox();
            this.lblAySec = new System.Windows.Forms.Label();
            this.lblArama = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.pnlHeaderCari = new System.Windows.Forms.Panel();
            this.lblTitleCari = new System.Windows.Forms.Label();
            this.lblDonem = new System.Windows.Forms.Label();
            this.cmbDonem = new System.Windows.Forms.ComboBox();
            this.btnDevirGeriAl = new System.Windows.Forms.Button();
            this.btnYilSonuDevir = new System.Windows.Forms.Button();
            this.btnCopKutusu = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnYeniCari = new System.Windows.Forms.Button();
            this.btnTahsilatGir = new System.Windows.Forms.Button();
            this.btnEkstre = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.pnlMuhasebeModul = new System.Windows.Forms.Panel();
            this.pnlMuhasebeContent = new System.Windows.Forms.Panel();
            this.pnlCardMuhasebeOzet = new System.Windows.Forms.Panel();
            this.btnMuhasebeEkstre = new System.Windows.Forms.Button();
            this.btnMuhasebeTahsilat = new System.Windows.Forms.Button();
            this.lblCardOzetDesc = new System.Windows.Forms.Label();
            this.lblCardOzetTitle = new System.Windows.Forms.Label();
            this.pnlHeaderMuhasebe = new System.Windows.Forms.Panel();
            this.lblTitleMuhasebe = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlCikisWrapper.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.pnlCariKartlarModul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariler)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlCardBakiye.SuspendLayout();
            this.pnlCardAlacak.SuspendLayout();
            this.pnlCardBorc.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlHeaderCari.SuspendLayout();
            this.pnlMuhasebeModul.SuspendLayout();
            this.pnlMuhasebeContent.SuspendLayout();
            this.pnlCardMuhasebeOzet.SuspendLayout();
            this.pnlHeaderMuhasebe.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.pnlSidebar.Controls.Add(this.btnMenuMuhasebe);
            this.pnlSidebar.Controls.Add(this.btnMenuCari);
            this.pnlSidebar.Controls.Add(this.pnlCikisWrapper);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 680);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnMenuMuhasebe
            // 
            this.btnMenuMuhasebe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuMuhasebe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuMuhasebe.FlatAppearance.BorderSize = 0;
            this.btnMenuMuhasebe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuMuhasebe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuMuhasebe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnMenuMuhasebe.Location = new System.Drawing.Point(0, 120);
            this.btnMenuMuhasebe.Name = "btnMenuMuhasebe";
            this.btnMenuMuhasebe.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuMuhasebe.Size = new System.Drawing.Size(230, 50);
            this.btnMenuMuhasebe.TabIndex = 2;
            this.btnMenuMuhasebe.Text = "💼  Muhasebe Ücretleri";
            this.btnMenuMuhasebe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuMuhasebe.UseVisualStyleBackColor = true;
            this.btnMenuMuhasebe.Click += new System.EventHandler(this.btnMenuMuhasebe_Click);
            // 
            // btnMenuCari
            // 
            this.btnMenuCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnMenuCari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuCari.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuCari.FlatAppearance.BorderSize = 0;
            this.btnMenuCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCari.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuCari.ForeColor = System.Drawing.Color.White;
            this.btnMenuCari.Location = new System.Drawing.Point(0, 70);
            this.btnMenuCari.Name = "btnMenuCari";
            this.btnMenuCari.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuCari.Size = new System.Drawing.Size(230, 50);
            this.btnMenuCari.TabIndex = 1;
            this.btnMenuCari.Text = "👥  Cari Kartlar";
            this.btnMenuCari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuCari.UseVisualStyleBackColor = false;
            this.btnMenuCari.Click += new System.EventHandler(this.btnMenuCari_Click);
            // 
            // pnlCikisWrapper
            // 
            this.pnlCikisWrapper.Controls.Add(this.btnMenuCikis);
            this.pnlCikisWrapper.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCikisWrapper.Location = new System.Drawing.Point(0, 610);
            this.pnlCikisWrapper.Name = "pnlCikisWrapper";
            this.pnlCikisWrapper.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCikisWrapper.Size = new System.Drawing.Size(230, 70);
            this.pnlCikisWrapper.TabIndex = 3;
            // 
            // btnMenuCikis
            // 
            this.btnMenuCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnMenuCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuCikis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuCikis.FlatAppearance.BorderSize = 0;
            this.btnMenuCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCikis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuCikis.ForeColor = System.Drawing.Color.White;
            this.btnMenuCikis.Location = new System.Drawing.Point(15, 15);
            this.btnMenuCikis.Name = "btnMenuCikis";
            this.btnMenuCikis.Size = new System.Drawing.Size(200, 40);
            this.btnMenuCikis.TabIndex = 0;
            this.btnMenuCikis.Text = "❌  Çıkış";
            this.btnMenuCikis.UseVisualStyleBackColor = false;
            this.btnMenuCikis.Click += new System.EventHandler(this.btnMenuCikis_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(42)))));
            this.pnlLogo.Controls.Add(this.lblLogoSubtitle);
            this.pnlLogo.Controls.Add(this.lblLogoTitle);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(230, 70);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogoSubtitle
            // 
            this.lblLogoSubtitle.AutoSize = true;
            this.lblLogoSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLogoSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblLogoSubtitle.Location = new System.Drawing.Point(16, 42);
            this.lblLogoSubtitle.Name = "lblLogoSubtitle";
            this.lblLogoSubtitle.Size = new System.Drawing.Size(117, 13);
            this.lblLogoSubtitle.TabIndex = 1;
            this.lblLogoSubtitle.Text = "Cari Yönetim Sistemi";
            // 
            // lblLogoTitle
            // 
            this.lblLogoTitle.AutoSize = true;
            this.lblLogoTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogoTitle.ForeColor = System.Drawing.Color.White;
            this.lblLogoTitle.Location = new System.Drawing.Point(14, 16);
            this.lblLogoTitle.Name = "lblLogoTitle";
            this.lblLogoTitle.Size = new System.Drawing.Size(142, 21);
            this.lblLogoTitle.TabIndex = 0;
            this.lblLogoTitle.Text = "NetFinans";
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Controls.Add(this.pnlCariKartlarModul);
            this.pnlMainContainer.Controls.Add(this.pnlMuhasebeModul);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(230, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1100, 680);
            this.pnlMainContainer.TabIndex = 1;
            // 
            // pnlCariKartlarModul
            // 
            this.pnlCariKartlarModul.Controls.Add(this.dgvCariler);
            this.pnlCariKartlarModul.Controls.Add(this.pnlFooter);
            this.pnlCariKartlarModul.Controls.Add(this.pnlSearch);
            this.pnlCariKartlarModul.Controls.Add(this.pnlHeaderCari);
            this.pnlCariKartlarModul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCariKartlarModul.Location = new System.Drawing.Point(0, 0);
            this.pnlCariKartlarModul.Name = "pnlCariKartlarModul";
            this.pnlCariKartlarModul.Size = new System.Drawing.Size(1100, 680);
            this.pnlCariKartlarModul.TabIndex = 0;
            // 
            // dgvCariler
            // 
            this.dgvCariler.AllowUserToAddRows = false;
            this.dgvCariler.AllowUserToDeleteRows = false;
            this.dgvCariler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCariler.BackgroundColor = System.Drawing.Color.White;
            this.dgvCariler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCariler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCariler.ColumnHeadersHeight = 38;
            this.dgvCariler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCariler.EnableHeadersVisualStyles = false;
            this.dgvCariler.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvCariler.Location = new System.Drawing.Point(0, 115);
            this.dgvCariler.MultiSelect = false;
            this.dgvCariler.Name = "dgvCariler";
            this.dgvCariler.ReadOnly = true;
            this.dgvCariler.RowHeadersVisible = false;
            this.dgvCariler.RowTemplate.Height = 32;
            this.dgvCariler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCariler.Size = new System.Drawing.Size(1100, 475);
            this.dgvCariler.TabIndex = 2;
            this.dgvCariler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCariler_CellDoubleClick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlFooter.Controls.Add(this.pnlCardBakiye);
            this.pnlFooter.Controls.Add(this.pnlCardAlacak);
            this.pnlFooter.Controls.Add(this.pnlCardBorc);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 590);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1100, 90);
            this.pnlFooter.TabIndex = 3;
            // 
            // pnlCardBakiye
            // 
            this.pnlCardBakiye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCardBakiye.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlCardBakiye.Controls.Add(this.lblGenelBakiye);
            this.pnlCardBakiye.Controls.Add(this.lblTitleBakiye);
            this.pnlCardBakiye.Location = new System.Drawing.Point(700, 10);
            this.pnlCardBakiye.Name = "pnlCardBakiye";
            this.pnlCardBakiye.Size = new System.Drawing.Size(260, 70);
            this.pnlCardBakiye.TabIndex = 2;
            // 
            // lblGenelBakiye
            // 
            this.lblGenelBakiye.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGenelBakiye.ForeColor = System.Drawing.Color.White;
            this.lblGenelBakiye.Location = new System.Drawing.Point(10, 32);
            this.lblGenelBakiye.Name = "lblGenelBakiye";
            this.lblGenelBakiye.Size = new System.Drawing.Size(240, 30);
            this.lblGenelBakiye.TabIndex = 1;
            this.lblGenelBakiye.Text = "₺0,00";
            this.lblGenelBakiye.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleBakiye
            // 
            this.lblTitleBakiye.AutoSize = true;
            this.lblTitleBakiye.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleBakiye.ForeColor = System.Drawing.Color.White;
            this.lblTitleBakiye.Location = new System.Drawing.Point(10, 8);
            this.lblTitleBakiye.Name = "lblTitleBakiye";
            this.lblTitleBakiye.Size = new System.Drawing.Size(140, 15);
            this.lblTitleBakiye.TabIndex = 0;
            this.lblTitleBakiye.Text = "NET KALAN BAKİYE (TL)";
            // 
            // pnlCardAlacak
            // 
            this.pnlCardAlacak.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlCardAlacak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlCardAlacak.Controls.Add(this.lblGenelAlacak);
            this.pnlCardAlacak.Controls.Add(this.lblTitleAlacak);
            this.pnlCardAlacak.Location = new System.Drawing.Point(420, 10);
            this.pnlCardAlacak.Name = "pnlCardAlacak";
            this.pnlCardAlacak.Size = new System.Drawing.Size(260, 70);
            this.pnlCardAlacak.TabIndex = 1;
            // 
            // lblGenelAlacak
            // 
            this.lblGenelAlacak.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGenelAlacak.ForeColor = System.Drawing.Color.White;
            this.lblGenelAlacak.Location = new System.Drawing.Point(10, 32);
            this.lblGenelAlacak.Name = "lblGenelAlacak";
            this.lblGenelAlacak.Size = new System.Drawing.Size(240, 30);
            this.lblGenelAlacak.TabIndex = 1;
            this.lblGenelAlacak.Text = "₺0,00";
            this.lblGenelAlacak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleAlacak
            // 
            this.lblTitleAlacak.AutoSize = true;
            this.lblTitleAlacak.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleAlacak.ForeColor = System.Drawing.Color.White;
            this.lblTitleAlacak.Location = new System.Drawing.Point(10, 8);
            this.lblTitleAlacak.Name = "lblTitleAlacak";
            this.lblTitleAlacak.Size = new System.Drawing.Size(126, 15);
            this.lblTitleAlacak.TabIndex = 0;
            this.lblTitleAlacak.Text = "TOPLAM ALACAK (TL)";
            // 
            // pnlCardBorc
            // 
            this.pnlCardBorc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.pnlCardBorc.Controls.Add(this.lblGenelBorc);
            this.pnlCardBorc.Controls.Add(this.lblTitleBorc);
            this.pnlCardBorc.Location = new System.Drawing.Point(140, 10);
            this.pnlCardBorc.Name = "pnlCardBorc";
            this.pnlCardBorc.Size = new System.Drawing.Size(260, 70);
            this.pnlCardBorc.TabIndex = 0;
            // 
            // lblGenelBorc
            // 
            this.lblGenelBorc.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGenelBorc.ForeColor = System.Drawing.Color.White;
            this.lblGenelBorc.Location = new System.Drawing.Point(10, 32);
            this.lblGenelBorc.Name = "lblGenelBorc";
            this.lblGenelBorc.Size = new System.Drawing.Size(240, 30);
            this.lblGenelBorc.TabIndex = 1;
            this.lblGenelBorc.Text = "₺0,00";
            this.lblGenelBorc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleBorc
            // 
            this.lblTitleBorc.AutoSize = true;
            this.lblTitleBorc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleBorc.ForeColor = System.Drawing.Color.White;
            this.lblTitleBorc.Location = new System.Drawing.Point(10, 8);
            this.lblTitleBorc.Name = "lblTitleBorc";
            this.lblTitleBorc.Size = new System.Drawing.Size(117, 15);
            this.lblTitleBorc.TabIndex = 0;
            this.lblTitleBorc.Text = "TOPLAM BORÇ (TL)";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlSearch.Controls.Add(this.clbAylar);
            this.pnlSearch.Controls.Add(this.lblAySec);
            this.pnlSearch.Controls.Add(this.lblArama);
            this.pnlSearch.Controls.Add(this.txtArama);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 60);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1100, 55);
            this.pnlSearch.TabIndex = 1;
            // 
            // clbAylar
            // 
            this.clbAylar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clbAylar.CheckOnClick = true;
            this.clbAylar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbAylar.FormattingEnabled = true;
            this.clbAylar.IntegralHeight = false;
            this.clbAylar.Location = new System.Drawing.Point(900, 8);
            this.clbAylar.Name = "clbAylar";
            this.clbAylar.Size = new System.Drawing.Size(184, 40);
            this.clbAylar.TabIndex = 3;
            // 
            // lblAySec
            // 
            this.lblAySec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAySec.AutoSize = true;
            this.lblAySec.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAySec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblAySec.Location = new System.Drawing.Point(850, 20);
            this.lblAySec.Name = "lblAySec";
            this.lblAySec.Size = new System.Drawing.Size(46, 15);
            this.lblAySec.TabIndex = 2;
            this.lblAySec.Text = "Aylar:";
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblArama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblArama.Location = new System.Drawing.Point(16, 18);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(147, 19);
            this.lblArama.TabIndex = 1;
            this.lblArama.Text = "🔍 Cari Ara:";
            // 
            // txtArama
            // 
            this.txtArama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtArama.Location = new System.Drawing.Point(170, 15);
            this.txtArama.Name = "txtArama";
            this.txtArama.PlaceholderText = "";
            this.txtArama.Size = new System.Drawing.Size(460, 25);
            this.txtArama.TabIndex = 0;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // pnlHeaderCari
            // 
            this.pnlHeaderCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHeaderCari.Controls.Add(this.lblTitleCari);
            this.pnlHeaderCari.Controls.Add(this.lblDonem);
            this.pnlHeaderCari.Controls.Add(this.cmbDonem);
            this.pnlHeaderCari.Controls.Add(this.btnDevirGeriAl);
            this.pnlHeaderCari.Controls.Add(this.btnYilSonuDevir);
            this.pnlHeaderCari.Controls.Add(this.btnCopKutusu);
            this.pnlHeaderCari.Controls.Add(this.btnSil);
            this.pnlHeaderCari.Controls.Add(this.btnYeniCari);
            this.pnlHeaderCari.Controls.Add(this.btnTahsilatGir);
            this.pnlHeaderCari.Controls.Add(this.btnEkstre);
            this.pnlHeaderCari.Controls.Add(this.btnYenile);
            this.pnlHeaderCari.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderCari.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderCari.Name = "pnlHeaderCari";
            this.pnlHeaderCari.Size = new System.Drawing.Size(1100, 60);
            this.pnlHeaderCari.TabIndex = 0;
            // 
            // lblTitleCari
            // 
            this.lblTitleCari.AutoSize = true;
            this.lblTitleCari.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleCari.ForeColor = System.Drawing.Color.White;
            this.lblTitleCari.Location = new System.Drawing.Point(12, 18);
            this.lblTitleCari.Name = "lblTitleCari";
            this.lblTitleCari.Size = new System.Drawing.Size(125, 21);
            this.lblTitleCari.TabIndex = 5;
            this.lblTitleCari.Text = "📅 2026 Dönemi";
            // 
            // lblDonem
            // 
            this.lblDonem.AutoSize = true;
            this.lblDonem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDonem.ForeColor = System.Drawing.Color.White;
            this.lblDonem.Location = new System.Drawing.Point(150, 20);
            this.lblDonem.Name = "lblDonem";
            this.lblDonem.Size = new System.Drawing.Size(58, 19);
            this.lblDonem.TabIndex = 6;
            this.lblDonem.Text = "Dönem:";
            // 
            // cmbDonem
            // 
            this.cmbDonem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cmbDonem.Items.AddRange(new object[] {
            "2026",
            "2027"});
            this.cmbDonem.Location = new System.Drawing.Point(212, 17);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Size = new System.Drawing.Size(65, 25);
            this.cmbDonem.TabIndex = 7;
            this.cmbDonem.SelectedIndex = 1;
            this.cmbDonem.SelectedIndexChanged += new System.EventHandler(this.cmbDonem_SelectedIndexChanged);
            // 
            // btnYilSonuDevir
            // 
            this.btnYilSonuDevir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYilSonuDevir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnYilSonuDevir.FlatAppearance.BorderSize = 0;
            this.btnYilSonuDevir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYilSonuDevir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnYilSonuDevir.ForeColor = System.Drawing.Color.White;
            this.btnYilSonuDevir.Location = new System.Drawing.Point(290, 12);
            this.btnYilSonuDevir.Name = "btnYilSonuDevir";
            this.btnYilSonuDevir.Size = new System.Drawing.Size(118, 36);
            this.btnYilSonuDevir.TabIndex = 10;
            this.btnYilSonuDevir.Text = "📅 Yıl Sonu Devir";
            this.btnYilSonuDevir.UseVisualStyleBackColor = false;
            this.btnYilSonuDevir.Click += new System.EventHandler(this.btnYilSonuDevir_Click);
            // 
            // btnDevirGeriAl
            // 
            this.btnDevirGeriAl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDevirGeriAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnDevirGeriAl.FlatAppearance.BorderSize = 0;
            this.btnDevirGeriAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevirGeriAl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDevirGeriAl.ForeColor = System.Drawing.Color.White;
            this.btnDevirGeriAl.Location = new System.Drawing.Point(411, 12);
            this.btnDevirGeriAl.Name = "btnDevirGeriAl";
            this.btnDevirGeriAl.Size = new System.Drawing.Size(104, 36);
            this.btnDevirGeriAl.TabIndex = 8;
            this.btnDevirGeriAl.Text = "⏪ Devir Geri Al";
            this.btnDevirGeriAl.UseVisualStyleBackColor = false;
            this.btnDevirGeriAl.Click += new System.EventHandler(this.btnDevirGeriAl_Click);
            // 
            // btnCopKutusu
            // 
            this.btnCopKutusu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopKutusu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnCopKutusu.FlatAppearance.BorderSize = 0;
            this.btnCopKutusu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopKutusu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCopKutusu.ForeColor = System.Drawing.Color.White;
            this.btnCopKutusu.Location = new System.Drawing.Point(518, 12);
            this.btnCopKutusu.Name = "btnCopKutusu";
            this.btnCopKutusu.Size = new System.Drawing.Size(98, 36);
            this.btnCopKutusu.TabIndex = 11;
            this.btnCopKutusu.Text = "🗑️ Çöp Kutusu";
            this.btnCopKutusu.UseVisualStyleBackColor = false;
            this.btnCopKutusu.Click += new System.EventHandler(this.btnCopKutusu_Click);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(619, 12);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(58, 36);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "🗑️ Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYeniCari
            // 
            this.btnYeniCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnYeniCari.FlatAppearance.BorderSize = 0;
            this.btnYeniCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniCari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnYeniCari.ForeColor = System.Drawing.Color.White;
            this.btnYeniCari.Location = new System.Drawing.Point(680, 12);
            this.btnYeniCari.Name = "btnYeniCari";
            this.btnYeniCari.Size = new System.Drawing.Size(86, 36);
            this.btnYeniCari.TabIndex = 14;
            this.btnYeniCari.Text = "➕ Yeni Cari";
            this.btnYeniCari.UseVisualStyleBackColor = false;
            this.btnYeniCari.Click += new System.EventHandler(this.btnYeniCari_Click);
            // 
            // btnTahsilatGir
            // 
            this.btnTahsilatGir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTahsilatGir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTahsilatGir.FlatAppearance.BorderSize = 0;
            this.btnTahsilatGir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTahsilatGir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTahsilatGir.ForeColor = System.Drawing.Color.White;
            this.btnTahsilatGir.Location = new System.Drawing.Point(769, 12);
            this.btnTahsilatGir.Name = "btnTahsilatGir";
            this.btnTahsilatGir.Size = new System.Drawing.Size(94, 36);
            this.btnTahsilatGir.TabIndex = 13;
            this.btnTahsilatGir.Text = "💵 Tahsilat Gir";
            this.btnTahsilatGir.UseVisualStyleBackColor = false;
            this.btnTahsilatGir.Click += new System.EventHandler(this.btnTahsilatGir_Click);
            // 
            // btnEkstre
            // 
            this.btnEkstre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkstre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnEkstre.FlatAppearance.BorderSize = 0;
            this.btnEkstre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkstre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEkstre.ForeColor = System.Drawing.Color.White;
            this.btnEkstre.Location = new System.Drawing.Point(866, 12);
            this.btnEkstre.Name = "btnEkstre";
            this.btnEkstre.Size = new System.Drawing.Size(94, 36);
            this.btnEkstre.TabIndex = 12;
            this.btnEkstre.Text = "📄 Cari Ekstre";
            this.btnEkstre.UseVisualStyleBackColor = false;
            this.btnEkstre.Click += new System.EventHandler(this.btnEkstre_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Location = new System.Drawing.Point(963, 12);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(76, 36);
            this.btnYenile.TabIndex = 11;
            this.btnYenile.Text = "🔄 Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // pnlMuhasebeModul
            // 
            this.pnlMuhasebeModul.Controls.Add(this.pnlMuhasebeContent);
            this.pnlMuhasebeModul.Controls.Add(this.pnlHeaderMuhasebe);
            this.pnlMuhasebeModul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMuhasebeModul.Location = new System.Drawing.Point(0, 0);
            this.pnlMuhasebeModul.Name = "pnlMuhasebeModul";
            this.pnlMuhasebeModul.Size = new System.Drawing.Size(1100, 680);
            this.pnlMuhasebeModul.TabIndex = 1;
            this.pnlMuhasebeModul.Visible = false;
            // 
            // pnlMuhasebeContent
            // 
            this.pnlMuhasebeContent.AutoScroll = true;
            this.pnlMuhasebeContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMuhasebeContent.Controls.Add(this.pnlCardMuhasebeOzet);
            this.pnlMuhasebeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMuhasebeContent.Location = new System.Drawing.Point(0, 60);
            this.pnlMuhasebeContent.Name = "pnlMuhasebeContent";
            this.pnlMuhasebeContent.Padding = new System.Windows.Forms.Padding(25);
            this.pnlMuhasebeContent.Size = new System.Drawing.Size(1100, 620);
            this.pnlMuhasebeContent.TabIndex = 1;
            // 
            // pnlCardMuhasebeOzet
            // 
            this.pnlCardMuhasebeOzet.BackColor = System.Drawing.Color.White;
            this.pnlCardMuhasebeOzet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardMuhasebeOzet.Controls.Add(this.btnMuhasebeEkstre);
            this.pnlCardMuhasebeOzet.Controls.Add(this.btnMuhasebeTahsilat);
            this.pnlCardMuhasebeOzet.Controls.Add(this.lblCardOzetDesc);
            this.pnlCardMuhasebeOzet.Controls.Add(this.lblCardOzetTitle);
            this.pnlCardMuhasebeOzet.Location = new System.Drawing.Point(25, 25);
            this.pnlCardMuhasebeOzet.Name = "pnlCardMuhasebeOzet";
            this.pnlCardMuhasebeOzet.Size = new System.Drawing.Size(990, 170);
            this.pnlCardMuhasebeOzet.TabIndex = 1;
            // 
            // btnMuhasebeEkstre
            // 
            this.btnMuhasebeEkstre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnMuhasebeEkstre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuhasebeEkstre.FlatAppearance.BorderSize = 0;
            this.btnMuhasebeEkstre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuhasebeEkstre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMuhasebeEkstre.ForeColor = System.Drawing.Color.White;
            this.btnMuhasebeEkstre.Location = new System.Drawing.Point(225, 105);
            this.btnMuhasebeEkstre.Name = "btnMuhasebeEkstre";
            this.btnMuhasebeEkstre.Size = new System.Drawing.Size(190, 42);
            this.btnMuhasebeEkstre.TabIndex = 3;
            this.btnMuhasebeEkstre.Text = "📄 Cari Ekstre Görüntüle";
            this.btnMuhasebeEkstre.UseVisualStyleBackColor = false;
            this.btnMuhasebeEkstre.Click += new System.EventHandler(this.btnEkstre_Click);
            // 
            // btnMuhasebeTahsilat
            // 
            this.btnMuhasebeTahsilat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnMuhasebeTahsilat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuhasebeTahsilat.FlatAppearance.BorderSize = 0;
            this.btnMuhasebeTahsilat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuhasebeTahsilat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMuhasebeTahsilat.ForeColor = System.Drawing.Color.White;
            this.btnMuhasebeTahsilat.Location = new System.Drawing.Point(20, 105);
            this.btnMuhasebeTahsilat.Name = "btnMuhasebeTahsilat";
            this.btnMuhasebeTahsilat.Size = new System.Drawing.Size(190, 42);
            this.btnMuhasebeTahsilat.TabIndex = 2;
            this.btnMuhasebeTahsilat.Text = "💵 Hızlı Tahsilat Gir";
            this.btnMuhasebeTahsilat.UseVisualStyleBackColor = false;
            this.btnMuhasebeTahsilat.Click += new System.EventHandler(this.btnTahsilatGir_Click);
            // 
            // lblCardOzetDesc
            // 
            this.lblCardOzetDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCardOzetDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblCardOzetDesc.Location = new System.Drawing.Point(20, 50);
            this.lblCardOzetDesc.Name = "lblCardOzetDesc";
            this.lblCardOzetDesc.Size = new System.Drawing.Size(945, 45);
            this.lblCardOzetDesc.TabIndex = 1;
            this.lblCardOzetDesc.Text = "Müşterilerinizden yapılan tahsilatları sisteme kaydetmek veya cari hesap ekstresi almak için aşağıdaki hızlı işlem butonlarını kullanabilirsiniz.";
            // 
            // lblCardOzetTitle
            // 
            this.lblCardOzetTitle.AutoSize = true;
            this.lblCardOzetTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCardOzetTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblCardOzetTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCardOzetTitle.Name = "lblCardOzetTitle";
            this.lblCardOzetTitle.Size = new System.Drawing.Size(306, 21);
            this.lblCardOzetTitle.TabIndex = 0;
            this.lblCardOzetTitle.Text = "📊 Hızlı Tahsilat & Ekstre İşlemleri";
            // 
            // pnlHeaderMuhasebe
            // 
            this.pnlHeaderMuhasebe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHeaderMuhasebe.Controls.Add(this.lblTitleMuhasebe);
            this.pnlHeaderMuhasebe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderMuhasebe.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderMuhasebe.Name = "pnlHeaderMuhasebe";
            this.pnlHeaderMuhasebe.Size = new System.Drawing.Size(1100, 60);
            this.pnlHeaderMuhasebe.TabIndex = 0;
            // 
            // lblTitleMuhasebe
            // 
            this.lblTitleMuhasebe.AutoSize = true;
            this.lblTitleMuhasebe.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitleMuhasebe.ForeColor = System.Drawing.Color.White;
            this.lblTitleMuhasebe.Location = new System.Drawing.Point(16, 17);
            this.lblTitleMuhasebe.Name = "lblTitleMuhasebe";
            this.lblTitleMuhasebe.Size = new System.Drawing.Size(370, 25);
            this.lblTitleMuhasebe.TabIndex = 0;
            this.lblTitleMuhasebe.Text = "Muhasebe Ücretleri ve Borçlandırma Paneli";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(1380, 680);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetFinans";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlCikisWrapper.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlCariKartlarModul.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariler)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlCardBakiye.ResumeLayout(false);
            this.pnlCardBakiye.PerformLayout();
            this.pnlCardAlacak.ResumeLayout(false);
            this.pnlCardAlacak.PerformLayout();
            this.pnlCardBorc.ResumeLayout(false);
            this.pnlCardBorc.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlHeaderCari.ResumeLayout(false);
            this.pnlHeaderCari.PerformLayout();
            this.pnlMuhasebeModul.ResumeLayout(false);
            this.pnlMuhasebeContent.ResumeLayout(false);
            this.pnlCardMuhasebeOzet.ResumeLayout(false);
            this.pnlCardMuhasebeOzet.PerformLayout();
            this.pnlHeaderMuhasebe.ResumeLayout(false);
            this.pnlHeaderMuhasebe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogoTitle;
        private System.Windows.Forms.Label lblLogoSubtitle;
        private System.Windows.Forms.Button btnMenuCari;
        private System.Windows.Forms.Button btnMenuMuhasebe;
        private System.Windows.Forms.Panel pnlCikisWrapper;
        private System.Windows.Forms.Button btnMenuCikis;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlCariKartlarModul;
        private System.Windows.Forms.Panel pnlHeaderCari;
        private System.Windows.Forms.Label lblTitleCari;
        private System.Windows.Forms.Label lblDonem;
        private System.Windows.Forms.ComboBox cmbDonem;
        private System.Windows.Forms.Button btnDevirGeriAl;
        private System.Windows.Forms.Button btnYilSonuDevir;
        private System.Windows.Forms.Button btnCopKutusu;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYeniCari;
        private System.Windows.Forms.Button btnTahsilatGir;
        private System.Windows.Forms.Button btnEkstre;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblArama;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label lblAySec;
        private System.Windows.Forms.CheckedListBox clbAylar;
        private System.Windows.Forms.DataGridView dgvCariler;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlCardBorc;
        private System.Windows.Forms.Label lblTitleBorc;
        private System.Windows.Forms.Label lblGenelBorc;
        private System.Windows.Forms.Panel pnlCardAlacak;
        private System.Windows.Forms.Label lblTitleAlacak;
        private System.Windows.Forms.Label lblGenelAlacak;
        private System.Windows.Forms.Panel pnlCardBakiye;
        private System.Windows.Forms.Label lblTitleBakiye;
        private System.Windows.Forms.Label lblGenelBakiye;
        private System.Windows.Forms.Panel pnlMuhasebeModul;
        private System.Windows.Forms.Panel pnlHeaderMuhasebe;
        private System.Windows.Forms.Label lblTitleMuhasebe;
        private System.Windows.Forms.Panel pnlMuhasebeContent;
        private System.Windows.Forms.Panel pnlCardMuhasebeOzet;
        private System.Windows.Forms.Label lblCardOzetTitle;
        private System.Windows.Forms.Label lblCardOzetDesc;
        private System.Windows.Forms.Button btnMuhasebeTahsilat;
        private System.Windows.Forms.Button btnMuhasebeEkstre;
    }
}