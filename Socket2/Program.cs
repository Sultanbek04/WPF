using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Socket2
{
  class Program
  {
    static void Main(string[] args)
    {
      IPHostEntry host=Dns.GetHostEntry("google.com");
      IPAddress ip=host.AddressList.First();
      int port=80;
      IPEndPoint ep=new IPEndPoint(ip, port); 
      Console.WriteLine(ep);
      Socket s=new Socket(AddressFamily.InterNetwork, SocketType.Stream,
        ProtocolType.IP);
      
      try
      {
        s.Connect(ep);
        if (s.Connected) { 
        string strSend="GET\r\n\r\n";
        s.Send(Encoding.ASCII.GetBytes(strSend));
        byte[] buffer=new byte[1024];
        int d;
          do
          {
            d=s.Receive(buffer);
            Console.WriteLine(Encoding.ASCII.GetString(buffer,0,d));
          }while(d>0);

      }
        else
        {
          Console.WriteLine("Error");
        }
      }
      catch(SocketException ex)
      {
        Console.WriteLine("Error: "+ex.Message);
      }

    Console.ReadLine();
    }
   
  }
}
