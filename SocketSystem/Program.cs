using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace SocketSystem
{
  class Program
  {
    static void Main(string[] args)
    {
      //TCP
      /* Socket socketTCP=new Socket(AddressFamily.InterNetwork, 
         SocketType.Stream, ProtocolType.Tcp);

       //UDP
       Socket socketUDP=new Socket(AddressFamily.InterNetwork, 
         SocketType.Dgram, ProtocolType.Udp);


       IPHostEntry host1=Dns.GetHostEntry("www.mail.ru");
       Console.WriteLine(host1.HostName);

       foreach(IPAddress iP in host1.AddressList)
       {
         Console.WriteLine(iP.ToString());
       } 

      IPHostEntry host2=Dns.GetHostEntry("google.com");
       Console.WriteLine(host2.HostName);
       foreach(IPAddress iPAddress in host2.AddressList)
       {
         Console.WriteLine(iPAddress.ToString());
       }

       IPAddress iPAddress1=IPAddress.Parse("127.0.0.1");
       int port=80;

       IPEndPoint endPoint=new IPEndPoint(iPAddress1, port);
       Console.WriteLine(endPoint);*/
      /* Console.WriteLine("J"); 
       IPAddress iPAddress2 = IPAddress.Parse("255.0.0.5");
       Console.WriteLine(iPAddress2.MapToIPv6());
       Console.WriteLine(iPAddress2.MapToIPv4());*/
      while (true)
      {
        Console.WriteLine("Please write Ip adress:");
        var ip = Console.ReadLine();
        int result = 0;
        int counter = 0;
        bool isIp = true;
        string n = string.Empty;
       bool isINeedToWrite=true;
        int indicator=0;


        if (ip.Length >= 7 && ip.Length <= 15 && !ip.StartsWith(":"))
        {

          foreach (var item in ip)
          {

            if (int.TryParse(item.ToString(), out result) == true)
            {
              n = n + item;
              ++counter;
              ++indicator;
            }
            if (int.TryParse(item.ToString(), out result) == false && item.ToString().Contains(".") && counter <= 3)
            {
              if (int.TryParse(n, out result) == true)
              {
                if (Convert.ToInt32(n) >= 0 && Convert.ToInt32(n) <= 255)
                {
             

                  isIp = true;
                  n = string.Empty;
                  counter = 0;
                }
                else { 
                  isIp = false;
                  Console.WriteLine("it is not Ipv4!");
                  isINeedToWrite=false;
               
                  break;
                
              }
              }
            }
            if (int.TryParse(item.ToString(), out result) == false && !item.ToString().Contains(".") && counter <= 3)
            {
              isIp = false;
              Console.WriteLine("it is not Ipv4!");
        
              isINeedToWrite =false;
              break;
            }

            if (indicator == 0)
            {
              isIp = false;
              Console.WriteLine("it is not Ipv4!");
              isINeedToWrite = false;
              break;

            }
          }
         

        }
        
        if (isIp == true) { 
        Console.WriteLine("It is ipv4!");
        }
        if (isINeedToWrite == true && isIp==false)
        {
          Console.WriteLine("It is not Ip!");
        }


      }


      Console.ReadLine();
    }
   



    }
  }








