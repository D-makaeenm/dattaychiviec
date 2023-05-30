using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bot_Telegram
{
    internal class timkiemdonhang
    {
        string chuoi_connection = @"Data Source=DuyVPro;Initial Catalog=BTL;Integrated Security=True;Trust Server Certificate=True";
        public string timdonhang(string tim)
        {
            string query = "timkiemdonhang";
            string kq = "";
            using(SqlConnection con = new SqlConnection(chuoi_connection))
            {

                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@[Mã khách hàng]", System.Data.SqlDbType.NVarChar, 20).Value = tim;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        object kqreturn = cmd.ExecuteScalar();
                        kq = (string)kqreturn;
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tìm kiếm đơn hàng " + ex.Message);
                }
                return kq;
            }
        }
    }
}
