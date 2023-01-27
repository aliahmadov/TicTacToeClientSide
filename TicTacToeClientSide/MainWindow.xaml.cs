using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace TicTacToeClientSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Socket ClientSocket = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
        private const int port = 27001;

        public ClientItem ClientItem { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            EnableAllButtons(false);
            ConnectBtn.IsEnabled = false;
            ClientItem = new ClientItem();
        }

        public System.Windows.Controls.Image CapturedImage { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConnectToServer();
            RequestLoop();
        }

        private void RequestLoop()
        {
            var receiver = Task.Run(() =>
            {
                while (true)
                {
                    ReceiveResponse();
                }
            });
        }

        public bool IsTurn { get; set; }

        private void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            IntegrateToView(text);
        }

        private void IntegrateToView(string text)
        {

            App.Current.Dispatcher.Invoke(() =>
            {
                var data = text.Split('\n');
                var row1 = data[0].Split('\t');
                var row2 = data[1].Split('\t');
                var row3 = data[2].Split('\t');

                b1.Content = row1[0];
                b2.Content = row1[1];
                b3.Content = row1[2];

                b4.Content = row2[0];
                b5.Content = row2[1];
                b6.Content = row2[2];

                b7.Content = row3[0];
                b8.Content = row3[1];
                b9.Content = row3[2];


                IsTurn = !IsTurn;

                EnableAllButtons(IsTurn);
            });
        }

        private void ConnectToServer()
        {
            int attempts = 0;
            while (!ClientSocket.Connected)
            {
                try
                {
                    ++attempts;
                    ClientSocket.Connect(IPAddress.Parse("192.168.1.73"), port);
                }
                catch (Exception)
                {
                }
            }

            MessageBox.Show("Connected");


            SendImageBytes(ClientItem);

            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);

            string text = Encoding.ASCII.GetString(data);
            this.Title = "Player : " + text;
            this.player.Text = this.Title;

            if (text == "X")
            {
                IsTurn = true;
                EnableAllButtons(IsTurn);
            }
            else
            {
                IsTurn = false;
                EnableAllButtons(IsTurn);
            }
            ConnectBtn.IsEnabled = false;
        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    var bt = sender as Button;
                    string request = bt.Content.ToString() + player.Text.Split(' ')[2];
                    SendString(request);
                });
            });
        }

        public void EnableAllButtons(bool enabled)
        {
            foreach (var item in myWrap.Children)
            {
                if (item is Button bt)
                {
                    bt.IsEnabled = enabled;
                }
            }
        }


        private void SendString(string request)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(request);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }



        private void SaveImageToJPEG(System.Windows.Controls.Image ImageToSave, string Location)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)ImageToSave.Source.Width,
                                                                           (int)ImageToSave.Source.Height,
                                                                           245, 215, PixelFormats.Default);
            renderTargetBitmap.Render(ImageToSave);
            JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
            jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            using (FileStream fileStream = new FileStream(Location, FileMode.Create))
            {
                jpegBitmapEncoder.Save(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }



        private void SendImageBytes(ClientItem clientItem)
        {
            var jsonString = JsonConvert.SerializeObject(clientItem);
            var bytes = Encoding.ASCII.GetBytes(jsonString);
            ClientSocket.Send(bytes);

        }

        private void TakePicBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new TakePictureWindow();
            window.ShowDialog();
            CapturedImage = window.captureImage;
            if (CapturedImage.Source != null)
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var path = $@"{desktop}/pic.jpeg";
                SaveImageToJPEG(CapturedImage, path);
                var bitmap = new Bitmap(path);
                var image = (System.Drawing.Image)bitmap;
                var imageByteArray = ImageToByteArray(image);
                ClientItem.ImageBytes = imageByteArray;
                ClientItem.Name = window.nameTxtBox.Text;
                ConnectBtn.IsEnabled = true;
            }
        }
    }
}
