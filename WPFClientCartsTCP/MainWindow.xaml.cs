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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace WPFClientCartsTCP
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    static string[] heroes = new string[] { "King", "Queen", "Roman" };
    private const string IP = "127.0.0.1";
    private const int Port = 12000;
    Random random = new Random();
    int card=0;
    int counter=0;
    int counterForTimer=20; 

    public MainWindow()
    {
      InitializeComponent();  
       card = random.Next(0, 4);
      tb1.Text += heroes[random.Next(card)] + '?';
      tb2.Text += heroes[random.Next(card)] + '?';
      tb3.Text += heroes[random.Next(card)] + '?';
      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromMilliseconds(1000);
      timer.Tick += Timer_Tick;
      timer.Start();
      DispatcherTimer timerForColor = new DispatcherTimer();
      timerForColor.Interval = TimeSpan.FromMilliseconds(100);
      timerForColor.Tick += Change_Color;
      timerForColor.Start();
      DispatcherTimer timerForTimer = new DispatcherTimer();
      timerForTimer.Interval = TimeSpan.FromMilliseconds(1000);
      timerForTimer.Tick +=TimerForTb;
      timerForTimer.Start();

    }

    private void Change_Color(object sender, EventArgs e)
    {
      Dispatcher.Invoke(new Action(delegate ()
      {
        tb1.Background = new SolidColorBrush(Color.FromArgb(
                  (byte)random.Next(256),
                  (byte)random.Next(256),
                  (byte)random.Next(256),
                  (byte)random.Next(256)));
        tb1.Foreground = new SolidColorBrush(Color.FromArgb(
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256)));
        tb2.Background = new SolidColorBrush(Color.FromArgb(
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256)));
        tb2.Foreground = new SolidColorBrush(Color.FromArgb(
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256)));
        tb3.Background = new SolidColorBrush(Color.FromArgb(
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256)));
        tb3.Foreground = new SolidColorBrush(Color.FromArgb(
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256),
                      (byte)random.Next(256)));
      }));
    }

    bool b = false;
    private void Timer_Tick(object sender, EventArgs e)
    {
      b = !b;
      if (b)
      {
        Dispatcher.Invoke(new Action(delegate ()
        {
          var animation = new DoubleAnimation();
          animation.From = tb1.ActualWidth;
          animation.To = 50;
          animation.Duration = TimeSpan.FromSeconds(1);
          tb1.BeginAnimation(Button.WidthProperty, animation);
          animation.From = tb2.ActualWidth;
          animation.To = 50;
          animation.Duration = TimeSpan.FromSeconds(1);
          tb2.BeginAnimation(Button.WidthProperty, animation);
          animation.From = tb3.ActualWidth;
          animation.To = 50;
          animation.Duration = TimeSpan.FromSeconds(1);
          tb3.BeginAnimation(Button.WidthProperty, animation);
        }));

      } 
     
      else
      {
        Dispatcher.Invoke(new Action(delegate ()
        {
          var animation = new DoubleAnimation();
          animation.From = tb1.ActualWidth;
          animation.To = 200;
          animation.Duration = TimeSpan.FromSeconds(1);
          tb1.BeginAnimation(Button.WidthProperty, animation);
          animation.From = tb2.ActualWidth;
          animation.To = 200;
          animation.Duration = TimeSpan.FromSeconds(1);
          tb2.BeginAnimation(Button.WidthProperty, animation);
          animation.From = tb3.ActualWidth;
          animation.To = 200;
          animation.Duration = TimeSpan.FromSeconds(1); 
          tb3.BeginAnimation(Button.WidthProperty, animation);

        }));
      }
    }

    private void TimerForTb(object sender, EventArgs e)
    {
      if (counterForTimer == 0)
      {
        timeWillBeOver.Text = "Time is over!";
        tbLog.Text = "YOU LOST XAXAXA";

      }
      if (counterForTimer != 0) { 
      if (counterForTimer <= 5)
      {
        
          timeWillBeOver.Text="Faster: " +counterForTimer.ToString();
        --counterForTimer;
       
      }
      else { 
      --counterForTimer;
       timeWillBeOver.Text="Time will be over: " +counterForTimer.ToString();
      }
    }
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (counter == -3 || counterForTimer==0) 
      {

        System.Environment.Exit(0);
      }

      string response = "";
      try
      {
        TcpClient client = new TcpClient();
        client.Connect(IP, Port);
        NetworkStream stream = client.GetStream();
        byte[] result = Encoding.UTF8.GetBytes(tbChoosenCard.Text);
        stream.Write(result, 0, result.Length);

        do
        {

          byte[] data = new byte[256];
          var len = stream.Read(data, 0, data.Length);
          response = Encoding.UTF8.GetString(data, 0, len);
          if (response == "You guessed")
          {

            tbLog.Text =response;
            card = random.Next(0, 4);
            tb1.Text = heroes[random.Next(card)] + '?';
            tb2.Text = heroes[random.Next(card)] + '?';
            tb3.Text = heroes[random.Next(card)] + '?';
            ++counter;
            tbScore.Text="Score: " +counter.ToString();

          }
          if(response=="You did not guess")
          {
            
            tbLog.Text = response;
            card = random.Next(0, 4);
            tb1.Text = heroes[random.Next(card)] + '?';
            tb2.Text = heroes[random.Next(card)] + '?';
            tb3.Text = heroes[random.Next(card)] + '?';
            --counter;
            tbScore.Text = "Score: " + counter.ToString();
            if (counter == -3)
            { 
              tbLog.Text="YOU LOST XAXAXA";
              stream.Close();
              client.Close();

              
            }
          }
          

          
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

