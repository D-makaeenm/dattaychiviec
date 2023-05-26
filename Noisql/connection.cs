using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BTL
{
    public class connection
    {
        private static string stringconnection = @"Data Source=DuyVPro;Initial Catalog=BTL;Persist Security Info=True;User ID=sa";


        public static SqlConnection getconnection()
        {
            return new SqlConnection(stringconnection);
        }
    }

}