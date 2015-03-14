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

namespace PZW_Domaci1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.LiviBotun.Click += new RoutedEventHandler(LiviBotun_Click);
            this.DesniBotun.Click += new RoutedEventHandler(DesniBotun_Click);

        }

        private void DesniBotun_Click(object sender, RoutedEventArgs e)
        {
            this.DesniRectangleContainer.Children.Add(new Rectangle()
            {
                Height = 40,
                Margin = new Thickness(50, 10, 50, 10),
                Fill = Brushes.Yellow
            });
        }

        private void LiviBotun_Click(object sender, RoutedEventArgs e)
        {
            this.LiviRectangleContainer.Children.Add(new Rectangle()
            {
                Width = 70,
                Height = 70,
                Margin = new Thickness(5),
                Fill = Brushes.Green
            });
        }
    }
}
