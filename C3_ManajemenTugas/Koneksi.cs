using System;
using System.Data.SqlClient;

namespace C3_ManajemenTugas
{
    class Koneksi
    {
        public SqlConnection GetConn()
        {
            // Ganti NAMA_SERVER_ANDA dengan nama server SQL Anda (misal: DESKTOP-123\SQLEXPRESS)
            SqlConnection conn = new SqlConnection(@"Data Source=KAIDEN\BLAZE;Initial Catalog=TugasDB;Integrated Security=True");
            return conn;
        }
    }
}