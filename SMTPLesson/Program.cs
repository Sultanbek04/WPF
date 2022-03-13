using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.Mail;

namespace SMTPLesson
{
  class Program
  {
    static void Main(string[] args)
    {
      SendMail("msultanbek04@mail.ru", "OpenAI123" , "zhansito@gmail.com");
    }
     
    static void SendMail(string fromMailLogin, string fromMailPassword, string toMailLogin)
    {
      MailAddress from=new MailAddress(fromMailLogin, "Бывший король");
      MailAddress to=new MailAddress(toMailLogin); 
      MailMessage mail=new MailMessage(from ,to);

      mail.Subject="Мой дорогой друг"; 

      mail.Body="<h3>  Мой дорогой друг </h3> <p/> Пожалуйста примите мои извинения за отпарвку вам этого " +
        "письма без вашего согласия"; 

      mail.IsBodyHtml=true;

      SmtpClient smtp=new SmtpClient("smtp.mail.ru", 2525);
      smtp.Credentials=new NetworkCredential(fromMailLogin, fromMailPassword);
      smtp.EnableSsl=true;
      smtp.Send(mail);  

        
    }
  } 
}
