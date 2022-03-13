using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServerTCPHW
{
  class Program
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    static void Main(string[] args)
    {
      

      TcpListener server = null;
      string response = "";
      try
      {
        server = new TcpListener(IPAddress.Parse(IP), Port);
        server.Start();
        while (true)
        {
          TcpClient client = server.AcceptTcpClient();

          NetworkStream stream = client.GetStream();
          byte[] data = new byte[256];
          var len = stream.Read(data, 0, data.Length);
          response = Encoding.UTF8.GetString(data, 0, len);
          Console.WriteLine($"At {DateTime.Now.TimeOfDay.ToString().Remove(5)} from {IP}  Message {response} is accepted");
          byte[] result = Encoding.UTF8.GetBytes($"At {DateTime.Now.TimeOfDay.ToString().Remove(5)} from {IP}  Message  is accepted");
          stream.Write(result, 0, result.Length);

        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (server != null)
          server.Stop();
        Console.ReadLine();
      }
    }
  }
}
