using ConsoleApp8.Models;
using System;
using System.IO;

namespace ConsoleApp8
{
    public class Program
    {
        public const int MAX_ATTEMPTS = 10;
        const string InitialDataFile = "customers.json";
        static void Main(string[] args)
        {
            string jsonText = File.ReadAllText(InitialDataFile);
            Console.WriteLine("JSON string is \n{0}", jsonText);
            CustomersModel jsonObject = jsonText.As<CustomersModel>();

            PrintShipmentOrders(SetIDForCustomerShipmentOrder(jsonObject));

            Console.WriteLine("The End");
            Console.ReadLine();
        }

        public static CustomersModel SetIDForCustomerShipmentOrder(CustomersModel jsonObject)
        {
            for (int customerElement = 0; customerElement < jsonObject.Customers.Count; customerElement++)
            {
                jsonObject.Customers[customerElement].ID = Guid.NewGuid();
                for (int shipmentElement = 0; shipmentElement < jsonObject.Customers[customerElement].Shipments.Count; shipmentElement++)
                {
                    jsonObject.Customers[customerElement].Shipments[shipmentElement].ID = (shipmentElement + 1).ToString();

                    for (int orderElement = 0; orderElement < jsonObject.Customers[customerElement].Shipments[shipmentElement].Orders.Count; orderElement++)
                    {
                        jsonObject.Customers[customerElement].Shipments[shipmentElement].Orders[orderElement].ID = orderElement + 1;
                    }
                }
            }
            return jsonObject;
        }

        public static void PrintShipmentOrders(CustomersModel jsonObject)
        {
            Validator validInput = new Validator();
            int attempt = 0;
            while (attempt < MAX_ATTEMPTS)
            {
                switch (validInput.GetChoiceToShowShipmentInfo())
                {
                    case 1:
                        for (int customerElement = 0; customerElement < jsonObject.Customers.Count; customerElement++)
                        {
                            Console.WriteLine("\nCustomer {0}", jsonObject.Customers[customerElement].Customer);
                            for (int shipmentElement = 0; shipmentElement < jsonObject.Customers[customerElement].Shipments.Count; shipmentElement++)
                            {
                                Console.WriteLine("\n  Shipment ID: {0}", jsonObject.Customers[customerElement].Shipments[shipmentElement].ID);
                                Console.WriteLine("  Shipment Address {0}", jsonObject.Customers[customerElement].Shipments[shipmentElement].Address);
                            }
                        }
                        attempt++;
                        break;
                    case 2:
                        for (int customerElement = 0; customerElement < jsonObject.Customers.Count; customerElement++)
                        {
                            Console.WriteLine("\nCustomer {0}", jsonObject.Customers[customerElement].Customer);
                            for (int shipmentElement = 0; shipmentElement < jsonObject.Customers[customerElement].Shipments.Count; shipmentElement++)
                            {
                                Console.WriteLine("\n  Shipment ID: {0}", jsonObject.Customers[customerElement].Shipments[shipmentElement].ID);
                                Console.WriteLine("  Shipment Address {0}", jsonObject.Customers[customerElement].Shipments[shipmentElement].Address);
                                for (int orderElement = 0; orderElement < jsonObject.Customers[customerElement].Shipments[shipmentElement].Orders.Count; orderElement++)
                                {
                                    Console.WriteLine("  Order - Type of Goods: {0}; Count is: {1}", jsonObject.Customers[customerElement].Shipments[shipmentElement].Orders[orderElement].TypeOfGoods, jsonObject.Customers[customerElement].Shipments[shipmentElement].Orders[orderElement].Count);
                                }
                            }
                        }
                        attempt++;
                        break;
                }
            }
        }
    }
}
