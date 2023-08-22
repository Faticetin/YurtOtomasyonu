using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayıtOtomasyonu
{
    public partial class frmGiderListesi : Form
    {
        public frmGiderListesi()
        {
            InitializeComponent();
        }

        private void frmGiderListesi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDBDataSet4.Giderler' table. You can move, or remove it, as needed.
            this.giderlerTableAdapter.Fill(this.yurtOtomasyonuDBDataSet4.Giderler);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            frmGiderGüncelleme frm = new frmGiderGüncelleme();
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            frm.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            frm.elektirik = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            frm.su = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            frm.dogalgaz = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            frm.net = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            frm.gida = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            frm.personel = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            frm.diger = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
