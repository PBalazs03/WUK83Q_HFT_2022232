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
    class ConcernWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Concern> Concerns { get; set; }

        private Concern selectedConcern;

        public Concern SelectedConcern 
        { 
            get { return selectedConcern; } 
            set 
            {
                if(value != null) 
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

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ConcernWindowViewModel()
        {
            if (!IsInDesignMode)
            {
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
            }
        }

    }
}
