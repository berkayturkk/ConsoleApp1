using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace MathAPIConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("CustomerId :");
            //string CustomerId = Console.ReadLine();
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44386/Math?CustomerId="+ CustomerId);
            //request.Method = "GET";
            //String test = String.Empty;
            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //{
            //    Stream dataStream = response.GetResponseStream();
            //    StreamReader reader = new StreamReader(dataStream);
            //    test = reader.ReadToEnd();
            //    reader.Close();
            //    dataStream.Close();
            //}

            //var CustomerList = JsonSerializer.Deserialize<List<Customer>>(test, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //foreach (Customer c in CustomerList)
            //{
            //    Console.WriteLine(CustomerId);
            //}

            //Console.WriteLine("OrderId :");
            //string OrderId = Console.ReadLine();
            //HttpWebRequest OrderRequest = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44386/Math?CustomerId=" + CustomerId+"?OrderId="+OrderId);
            //request.Method = "GET";
            //String OrderTest = String.Empty;
            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //{
            //    Stream dataStream = response.GetResponseStream();
            //    StreamReader reader = new StreamReader(dataStream);
            //    OrderTest = reader.ReadToEnd();
            //    reader.Close();
            //    dataStream.Close();
            //}

            //var OrderList = JsonSerializer.Deserialize<List<Customer>>(OrderTest, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //foreach (Customer c in OrderList)
            //{
            //    Console.WriteLine(OrderId);
            //}

            #region GetCustomers

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44312/Web/GetCustomers");
            request.Method = "GET";
            String test = String.Empty;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var CustomerList = JsonSerializer.Deserialize<List<Customer>>(test, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (Customer customer in CustomerList)
            {
                Console.WriteLine(customer.CustomerID);
            }

            #endregion

            #region GetOrder

            Console.WriteLine("Customer seçiniz : ");
            var secilen = Console.ReadLine();

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("https://localhost:44312/Web/GetOrder?CustomerId=" + secilen);
            request2.Method = "GET";
            String test2 = String.Empty;

            using (HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse())
            {
                Stream dataStream = response2.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test2 = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var OrderList = JsonSerializer.Deserialize<List<Orders>>(test2, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (Orders order in OrderList)
            {
                Console.WriteLine(order.OrderID);
            } 

            #endregion

            Console.WriteLine("Order seçiniz : ");
            var secilenOrder = Console.ReadLine();

            HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create("https://localhost:44312/Web/GetTotalPrice?CustomerId=" + secilen+"&OrderId="+secilenOrder);
            request3.Method = "GET";
            String test3 = String.Empty;

            using (HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse())
            {
                Stream dataStream = response3.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test3 = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var TotalList = JsonSerializer.Deserialize<List<Orders>>(test3, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            foreach (Orders total in TotalList)
            {
                Console.WriteLine("****** BİLGİLER ******");
                Console.WriteLine("CustomerID = " + total.CustomerID);
                Console.WriteLine("OrderID = " + total.OrderID);
            }
            
            HttpWebRequest request4 = (HttpWebRequest)HttpWebRequest.Create("https://api.apilayer.com/exchangerates_data/convert?to=TRY&from=USD&amount=");
            request4.Method = "GET";
            request4.Headers.Add("apikey", "Bxf2813K4uCbNFy2Wml0pIkcsAyO283I");

            String test4 = String.Empty;
            using (HttpWebResponse response4 = (HttpWebResponse)request4.GetResponse())
            {
                Stream dataStream = response4.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test4 = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                Console.WriteLine(test4);
            }

            var Exchange = JsonSerializer.Deserialize<Exchange>(test4, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine("Total Price = " + Exchange.Result + " TRY");




            Console.ReadKey();
        }
    }
}
