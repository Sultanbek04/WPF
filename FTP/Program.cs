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
    //const string fileName = "TestFTP.txt";
    //const string fileAddressFTP = ftp + fileName;
    //onst string saveFileAddress = fileName;
    const string newFileName = "NewFile.txt";
    const string newFileAddress = newFileName;
    const string newFileAddressFTP = ftp + newFileName;

    static void Main(string[] args)
    {
      FtpWebRequest request = (FtpWebRequest)WebRequest.Create(newFileAddressFTP);
      //Устанавливаем метод на загрузку файла на сервер
      request.Method = WebRequestMethods.Ftp.UploadFile;

      //создаем поток для загрузки файла


      FileStream fs = new FileStream(newFileAddress, FileMode.Open);

      //Буфер для считаваемых данных
      byte[] fileContents = new byte[fs.Length];
      fs.Read(fileContents, 0, fileContents.Length);
      fs.Close();
      request.ContentLength = fileContents.Length;
      var r = request.GetRequestStream();
      r.Write(fileContents, 0, fileContents.Length);
      r.Close();

      FtpWebResponse response = (FtpWebResponse)request.GetResponse();
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("File is Uploaded");
      Console.WriteLine("Status:" + response.StatusDescription);
      response.Close();
      Console.ReadLine();

    }
  }
}

 