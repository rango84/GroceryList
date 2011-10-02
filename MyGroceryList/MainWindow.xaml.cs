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
        public MainWindow()
        {
            InitializeComponent();
            Loaded += InitOnLoad;
            m_Manager = new GroceryManager();
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
    }
}
