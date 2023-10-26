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
    class NonCrudWindowViewModel : ObservableRecipient
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


        public ICommand NONCRUD1command { get; set; }
        public ICommand NONCRUD2command { get; set; }
        public ICommand NONCRUD3command { get; set; }
        public ICommand NONCRUD4command { get; set; }
        public ICommand NONCRUD5command { get; set; }
        public ICommand NONCRUD6command { get; set; }
        public ICommand NONCRUD7command { get; set; }
        public ICommand NONCRUD8command { get; set; }
        public ICommand NONCRUD9command { get; set; }

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
                coll1 = new ObservableCollection<Auto>();
                coll2 = new ObservableCollection<Auto>();
                coll3 = new ObservableCollection<Brand>();
                coll4 = new ObservableCollection<Brand>();
                coll5 = new ObservableCollection<Brand>();
                coll6 = new ObservableCollection<Concern>();
                coll7 = new ObservableCollection<Concern>();
                coll8 = new ObservableCollection<Concern>();
                coll9 = new ObservableCollection<Owner>();
                rest = new RestService("http://localhost:21840/");

                NONCRUD1command = new RelayCommand(() =>
                {
                    coll1.Clear();
                    AutosCRUD = rest.Get<Auto>("Auto/average");
                    foreach (var item in AutosCRUD)
                    {
                        coll1.Add(item);
                    }
                });
                NONCRUD2command = new RelayCommand(() =>
                {
                    coll2.Clear();
                    AutosCRUD = rest.Get<Auto>("Auto/youngorold");
                    foreach (var item in AutosCRUD)
                    {
                        coll2.Add(item);
                    }
                });
                NONCRUD3command = new RelayCommand(() =>
                {
                    coll3.Clear();
                    BrandCRUD = rest.Get<Brand>("Brand/brandwiththemostcars");
                    foreach (var item in BrandCRUD)
                    {
                        coll3.Add(item);
                    }
                });
                NONCRUD4command = new RelayCommand(() =>
                {
                    coll4.Clear();
                    BrandCRUD = rest.Get<Brand>("Brand/modelsofbrand");
                    foreach (var item in BrandCRUD)
                    {
                        coll4.Add(item);
                    }
                });
                NONCRUD5command = new RelayCommand(() =>
                {
                    coll5.Clear();
                    BrandCRUD = rest.Get<Brand>("Brand/brandsofconcern");
                    foreach (var item in BrandCRUD)
                    {
                        coll5.Add(item);
                    }
                });
                NONCRUD6command = new RelayCommand(() =>
                {
                    coll6.Clear();
                    ConcernCRUD = rest.Get<Concern>("Concern/mostbrandconcern");
                    foreach (var item in ConcernCRUD)
                    {
                        coll6.Add(item);
                    }
                });
                NONCRUD7command = new RelayCommand(() =>
                {
                    coll7.Clear();
                    ConcernCRUD = rest.Get<Concern>("Concern/countrysconcern");
                    foreach (var item in ConcernCRUD)
                    {
                        coll7.Add(item);
                    }
                });
                NONCRUD8command = new RelayCommand(() =>
                {
                    coll8.Clear();
                    ConcernCRUD = rest.Get<Concern>("Concern/concernlist");
                    foreach (var item in ConcernCRUD)
                    {
                        coll8.Add(item);
                    }
                });
                //NONCRUD9command = new RelayCommand(() =>
                //{
                //    coll9.Clear();
                //    OwnerCRUD = rest.Get<Owner>("Owner/ownerwiththemostcars");
                //});
            }
        }

    }
}
