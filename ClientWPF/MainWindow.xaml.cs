using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ClientWPF
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    public MainWindow()
    {

      InitializeComponent();
    }



    private void Button_Click(object sender, RoutedEventArgs e)
    {
      IPAddress ipAddress = IPAddress.Parse(IP);
      IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, Port);
      Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      try
      {
        socket.Connect(ipEndPoint);
       // string message = tbMessage.Text;

        // byte[] bytes = Encoding.UTF8.GetBytes(message);


        char[] delims = { '.', '!', '?', ',', '(', ')', '\t', '\n', '\r', ' ' };
        string line;

        using (var file = new StreamReader(tbMessage.Text))
        {
          while ((line = file.ReadLine()) != null)
          {
            var data = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < data.Length; ++i)
            {
              byte[] bytes = Encoding.UTF8.GetBytes(data[i]);
              socket.Send(bytes);
            }
          }
        }




        //tbLog.Text += "Message sent: " + message + "\r\n";

        var bytesAnswer = new byte[1000];
        var length = socket.Receive(bytesAnswer);
       // string info = Encoding.UTF8.GetString(bytesAnswer, 0, length) + "\r\n";

        tbLog.Text += Encoding.UTF8.GetString(bytesAnswer, 0, length) + "\r\n";
        socket.Shutdown(SocketShutdown.Both);
      }
      catch (Exception ex)
      {
        tbLog.Text += ex.Message + "\r\n";
      }
      finally
      {
        socket.Close();
      }
    }
  }
}

