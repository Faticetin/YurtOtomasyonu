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
    public partial class frmAdminGiris : Form
    {
        public frmAdminGiris()
        {
            InitializeComponent();
        }
        SqlConnectionString sqlString = new SqlConnectionString();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Admin where YoneticiAd=@yoneticiad and YoneticiSifre=@yoneticisifre", sqlString.connection());
            command.Parameters.AddWithValue("@yonetiad",txtAd.Text);
            command.Parameters.AddWithValue("@yoneticisifre",txtSifre.Text);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read()) 
            {
                frmAna frm = new frmAna();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış şifre veya kullanıcı adı ");
                txtAd.Clear();
                txtSifre.Clear();
                txtAd.Focus();
            }
            sqlString.connection().Close();
        }
    }
}
