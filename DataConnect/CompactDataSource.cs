using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Configuration;
namespace DataConnect
{
    public static class CompactDataSource
    {
        public static SqlCeConnection EstablishConnection() 
        {
            string connection = ConfigurationManager.ConnectionStrings["MyGroceryList.Properties.Settings.GroceryDBConnectionString"].ToString();
            SqlCeConnection conn = null; 
            try 
            {
                conn = new SqlCeConnection(connection);
                conn.Open();
            }
            catch(Exception ex)
            {
                //TODO handle Exception
            }
            return conn;
        }

    }
}
