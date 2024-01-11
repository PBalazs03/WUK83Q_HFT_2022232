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
using WUK83Q_HFT_202223.WPFClient.NonCrudWindows;
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
        public List<Brand> brandCRUD { get; set; }
        public List<Concern> concernCRUD { get; set; }
        public List<Owner> ownerCRUD { get; set; }
        //public List<Auto.Aut> processorInfosCRUD { get; set; }
        public ObservableCollection<Auto> collection { get; set; }
        public ObservableCollection<Brand> collection2 { get; set; }
        public ObservableCollection<Concern> collection3 { get; set; }
        public ObservableCollection<Owner> collection4 { get; set; }
        public ObservableCollection<Auto.AutoInfo> collectionnn { get; set; }
        public CompositeCollection compositeCollection { get; set; }

        public NonCrudWindow()
        {
            InitializeComponent();
            DataContext = this;
            rest = new RestService("http://localhost:21840/");
            collection = new ObservableCollection<Auto>();
            collection2 = new ObservableCollection<Brand>();
            collection3 = new ObservableCollection<Concern>();
            collection4 = new ObservableCollection<Owner>();


        }
        //  BUTTONS
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AverageCarAge aca = new AverageCarAge();
            aca.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            YoungestOrOldestCar yooc = new YoungestOrOldestCar();
            yooc.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BrandWithTheMostCars bwtmc = new BrandWithTheMostCars();
            bwtmc.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ModelsOfbBrand modelsOfbBrand = new ModelsOfbBrand();
            modelsOfbBrand.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.collection2.Clear();
            brandCRUD = rest.Get<Brand>("Brand/brandsofconcern");
            foreach (var item in collection2)
            {
                collection2.Add(item);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MostBrandConcern mbc = new MostBrandConcern();
            mbc.Show();
        }

        

        

        
    }
}
