using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetCommon
{
    public class GroceryList
    {
        string m_GroceryListName;
        DateTime m_GroderyListDate;

        
        public GroceryList(string name, DateTime date) 
        {
            m_GroceryListName = name;
            m_GroderyListDate = date;
        }
        
        public string GroceryListName { get { return m_GroceryListName; } set { m_GroceryListName = value; } }
        public DateTime GroceryListDate { get { return m_GroderyListDate; } set { m_GroderyListDate = value; } }
        public string FormattedListDate { get { return m_GroderyListDate.ToString("yyyy-MM-dd"); } }
    }
}
