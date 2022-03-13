using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HTTP
{
  class Program
  {
    private const string IP="127.0.0.1";
    private const int Port=12000;
    static void Main(string[] args)
    {
      WebClient client=new WebClient();
       client.DownloadFile("https://translate.google.kz/", "googleT.html"); 
      Console.WriteLine("Файл загружен"); 

    }
  }
}
