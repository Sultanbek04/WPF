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

namespace ClientTCPHW
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    Random random=new Random();
    public MainWindow()
    {
      InitializeComponent();

    }

    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
      string response = "";
      try
      {
        TcpClient client = new TcpClient();
        client.Connect(IP, Port);
        NetworkStream stream = client.GetStream();
        byte[] result = Encoding.UTF8.GetBytes(tbMessage.Text);
        stream.Write(result, 0, result.Length);
        var tbSent = new TextBlock();
        tbSent.Text = $"At {DateTime.Now.TimeOfDay.ToString().Remove(5)} from {IP}  sent a message: {tbMessage.Text}";
        tbSent.FontSize = random.Next(20, 50);
     
        tbSent.Background = new SolidColorBrush(Color.FromArgb(
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256)));
        spLogs.Children.Add(tbSent);
        do
        {

          byte[] data = new byte[256];
          var len = stream.Read(data, 0, data.Length);
          response = Encoding.UTF8.GetString(data, 0, len);
          var tbResponse=new TextBlock();
          tbResponse.Text=response;
          tbResponse.FontSize=random.Next(20, 50);
      
          tbResponse.Background= new SolidColorBrush(Color.FromArgb(
                  (byte)random.Next(256),
                  (byte)random.Next(256),
                  (byte)random.Next(256),
                  (byte)random.Next(256)));
          spLogs.Children.Add(tbResponse);

        }

        while (stream.DataAvailable);
        stream.Close();
        client.Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}

