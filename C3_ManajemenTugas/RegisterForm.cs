using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C3_ManajemenTugas
{
    // Pastikan nama Class di sini adalah RegisterForm
    public partial class RegisterForm : Form
    {
        Koneksi kon = new Koneksi();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {

        }

        private void linkLogin_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void btnDaftar_Click_1(object sender, EventArgs e)
        {
            // Validasi sederhana
            if (txtNama.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || cmbRole.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi!");
                return;
            }

            try
            {
                using (SqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    // Query untuk memasukkan user baru
                    string query = "INSERT INTO users (nama, email, password, role) VALUES (@nama, @email, @pass, @role)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@role", cmbRole.Text); // Pastikan isi ComboBox: 'dosen' atau 'mahasiswa'

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registrasi Berhasil! Silakan Login.");

                    // Kembali ke Login
                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Daftar: " + ex.Message);
            }
        }
    }
}