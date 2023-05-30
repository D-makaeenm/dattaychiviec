using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Bot_Telegram
{
    internal class timkiemDB
    {
        static string connect = "Server = DUYVPRO\\DUY; Database=BTL;Trusted_Connection=True;TrustServerCertificate=True;";
        //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
        public static string TimKiem(string q)
        {
            string kq = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(connect))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "sp_search";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@q", SqlDbType.NVarChar, 50).Value = "%" + q.Replace(' ', '%') + "%";
                        object obj = cm.ExecuteScalar(); //lấy col1 of row1
                        if (obj != null)
                            kq = (string)obj;
                        else
                            kq = "không có dữ liệu";
                    }
                }
            }
            catch (Exception ex)
            {
                kq += $"Error: {ex.Message}";
            }
            return kq;
        }
    }
}
