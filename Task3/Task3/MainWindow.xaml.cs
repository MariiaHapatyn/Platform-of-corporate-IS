using System;
using System.Collections.Generic;
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
using Task3.DAO.DataTypes;
using Task3.DAO.IOTypes;
using Taxi_Driver_WPF.IOTypes;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Driver currentDriver;
        private ClientsDB clientsInfo;
        private DriversDB driversInfo;
        private OrdersDB ordersInfo;

        public MainWindow()
        {
            InitializeComponent();
            clientsInfo = new ClientsDB("../../DAO/InputData/ClientsData.txt");
            clientsInfo.ReadFromFile();

            driversInfo = new DriversDB("../../DAO/InputData/DriversData.txt");
            driversInfo.ReadFromFile();
        }
        private void startWork_Click(object sender, RoutedEventArgs e)
        {
            currentDriver = driversInfo.FindDriver(driverSurName.Text, driverUserName.Text);
            driverInfoSurnameNameDetails.Content = currentDriver.Surname + " " + currentDriver.Name;
            driverInfoAgeDetails.Content = currentDriver.Age;
            driverInfoCarDetails.Content = currentDriver.CarNumber;
            driverInfoExpDetails.Content = currentDriver.Experience;
            driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";
            driverInfoCostPerMinDetails.Content = currentDriver.CostPerMinute;

            ordersInfo = new OrdersDB("../../DAO/InputData/OrdersData.txt", clientsInfo, driversInfo);
            ordersInfo.ReadFromFile();
            ShowOrdersInListView();
        }
        private void endOfWork_Click(object sender, RoutedEventArgs e)
        {
            driversInfo.UpdateDriver(currentDriver);
            driversInfo.WriteToFile();
            ordersInfo.WriteToFile();
            MessageBox.Show(String.Format("Дякуюємо за роботу {0}!", currentDriver.Name), "Допобачення");
            Close();
        }
        private void orders_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                //OrderWindow wind = new OrderWindow(item as Order);
               // wind.Show();
            }
        }
        public void updateOrders(Order orderToUpdate)
        {
            ordersInfo.UpdateOrder(orderToUpdate);
            currentDriver.PayCheck += orderToUpdate.Cost;
            driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";
            ShowOrdersInListView();
        }
        private void ShowOrdersInListView()
        {
            orders.Items.Clear();
            foreach (Order order in ordersInfo.AllOrders)
            {
                if (order.Driver.Id == currentDriver.Id)
                {
                    orders.Items.Add(order);
                }
            }
        }
    }
}
