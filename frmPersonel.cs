using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayıtOtomasyonu
{
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
        }
        SqlConnectionString sqlString = new SqlConnectionString();
        private void Personel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDBDataSet6.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDBDataSet6.Personel);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman) values (@personeladsoyad,@personeldepartmn)", sqlString.connection());
            command.Parameters.AddWithValue("@personeladsoyad", txtAd.Text);
            command.Parameters.AddWithValue("@personeldepartmn", txtGorev.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();
            MessageBox.Show("Kayıt başarıyla gerçekleştirildi");
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDBDataSet6.Personel);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("delete from Personel where Id=@id", sqlString.connection());
            command.Parameters.AddWithValue("@id", txtId.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();
            MessageBox.Show("Kayıt başarıyla silindi");
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDBDataSet6.Personel);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, gorev, Id;
            Id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            gorev = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            txtId.Text = Id;
            txtAd.Text = ad;
            txtGorev.Text = gorev;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update Personel set PersonelAdSoyad=@personeladsoyad, PersonelDepartman=@personeldepartman where Id=@id", sqlString.connection());
            command.Parameters.AddWithValue("@personeladsoyad", txtAd.Text);
            command.Parameters.AddWithValue("@personeldepartman", txtGorev.Text);
            command.Parameters.AddWithValue("@id", txtId.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();

            MessageBox.Show("Başarılı bir şekilde güncellendi");
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDBDataSet6.Personel);
        }
    }
}
