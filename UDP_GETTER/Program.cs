using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDP_GETTER
{

  class Program
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    static void Main(string[] args)
    {

      UdpClient server=new UdpClient(Port);
      IPEndPoint ep=null;
      try
      {
        while (true)
        {
          Console.WriteLine("___Ready___");
          byte[] data=server.Receive(ref ep);
          Console.WriteLine($"{Encoding.UTF8.GetString(data)}- {ep.Address}: {ep.Port}");
         
         
        
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      server.Close();
    }
  }
}

