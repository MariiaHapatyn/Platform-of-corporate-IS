using System;
using System.Collections.Generic;
using System.IO;
using Task3.DAO.DataTypes;

namespace Taxi_Driver_WPF.IOTypes
{
    public class DriversDB
    {
        private string fileName;
        private List<Driver> allDrivers;
        public List<Driver> AllDrivers
        {
            get
            {
                return allDrivers;
            }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("DriversDB is empty");
                }
                allDrivers = value;
            }
        }
        public DriversDB(string _fileName)
        {
            allDrivers = new List<Driver>();
            fileName = _fileName;
        }

        public void ReadFromFile()
        {
            string[] allLines = File.ReadAllLines(fileName);
            foreach (string line in allLines)
            {
                string[] lineElems = line.Split(' ');
                allDrivers.Add(new Driver(Convert.ToUInt32(lineElems[0]), lineElems[1], lineElems[2], Convert.ToUInt32(lineElems[3]), lineElems[4], Convert.ToUInt32(lineElems[5]), Convert.ToUInt32(lineElems[6]), Convert.ToDouble(lineElems[7])));
            }
        }
        public void UpdateDriver(Driver driverToUpdate)
        {
            for (int i = 0; i < allDrivers.Count; ++i)
            {
                if (allDrivers[i].Id == driverToUpdate.Id)
                {
                    allDrivers[i] = driverToUpdate;
                    break;
                }
            }
        }
        public void WriteToFile()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Driver driver in allDrivers)
                {
                    writer.WriteLine(driver);
                }
            }
        }

        public Driver FindDriver(string surname, string name)
        {
            Driver searchResult = new Driver();
            foreach (Driver driver in allDrivers)
            {
                if (driver.Surname == surname && driver.Name == name)
                {
                    searchResult = driver;
                    break;
                }
            }
            return searchResult;
        }

        public Driver GetDriverById(uint driverId)
        {
            Driver searchResult = new Driver();
            foreach (Driver driver in allDrivers)
            {
                if (driver.Id == driverId)
                {
                    searchResult = driver;
                    break;
                }
            }
            return searchResult;
        }
    }
}