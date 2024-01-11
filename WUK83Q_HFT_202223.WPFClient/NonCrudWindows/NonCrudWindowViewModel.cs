using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WUK83Q_HFT_202223.WpfClient;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_202223.WPFClient
{
    class NonCrudWindowViewModel : ObservableRecipient, INotifyPropertyChanged
    {
        private string errorMessage;

        

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        static RestService rest;
        public List<Auto> AutosCRUD { get; set; }
        public List<Brand> BrandCRUD { get; set; }
        public List<Concern> ConcernCRUD { get; set; }
        public List<Concern> OwnerCRUD { get; set; }

        
        public int Id { get; set; }
        public string YOO { get; set; }
        public double AvgCar1 { get; set; }
        public string BrandName { get; set; }
        public string ConcerName { get; set; }
        public char YoO { get; set; }

        public List<Auto.AutoInfo> autoInfosCRUD { get; set; }
        public ObservableCollection<Auto> coll1 { get; set; }
        public ObservableCollection<Auto> coll2 { get; set; }
        public ObservableCollection<Brand> coll3 { get; set; }
        public ObservableCollection<Brand> coll4 { get; set; }
        public ObservableCollection<Brand> coll5 { get; set; }
        public ObservableCollection<Concern> coll6 { get; set; }
        public ObservableCollection<Concern> coll7 { get; set; }
        public ObservableCollection<Concern> coll8 { get; set; }
        public ObservableCollection<Owner> coll9 { get; set; }


        public ICommand AvgCarAgecommand { get;}
        public ICommand YoungestOrOldestCarCommand { get; set; }
        public ICommand BrandWithTheMostCarsCommand { get;}
        public ICommand ModelsOfBrandCommand { get;}
        public ICommand MostBrandConcernCommand { get;}
        
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public NonCrudWindowViewModel()
        {
            if (!IsInDesignMode) 
            {
                
                AvgCar1 = 5.3;
                
                rest = new RestService("http://localhost:21840/", "Auto");

                //coll1 = new ObservableCollection<Auto>();
                //coll2 = new ObservableCollection<Auto>();
                //coll3 = new ObservableCollection<Brand>();
                //coll4 = new ObservableCollection<Brand>();
                //coll5 = new ObservableCollection<Brand>();
                //coll6 = new ObservableCollection<Concern>();
                //coll7 = new ObservableCollection<Concern>();
                //coll8 = new ObservableCollection<Concern>();
                //coll9 = new ObservableCollection<Owner>();

                AvgCarAgecommand = new RelayCommand(() =>
                {
                    
                    AvgCar1 = rest.GetSingle<double>("Auto/average");
                    
                    OnPropertyChanged("AvgCar1");
                    
                    
                });
                YoungestOrOldestCarCommand = new RelayCommand(() =>
                {

                    //AutosCRUD = rest.Get<Auto>($"Auto/youngorold?YoungOrOld={YoO}");
                    //OnPropertyChanged("AutosCRUD");
                });
                BrandWithTheMostCarsCommand = new RelayCommand(() =>
                {
                   
                    BrandName = rest.GetSingle<string>("Brand/brandwiththemostcars");
                    OnPropertyChanged("BrandName");
                });
                ModelsOfBrandCommand = new RelayCommand(() =>
                {
                    
                    BrandCRUD = rest.Get<Brand>("Brand/modelsofbrand");
                    foreach (var item in BrandCRUD)
                    {
                        coll4.Add(item);
                    }
                });
                MostBrandConcernCommand = new RelayCommand(() =>
                {
                    
                    ConcerName = rest.GetSingle<string>("Concern/mostbrandconcern");
                    OnPropertyChanged("ConcernName");
                });
                
            }
        }

    }
}
