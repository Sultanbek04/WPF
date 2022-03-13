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

namespace WPFMessangerToEachOther
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
      Socket socket = new Socket(AddressFamily.InterNetwork,
        SocketType.Stream, ProtocolType.Tcp);



      try
      {

        socket.Listen(10);
        var answer = socket.Accept();
        byte[] bytesForAnswer = new byte[1000];
        var lengthForAnswer = answer.Receive(bytesForAnswer);
        var message = Encoding.UTF8.GetString(bytesForAnswer, 0, lengthForAnswer);
        tbAnswer.Text=message;

        answer.Send(Encoding.UTF8.GetBytes("Bitch I have gotten your message!"));
        answer.Close();


        socket.Connect(ipEndPoint);
        byte[] bytes = Encoding.UTF8.GetBytes(tbMessage.Text);
        socket.Send(bytes);




        var bytesAnswer = new byte[1000];
        var length = socket.Receive(bytesAnswer);
        string sentMessage = Encoding.UTF8.GetString(bytesAnswer, 0, length) + 
          "\r\n";
        tbAnswer.Text += " " + Encoding.UTF8.GetString(bytesAnswer, 0, length) + 
          "\r\n";
        socket.Shutdown(SocketShutdown.Both);
      }
      catch (Exception ex)
      {
        tbAnswer.Text += ex.Message + "\r\n";
      }
    }
  }
}
