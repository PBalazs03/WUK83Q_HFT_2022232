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
            }
        }
    }
}
