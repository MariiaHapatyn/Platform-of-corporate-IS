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
            AddDriversInfo();
            //AddOrdersInfo();
            //using (DriverContext content = new DriverContext())
            //{
            //    content.Database.Delete();
            //}
        }
        private void AddClientsInfo()
        {
            using (var cont = new DriverContext())
            {
                var maria = new TaxiClient("Maria", "+380639786514");
                var olya = new TaxiClient("Olya", "+380739706543");
                var andriy = new TaxiClient("Andriy", "+380966785432");
                var andriana = new TaxiClient("Andriana", "+380967689854");
                var natalia = new TaxiClient("Natalia", "+380960807654");

                cont.Clients.Add(maria);
                cont.Clients.Add(olya);
                cont.Clients.Add(andriy);
                cont.Clients.Add(andriana);
                cont.Clients.Add(natalia);
                cont.SaveChanges();
            }
        }

        private void AddDriversInfo()
        {
            using (var cont = new DriverContext())
            {
                var olya = new TaxiDriver("Pastushchak", "Olha", 19, "BC1567AC", 5, 50, 29);
                var andriana = new TaxiDriver("Shcherbak", "Andriana", 19, "BC7898BM", 3, 75, 0);
                var maria = new TaxiDriver("Maria", "Hapatyn", 20, "BC8765", 3, 23, 0);
                var andriy = new TaxiDriver("Dubyk", "Andriyko", 12, "BC3456AM1", 3, 23, 50);

                cont.Drivers.Add(olya);
                cont.Drivers.Add(andriana);
                cont.Drivers.Add(maria);
                cont.Drivers.Add(andriy);

                cont.SaveChanges();
            }
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
