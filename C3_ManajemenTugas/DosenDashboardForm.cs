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
    public partial class DosenDashboardForm : Form
    {
        Koneksi kon = new Koneksi();
        SqlConnection conn;

        public DosenDashboardForm()
        {
            InitializeComponent();
            conn = kon.GetConn();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

             
                MessageBox.Show("Koneksi ke Database TugasDB Berhasil!");

                conn.Close();

                LoadDosen();
                LoadDataTugas();
                HitungTotalTugas();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Koneksi Gagal: " + ex.Message);
            }
        }

        void LoadDosen()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT user_id, nama FROM users WHERE role = 'dosen'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                cmbDosen.DataSource = dt;
                cmbDosen.DisplayMember = "nama";
                cmbDosen.ValueMember = "user_id";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load dosen: " + ex.Message);
            }
        }

        void LoadDataTugas()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = @"SELECT t.id_tugas, t.judul, t.deskripsi, t.deadline, u.nama as nama_dosen 
                                 FROM tugas t 
                                 JOIN users u ON t.dosen_id = u.user_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvTugas.DataSource = dt;

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        void ClearForm()
        {
            txtIDTugas.Clear();
            txtJudul.Clear();
            txtDeskripsi.Clear();
            dtpDeadline.Value = DateTime.Now;
            txtSearch.Clear();
        }

        void HitungTotalTugas()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tugas", conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    lblTotalTugas.Text = "Total Tugas Tersedia: " + result.ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            LoadDataTugas();
        }

        private void dgvTugas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTugas.Rows[e.RowIndex];
                txtIDTugas.Text = row.Cells["id_tugas"].Value.ToString();
                txtJudul.Text = row.Cells["judul"].Value.ToString();
                txtDeskripsi.Text = row.Cells["deskripsi"].Value.ToString();

                if (row.Cells["deadline"].Value != DBNull.Value)
                    dtpDeadline.Value = Convert.ToDateTime(row.Cells["deadline"].Value);

                cmbDosen.Text = row.Cells["nama_dosen"].Value.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtJudul.Text) || string.IsNullOrEmpty(txtDeskripsi.Text))
                {
                    MessageBox.Show("Judul dan Deskripsi tidak boleh kosong!");
                    return;
                }

                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "INSERT INTO tugas (judul, deskripsi, deadline, dosen_id) VALUES (@judul, @desc, @deadline, @dosenId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                cmd.Parameters.AddWithValue("@desc", txtDeskripsi.Text);
                cmd.Parameters.AddWithValue("@deadline", dtpDeadline.Value);
                cmd.Parameters.AddWithValue("@dosenId", cmbDosen.SelectedValue);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Tugas berhasil disimpan!");

                LoadDataTugas();
                HitungTotalTugas();
                ClearForm();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal simpan: " + ex.Message);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDTugas.Text))
                {
                    MessageBox.Show("Pilih data yang ingin diubah dari tabel!");
                    return;
                }

                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "UPDATE tugas SET judul=@judul, deskripsi=@desc, deadline=@deadline, dosen_id=@dosenId WHERE id_tugas=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                cmd.Parameters.AddWithValue("@desc", txtDeskripsi.Text);
                cmd.Parameters.AddWithValue("@deadline", dtpDeadline.Value);
                cmd.Parameters.AddWithValue("@dosenId", cmbDosen.SelectedValue);
                cmd.Parameters.AddWithValue("@id", txtIDTugas.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diperbarui!");
                LoadDataTugas();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDTugas.Text)) return;

            DialogResult confirm = MessageBox.Show("Yakin ingin menghapus tugas ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tugas WHERE id_tugas = @id", conn);
                    cmd.Parameters.AddWithValue("@id", txtIDTugas.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil dihapus");
                    LoadDataTugas();
                    HitungTotalTugas();
                    ClearForm();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal hapus: " + ex.Message);
                }
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT t.id_tugas, t.judul, t.deskripsi, t.deadline, u.nama as nama_dosen " +
                               "FROM tugas t JOIN users u ON t.dosen_id = u.user_id " +
                               "WHERE t.judul LIKE @keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + txtSearch.Text + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTugas.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pencarian gagal: " + ex.Message);
            }
        }

     
        private void dgvTugas_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Deskripsi_Click(object sender, EventArgs e) { }
        private void txtJudul_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void dtpDeadline_ValueChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void lblTotalTugas_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}