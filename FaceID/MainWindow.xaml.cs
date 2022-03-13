using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace FaceID
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    private readonly IFaceServiceClient objFaceServiceClient = new FaceServiceClient("f721dc048791492f990ba2b581a781f9");
    public MainWindow()
    {
      InitializeComponent();
    }

    private async void btnBrowse_Click(object sender, RoutedEventArgs e)
    {

      var openDlg = new Microsoft.Win32.OpenFileDialog();
      openDlg.Filter = "JPEG Image(*.jpg)|*.jpg";
      bool? result = openDlg.ShowDialog(this);
      if (!(bool)result)
      {
        return;
      }

      string filePath = openDlg.FileName;
      Uri fileUri = new Uri(filePath);
      BitmapImage bitmapSource = new BitmapImage();
      bitmapSource.BeginInit();
      bitmapSource.CacheOption = BitmapCacheOption.None;
      bitmapSource.UriSource = fileUri;
      bitmapSource.EndInit();
      imgPhoto.Source = bitmapSource;
      Title = "Detecting..."; 
      FaceRectangle[] faceRects = await UploadAndTrackFaces(filePath);
      Title = String.Format("Detection Finished. {0} face(s) detected", faceRects.Length);

      if (faceRects.Length > 0)
      {
        DrawingVisual visual = new DrawingVisual();
        DrawingContext drawingContext = visual.RenderOpen();
        drawingContext.DrawImage(bitmapSource,
        new Rect(0, 0, bitmapSource.Width, bitmapSource.Height));
        double dpi = bitmapSource.DpiX;
        double resizeFactor = 96 / dpi;
        foreach (var faceRect in faceRects)
        {

          drawingContext.DrawRectangle(
          Brushes.Transparent,
          new Pen(Brushes.Red, 2),
          new Rect(
          faceRect.Left * resizeFactor,
          faceRect.Top * resizeFactor,
          faceRect.Width * resizeFactor,
          faceRect.Height * resizeFactor
          )
          );
        }

        drawingContext.Close();
        RenderTargetBitmap faceWithRectBitmap = new RenderTargetBitmap(
        (int)(bitmapSource.PixelWidth * resizeFactor),
        (int)(bitmapSource.PixelHeight * resizeFactor),
        96,
        96,
        PixelFormats.Pbgra32);

        faceWithRectBitmap.Render(visual);
        imgPhoto.Source = faceWithRectBitmap;

      }

    }


    private async Task<FaceRectangle[]> UploadAndTrackFaces(string imageFilePath)
    {

      try
      {
        using (Stream imageFileStream = File.OpenRead(imageFilePath))
        {

          var faces = await objFaceServiceClient.DetectAsync(imageFileStream);
          var faceRects = faces.Select(face => face.FaceRectangle);
          return faceRects.ToArray();
        }
      }
      catch (Exception)
      {
        return new FaceRectangle[0];
      }
    }
  }
}
