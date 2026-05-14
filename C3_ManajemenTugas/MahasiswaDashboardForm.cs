using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C3_ManajemenTugas
{
    public partial class MahasiswaDashboardForm : Form
    {
        Koneksi kon = new Koneksi();
        BindingSource bsTugasMhs = new BindingSource();

        public MahasiswaDashboardForm()
        {
            InitializeComponent();
        }

        private void MahasiswaDashboardForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tugasDBDataSet1.v_TugasLengkap' table. You can move, or remove it, as needed.
            this.v_TugasLengkapTableAdapter.Fill(this.tugasDBDataSet1.v_TugasLengkap);
            // Menampilkan nama dari session login
            // Menggunakan try-catch agar jika label1 belum diganti namanya tidak crash
            try
            {
                label1.Text = "Selamat Datang, " + UserSession.Nama;
            }
            catch { }

            LoadDaftarTugas();
        }

        // --- MENGAMBIL DATA TUGAS DARI VIEW ---
        void LoadDaftarTugas()
        {
            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    // KRITERIA UJIAN: MENGGUNAKAN VIEW v_TugasLengkap
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_TugasLengkap", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bsTugasMhs.DataSource = dt;

                    if (dgvTugasMhs != null)
                    {
                        dgvTugasMhs.DataSource = bsTugasMhs;
                    }

                    // Menghubungkan ke BindingNavigator jika ada di form
                    // Pastikan komponen BindingNavigator di design diberi nama bnMahasiswa
                    Control[] nav = this.Controls.Find("bnMahasiswa", true);
                    if (nav.Length > 0 && nav[0] is BindingNavigator bnav)
                    {
                        bnav.BindingSource = bsTugasMhs;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat tugas: " + ex.Message);
            }
        }

        // --- FITUR BROWSE FILE ---
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zip Files (*.zip)|*.zip|PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Menampilkan path file ke textbox
                txtFilePath.Text = ofd.FileName;
            }
        }

        // --- FITUR UPLOAD TUGAS (MENGGUNAKAN STORED PROCEDURE) ---
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (dgvTugasMhs.CurrentRow == null)
            {
                MessageBox.Show("Pilih tugas yang ingin dikerjakan pada tabel terlebih dahulu!");
                return;
            }

            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Silakan pilih file tugas Anda terlebih dahulu!");
                return;
            }

            // Mengambil ID langsung dari sumber data (BindingSource) 
            // yang saat ini sedang dipilih di tabel
            DataRowView barisSekarang = (DataRowView)vTugasLengkapBindingSource.Current;
            int idTugas = Convert.ToInt32(barisSekarang["id_tugas"]);

            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    // KRITERIA UJIAN: MENGGUNAKAN STORED PROCEDURE sp_MahasiswaUpload
                    SqlCommand cmd = new SqlCommand("sp_MahasiswaUpload", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tugas_id", idTugas);
                    cmd.Parameters.AddWithValue("@mhs_id", UserSession.UserId);
                    cmd.Parameters.AddWithValue("@file_url", txtFilePath.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tugas Berhasil Diupload!");
                    txtFilePath.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Upload: " + ex.Message);
            }
        }

        // --- FITUR SEARCH (MENGGUNAKAN STORED PROCEDURE) ---
        private void btnCari_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCari.Text))
            {
                LoadDaftarTugas();
                return;
            }

            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    // KRITERIA UJIAN: SEARCH MENGGUNAKAN STORED PROCEDURE sp_SearchTugas
                    SqlCommand cmd = new SqlCommand("sp_SearchTugas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@keyword", txtCari.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bsTugasMhs.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pencarian gagal: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        // --- PENYELAMAT ERROR (Event Handler yang terdaftar di Designer namun kosong) ---
        private void dgvTugasMhs_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void txtFilePath_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void btnCetakReport_Click(object sender, EventArgs e) { }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }

        
    }
}