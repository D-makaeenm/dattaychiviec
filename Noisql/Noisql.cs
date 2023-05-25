using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noisql
{
    public class thuVien
    {
        SqlDataAdapter dataAdapter; // truy xuất dữ liệu vào bảng
        SqlCommand sqlCommand; // dùng để truy vấn và cập nhật CSDL

        public thuVien()
        {
        }

        public DataTable getAllSINHVIEN()
        {
            DataTable datatable = new DataTable();
            string query = "select * from SINHVIEN";
            using (SqlConnection sqlConnection = connection.getconnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(datatable);
                sqlConnection.Close();
            }
            return datatable;
        }
    }
}
