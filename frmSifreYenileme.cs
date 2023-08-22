using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayıtOtomasyonu
{
    public partial class frmSifreYenileme : Form
    {
        public frmSifreYenileme()
        {
            InitializeComponent();
        }
        SqlConnectionString sqlString = new SqlConnectionString();
        private void frmSifreYenileme_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDBDataSet5.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDBDataSet5.Admin);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Admin (YoneticiAd,YoneticiSifre)values(@yöneticiad,@yöneticisifre)", sqlString.connection());
            command.Parameters.AddWithValue("@yöneticiad", txtAd.Text);
            command.Parameters.AddWithValue("@yöneticisifre", txtSifre.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();
            MessageBox.Show("Yönetici Eklendi");
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDBDataSet5.Admin);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, sifre, Id;
            Id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            txtAd.Text = ad;
            txtSifre.Text = sifre;
            txtId.Text = Id;

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("delete from Admin where Id=@id", sqlString.connection());
            command.Parameters.AddWithValue("@id", txtId.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();
            MessageBox.Show("Yönetici Silindi");
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDBDataSet5.Admin);
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update Admin set YoneticiAd=@ad,YoneticiSifre=@sifre where Id=id ",sqlString.connection());
            command.Parameters.AddWithValue("@ad",txtAd.Text);
            command.Parameters.AddWithValue("@sifre",txtSifre.Text);
            command.Parameters.AddWithValue("@id",txtSifre.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();
            MessageBox.Show("Başarıyla Güncellendi");
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDBDataSet5.Admin);
        }
    }
}
