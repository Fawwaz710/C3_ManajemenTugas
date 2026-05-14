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
    public partial class LoginForm : Form
    {
        Koneksi kon = new Koneksi();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    // KRITERIA UJIAN: SQL INJECTION (Sengaja menggunakan string concatenation)
                    // Masukkan ' OR '1'='1 pada password untuk mendemokan bypass
                    string query = "SELECT * FROM users WHERE nama = @nama AND password = @password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Simpan data user ke session
                        UserSession.UserId = Convert.ToInt32(reader["user_id"]);
                        UserSession.Nama = reader["nama"].ToString();
                        UserSession.Role = reader["role"].ToString();

                        MessageBox.Show("Selamat Datang, " + UserSession.Nama);

                        // Pindah halaman sesuai ROLE
                        if (UserSession.Role == "dosen")
                        {
                            DosenDashboardForm dosen = new DosenDashboardForm();
                            dosen.Show();
                        }
                        else
                        {
                            MahasiswaDashboardForm mhs = new MahasiswaDashboardForm();
                            mhs.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password Salah!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void LoginForm_Load(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }

}

