using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.DAO.IOTypes;

namespace Taxi_Tests
{
	[TestClass]
	public class TaxiClientsDBTests
	{
		[TestMethod]
		public void Test_ReadingFromFile()
		{
			ClientsDB clientsInfo = new ClientsDB("../../ClientsData.txt");
			clientsInfo.ReadFromFile();
			Assert.AreEqual(clientsInfo.AllClients.Count, 5);
		}

		[TestMethod]
		public void Test_GetClientById()
		{
			ClientsDB clientsInfo = new ClientsDB("../../ClientsData.txt");
			clientsInfo.ReadFromFile();
			Assert.AreEqual(clientsInfo.GetClientById(1).Id, Convert.ToUInt32(1));
		}
	}
}
