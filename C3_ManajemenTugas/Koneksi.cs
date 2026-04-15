using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace C3_ManajemenTugas
{
    internal class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=KAIDEN\\BLAZE;Initial Catalog=TugasDB;Integrated Security=True";

            return conn;
        }
    }
}
