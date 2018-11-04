using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.DAO.DataTypes;

namespace Taxi_Tests
{
	[TestClass]
	public class TaxiClientTests
	{
		[TestMethod]
		public void Test_TaxiClientConstructorAndProperties()
		{
			Client client = new Client(1, "Марія", "+380966784576");
			Assert.AreEqual(client.Name, "Марія");
			Assert.AreEqual(client.PhoneNumber, "+380966784576");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Test_TaxiClientPopertiesException()
		{
			Client client = new Client(1, "Марія", "+380966784576");
			//not valid phone number
			client.PhoneNumber = "+380966784576000";
		}
	}
}
