using System;
using System.Collections.Generic;
using System.IO;
using Task3.DAO.DataTypes;




namespace Task3.DAO.IOTypes
{
    public class ClientsDB
    {
        private readonly string fileName;
        private List<Client> allClients;
        public List<Client> AllClients
        {
            get
            {
                return allClients;
            }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("ClientsDB is empty");
                }
                allClients = value;
            }
        }
        public ClientsDB(string _fileName)
        {
            allClients = new List<Client>();
            fileName = _fileName;
        }

        public void ReadFromFile()
        {
            string[] allLines = File.ReadAllLines(fileName);
            foreach (string line in allLines)
            {
                string[] lineElems = line.Split(' ');
                allClients.Add(new Client(Convert.ToUInt32(lineElems[0]), lineElems[1], lineElems[2]));
            }
        }

        public void WriteToFile()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Client client in allClients)
                {
                    writer.WriteLine(client);
                }
            }
        }

        public Client GetClientById(uint clientId)
        {
            Client searchResult = new Client();
            foreach (Client client in allClients)
            {
                if (client.Id == clientId)
                {
                    searchResult = client;
                    break;
                }
            }
            return searchResult;
        }
    }
}
