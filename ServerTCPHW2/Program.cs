using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServerTCPHW2
{
  class Program
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;


    static void Main(string[] args)
    {
      var allDataOfGivenFile = new Dictionary<string, string>();
      char[] delims = { '!', '?', ',', '(', ')', '\t', '\n', '\r', ' ' };
      string line;


      using (var file = new StreamReader("D:/AllCurrentsPerDollar.txt"))
      {
        while ((line = file.ReadLine()) != null)
        {
          string keyForDict = null;
          var str = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);
          for (int i = 0; i < str.Length - 1; ++i)
          {
            if (i + 1 == str.Length - 1)
            {

              allDataOfGivenFile.Add(keyForDict, str[i]); ;

            }
            keyForDict = keyForDict + str[i] + " ";
          }

        }
      }


      UdpClient client = new UdpClient(IP, Port);
      string response = "";
      try
      {
        byte[] data = Encoding.UTF8.GetBytes(message);
        int numberOfSentBytes = client.Send(data, data.Length);
        while (true)
        {
          
          response = Encoding.UTF8.GetString(data, 0, data.Length);
          var allNeededData = new List<string>();
          allNeededData.Add("in USD: " + allDataOfGivenFile[response] + " ");
          
          allNeededData.Add(IP+ " ");
          allNeededData.Add(DateTime.Now.ToString());
         Console.Write(allNeededData[2]);

          for (int i = 0; i < allNeededData.Count; ++i)
          {
            byte[] result = Encoding.UTF8.GetBytes(allNeededData[i]); 
            stream.Write(result, 0, result.Length);
          }
        }    
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (server != null) {
          TcpClient client = server.AcceptTcpClient();

          NetworkStream stream = client.GetStream();
          byte[] result = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
          stream.Write(result, 0, result.Length);
          server.Stop();
        }
        Console.ReadLine();
      }
    }
  }
}


