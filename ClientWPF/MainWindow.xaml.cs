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

    public SocketShutdown SoketShutDown { get; private set; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        var ipAdress = IPAddress.Parse(IP);
        IPEndPoint iPEndPoint = new IPEndPoint(ipAdress, Port);

        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
          ProtocolType.Tcp);

        socket.Connect(iPEndPoint);
        string message = tbMessage.Text;

        byte[] bytes = Encoding.UTF8.GetBytes(message);
        socket.Send(bytes);
        tbLog.Text += "Message sent: " + message;
        var bytesAnswer = new byte[1000];
        socket.Receive(bytes);
        tbLog.Text = Encoding.UTF8.GetString(bytesAnswer, 0, 1000) + "\r\n";
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();


      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

    }
  }
}
