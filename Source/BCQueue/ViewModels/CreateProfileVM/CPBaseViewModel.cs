using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BCQueue.ViewModels.CreateProfileVM
{
    public class CPBaseViewModel : ViewModelBase
    {
        private ViewModelBase _currentCPViewModel;

        #region Static Instances of ViewModels
        //Static Instances of ViewModels in CreateProfileVM 
        public readonly static CreateProfileVM.CPFirstViewModel _cPFirstViewModel = new CreateProfileVM.CPFirstViewModel();
        public readonly static CreateProfileVM.CPSecondViewModel _cPSecondViewModel = new CreateProfileVM.CPSecondViewModel();
        public readonly static CreateProfileVM.CPThirdViewModel _cPThirdViewModel = new CreateProfileVM.CPThirdViewModel();
        public readonly static CreateProfileVM.CPEditPlayerViewModel _cPEditPlayerViewModel = new CreateProfileVM.CPEditPlayerViewModel();
        #endregion

        public ViewModelBase CurrentCPViewModel
        {
            get
            {
                return _currentCPViewModel;
            }
            set
            {
                if (_currentCPViewModel == value)
                    return;
                _currentCPViewModel = value;
                RaisePropertyChanged("CurrentCPViewModel");
            }
        }

        public ICommand CPFirstViewCommand { get; private set; }
        public ICommand CPSecondViewCommand { get; private set; }
        public ICommand CPThirdViewCommand { get; private set; }
        public ICommand CPEditPlayerViewCommand { get; private set; }

        private static void ExecuteCPFirstViewCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPFirstViewModel;
        }
        private static void ExecuteCPSecondViewCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPSecondViewModel;
        }
        private static void ExecuteCPThirdViewCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPThirdViewModel;
        }
        private static void ExecuteCPEditPlayerViewCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPEditPlayerViewModel;
        }

        public CPBaseViewModel()
        {
            CurrentCPViewModel = CPBaseViewModel._cPFirstViewModel;
            CPFirstViewCommand = new RelayCommand(() => ExecuteCPFirstViewCommand());
            CPSecondViewCommand = new RelayCommand(() => ExecuteCPSecondViewCommand());
            CPThirdViewCommand = new RelayCommand(() => ExecuteCPThirdViewCommand());
            CPEditPlayerViewCommand = new RelayCommand(() => ExecuteCPEditPlayerViewCommand());
        }
    }
}
