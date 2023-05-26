using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BTL;

namespace Noisql
{
    internal class thuvien
    {
        SqlDataAdapter dataAdapter; 
        SqlCommand sqlCommand;
        //public thuvien()
        //{
        //}
        public DataTable getallData()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from HDX";
            using (SqlConnection sqlConnection = connection.getconnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
    }
}
