using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpHW
{
  
  class Program
  {
    static void Main(string[] args)
    {
      SendLetter("msultanbek04@mail.ru", "OpenAI123", "hello@mail.ru", "Sula", "S");
      Console.ReadLine();
    }
    public static void SendLetter(string mail, string passwords, string getter, string header, string body)
    {
     

          MailAddress from = new MailAddress(mail, passwords);
          MailAddress to = new MailAddress(getter);
          MailMessage m = new MailMessage(from, to);
          m.Subject = header;
          m.Body = body;
          m.IsBodyHtml = true;
          SmtpClient smtp = new SmtpClient(getter, i);
          smtp.Credentials = new NetworkCredential(mail, passwords);
          smtp.EnableSsl = true;
          smtp.Send(m);
          Console.WriteLine("Done");

        }

      

        
      
    }
  }
}
