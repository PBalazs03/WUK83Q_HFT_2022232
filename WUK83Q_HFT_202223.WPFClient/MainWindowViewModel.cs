using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;
using Microsoft.VisualBasic;
using WUK83Q_HFT_202223.WpfClient;
using System.Windows.Automation;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;
using System.Windows.Navigation;

namespace WUK83Q_HFT_202223.WPFClient
{
    internal class MainWindowViewModel : ObservableRecipient
    {
        #region ErrorSection
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        #endregion

        // AUTO
        #region Auto
        public RestCollection<Auto> Autos { get; set; }

        private Auto selectedAuto;
        public Auto SelectedAuto
        {
            get { return selectedAuto; }
            set
            {
                if (value != null)
                {
                    selectedAuto = new Auto()
                    {
                        AutoId = value.AutoId,
                        Brand = value.Brand,
                        Type = value.Type,
                        Vintage = value.Vintage,
                        OwnerId = value.OwnerId,
                        BrandId = value.BrandId,
                        _Owner = value._Owner,
                        _Brand = value._Brand,
                    };
                    OnPropertyChanged();
                    (DeleteAutoCommand as RelayCommand).NotifyCanExecuteChanged();


                }
            }
        }
        public ICommand CreateAutoCommand { get; set; }
        public ICommand DeleteAutoCommand { get; set; }
        public ICommand UpdateAutoCommand { get; set; }
        #endregion

        // BRAND
        #region Brand
        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        BrandId = value.BrandId,
                        BrandName = value.BrandName,
                        OriginOfBrand = value.OriginOfBrand,
                        BornOfBrand = value.BornOfBrand,
                        IsProducingFullyElectricCars = value.IsProducingFullyElectricCars,
                        HasFormula1Team = value.HasFormula1Team,
                        ConcernId = value.ConcernId,
                        _Concern = value._Concern,
                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }
        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        #endregion

        // CONCERN
        #region Concern
        public RestCollection<Concern> Concerns { get; set; }

