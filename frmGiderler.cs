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
    public partial class frmGiderler : Form
    {
        public frmGiderler()
        {
            InitializeComponent();
        }
        SqlConnectionString sqlString = new SqlConnectionString();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand command = new SqlCommand("insert into Giderler(Elektirik,Su,Dogalgaz,Net,Gida,Personel,Diger) values (@elektirik,@su,@dogalgaz,@net,@gida,@personel,@diger) ", sqlString.connection());
                command.Parameters.AddWithValue("@elektirik", txtElektirik.Text);
                command.Parameters.AddWithValue("@su", txtSu.Text);
                command.Parameters.AddWithValue("@dogalgaz", txtDogalgaz.Text);
                command.Parameters.AddWithValue("@net", txtİntarnet.Text);
                command.Parameters.AddWithValue("@gida", txtGida.Text);
                command.Parameters.AddWithValue("@personel", txtPersonel.Text);
                command.Parameters.AddWithValue("@diger", txtDiger.Text);
                command.ExecuteNonQuery();
                sqlString.connection().Close();
                MessageBox.Show("Kayıtlar girildi");

            }
            catch (Exception)
            {

               MessageBox.Show("Hata oluştu tekrar deneyiniz");
            }
        }

        private void frmGiderler_Load(object sender, EventArgs e)
        {

        }
    }
}
