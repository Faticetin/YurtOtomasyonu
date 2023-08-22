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
    public partial class frmOgrDuzenle : Form
    {
        public frmOgrDuzenle()
        {
            InitializeComponent();
        }

        SqlConnectionString sqlString = new SqlConnectionString();
        public string id, ad, soyad, tc, telefon, dogumTarihi, bolum, mail, odaNo, veliAdSoyad, veliTelefon, adres;

        private void button1_Click(object sender, EventArgs e)
        {
            //Öğrenci Silme
            SqlCommand command = new SqlCommand("delete from Ogrenci where Id=@id",sqlString.connection());
            command.Parameters.AddWithValue("@id", txtId.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();
            MessageBox.Show("Başarıyla silindi");

            //Oda Kayıt Arttırma 
            SqlCommand command2 = new SqlCommand("update odalar set OdaAktif=OdaAktif-1 where OdaNo=@odano", sqlString.connection());
            command2.Parameters.AddWithValue("@odano",cmbOgrOdaNo.Text);
            command2.ExecuteNonQuery();
            sqlString.connection().Close(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand command = new SqlCommand("update Ogrenci set OgrAd=@ograd,OgrSoyad=@ogrsoyad,OgrTc=@ogrtc,OgrTelefon=@ogrtelefon,OgrDogumTarihi=@ogrdogumtarihi,OgrBolum=@ogrbolum,OgrMail=@ogrmail,OgrOda=@ogroda,OgrVeliAdSoyad=@ogrveliad,OgrVeliTelefon=@ogrvelitelefon,OgrVeliAdres=@ogrveliadres where Id=@id", sqlString.connection());
                command.Parameters.AddWithValue("@id", txtId.Text);
                command.Parameters.AddWithValue("@ograd", txtOgrAd.Text);
                command.Parameters.AddWithValue("@ogrsoyad", txtOgrSoyad.Text);
                command.Parameters.AddWithValue("@ogrtc", mskOgrTc.Text);
                command.Parameters.AddWithValue("@ogrtelefon", mskOgrTelefon.Text);
                command.Parameters.AddWithValue("@ogrdogumtarihi", mskOgrDogumTarihi.Text);
                command.Parameters.AddWithValue("@ogrbolum", cmbBolumler.Text);
                command.Parameters.AddWithValue("@ogrmail", txtMail.Text);
                command.Parameters.AddWithValue("@ogroda", cmbOgrOdaNo.Text);
                command.Parameters.AddWithValue("@ogrveliad", txtVeliAdSoyad.Text);
                command.Parameters.AddWithValue("@ogrvelitelefon", mskVeliTelefon.Text);
                command.Parameters.AddWithValue("@ogrveliadres", rchAdres.Text);
                command.ExecuteNonQuery();
                sqlString.connection().Close();

                MessageBox.Show("Güncelleme başarılıyla gerçekleştirildi");
            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme Başarısız");
            }


        }

        private void frmOgrDuzenle_Load(object sender, EventArgs e)
        {
            txtId.Text = id;
            txtOgrAd.Text = ad;
            txtOgrSoyad.Text = soyad;
            mskOgrTc.Text = tc;
            mskOgrTelefon.Text = telefon;
            mskOgrDogumTarihi.Text = dogumTarihi;
            cmbBolumler.Text = bolum;
            txtMail.Text = mail;
            cmbOgrOdaNo.Text = odaNo;
            txtVeliAdSoyad.Text = veliAdSoyad;
            mskVeliTelefon.Text = veliTelefon;
            rchAdres.Text = adres;
        }
    }
}
