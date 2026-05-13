using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C3_ManajemenTugas
{
    public partial class MahasiswaDashboardForm : Form
    {
        public MahasiswaDashboardForm()
        {
            InitializeComponent();
        }

        private void MahasiswaDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Pilih File Tugas";
            openFileDialog1.Filter = "ZIP Files (*.zip)|*.zip|PDF Files (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
