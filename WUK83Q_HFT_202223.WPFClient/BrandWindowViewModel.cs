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

namespace WUK83Q_HFT_202223.WPFClient
{
    class BrandWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;

        

        public Brand SelectedBrand
        {
            get => selectedBrand;
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

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BrandWindowViewModel()
        {

        }
    }
}
