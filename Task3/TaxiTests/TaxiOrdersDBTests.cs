using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.DAO.IOTypes;
using Task3.DAO.DataTypes;
using System.Collections.Generic;

namespace Taxi_Tests
{
	[TestClass]
	public class TaxiOrdersDBTests
	{
		[TestMethod]
		public void Test_ReadingFromFile()
		{
			ClientsDB clientsInfo = new ClientsDB("../../Clients.txt");
			clientsInfo.ReadFromFile();
			DriversDB driversInfo = new DriversDB("../../Drivers.txt");
			driversInfo.ReadFromFile();
			OrdersDB ordersInfo = new OrdersDB("../../Orders.txt", clientsInfo, driversInfo);
			ordersInfo.ReadFromFile();
			Assert.AreEqual(ordersInfo.AllOrders.Count, 8);
		}
	}
}
