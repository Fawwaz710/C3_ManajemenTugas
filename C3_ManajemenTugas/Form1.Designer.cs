namespace C3_ManajemenTugas
{
    partial class Form1
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
            this.dgvTugas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJudul = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.txtIDTugas = new System.Windows.Forms.TextBox();
            this.btnTampil = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTotalTugas = new System.Windows.Forms.Label();
            this.cmbDosen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTugas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTugas
            // 
            this.dgvTugas.BackgroundColor = System.Drawing.SystemColors.HotTrack;
            this.dgvTugas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTugas.Location = new System.Drawing.Point(773, 26);
            this.dgvTugas.Name = "dgvTugas";
            this.dgvTugas.RowHeadersWidth = 51;
            this.dgvTugas.RowTemplate.Height = 24;
            this.dgvTugas.Size = new System.Drawing.Size(448, 424);
            this.dgvTugas.TabIndex = 0;
            this.dgvTugas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTugas_CellClick);
            this.dgvTugas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTugas_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Judul Tugas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtJudul
            // 
            this.txtJudul.Location = new System.Drawing.Point(116, 25);
            this.txtJudul.Name = "txtJudul";
            this.txtJudul.Size = new System.Drawing.Size(100, 22);
            this.txtJudul.TabIndex = 3;
            this.txtJudul.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Deskripsi";
            this.label3.Click += new System.EventHandler(this.Deskripsi_Click);
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Location = new System.Drawing.Point(116, 56);
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(200, 59);
            this.txtDeskripsi.TabIndex = 5;
            this.txtDeskripsi.TextChanged += new System.EventHandler(this.txtJudul_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Deadline";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.Location = new System.Drawing.Point(116, 180);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(200, 22);
            this.dtpDeadline.TabIndex = 7;
            this.dtpDeadline.ValueChanged += new System.EventHandler(this.dtpDeadline_ValueChanged);
            // 
            // txtIDTugas
            // 
            this.txtIDTugas.Location = new System.Drawing.Point(40, 260);
            this.txtIDTugas.Name = "txtIDTugas";
            this.txtIDTugas.Size = new System.Drawing.Size(100, 22);
            this.txtIDTugas.TabIndex = 8;
            this.txtIDTugas.Visible = false;
            this.txtIDTugas.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnTampil
            // 
            this.btnTampil.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampil.Location = new System.Drawing.Point(513, 95);
            this.btnTampil.Name = "btnTampil";
            this.btnTampil.Size = new System.Drawing.Size(122, 23);
            this.btnTampil.TabIndex = 9;
            this.btnTampil.Text = "Tampilkan Data";
            this.btnTampil.UseVisualStyleBackColor = true;
            this.btnTampil.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(513, 124);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(122, 23);
            this.btnSimpan.TabIndex = 10;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUbah.Location = new System.Drawing.Point(513, 153);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(122, 23);
            this.btnUbah.TabIndex = 11;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Location = new System.Drawing.Point(513, 182);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(122, 23);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnCari
            // 
            this.btnCari.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(513, 66);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(122, 23);
            this.btnCari.TabIndex = 13;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(650, 67);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 22);
            this.txtSearch.TabIndex = 14;
            // 
            // lblTotalTugas
            // 
            this.lblTotalTugas.AutoSize = true;
            this.lblTotalTugas.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTugas.Location = new System.Drawing.Point(517, 25);
            this.lblTotalTugas.Name = "lblTotalTugas";
            this.lblTotalTugas.Size = new System.Drawing.Size(110, 19);
            this.lblTotalTugas.TabIndex = 15;
            this.lblTotalTugas.Text = "Total Tugas: 0";
            this.lblTotalTugas.Click += new System.EventHandler(this.lblTotalTugas_Click);
            // 
            // cmbDosen
            // 
            this.cmbDosen.FormattingEnabled = true;
            this.cmbDosen.Items.AddRange(new object[] {
            "Dosen Teknik ",
            "Dosen PDW",
            "Dosen PABD",
            "Dosen Routing",
            "Dosen STQA",
            "Dosen HCI"});
            this.cmbDosen.Location = new System.Drawing.Point(116, 124);
            this.cmbDosen.Name = "cmbDosen";
            this.cmbDosen.Size = new System.Drawing.Size(166, 24);
            this.cmbDosen.TabIndex = 16;
            this.cmbDosen.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nama Dosen ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1268, 487);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDosen);
            this.Controls.Add(this.lblTotalTugas);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnTampil);
            this.Controls.Add(this.txtIDTugas);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtJudul);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTugas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTugas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTugas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJudul;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.TextBox txtIDTugas;
        private System.Windows.Forms.Button btnTampil;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTotalTugas;
        private System.Windows.Forms.ComboBox cmbDosen;
        private System.Windows.Forms.Label label4;
    }
}

