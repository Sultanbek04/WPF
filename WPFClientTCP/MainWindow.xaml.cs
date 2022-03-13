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

namespace WPFClientTCP
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    static List<int> blackNumbers = new List<int> { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
    public MainWindow()
    {
      InitializeComponent();
    }
    void SetNumber(string val) 
    {
      int result = Convert.ToInt32(val);
      if (result == 0)
      {
        tbNumber.Background = Brushes.LightGreen;
        tbNumber.Foreground = Brushes.Black;
      }
      else if (blackNumbers.Contains(result))
      {
        tbNumber.Background = Brushes.Black;
        tbNumber.Foreground = Brushes.White;
      }
      else
      {
        tbNumber.Background=Brushes.Red;
        tbNumber.Foreground=Brushes.Black;
      }
      tbNumber.Text=val;
    }
    private void bRoll_Click(object sender, RoutedEventArgs e)
    {
      string response="";
      try
      {
        TcpClient client=new TcpClient(); 
        client.Connect(IP, Port);
        NetworkStream stream=client.GetStream();
        do
        {
          byte[] data=new byte[256];
          var len=stream.Read(data, 0, data.Length);
          response+=Encoding.UTF8.GetString(data, 0, len);
        }
        while(stream.DataAvailable);
        stream.Close(); 
        client.Close();
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      SetNumber(response);  
      tbLog.Text+=response + " ";
    }
  }
}
