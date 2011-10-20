using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSetCommon;
using System.Data;
using System.Data.SqlServerCe;

namespace DataConnect
{
    public class GroceryManager
    {
        public List<GroceryList> GetAllGroceryLists() 
        {
            List<GroceryList> groceryList = new List<GroceryList>();
            using (SqlCeConnection Con = CompactDataSource.EstablishConnection())
            {
                using (SqlCeCommand Cmd = Con.CreateCommand())
                {
                    string sql = "SELECT * FROM GroceryList";
                    Cmd.CommandText = sql;
                    SqlCeDataReader rdr = Cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        groceryList.Add(new GroceryList(Convert.ToString(rdr["GroceryListName"]),
                                                            Convert.ToDateTime(rdr["GroceryListDate"]))
                                                            );

                    }

                }
            }
            return groceryList;
        }

        public void AddNewGroceryList(GroceryList GroceryList) 
        {
            using (SqlCeConnection Con = CompactDataSource.EstablishConnection()) 
            {
                using (SqlCeCommand Cmd = Con.CreateCommand()) 
                {
                    Cmd.CommandText = "INSERT INTO GroceryList(GroceryListName, GroceryListDate) VALUES (@Name,@Date) ";
                    Cmd.Parameters.AddWithValue("@Name", GroceryList.GroceryListName);
                    Cmd.Parameters.AddWithValue("@Date", GroceryList.GroceryListDate);
                    Cmd.ExecuteScalar();
                }
            }
        }
    }


}
