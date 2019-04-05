using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace WebApplication4.DAL
{
    public class DBConnect
    {
        public class Dbconnect
        {
              static protected SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CT7CLQD\SQLEXPRESS;Initial Catalog=WebTinTuc;Integrated Security=True");
            public static void openConnect()
            {
                if (con != null && con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            public static void closeConnect()
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}