using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlServerCe;
using DataConnect;
using DataSetCommon;

namespace MyGroceryList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GroceryManager m_Manager;
        private delegate void UpdateInfo(object sender, RoutedEventArgs e);
        private UpdateInfo m_UpdateInfo;
        public MainWindow()
        {
            m_UpdateInfo += new UpdateInfo(InitOnLoad);
            InitializeComponent();
            Loaded += InitOnLoad;
            m_Manager = new GroceryManager();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void InitOnLoad(object sender, RoutedEventArgs e)
        {
            groceryList.ItemsSource=m_Manager.GetAllGroceryLists();
        }

        private void ApplicationClose(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNewGroceryList_Click(object sender, RoutedEventArgs e)
        {
            AddGroceryList newList = new AddGroceryList();
            string newListName = String.Empty;
            if ((bool)newList.ShowDialog()) 
            {
                newListName = newList.txtGroceryListName.Text;
                GroceryList newGroceryList = new GroceryList(newListName, DateTime.Now);
                m_Manager.AddNewGroceryList(newGroceryList);
                m_UpdateInfo.Invoke(this, e);
            }
        }

        private void btnViewList_Click(object sender, RoutedEventArgs e)
        {
            if (groceryList.SelectedItem == null)
                return;
            GroceryList selectedList = groceryList.SelectedItem as GroceryList;
            if (selectedList == null)
                return;
            try 
            {
                GroceryListView groceryListView = new GroceryListView();
                groceryListView.ShowDialog();
            }
            catch 
            {

            }

        }
    }
}
