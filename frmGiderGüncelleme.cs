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
    public partial class frmGiderGüncelleme : Form
    {
        public frmGiderGüncelleme()
        {
            InitializeComponent();
        }
        public string elektirik, su, dogalgaz, net, gida, personel, diger,id;
        SqlConnectionString sqlString = new SqlConnectionString();
        private void btnGüncelle_Click_1(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update Giderler set Elektirik=@elektirik,Su=@su,Dogalgaz=@dogalgaz,Net=@net,Gida=@gida,Personel=@personel,Diger=@diger where Id=@id",sqlString.connection());
            command.Parameters.AddWithValue("@id", txtId.Text);
            command.Parameters.AddWithValue("@elektirik", txtElektirik.Text);
            command.Parameters.AddWithValue("@su", txtSu.Text);
            command.Parameters.AddWithValue("@dogalgaz", txtDogalgaz.Text);
            command.Parameters.AddWithValue("@net", txtİntarnet.Text);
            command.Parameters.AddWithValue("@gida", txtGida.Text);
            command.Parameters.AddWithValue("@personel", txtPersonel.Text);
            command.Parameters.AddWithValue("@diger", txtDiger.Text);
            command.ExecuteNonQuery();
            sqlString.connection().Close();
        }

        private void frmGiderGüncelleme_Load(object sender, EventArgs e)
        {
            txtId.Text = id; ;
            txtElektirik.Text = elektirik;
            txtSu.Text = su;
            txtDogalgaz.Text = dogalgaz;
            txtGida.Text = gida;
            txtPersonel.Text = personel;
            txtİntarnet.Text = net;
            txtDiger.Text = diger;
        }
    }
}
