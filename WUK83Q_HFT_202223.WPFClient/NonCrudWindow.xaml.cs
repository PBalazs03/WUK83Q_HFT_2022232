using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Shapes;
using WUK83Q_HFT_202223.WpfClient;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_202223.WPFClient
{
    /// <summary>
    /// Interaction logic for NonCrudWindow.xaml
    /// </summary>
    ///

    


    public partial class NonCrudWindow : Window
    {

        static RestService rest;
        public List<Auto> autosCRUD { get; set; }
        //public List<Auto.Aut> processorInfosCRUD { get; set; }
        public ObservableCollection<Auto> collection { get; set; }
        //public ObservableCollection<Auto.AutoInfo> collection2 { get; set; }
        //public CompositeCollection compositeCollection { get; set; }

        public NonCrudWindow()
        {
            InitializeComponent();
            DataContext = this;
            rest = new RestService("");


        }
    }
}
