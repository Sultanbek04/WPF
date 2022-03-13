using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChooseACard
{
  class Program
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    static Random random=new Random();
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
          Console.WriteLine("Waiting....");
          TcpClient client = server.AcceptTcpClient();
          Console.WriteLine("Connection with Client");

          NetworkStream stream = client.GetStream();
          byte[] data = new byte[256];
          var len = stream.Read(data, 0, data.Length);
          response = Encoding.UTF8.GetString(data, 0, len);
          int n=random.Next(1, 4);

          if (Convert.ToInt32(response) == n)
          {
            
            byte[] result = Encoding.UTF8.GetBytes("You guessed");
            stream.Write(result, 0, result.Length);
            stream.Close();
            client.Close();
          }
          else
          {
            byte[] result = Encoding.UTF8.GetBytes("You did not guess");
            stream.Write(result, 0, result.Length);
            stream.Close();
            client.Close();
          }
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
