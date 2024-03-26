using MES_by_Polytech.View;
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

namespace MES_by_Polytech
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

        private void btWorkshop_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Navigate(new WorkshopPage());
        }

        private void btStorage_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Navigate(new StoragePage());
        }

        private void btHistory_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Navigate(new HistoryPage());
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Navigate(new BrowseGood());
        }
    }
}
