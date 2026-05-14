using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C3_ManajemenTugas
{
    public partial class DosenDashboardForm : Form
    {
        Koneksi kon = new Koneksi();
        BindingSource bsTugas = new BindingSource();

        public DosenDashboardForm()
        {
            InitializeComponent();
        }

        private void DosenDashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                label13.Text = "Selamat Datang, " + UserSession.Nama;
                LoadDataTugas();
                LoadMonitoringMhs();
            }
            catch { } // Mencegah crash jika lblWelcome belum diganti namanya
        }

        void LoadDataTugas()
        {
            using (SqlConnection conn = kon.GetConn())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_TugasLengkap WHERE dosen_id = " + UserSession.UserId, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bsTugas.DataSource = dt;
                dgvTugas.DataSource = bsTugas;
                if (bindingNavigator1 != null) bindingNavigator1.BindingSource = bsTugas;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            DateTime deadlineBaru = dtpTanggal.Value.Date + dtpJam.Value.TimeOfDay;
            if (deadlineBaru < DateTime.Now) { MessageBox.Show("Deadline tidak boleh di masa lalu!"); return; }

            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertTugas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDeskripsi.Text);
                    cmd.Parameters.AddWithValue("@dl", deadlineBaru);
                    cmd.Parameters.AddWithValue("@dosen_id", UserSession.UserId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tugas Berhasil Disimpan!");
                    LoadDataTugas();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void LoadMonitoringMhs()
        {
            using (SqlConnection conn = kon.GetConn())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_MonitoringMahasiswa WHERE dosen_id = " + UserSession.UserId, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMonitoring.DataSource = dt;
            }
        }

        private void btnBeriNilai_Click(object sender, EventArgs e)
        {
            if (dgvMonitoring.CurrentRow == null) return;
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
                    LoadMonitoringMhs();
                }
            }
            catch { MessageBox.Show("Input nilai harus angka!"); }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        // --- PENYELAMAT ERROR (JANGAN DIHAPUS) ---
        // Fungsi di bawah ini sengaja dikosongkan untuk menangani event yang terlanjur terdaftar di Designer
        private void lblTotalTugas_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void txtJudul_TextChanged(object sender, EventArgs e) { }
        private void dtpDeadline_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Deskripsi_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnHapus_Click(object sender, EventArgs e)
        {}

        private void btnCari_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}