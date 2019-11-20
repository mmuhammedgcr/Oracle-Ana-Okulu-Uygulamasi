namespace WpfApplication1
{
    partial class Raporlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDersKonusu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtOgrenciSoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOgrRaporExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOgrenciAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOgrenci = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtOgretmenSoyad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOGRTMNRaporExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOgretmenAd = new System.Windows.Forms.TextBox();
            this.dgvOgretmen = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSinifRaporExport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSinifAd = new System.Windows.Forms.TextBox();
            this.dgvSinif = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtVeliSoyad = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnVeliRaporExport = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtVeliAd = new System.Windows.Forms.TextBox();
            this.dgvVeli = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnOdemeRaporExport = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOgrenciOdemeSoyad = new System.Windows.Forms.TextBox();
            this.txtOgrenciOdemeAd = new System.Windows.Forms.TextBox();
            this.dgvOdeme = new System.Windows.Forms.DataGridView();
            this.txtOdemeOgrenci = new System.Windows.Forms.TextBox();
            this.txtOdemeId = new System.Windows.Forms.TextBox();
            this.txtOdemeMiktar = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOdemeEkle = new System.Windows.Forms.Button();
            this.btnOdemeGuncelle = new System.Windows.Forms.Button();
            this.btnOdemeReset = new System.Windows.Forms.Button();
            this.btnOdemeSil = new System.Windows.Forms.Button();
            this.dtpOdeme = new System.Windows.Forms.DateTimePicker();
            this.dgvDersKonusu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOgrenci)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOgretmen)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinif)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeli)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdeme)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDersKonusu
            // 
            this.dgvDersKonusu.Controls.Add(this.tabPage1);
            this.dgvDersKonusu.Controls.Add(this.tabPage2);
            this.dgvDersKonusu.Controls.Add(this.tabPage3);
            this.dgvDersKonusu.Controls.Add(this.tabPage7);
            this.dgvDersKonusu.Controls.Add(this.tabPage5);
            this.dgvDersKonusu.Location = new System.Drawing.Point(12, 12);
            this.dgvDersKonusu.Name = "dgvDersKonusu";
            this.dgvDersKonusu.SelectedIndex = 0;
            this.dgvDersKonusu.Size = new System.Drawing.Size(1277, 531);
            this.dgvDersKonusu.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SaddleBrown;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.btnOgrRaporExport);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.dgvOgrenci);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1269, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Öğrenciler";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtOgrenciSoyad);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.Location = new System.Drawing.Point(45, 389);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(310, 65);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Soyada Göre Arama";
            // 
            // txtOgrenciSoyad
            // 
            this.txtOgrenciSoyad.Location = new System.Drawing.Point(111, 25);
            this.txtOgrenciSoyad.Name = "txtOgrenciSoyad";
            this.txtOgrenciSoyad.Size = new System.Drawing.Size(161, 26);
            this.txtOgrenciSoyad.TabIndex = 0;
            this.txtOgrenciSoyad.TextChanged += new System.EventHandler(this.txtOgrenciSoyad_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Soyad:";
            // 
            // btnOgrRaporExport
            // 
            this.btnOgrRaporExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOgrRaporExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOgrRaporExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOgrRaporExport.Location = new System.Drawing.Point(403, 356);
            this.btnOgrRaporExport.Name = "btnOgrRaporExport";
            this.btnOgrRaporExport.Size = new System.Drawing.Size(152, 55);
            this.btnOgrRaporExport.TabIndex = 4;
            this.btnOgrRaporExport.Text = "Rapor Al";
            this.btnOgrRaporExport.UseVisualStyleBackColor = false;
            this.btnOgrRaporExport.Click += new System.EventHandler(this.btnOgrRaporExport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOgrenciAd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(45, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ada Göre Arama";
            // 
            // txtOgrenciAd
            // 
            this.txtOgrenciAd.Location = new System.Drawing.Point(111, 29);
            this.txtOgrenciAd.Name = "txtOgrenciAd";
            this.txtOgrenciAd.Size = new System.Drawing.Size(161, 26);
            this.txtOgrenciAd.TabIndex = 0;
            this.txtOgrenciAd.TextChanged += new System.EventHandler(this.txtOgrenciAd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ad:";
            // 
            // dgvOgrenci
            // 
            this.dgvOgrenci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOgrenci.Location = new System.Drawing.Point(27, 17);
            this.dgvOgrenci.Name = "dgvOgrenci";
            this.dgvOgrenci.Size = new System.Drawing.Size(579, 270);
            this.dgvOgrenci.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SaddleBrown;
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.btnOGRTMNRaporExport);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.dgvOgretmen);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1269, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Öğretmenler";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtOgretmenSoyad);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox6.Location = new System.Drawing.Point(39, 399);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(325, 86);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Soyada Göre Arama";
            // 
            // txtOgretmenSoyad
            // 
            this.txtOgretmenSoyad.Location = new System.Drawing.Point(132, 39);
            this.txtOgretmenSoyad.Name = "txtOgretmenSoyad";
            this.txtOgretmenSoyad.Size = new System.Drawing.Size(161, 26);
            this.txtOgretmenSoyad.TabIndex = 0;
            this.txtOgretmenSoyad.TextChanged += new System.EventHandler(this.txtOgretmenSoyad_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Soyadı";
            // 
            // btnOGRTMNRaporExport
            // 
            this.btnOGRTMNRaporExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOGRTMNRaporExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOGRTMNRaporExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOGRTMNRaporExport.Location = new System.Drawing.Point(412, 357);
            this.btnOGRTMNRaporExport.Name = "btnOGRTMNRaporExport";
            this.btnOGRTMNRaporExport.Size = new System.Drawing.Size(207, 59);
            this.btnOGRTMNRaporExport.TabIndex = 5;
            this.btnOGRTMNRaporExport.Text = "Rapor Al";
            this.btnOGRTMNRaporExport.UseVisualStyleBackColor = false;
            this.btnOGRTMNRaporExport.Click += new System.EventHandler(this.btnOGRTMNRaporExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtOgretmenAd);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(39, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ada Göre Arama";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Adı";
            // 
            // txtOgretmenAd
            // 
            this.txtOgretmenAd.Location = new System.Drawing.Point(117, 36);
            this.txtOgretmenAd.Name = "txtOgretmenAd";
            this.txtOgretmenAd.Size = new System.Drawing.Size(161, 26);
            this.txtOgretmenAd.TabIndex = 0;
            this.txtOgretmenAd.TextChanged += new System.EventHandler(this.txtOgretmenAd_TextChanged);
            // 
            // dgvOgretmen
            // 
            this.dgvOgretmen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOgretmen.Location = new System.Drawing.Point(20, 20);
            this.dgvOgretmen.Name = "dgvOgretmen";
            this.dgvOgretmen.Size = new System.Drawing.Size(610, 242);
            this.dgvOgretmen.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SaddleBrown;
            this.tabPage3.Controls.Add(this.btnSinifRaporExport);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.dgvSinif);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1269, 505);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sınıf";
            // 
            // btnSinifRaporExport
            // 
            this.btnSinifRaporExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSinifRaporExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSinifRaporExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSinifRaporExport.Location = new System.Drawing.Point(408, 338);
            this.btnSinifRaporExport.Name = "btnSinifRaporExport";
            this.btnSinifRaporExport.Size = new System.Drawing.Size(223, 83);
            this.btnSinifRaporExport.TabIndex = 6;
            this.btnSinifRaporExport.Text = "Rapor Al";
            this.btnSinifRaporExport.UseVisualStyleBackColor = false;
            this.btnSinifRaporExport.Click += new System.EventHandler(this.btnSinifRaporExport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtSinifAd);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(45, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 106);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Arama";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Sınıf Adı";
            // 
            // txtSinifAd
            // 
            this.txtSinifAd.Location = new System.Drawing.Point(132, 34);
            this.txtSinifAd.Name = "txtSinifAd";
            this.txtSinifAd.Size = new System.Drawing.Size(161, 26);
            this.txtSinifAd.TabIndex = 0;
            this.txtSinifAd.TextChanged += new System.EventHandler(this.txtSinifAd_TextChanged);
            // 
            // dgvSinif
            // 
            this.dgvSinif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinif.Location = new System.Drawing.Point(57, 21);
            this.dgvSinif.Name = "dgvSinif";
            this.dgvSinif.Size = new System.Drawing.Size(562, 279);
            this.dgvSinif.TabIndex = 2;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.SaddleBrown;
            this.tabPage7.Controls.Add(this.groupBox8);
            this.tabPage7.Controls.Add(this.btnVeliRaporExport);
            this.tabPage7.Controls.Add(this.groupBox7);
            this.tabPage7.Controls.Add(this.dgvVeli);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1269, 505);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Veli";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtVeliSoyad);
            this.groupBox8.Controls.Add(this.label23);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox8.Location = new System.Drawing.Point(53, 412);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(322, 73);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Soyada Göre Arama";
            // 
            // txtVeliSoyad
            // 
            this.txtVeliSoyad.Location = new System.Drawing.Point(92, 25);
            this.txtVeliSoyad.Name = "txtVeliSoyad";
            this.txtVeliSoyad.Size = new System.Drawing.Size(161, 26);
            this.txtVeliSoyad.TabIndex = 0;
            this.txtVeliSoyad.TextChanged += new System.EventHandler(this.txtVeliSoyad_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(21, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 20);
            this.label23.TabIndex = 1;
            this.label23.Text = "Soyad";
            // 
            // btnVeliRaporExport
            // 
            this.btnVeliRaporExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnVeliRaporExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVeliRaporExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVeliRaporExport.Location = new System.Drawing.Point(406, 339);
            this.btnVeliRaporExport.Name = "btnVeliRaporExport";
            this.btnVeliRaporExport.Size = new System.Drawing.Size(223, 83);
            this.btnVeliRaporExport.TabIndex = 7;
            this.btnVeliRaporExport.Text = "Rapor Al";
            this.btnVeliRaporExport.UseVisualStyleBackColor = false;
            this.btnVeliRaporExport.Click += new System.EventHandler(this.btnVeliRaporExport_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.txtVeliAd);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox7.Location = new System.Drawing.Point(53, 317);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(322, 74);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Ada Göre Arama";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(43, 34);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 20);
            this.label24.TabIndex = 1;
            this.label24.Text = "Adı";
            // 
            // txtVeliAd
            // 
            this.txtVeliAd.Location = new System.Drawing.Point(92, 31);
            this.txtVeliAd.Name = "txtVeliAd";
            this.txtVeliAd.Size = new System.Drawing.Size(161, 26);
            this.txtVeliAd.TabIndex = 0;
            this.txtVeliAd.TextChanged += new System.EventHandler(this.txtVeliAd_TextChanged);
            // 
            // dgvVeli
            // 
            this.dgvVeli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeli.Location = new System.Drawing.Point(28, 28);
            this.dgvVeli.Name = "dgvVeli";
            this.dgvVeli.Size = new System.Drawing.Size(613, 271);
            this.dgvVeli.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.SaddleBrown;
            this.tabPage5.Controls.Add(this.btnOdemeRaporExport);
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Controls.Add(this.dgvOdeme);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1269, 505);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Ödeme";
            // 
            // btnOdemeRaporExport
            // 
            this.btnOdemeRaporExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOdemeRaporExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdemeRaporExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOdemeRaporExport.Location = new System.Drawing.Point(377, 294);
            this.btnOdemeRaporExport.Name = "btnOdemeRaporExport";
            this.btnOdemeRaporExport.Size = new System.Drawing.Size(223, 83);
            this.btnOdemeRaporExport.TabIndex = 8;
            this.btnOdemeRaporExport.Text = "Rapor Al";
            this.btnOdemeRaporExport.UseVisualStyleBackColor = false;
            this.btnOdemeRaporExport.Click += new System.EventHandler(this.btnOdemeRaporExport_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.txtOgrenciOdemeSoyad);
            this.groupBox5.Controls.Add(this.txtOgrenciOdemeAd);
            this.groupBox5.Location = new System.Drawing.Point(57, 274);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(299, 140);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Miktar";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Öğrenci";
            // 
            // txtOgrenciOdemeSoyad
            // 
            this.txtOgrenciOdemeSoyad.Location = new System.Drawing.Point(100, 75);
            this.txtOgrenciOdemeSoyad.Name = "txtOgrenciOdemeSoyad";
            this.txtOgrenciOdemeSoyad.Size = new System.Drawing.Size(161, 20);
            this.txtOgrenciOdemeSoyad.TabIndex = 4;
            this.txtOgrenciOdemeSoyad.TextChanged += new System.EventHandler(this.txtOgrenciOdemeSoyad_TextChanged);
            // 
            // txtOgrenciOdemeAd
            // 
            this.txtOgrenciOdemeAd.Location = new System.Drawing.Point(100, 29);
            this.txtOgrenciOdemeAd.Name = "txtOgrenciOdemeAd";
            this.txtOgrenciOdemeAd.Size = new System.Drawing.Size(161, 20);
            this.txtOgrenciOdemeAd.TabIndex = 6;
            this.txtOgrenciOdemeAd.TextChanged += new System.EventHandler(this.txtOgrenciOdemeAd_TextChanged);
            // 
            // dgvOdeme
            // 
            this.dgvOdeme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdeme.Location = new System.Drawing.Point(20, 29);
            this.dgvOdeme.Name = "dgvOdeme";
            this.dgvOdeme.Size = new System.Drawing.Size(580, 210);
            this.dgvOdeme.TabIndex = 2;
            // 
            // txtOdemeOgrenci
            // 
            this.txtOdemeOgrenci.Location = new System.Drawing.Point(206, 83);
            this.txtOdemeOgrenci.Name = "txtOdemeOgrenci";
            this.txtOdemeOgrenci.Size = new System.Drawing.Size(161, 20);
            this.txtOdemeOgrenci.TabIndex = 0;
            // 
            // txtOdemeId
            // 
            this.txtOdemeId.Location = new System.Drawing.Point(206, 57);
            this.txtOdemeId.Name = "txtOdemeId";
            this.txtOdemeId.Size = new System.Drawing.Size(161, 20);
            this.txtOdemeId.TabIndex = 0;
            // 
            // txtOdemeMiktar
            // 
            this.txtOdemeMiktar.Location = new System.Drawing.Point(206, 109);
            this.txtOdemeMiktar.Name = "txtOdemeMiktar";
            this.txtOdemeMiktar.Size = new System.Drawing.Size(161, 20);
            this.txtOdemeMiktar.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 1;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(42, 64);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(15, 13);
            this.label30.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 1;
            // 
            // btnOdemeEkle
            // 
            this.btnOdemeEkle.Location = new System.Drawing.Point(40, 236);
            this.btnOdemeEkle.Name = "btnOdemeEkle";
            this.btnOdemeEkle.Size = new System.Drawing.Size(75, 23);
            this.btnOdemeEkle.TabIndex = 2;
            this.btnOdemeEkle.Text = "Ekle";
            this.btnOdemeEkle.UseVisualStyleBackColor = true;
            // 
            // btnOdemeGuncelle
            // 
            this.btnOdemeGuncelle.Location = new System.Drawing.Point(139, 236);
            this.btnOdemeGuncelle.Name = "btnOdemeGuncelle";
            this.btnOdemeGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnOdemeGuncelle.TabIndex = 2;
            this.btnOdemeGuncelle.Text = "Güncelle";
            this.btnOdemeGuncelle.UseVisualStyleBackColor = true;
            // 
            // btnOdemeReset
            // 
            this.btnOdemeReset.Location = new System.Drawing.Point(139, 283);
            this.btnOdemeReset.Name = "btnOdemeReset";
            this.btnOdemeReset.Size = new System.Drawing.Size(75, 23);
            this.btnOdemeReset.TabIndex = 2;
            this.btnOdemeReset.Text = "Temizle";
            this.btnOdemeReset.UseVisualStyleBackColor = true;
            // 
            // btnOdemeSil
            // 
            this.btnOdemeSil.Location = new System.Drawing.Point(241, 236);
            this.btnOdemeSil.Name = "btnOdemeSil";
            this.btnOdemeSil.Size = new System.Drawing.Size(75, 23);
            this.btnOdemeSil.TabIndex = 2;
            this.btnOdemeSil.Text = "Sil";
            this.btnOdemeSil.UseVisualStyleBackColor = true;
            // 
            // dtpOdeme
            // 
            this.dtpOdeme.Location = new System.Drawing.Point(206, 142);
            this.dtpOdeme.Name = "dtpOdeme";
            this.dtpOdeme.Size = new System.Drawing.Size(200, 20);
            this.dtpOdeme.TabIndex = 3;
            // 
            // Raporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 531);
            this.Controls.Add(this.dgvDersKonusu);
            this.Name = "Raporlar";
            this.Text = "Raporlar";
            this.dgvDersKonusu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOgrenci)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOgretmen)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinif)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeli)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdeme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl dgvDersKonusu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgrenciAd;
        private System.Windows.Forms.DataGridView dgvOgrenci;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOgretmenSoyad;
        private System.Windows.Forms.TextBox txtOgretmenAd;
        private System.Windows.Forms.DataGridView dgvOgretmen;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSinifOgretmen;
        private System.Windows.Forms.TextBox txtSinifOgrenci;
        private System.Windows.Forms.TextBox txtSinifAd;
        private System.Windows.Forms.DataGridView dgvSinif;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtVeliSoyad;
        private System.Windows.Forms.TextBox txtVeliAd;
        private System.Windows.Forms.DataGridView dgvVeli;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvOdeme;
        private System.Windows.Forms.TextBox txtOdemeOgrenci;
        private System.Windows.Forms.TextBox txtOdemeId;
        private System.Windows.Forms.TextBox txtOdemeMiktar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOdemeEkle;
        private System.Windows.Forms.Button btnOdemeGuncelle;
        private System.Windows.Forms.Button btnOdemeReset;
        private System.Windows.Forms.Button btnOdemeSil;
        private System.Windows.Forms.DateTimePicker dtpOdeme;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtOgrenciOdemeSoyad;
        private System.Windows.Forms.TextBox txtOgrenciOdemeAd;
        private System.Windows.Forms.Button btnOgrRaporExport;
        private System.Windows.Forms.Button btnOGRTMNRaporExport;
        private System.Windows.Forms.Button btnSinifRaporExport;
        private System.Windows.Forms.Button btnVeliRaporExport;
        private System.Windows.Forms.Button btnOdemeRaporExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOgrenciSoyad;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
    }
}