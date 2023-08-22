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
    public partial class frmGelirİstatistikleri : Form
    {
        public frmGelirİstatistikleri()
        {
            InitializeComponent();
        }
        SqlConnectionString sqlString = new SqlConnectionString();
        private void frmGelirİstatistikleri_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select sum(OdemeMiktarı) from Kasa", sqlString.connection()); ;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblToplamPara.Text = reader[0].ToString() + "TL";
            }
            reader.Close();
            sqlString.connection().Close();

            SqlCommand command2 = new SqlCommand("Select distinct(OdemeAy) from Kasa", sqlString.connection());
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                cmbAy.Items.Add(reader2[0].ToString());
            }
            reader2.Close();
            sqlString.connection().Close();

            //Aylık Kazanç Manuel

            SqlCommand command3 = new SqlCommand("select OdemeAy, sum(OdemeMiktarı)from Kasa group by OdemeAy", sqlString.connection());
            SqlDataReader reader3=command3.ExecuteReader();
            while (reader3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(reader3[0], reader3[1]);
            }
            reader3.Close();
            sqlString.connection().Close();

        }

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select Sum(OdemeMiktarı) from Kasa where OdemeAy=@odemeay ", sqlString.connection());
            command.Parameters.AddWithValue("@odemeay", cmbAy.Text);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblAyPara.Text = reader[0].ToString();
            }
            reader.Close();
            sqlString.connection().Close();
        }

    }
}
