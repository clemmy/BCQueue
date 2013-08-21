using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;


namespace BCQueue.ViewModels.CreateProfileVM
{
    public class CPFirstViewModel : ViewModelBase
    {
        #region LabelBinding Fields
        private string _clubNameText;
        private int _numRowsText;
        private int _numColumnsText;
        private int _timerValueText;
        int x;
        private int count;
        #endregion

        #region Properties
        public string ClubNameText
        {
            get { return _clubNameText; }
            set
            {
                _clubNameText = value;
                RaisePropertyChanged("ClubNameText");
            }
        }

        public int NumRowsText
        {
            get { return _numRowsText; }
            set
            {
                _numRowsText = value;
                RaisePropertyChanged("NumRowsText");
            }
        }

        public int NumColumnsText
        {
            get { return _numColumnsText; }
            set
            {
                _numColumnsText = value;
                RaisePropertyChanged("NumColumnsText");
            }
        }

        public int TimerValueText
        {
            get { return _timerValueText; }
            set
            {
                _timerValueText = value;
                RaisePropertyChanged("TimerValueText");
            }
        }
        #endregion
        public ICommand CPNextPageCommand { get; private set; }

        private void ExecuteCPNextPageCommand()
        {
            count = 1;
            (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.Profile.ClubName = Convert.ToString(ClubNameText);
            if (String.IsNullOrWhiteSpace(ClubNameText))
            {
                count--;
            }
            if (Int32.TryParse(NumRowsText.ToString(), out x))
            {
                (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.Profile.NumRows = x;
                count++;
            }
            else
            {
                count--;
            }
            if (Int32.TryParse(NumColumnsText.ToString(), out x))
            {
                (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.Profile.NumColumns = x;
                count++;
            }
            else
            {
                count--;
            }
            if (Int32.TryParse(TimerValueText.ToString(), out x))
            {
                (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.Profile.TimerValue = x;
                count++;
            }
            else
            {
                count--;
            }
            if (count == 4)
            {
                (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPSecondViewModel;
                count = 0;
            }
        }
        public CPFirstViewModel()
        {
            CPNextPageCommand = new RelayCommand(() => ExecuteCPNextPageCommand());
        }
    }
}
