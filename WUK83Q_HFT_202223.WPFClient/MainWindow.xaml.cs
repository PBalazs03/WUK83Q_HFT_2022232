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

namespace WUK83Q_HFT_202223.WPFClient
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

        private void Button_Click_AutoData(object sender, RoutedEventArgs e)
        {
            AutoWindow aw = new AutoWindow();
            aw.Show();
        }

        private void Button_Click_BrandData(object sender, RoutedEventArgs e)
        {
            BrandWindow bw = new BrandWindow();
            bw.Show();
        }

        private void Button_Click_ConcernData(object sender, RoutedEventArgs e)
        {
            ConcernWindow cw = new ConcernWindow();
            cw.Show();
        }

        private void Button_Click_OwnerData(object sender, RoutedEventArgs e)
        {
            OwnerWindow ow = new OwnerWindow();
            ow.Show();
        }

        private void Button_Click_NONCRUDMETHODS(object sender, RoutedEventArgs e)
        {
            NonCrudWindow nw = new NonCrudWindow();
            nw.Show();
        }
    }
}
