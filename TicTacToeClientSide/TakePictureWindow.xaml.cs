using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Emgu.CV;
using Emgu.CV.Structure;

namespace TicTacToeClientSide
{
    /// <summary>
    /// Interaction logic for TakePictureWindow.xaml
    /// </summary>
    public partial class TakePictureWindow : Window
    {
        bool _streaming;
        Capture _capture;

        DispatcherTimer dispatcherTimer;


        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
        public ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }



        public TakePictureWindow()
        {
            InitializeComponent();
            _streaming = false;
            _capture = new Capture();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, byte>();
            var bmp = img.Bitmap;
            this.picturePreview.Source = ImageSourceFromBitmap(bmp);
        }

        private void StreamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_streaming)
            {
                dispatcherTimer.Start();
                _capture.Start();
                cameraPanel.Background = new SolidColorBrush(Colors.Black);
                StreamBtn.Content = "Stop Streaming";
                StreamBtn.Background=new SolidColorBrush(Colors.Red);
            }
            else
            {
                dispatcherTimer.Stop();
                _capture.Stop();
                StreamBtn.Content = "Start Streaming";
                StreamBtn.Background = new SolidColorBrush(Colors.Green);
            }
            _streaming = !_streaming;

        }

        private void CaptureBtn_Click(object sender, RoutedEventArgs e)
        {
            captureImage.Source=this.picturePreview.Source;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _capture.Dispose();
            dispatcherTimer.Stop();
        }
    }
}
