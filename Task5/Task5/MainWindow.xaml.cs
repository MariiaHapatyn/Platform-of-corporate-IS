using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task3.UnitOfWork;
using Task5.DataTypes;

namespace Task5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaxiDriver currentDriver;
        public MainWindow()
        {
            InitializeComponent();
            Closing += endOfWork_Close;
            AddClientsInfo();
            //AddDriversInfo();
            //AddOrdersInfo();
            //using (DriverContext content = new DriverContext())
            //{
            //    content.Database.Delete();
            //}
        }
        private void AddClientsInfo()
        {
           
        }
        private void AddDriversInfo()
        {
            
        }
        private void AddOrdersInfo()
        {
            
        }

        public void updateOrders(TaxiOrder orderToUpdate)
        {
            
        }

        private void orders_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void startWork_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void updateDriverInfo()
        {
           
        }

        private void endOfWork_Click(object sender, RoutedEventArgs e)
        {
            updateDriverInfo();
            Close();
        }

        private void endOfWork_Close(object sender, CancelEventArgs e)
        {
            updateDriverInfo();
            MessageBox.Show(String.Format("Дякуюємо за роботу {0}!", currentDriver.Name), "Допобачення");
        }
    }
}
