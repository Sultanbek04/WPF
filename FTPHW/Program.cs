using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace FTP
{

  class Program
  {
    const string ftp = "ftp://10.16.13.119/";
    const string DirectoryName = "TestFTP";
    

    static void Main(string[] args)
    {
      FtpWebRequest requestCreate = (FtpWebRequest)FtpWebRequest.Create(ftp + DirectoryName);
      requestCreate.KeepAlive = false;
      Console.WriteLine("Getting the response");
      requestCreate.Method = WebRequestMethods.Ftp.MakeDirectory;   
      using (var resp = (FtpWebResponse)requestCreate.GetResponse())
      {
        Console.WriteLine(resp.StatusCode);
      }


      FtpWebRequest requestDelete = (FtpWebRequest)FtpWebRequest.Create(ftp + DirectoryName);
      requestDelete.KeepAlive = false;
      Console.WriteLine("Getting the response");
      requestDelete.Method = WebRequestMethods.Ftp.RemoveDirectory;
      using (var resp = (FtpWebResponse)requestDelete.GetResponse())
      {
        Console.WriteLine(resp.StatusCode);
      }


      Console.ReadLine();

    }
  }
}