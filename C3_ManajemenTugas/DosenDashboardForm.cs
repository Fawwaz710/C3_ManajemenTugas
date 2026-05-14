using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C3_ManajemenTugas
{
    public partial class DosenDashboardForm : Form
    {
        Koneksi kon = new Koneksi();

        public DosenDashboardForm()
        {
            InitializeComponent();
        }

        private void DosenDashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Tampilkan Nama Dosen
                label13.Text = "Selamat Datang, " + UserSession.Nama;

                // 2. Memanggil data via TableAdapter (Cara Wizard PDF)
                RefreshSemuaData();

                // 3. KRUSIAL: Filter agar dosen hanya melihat tugas miliknya
                // Ini akan menyaring data yang muncul di GridView dan TextBox yang sudah di-tag
                this.tugasBindingSource.Filter = "dosen_id = " + UserSession.UserId;
                this.v_MonitoringMahasiswaBindingSource.Filter = "dosen_id = " + UserSession.UserId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memuat data: " + ex.Message);
            }
        }

        // Fungsi Refresh Data agar sinkron dengan Database
        void RefreshSemuaData()
        {
            this.tugasTableAdapter.Fill(this.tugasDBDataSet.tugas);
            this.v_MonitoringMahasiswaTableAdapter.Fill(this.tugasDBDataSet1.v_MonitoringMahasiswa);

            // Update Label Total (Menghitung jumlah baris setelah difilter)
            lblTotalTugas.Text = "Total Tugas: " + tugasBindingSource.Count.ToString();
        }

        // --- TAB 1: KELOLA TUGAS (STORED PROCEDURE) ---
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi Deadline (Revisi Dosen)
            DateTime deadlineBaru = dtpTanggal.Value.Date + dtpJam.Value.TimeOfDay;
            if (deadlineBaru < DateTime.Now) { MessageBox.Show("Deadline tidak boleh di masa lalu!"); return; }

            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    // KRITERIA UJIAN: MENGGUNAKAN STORED PROCEDURE
                    SqlCommand cmd = new SqlCommand("sp_InsertTugas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                    cmd.Parameters.AddWithValue("@desk", txtDeskripsi.Text);
                    cmd.Parameters.AddWithValue("@dl", deadlineBaru);
                    cmd.Parameters.AddWithValue("@dosen_id", UserSession.UserId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tugas Berhasil Disimpan via Stored Procedure!");

                    RefreshSemuaData(); // Refresh Dataset
                    ClearInput();
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
        }

        // --- FITUR SEARCH (STORED PROCEDURE) ---
        private void btnCari_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    // KRITERIA UJIAN: SEARCH VIA STORED PROCEDURE
                    SqlCommand cmd = new SqlCommand("sp_SearchTugas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@keyword", txtCari.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Tampilkan hasil pencarian ke BindingSource
                    tugasBindingSource.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- TAB 2: MONITORING & PENILAIAN ---
        private void btnBeriNilai_Click(object sender, EventArgs e)
        {
            if (dgvMonitoring.CurrentRow == null) return;

            // Ambil ID dari baris yang dipilih di GridView
            int idPeng = Convert.ToInt32(dgvMonitoring.CurrentRow.Cells["id_pengumpulan"].Value);

            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateNilai", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_peng", idPeng);
                    cmd.Parameters.AddWithValue("@nilai", float.Parse(txtNilai.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Nilai Berhasil Diupdate!");
                    RefreshSemuaData();
                }
            }
            catch { MessageBox.Show("Input nilai harus angka!"); }
        }

        void ClearInput()
        {
            txtJudul.Clear();
            txtDeskripsi.Clear();
            txtNilai.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }
    }
}