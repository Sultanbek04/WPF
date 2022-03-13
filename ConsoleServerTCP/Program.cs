using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleServerTCP
{
  class Program
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    static Random random=new Random();
    static void Main(string[] args)
    {
       TcpListener server=null; 
       
      try
      {
        server = new TcpListener(IPAddress.Parse(IP), Port);  
        server.Start();
        while (true)
        {
          Console.WriteLine("Waiting...."); 
          TcpClient client= server.AcceptTcpClient();

          Console.WriteLine("Connection with Client");


          NetworkStream stream=client.GetStream();
          string response=GetNumber();

          byte[] data=Encoding.UTF8.GetBytes(response);
          stream.Write(data, 0, data.Length); 
          Console.WriteLine($"Ball on { response}");
          stream.Close();
          client.Close();
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if(server!=null)
           server.Stop();
        Console.ReadLine(); 
      }
    }
    static string GetNumber()
    {
      int val=random.Next(-1, 1+36);
      if(val==-1)
        return "00";

      return val.ToString();
    }
  }
}
    
  
