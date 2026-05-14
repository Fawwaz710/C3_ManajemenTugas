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
            // TODO: This line of code loads data into the 'tugasDBDataSet1.v_TugasLengkap' table. You can move, or remove it, as needed.
            this.v_TugasLengkapTableAdapter.Fill(this.tugasDBDataSet1.v_TugasLengkap);
            try
            {
                // 1. Tampilkan Nama Dosen
                label13.Text = "Selamat Datang, " + UserSession.Nama;

                // 2. Memanggil data via TableAdapter (Cara Wizard PDF)
                RefreshSemuaData();

                // 3. KRUSIAL: Filter agar dosen hanya melihat tugas miliknya
                // Ini akan menyaring data yang muncul di GridView dan TextBox yang sudah di-tag
                this.tugasBindingSource.Filter = "dosen_id = " + UserSession.UserId;
                this.vMonitoringMahasiswaBindingSource.Filter = "dosen_id = " + UserSession.UserId;
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

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (vTugasLengkapBindingSource.Current == null) return;

            try
            {
                // 1. Sinkronkan perubahan dari UI ke BindingSource
                this.vTugasLengkapBindingSource.EndEdit();

                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    // 2. Gunakan Stored Procedure sp_UpdateTugas
                    SqlCommand cmd = new SqlCommand("sp_UpdateTugas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ambil ID dari row yang sedang aktif di navigator
                    DataRowView current = (DataRowView)vTugasLengkapBindingSource.Current;
                    cmd.Parameters.AddWithValue("@id_tugas", current["id_tugas"]);
                    cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                    cmd.Parameters.AddWithValue("@desk", txtDeskripsi.Text);
                    cmd.Parameters.AddWithValue("@dl", dtpTanggal.Value.Date + dtpJam.Value.TimeOfDay);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diperbarui!", "Sukses");
                    RefreshSemuaData(); // Fungsi untuk Fill TableAdapter lagi
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (vTugasLengkapBindingSource.Current == null) return;

            DialogResult dr = MessageBox.Show("Yakin hapus tugas ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    DataRowView current = (DataRowView)vTugasLengkapBindingSource.Current;
                    using (SqlConnection conn = kon.GetConn())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_DeleteTugas", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_tugas", current["id_tugas"]);
                        cmd.ExecuteNonQuery();
                    }
                    vTugasLengkapBindingSource.RemoveCurrent();
                    MessageBox.Show("Data berhasil dihapus!");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();

                    // SQL untuk mereset data dengan menyalakan izin Input ID (IDENTITY_INSERT)
                    // Sesuaikan nama kolom (id_tugas, judul, deskripsi, deadline, dosen_id) dengan tabel Anda
                    string query = @"
                -- 1. Hapus data di tabel pengumpulan dulu (karena ada relasi FK)
                DELETE FROM pengumpulan;

                -- 2. Hapus data di tabel tugas
                DELETE FROM tugas;

                -- 3. Izinkan input ID manual
                SET IDENTITY_INSERT tugas ON;

                -- 4. Masukkan data dari backup (Sebutkan kolomnya satu per satu secara eksplisit)
                INSERT INTO tugas (id_tugas, judul, deskripsi, deadline, dosen_id)
                SELECT id_tugas, judul, deskripsi, deadline, dosen_id FROM tugas_Backup;

                -- 5. Matikan izin input ID manual
                SET IDENTITY_INSERT tugas OFF;
            ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil direset total!", "Sukses");

                    // Panggil fungsi refresh agar data muncul kembali di grid
                    RefreshSemuaData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal: " + ex.Message);
            }
        }

        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    // KODE TIDAK AMAN (Sesuai Modul Hal 7)
                    // Skenario: Masukkan ' OR 1=1 -- di txtJudul
                    string query = "UPDATE tugas SET judul='HACKED' WHERE judul='" + txtJudul.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    int result = cmd.ExecuteNonQuery();

                    MessageBox.Show(result + " baris terupdate oleh Injeksi!", "Hacked");
                    RefreshSemuaData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RefreshTampilanData_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Ambil data terbaru dari database ke dalam DataTable di dalam DataSet
                // Pastikan nama v_TugasLengkapTableAdapter sesuai dengan yang ada di tray Designer bawah
                this.v_TugasLengkapTableAdapter.Fill(this.tugasDBDataSet1.v_TugasLengkap);

                // 2. Pasang kembali filter agar dosen hanya melihat tugas buatannya sendiri
                this.vTugasLengkapBindingSource.Filter = "dosen_id = " + UserSession.UserId;

                // 3. Update label total jika ada
                lblTotalTugas.Text = "Total Tugas: " + vTugasLengkapBindingSource.Count.ToString();

                // 4. Reset bindings agar UI (Grid & TextBox) benar-benar terupdate
                this.vTugasLengkapBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Refresh: " + ex.Message);
            }
        }
    }
}