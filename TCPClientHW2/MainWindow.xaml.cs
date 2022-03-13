using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace TCPClientHW2
{
  public partial class MainWindow : Window
  {
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    Random random = new Random();

    static Dictionary<string, string> allDataOfGivenFile = new Dictionary<string, string>();
    public MainWindow()
    {
      InitializeComponent();

      char[] delims = { '!', '?', ',', '(', ')', '\t', '\n', '\r', ' ' };
      string line;

      using (var file = new StreamReader("D:/AllCurrentsPerDollar.txt"))
      {
        while ((line = file.ReadLine()) != null)
        {
          string keyForDictAndTextForTb = null;
          var str = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);
          for (int i = 0; i < str.Length - 1; ++i)
          {
            if (i + 1 == str.Length - 1)
            {

              allDataOfGivenFile.Add(keyForDictAndTextForTb, str[i]);
              var tb = new TextBlock();
              tb.FontSize = 20;
              tb.Background = new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));
              tb.FontWeight = FontWeights.DemiBold;
              tb.Text = keyForDictAndTextForTb;
              currencies.Items.Add(tb);

            }
            keyForDictAndTextForTb = keyForDictAndTextForTb + str[i] + " ";
          }

        }
      }
    }

    private void Currencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      List<string> allNeededData = new List<string>();
      var selectedItem = (TextBlock)currencies.SelectedItem;
      int counter = 0;
      string response = "";
      try
      {
        TcpClient client = new TcpClient();
        client.Connect(IP, Port);
        NetworkStream stream = client.GetStream();
        byte[] result = Encoding.UTF8.GetBytes(selectedItem.Text);
        stream.Write(result, 0, result.Length);

        do
        {
          string[] allNeededInfo = new string[3];
          byte[] data = new byte[256];
          TextBlock tbAllNeededInfo = new TextBlock();
          tbAllNeededInfo.FontSize = random.Next(20, 45);

          var len = stream.Read(data, 0, data.Length);

          tbAllNeededInfo.Text += Encoding.UTF8.GetString(data, 0, len);
          spForLogs.Children.Add(tbAllNeededInfo);

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



