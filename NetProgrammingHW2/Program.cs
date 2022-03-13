using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace NetProgrammingHW2
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Please write a domen of site: ");    
      var host=Dns.GetHostEntry(Console.ReadLine());
      foreach (IPAddress iPAddress in host.AddressList)
      {
        Console.WriteLine(iPAddress.ToString());
      }

      Console.ReadLine();
    }
  }
}
