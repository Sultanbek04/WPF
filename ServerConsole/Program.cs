using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerConsole
{

  class Program
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;


    static void Main(string[] args)
    {
      IPAddress ipAddress = IPAddress.Parse(IP);
      IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, Port);

      Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

      socket.Bind(ipEndPoint);
      Console.WriteLine("____Server started____");
      try
      {
        while (true)
        { 
          socket.Listen(10);
          var answer = socket.Accept();
          Console.WriteLine("Something accepted");
          byte[] bytes = new byte[1000];
          var length = answer.Receive(bytes);

          var message = Encoding.UTF8.GetString(bytes, 0, length);


          memStream.WriteByte(secondString[count++]);
          Console.WriteLine("Message: " + message);
          answer.Send(Encoding.UTF8.GetBytes(DateTime.Now.ToString())); 

          answer.Close();
          socket.Close();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }
      finally
      {
        socket.Close();
      }
      Console.ReadLine();
    }
  }
}