        private Concern selectedConcern;
        public Concern SelectedConcern
        {
            get { return selectedConcern; }
            set
            {
                if (value != null)
                {
                    selectedConcern = new Concern()
                    {
                        ConcernId = value.ConcernId,
                        ConcernName = value.ConcernName,
                        BornOfConcern = value.BornOfConcern,
                        CountryOfConcern = value.CountryOfConcern,
                        PositionInRanking = value.PositionInRanking,
                    };
                    OnPropertyChanged();
                    (DeleteConcernCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }
        public ICommand CreateConcernCommand { get; set; }
        public ICommand DeleteConcernCommand { get; set; }
        public ICommand UpdateConcernCommand { get; set; }
        #endregion

        // OWNER
        #region Owner
        public RestCollection<Owner> Owners { get; set; }

        private Owner selectedOwner;
        public Owner SelectedOwner
        {
            get { return selectedOwner; }
            set
            {
                if (value != null)
                {
                    selectedOwner = new Owner()
                    {
                        Name = value.Name,
                        BirthDate = value.BirthDate,
                        BirthPlace = value.BirthPlace,
                        OwnerId = value.OwnerId
                    };
                    OnPropertyChanged();
                    (DeleteOwnerCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }
        public ICommand CreateOwnerCommand { get; set; }
        public ICommand DeleteOwnerCommand { get; set; }
        public ICommand UpdateOwnerCommand { get; set; }
        #endregion

        #region NONCRUD
        static RestService rest;
        public List<Auto> AutosCRUD { get; set; }
        public List<Brand> BrandCRUD { get; set; }
        public List<Concern> ConcernCRUD { get; set; }
        public List<Concern> OwnerCRUD { get; set; }
        public List<Auto.AutoInfo> autoInfosCRUD { get; set; }
        public ObservableCollection<Auto> coll1 { get; set; }
        public ObservableCollection<Auto> coll2 { get; set; }
        public ObservableCollection<Auto> coll3 { get; set; }
        public ObservableCollection<Brand> coll4 { get; set; }
        public ObservableCollection<Brand> coll5 { get; set; }
        public ObservableCollection<Brand> coll6 { get; set; }
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



        #endregion

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                // AUTO
                #region Auto
                Autos = new RestCollection<Auto>("http://localhost:21840/", "auto", "hub");
                CreateAutoCommand = new RelayCommand(() =>
                {
                    Autos.Add(new Auto()
                    {
                        AutoId = SelectedAuto.AutoId,
                        Brand = SelectedAuto.Brand,
                        Type = SelectedAuto.Type,
                        Vintage = SelectedAuto.Vintage,
                        OwnerId = SelectedAuto.OwnerId,
                        BrandId = SelectedAuto.BrandId,
                    });
                });

                UpdateAutoCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Autos.Update(SelectedAuto);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteAutoCommand = new RelayCommand(() =>
                {
                    Autos.Delete(SelectedAuto.AutoId);
                }
                , () =>
                {
                    return SelectedAuto != null;
                }
                );

                SelectedAuto = new Auto();
                #endregion


                // BRAND
                #region Brand

                Brands = new RestCollection<Brand>("http://localhost:21840/", "brand", "hub");
                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        BrandId = SelectedBrand.BrandId,
                        BrandName = SelectedBrand.BrandName,
                        OriginOfBrand = SelectedBrand.OriginOfBrand,
                        BornOfBrand = SelectedBrand.BornOfBrand,
                        IsProducingFullyElectricCars = SelectedBrand.IsProducingFullyElectricCars,
                        HasFormula1Team = SelectedBrand.HasFormula1Team,
                        ConcernId = SelectedBrand.ConcernId,

                    });
                });

                UpdateBrandCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Brands.Update(SelectedBrand);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteBrandCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.BrandId);
                }
                , () =>
                {
                    return SelectedBrand != null;
                }
                );

                SelectedBrand = new Brand();
                #endregion


                // CONCERN
                #region Concern

                Concerns = new RestCollection<Concern>("http://localhost:21840/", "concern", "hub");
                CreateConcernCommand = new RelayCommand(() =>
                {
                    Concerns.Add(new Concern()
                    {
                        ConcernId = SelectedConcern.ConcernId,
                        ConcernName = SelectedConcern.ConcernName,
                        BornOfConcern = SelectedConcern.BornOfConcern,
                        CountryOfConcern = SelectedConcern.CountryOfConcern,
                        PositionInRanking = SelectedConcern.PositionInRanking,
                    });
                });

                UpdateConcernCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Concerns.Update(SelectedConcern);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteConcernCommand = new RelayCommand(() =>
                {
                    Concerns.Delete(SelectedConcern.ConcernId);
                }
                , () =>
                {
                    return SelectedConcern != null;
                }
                );
                SelectedConcern = new Concern();
                #endregion

                // OWNER
                #region Owner

                Owners = new RestCollection<Owner>("http://localhost:21840/", "owner", "hub");

                CreateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Add(new Owner()
                    {
                        OwnerId = SelectedOwner.OwnerId,
                        Name = SelectedOwner.Name,
                        BirthDate = SelectedOwner.BirthDate,
                        BirthPlace = SelectedOwner.BirthPlace,

                    });
                });

                UpdateOwnerCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Owners.Update(SelectedOwner);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Delete(SelectedOwner.OwnerId);
                }
                , () =>
                {
                    return SelectedOwner != null;
                }
                );
                SelectedOwner = new Owner();

                #endregion

                #region NONCRUD
                coll1 = new ObservableCollection<Auto>();
                coll2 = new ObservableCollection<Auto>();
                coll3 = new ObservableCollection<Auto>();
                coll4 = new ObservableCollection<Brand>();
                coll5 = new ObservableCollection<Brand>();
                coll6 = new ObservableCollection<Brand>();
                coll7 = new ObservableCollection<Concern>();
                coll8 = new ObservableCollection<Concern>();
                coll9 = new ObservableCollection<Owner>();
                rest = new RestService("http://localhost:21840/");

                NONCRUD1command = new RelayCommand(() => 
                {
                    coll1.Clear();
                    AutosCRUD = rest.Get<Auto>("");
                    foreach (var item in AutosCRUD)
                    {
                        coll1.Add(item);
                    }
                });
                NONCRUD2command = new RelayCommand(() =>
                {
                    coll2.Clear();
                    AutosCRUD = rest.Get<Auto>("");
                    foreach (var item in AutosCRUD)
                    {
                        coll2.Add(item);
                    }
                });
                NONCRUD3command = new RelayCommand(() =>
                {
                    coll3.Clear();
                    AutosCRUD = rest.Get<Auto>("");
                    foreach (var item in AutosCRUD)
                    {
                        coll3.Add(item);
                    }
                });
                NONCRUD4command = new RelayCommand(() =>
                {
                    coll4.Clear();
                    BrandCRUD = rest.Get<Brand>("");
                    foreach (var item in BrandCRUD)
                    {
                        coll4.Add(item);
                    }
                });
                NONCRUD5command = new RelayCommand(() =>
                {
                    coll5.Clear();
                    BrandCRUD = rest.Get<Brand>("");
                    foreach (var item in BrandCRUD)
                    {
                        coll5.Add(item);
                    }
                });
                NONCRUD6command = new RelayCommand(() =>
                {
                    coll6.Clear();
                    BrandCRUD = rest.Get<Brand>("");
                    foreach (var item in BrandCRUD)
                    {
                        coll6.Add(item);
                    }
                });
                NONCRUD7command = new RelayCommand(() =>
                {
                    coll7.Clear();
                    ConcernCRUD = rest.Get<Concern>("");
                    foreach (var item in ConcernCRUD)
                    {
                        coll7.Add(item);
                    }
                });
                NONCRUD8command = new RelayCommand(() =>
                {
                    coll8.Clear();
                    ConcernCRUD = rest.Get<Concern>("");
                    foreach (var item in ConcernCRUD)
                    {
                        coll8.Add(item);
                    }
                });
                //NONCRUD9command = new RelayCommand(() =>
                //{
                //    coll9.Clear();
                //    OwnerCRUD = rest.Get<Owner>("");
                //});
                #endregion


            }
        }
    }
}
