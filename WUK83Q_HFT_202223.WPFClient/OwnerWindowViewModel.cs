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
using System.Xml.Linq;
using System.Windows.Input;
using System.Windows;

namespace WUK83Q_HFT_202223.WPFClient
{
    class OwnerWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

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
                        OwnerId = value.OwnerId,
                        Name = value.Name,
                        BirthDate = value.BirthDate,
                        BirthPlace = value.BirthPlace
                        
                    };
                    OnPropertyChanged();
                    (DeleteOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            } 
        }
        public ICommand CreateOwnerCommand { get; set; }
        public ICommand DeleteOwnerCommand { get; set; }
        public ICommand UpdateOwnerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public OwnerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
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
