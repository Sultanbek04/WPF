using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPNetProgram
{
  class Program
  {
    private const string  IP="127.0.0.1";
    private const int Port=12000;
    static void Main(string[] args)
    {
      UdpClient client=new UdpClient(IP, Port); 
      string message="Hello World!";
      byte[] data=Encoding.UTF8.GetBytes(message);
      int numberOfSentBytes=client.Send(data, data.Length); 
      client.Close();
      Console.WriteLine("Good job"); 
      Console.ReadLine();
    }
  }
}
