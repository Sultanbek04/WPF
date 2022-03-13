using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WPFAcquaintance
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
 Random random=new Random();
    Thread thread;
    public MainWindow()
    {

      InitializeComponent();
      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromSeconds(1);
      timer.Tick += Timer_Tick;
      timer.Start();
      ff


    }
    private void Timer_Tick(object sender, EventArgs e)
    {
      Dispatcher.Invoke(new Action(delegate () { 

     david.FontSize=random.Next(1, 70);
      david.Background= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));
        david.Foreground= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));
        nikita.FontSize=random.Next(1,70);
      nikita.Background= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));
        nikita.Foreground= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));kkkkkkkkkk
        vitaly.FontSize=random.Next(1, 70);
      vitaly.Background= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));
        Background= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));
        vitaly.Foreground= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));
        click_me.FontSize=35;
        click_me.Content="Click Me!";

      }));
      }

    private void click_me_Click(object sender, RoutedEventArgs e)
    {
      thread= new Thread(new ThreadStart(ShowInfo));
      thread.Start();

    }
private void ShowInfo()
    {
      Dispatcher.Invoke(new Action(delegate () {

        click_me.FontSize=20;
      click_me.Content="Hello from Sultanbek!";
      click_me.Background= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));
      click_me.Foreground= new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256),
                    (byte)random.Next(256)));

    
    //  click_me.FontSize=27;
      //click_me.Content="Click me again!";
        //thread.Abort();
      }));
      }
   
    }
  }

