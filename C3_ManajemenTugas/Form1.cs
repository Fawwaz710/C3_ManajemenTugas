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
    public partial class Form1 : Form
    {
            SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Koneksi kon = new Koneksi();


                SqlConnection conn = kon.GetConn();

                conn.Open();
                MessageBox.Show("Koneksi ke Database TugasDB Berhasil!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal: " + ex.Message);
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            HitungTotalTugas(); 
        }
        }

        void LoadDataTugas()
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // Query untuk mengambil data tugas dan nama dosennya
                    string query = @"SELECT t.id_tugas, t.judul, t.deskripsi, t.deadline, u.nama as nama_dosen 
                         FROM tugas t 
                         JOIN users u ON t.dosen_id = u.user_id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvTugas.DataSource = dt; // dgvTugas adalah nama DataGridView Anda

                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal load data: " + ex.Message);
                }
            }

        void HitungTotalTugas()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tugas", conn);
                int total = (int)cmd.ExecuteScalar();
                lblTotalTugas.Text = "Total Tugas Tersedia: " + total.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTotalTugas_Click(object sender, EventArgs e)
        {

        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            LoadDataTugas();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtJudul_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTugas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTugas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTugas.Rows[e.RowIndex];
                txtIDTugas.Text = row.Cells["id_tugas"].Value.ToString();
                txtJudul.Text = row.Cells["judul"].Value.ToString();
                txtDeskripsi.Text = row.Cells["deskripsi"].Value.ToString();
                dtpDeadline.Value = Convert.ToDateTime(row.Cells["deadline"].Value);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                // COMMIT 14: VALIDASI INPUT
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
            cmd.Parameters.AddWithValue("@dosenId", 1); // Hardcode ID Dosen sementara

            cmd.ExecuteNonQuery();
            MessageBox.Show("Tugas berhasil disimpan!");

            LoadDataTugas();   // Refresh tabel
            HitungTotalTugas(); // Refresh statistik
            ClearForm();       // Kosongkan input
            conn.Close();
        }
    catch (Exception ex) {
        MessageBox.Show("Gagal simpan: " + ex.Message);
    }
        }
    }
}
