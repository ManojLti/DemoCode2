using Azure.Messaging.ServiceBus;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using DemoCode.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoCode.Services
{
    public class SBService
    {
        IConfiguration _iconfiguration;
        public SBService()
        {

        }
        public SBService(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=demostorageaccount009;AccountKey=sDfs1XxBaVUlMEn5/Ke8j08LfE7msCOyE0LbAeop4myR7kKinQpMtaYUF/CJXXfSuC3CFkLG0zaNynM2ajMKiA==;EndpointSuffix=core.windows.net";
 
        string QueueName = "clientqueue";


       public bool  ValidateEmail(String Email)
        {
            bool isEmail = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                return false;
            }
            return true;

        }
        public bool ValidatePhone(String phone)
        {
            if (phone.Length == 10)
                return true;
            return false;
        }
        public int AddEmployee(EmployeeEntity emp)
        {
            if(!ValidateEmail(emp.Email))
            {
                return 0;
            }
            if (!ValidatePhone(emp.Phone))
                return 0;

            QueueClient queueClient = new QueueClient(connectionString, QueueName);
            // Create the queue if it doesn't already exist
            queueClient.CreateIfNotExists();
            string[] msg = { emp.ID, emp.Name, emp.Phone, emp.Email,emp.Department };
            if (queueClient.Exists())
            {
                // Send a message to the queue
                foreach (string message in msg)
                    queueClient.SendMessage(message);
                return 1;
            }
            return 0;

        }

        //Peek message
        public string PeekEmployee()
        {
           // connectionString = _iconfiguration.GetSection("ConnectionString").GetSection("Connection").Value;
           // QueueName = _iconfiguration[QueueName];
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(connectionString, QueueName);
            if (queueClient.Exists())
            {
                // Peek at the next message
                PeekedMessage[] peekedMessage = queueClient.PeekMessages();

                // Display the message
                //Console.WriteLine($"Peeked message: '{peekedMessage[0].Body}'");
                return peekedMessage[0].MessageText;

            }
            return null;
        }



    }
}
