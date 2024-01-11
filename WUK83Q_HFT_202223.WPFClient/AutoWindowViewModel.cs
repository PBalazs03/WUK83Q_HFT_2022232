using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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
    class AutoWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Auto> Autos { get; set; }

        private Auto selectedAuto;

        public Auto SelectedAuto 
        { 
            get {  return selectedAuto; } 
            set
            {
                if(value != null)
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

        

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public AutoWindowViewModel()
        {
            if (!IsInDesignMode)
            {
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
                    }) ;
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
            }

        }
    }
}
