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
    public partial class frmOgrKayıt : Form
    {
        public frmOgrKayıt()
        {
            InitializeComponent();
        }
        SqlConnectionString sqlString = new SqlConnectionString();

        private void frmOgrKayıt_Load(object sender, EventArgs e)
        {

            //Bölümleri Listeleme Komudu


            SqlCommand command1 = new SqlCommand("select BolumAd from Bolumler", sqlString.connection());
            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                cmbBolumler.Items.Add(reader1[0].ToString());
            }
            sqlString.connection().Close();

            //Odaları Listeleme Komudu


            SqlCommand command2 = new SqlCommand("select OdaNo from Odalar where OdaKapasitesi != OdaAktif ", sqlString.connection());
            SqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                cmbOgrOdaNo.Items.Add(reader2[0].ToString());
            }
            sqlString.connection().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand command = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,OgrTc,OgrTelefon,OgrDogumTarihi,OgrBolum,OgrMail,OgrOda,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values (@ograd,@ogrsoyad,@ogrtc,@ogrtelefon,@ogrdogum,@ogrbolum,@ogrmail,@ogroda,@ogrveliadsoyad,@ogrvelitelefon,@ogrveliadres)", sqlString.connection());

                command.Parameters.Add("@ograd", txtOgrAd.Text);
                command.Parameters.Add("@ogrsoyad", txtOgrSoyad.Text);
                command.Parameters.Add("@ogrtc", mskOgrTc.Text);
                command.Parameters.Add("@ogrtelefon", mskOgrTelefon.Text);
                command.Parameters.Add("@ogrdogum", mskOgrDogumTarihi.Text);
                command.Parameters.Add("@ogrbolum", cmbBolumler.Text);
                command.Parameters.Add("@ogrmail", txtMail.Text);
                command.Parameters.Add("@ogroda", cmbOgrOdaNo.Text);
                command.Parameters.Add("@ogrveliadsoyad", txtVeliAdSoyad.Text);
                command.Parameters.Add("@ogrvelitelefon", mskVeliTelefon.Text);
                command.Parameters.Add("@ogrveliadres", rchAdres.Text);

                command.ExecuteNonQuery();
                sqlString.connection().Close();

                //öğrenci id alanı
                SqlCommand command3 = new SqlCommand("select Id from Ogrenci", sqlString.connection());
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    label12.Text = reader[0].ToString();
                }
                reader.Close();
                sqlString.connection().Close();

                //öğrenci borç alanı
                SqlCommand command2 = new SqlCommand("insert into Borclar (OgrId,OgrAd,OgrSoyad) values (@ogrıd,@ograd,@ogrsoyad)", sqlString.connection());
                command2.Parameters.AddWithValue("@ogrıd", label12.Text);
                command2.Parameters.AddWithValue("@ograd", txtOgrAd.Text);
                command2.Parameters.AddWithValue("@ogrsoyad", txtOgrSoyad.Text);
                command2.ExecuteNonQuery();
                sqlString.connection().Close();

                MessageBox.Show("Başarıyla Kaydedildi");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hatalı kayıt. Yeniden Deneyiniz" + ex);
            }
            //Öğrenci oda kontenjanı artırma 

            SqlCommand command4 = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@odano", sqlString.connection());
            command4.Parameters.AddWithValue("@odano", cmbOgrOdaNo.Text);
            command4.ExecuteNonQuery();
            sqlString.connection().Close();


        }
    }
}
