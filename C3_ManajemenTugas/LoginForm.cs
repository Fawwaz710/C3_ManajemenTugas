using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C3_ManajemenTugas
{
    public partial class LoginForm : Form
    {
        // Panggil class koneksi
        Koneksi kon = new Koneksi();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validasi input kosong
            if (string.IsNullOrEmpty(txtNama.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Nama dan Password harus diisi!");
                return;
            }

            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();

                    // KRITERIA UJIAN 3: DEMO SQL INJECTION
                    // Kode ini sengaja menggunakan penggabungan string (+) agar bisa didemokan saat ujian.
                    // Skenario: Masukkan ' OR '1'='1 pada kolom password untuk bypass.
                    string query = "SELECT * FROM users WHERE nama = '" + txtNama.Text + "' AND password = '" + txtPassword.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // 1. Simpan data user ke class UserSession agar dashboard tahu siapa yang masuk
                        UserSession.UserId = Convert.ToInt32(reader["user_id"]);
                        UserSession.Nama = reader["nama"].ToString();
                        UserSession.Role = reader["role"].ToString();

                        MessageBox.Show("Login Berhasil! Selamat Datang " + UserSession.Nama, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 2. Arahkan ke Halaman yang sesuai berdasarkan ROLE
                        if (UserSession.Role.ToLower() == "dosen")
                        {
                            DosenDashboardForm dosen = new DosenDashboardForm();
                            dosen.Show();
                        }
                        else if (UserSession.Role.ToLower() == "mahasiswa")
                        {
                            MahasiswaDashboardForm mhs = new MahasiswaDashboardForm();
                            mhs.Show();
                        }

                        // 3. Sembunyikan form login
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Error: " + ex.Message);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Pindah ke halaman Register
            RegisterForm reg = new RegisterForm();
            reg.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tugasDBDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.tugasDBDataSet.users);

        }
    }
}