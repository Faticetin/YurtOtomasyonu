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
    public partial class frmOdemeler : Form
    {
        public frmOdemeler()
        {
            InitializeComponent();
        }
        SqlConnectionString sqlString = new SqlConnectionString();
        private void frmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDBDataSet2.Borclar' table. You can move, or remove it, as needed.
            this.borclarTableAdapter.Fill(this.yurtOtomasyonuDBDataSet2.Borclar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            txtId.Text = id;
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            txtBorc.Text = kalan;
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            //Ödenen tutarı kalan tutdan düşme
            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt32(txtOdenen.Text);
            kalan = Convert.ToInt32(txtBorc.Text);
            yeniborc = kalan - odenen;
            txtBorc.Text = yeniborc.ToString();

            //Yeni tutarı veri tabanına kaydet
            SqlCommand command = new SqlCommand("update Borclar set OgrKalanBorc=@ogrKalanBorc where OgrId=@id", sqlString.connection());
            command.Parameters.AddWithValue("@id", txtId.Text);
            command.Parameters.AddWithValue("@ogrKalanBorc", txtBorc.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();
            MessageBox.Show("Borç Ödendi");
            this.borclarTableAdapter.Fill(this.yurtOtomasyonuDBDataSet2.Borclar);


            //Kasa tablosuna ekleme
            SqlCommand command2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktarı) values (@odemeay,@odememiktar)",sqlString.connection());
            command2.Parameters.AddWithValue("@odemeay", txtOdenenAy.Text);
            command2.Parameters.AddWithValue("@odememiktar", txtOdenen.Text);
            command2.ExecuteNonQuery();
            sqlString.connection().Close();
        }
    }
}
