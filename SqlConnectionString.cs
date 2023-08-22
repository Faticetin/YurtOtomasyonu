using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YurtKayıtOtomasyonu
{
    internal class SqlConnectionString
    {
        public SqlConnection connection() 
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RH6TJ0Q\\SQLEXPRESS;Initial Catalog=YurtOtomasyonuDB;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
