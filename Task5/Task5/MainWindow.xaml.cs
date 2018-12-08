using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
                var andriy = new TaxiDriver("Dubyk", "Andriy", 12, "BC3456AM1", 3, 23, 50);

                cont.Drivers.Add(olya);
                cont.Drivers.Add(andriana);
                cont.Drivers.Add(maria);
                cont.Drivers.Add(andriy);

                cont.SaveChanges();
            }
        }

        private void AddOrdersInfo()
        {
            using (var cont = new DriverContext())
            {
                var maria = (from elem in cont.Clients where elem.ClientId == 1 select elem).First();
                var olya = (from elem in cont.Clients where elem.ClientId == 2 select elem).First();
                var natalia = (from elem in cont.Clients where elem.ClientId == 5 select elem).First();

                var olyaDriver = (from elem in cont.Drivers where elem.DriverId == 1 select elem).First();
                var andrianaDriver = (from elem in cont.Drivers where elem.DriverId == 2 select elem).First();

                cont.Orders.Add(new TaxiOrder(olya, olyaDriver, Convert.ToDateTime("2017-12-07 18:00"), "Університетська,1", "Федьковича,60", 19, 15, true));
                cont.Orders.Add(new TaxiOrder(maria, olyaDriver, Convert.ToDateTime("2017-12-07 19:00"), "Наукова,7А", "Стрийська,89", 0, 0, false));
                cont.Orders.Add(new TaxiOrder(natalia, olyaDriver, Convert.ToDateTime("2017-12-07 15:00"), "Пасічна,70", "Сихівська,34", 0, 0, false));
                cont.Orders.Add(new TaxiOrder(maria, andrianaDriver, Convert.ToDateTime("2017-12-07 14:00"), "Пасічна,23", "Галицька,30", 0, 0, false));
                cont.Orders.Add(new TaxiOrder(natalia, andrianaDriver, Convert.ToDateTime("2017-12-07 18:00"), "Університетська,1", "Вашингтона,12", 0, 0, false));
                cont.SaveChanges();
            }
        }

        public void updateOrders(TaxiOrder orderToUpdate)
        {
            using (UnitOfWork.UnitOfWork content = new UnitOfWork.UnitOfWork())
            {
                //UpdateOrderInfoINDB
                content.Orders.Update(orderToUpdate);
                content.Save();
                currentDriver.PayCheck += orderToUpdate.Cost;
                driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";

                //ShowOrdersInListView //Eager Loading
                var currentOrders = content.Orders.Get(s => s.Driver.DriverId == currentDriver.DriverId, includeProperties: "Client");
                orders.Items.Clear();
                foreach (var order in currentOrders)
                {
                    orders.Items.Add(order);
                }
            }
        }

        private void orders_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                OrderWindow wind = new OrderWindow(item as TaxiOrder);
                wind.Show();
            }
        }

        private void startWork_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork.UnitOfWork content = new UnitOfWork.UnitOfWork())
            {
                currentDriver = content.Drivers.Get(s => s.Name == driverUserName.Text).FirstOrDefault();
                driverInfoSurnameNameDetails.Content = currentDriver.Surname + " " + currentDriver.Name;
                driverInfoAgeDetails.Content = currentDriver.Age;
                driverInfoCarDetails.Content = currentDriver.CarNumber;
                driverInfoExpDetails.Content = currentDriver.Experience;
                driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";
                driverInfoCostPerMinDetails.Content = currentDriver.CostPerMinute;

                var currentOrders = content.Orders.Get(s => s.Driver.DriverId == currentDriver.DriverId, includeProperties: "Client");

                orders.Items.Clear();
                foreach (var order in currentOrders)
                {
                    orders.Items.Add(order);
                }
            }
        }

        private void updateDriverInfo()
        {
            using (UnitOfWork.UnitOfWork content = new UnitOfWork.UnitOfWork())
            {
                if (currentDriver != null)
                {
                    content.Drivers.Update(currentDriver);
                    content.Save();
                }
            }
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
