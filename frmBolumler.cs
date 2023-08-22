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
    public partial class frmBolumler : Form
    {
        public frmBolumler()
        {
            InitializeComponent();
        }
       SqlConnectionString sqlString = new SqlConnectionString();
        private void frmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDBDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDBDataSet.Bolumler);

        }

        private void pcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("insert into Bolumler (BolumAd) values (@bolumad)", sqlString.connection());
                command.Parameters.AddWithValue("@bolumad", txtBolumAdı.Text);
                command.ExecuteNonQuery();
                sqlString.connection().Close();
                MessageBox.Show("Bölüm Eklendi");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDBDataSet.Bolumler);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!! Yeniden Deneyiniz" + ex);
            }
        }

        private void pcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("delete from Bolumler where Id=@id", sqlString.connection());
                command.Parameters.AddWithValue("@id", txtBolumId.Text);
                command.ExecuteNonQuery();
                sqlString.connection().Close();
                MessageBox.Show("Silme İşlemi Gerçekleştirildi");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDBDataSet.Bolumler);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata!! Yeniden Deneyiniz" + ex);
            }
        }

        int secilen;
        private void dgwBolumler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dgwBolumler.SelectedCells[0].RowIndex;
            id = dgwBolumler.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dgwBolumler.Rows[secilen].Cells[1].Value.ToString();

            txtBolumAdı.Text = bolumad;
            txtBolumId.Text = id;
        }

        private void pcbBolumDüzenle_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand command = new SqlCommand("update Bolumler set BolumAd=@bolumad where Id=@id", sqlString.connection());
                command.Parameters.AddWithValue("@bolumad", txtBolumAdı.Text);
                command.Parameters.AddWithValue("@id", txtBolumId.Text);
                command.ExecuteNonQuery();
                sqlString.connection().Close();
                MessageBox.Show("Güncelleme Başarıyla Gerçekleştirildi");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDBDataSet.Bolumler);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu Tekrar Deneyiniz!!!!" + ex);
            }

        }
    }
}
