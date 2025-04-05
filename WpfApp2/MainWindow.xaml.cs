using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void EscButton_MouseEnter(object sender, MouseEventArgs e)
        {
            double maxX = MainCanvas.ActualWidth-NoButton.ActualWidth;
            double maxY = MainCanvas.ActualHeight-NoButton.ActualHeight;
            if (maxX <= 0 || maxY <= 0)
            {
                return;
            }
            double newX = rnd.NextDouble()*maxX;
            double newY = rnd.NextDouble()*maxY;
            Canvas.SetLeft(NoButton, newX);
            Canvas.SetTop(NoButton, newY);
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            string videoPath = @"C:\Users\Nazar\Desktop\MathAnalys\StudyUni\WpfApp1\WpfApp2\bin\Debug\net8.0-windows\Life could be a dream.mp4";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = videoPath,
                UseShellExecute = true
            });
        }
    }
}