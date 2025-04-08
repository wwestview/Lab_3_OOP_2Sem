using System;
using System.Collections.ObjectModel; 
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<int> Numbers { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Numbers = new ObservableCollection<int>();
            this.DataContext = this;
        }

        private void GenerateButtons_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Clear();
            if (!int.TryParse(FromTextBox.Text, out int from) || !int.TryParse(ToTextBox.Text, out int to) || !int.TryParse(StepTextBox.Text, out int step) || step <= 0 || from > to)
            {
                MessageBox.Show("Перевірте правильність введення даних.");
                return;
            }

            for (int i = from; i <= to; i += step)
            {
                Numbers.Add(i);
            }
        }

        private void RemoveMultiples_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(MultipleTextBox.Text, out int multiple) || multiple == 0)
            {
                MessageBox.Show("Введіть коректне число.");
                return;
            }

            int removedCount = 0;

            for (int i = Numbers.Count - 1; i >= 0; i--)
            {
                if (Numbers[i] % multiple == 0)
                {
                    Numbers.RemoveAt(i); 
                    removedCount++;
                }
            }

           

            if (removedCount == 0)
            {
                string videoPath = @"C:\Users\Nazar\Desktop\MathAnalys\StudyUni\WpfApp1\WpfApp1\bin\Debug\net8.0-windows\Wide Zelensky Walk.mp4"; // Розгляньте використання відносного шляху або конфігурації

                if (System.IO.File.Exists(videoPath))
                {
                    MessageBox.Show("Кидаю плотний салам!");
                    try 
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = videoPath,
                            UseShellExecute = true 
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не вдалося відкрити відеофайл: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Відеофайл не знайдено:\n" + videoPath);
                }
            }
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.DataContext is int number)
                {
                    if (IsPrime(number))
                    {
                        MessageBox.Show($"{number} — це просте число.");
                    }
                    else
                    {
                        MessageBox.Show($"{number} — це складене число.");
                    }
                }
            }
        }
   
    }
}