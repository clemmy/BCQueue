using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BCQueue.ViewModels.CreateProfileVM
{
    public class CPSecondViewModel : ViewModelBase
    {
        Member temp = new Member();
        #region MemberFields
        public BCQueue.Member.pd _preferredDiscipline;

        #endregion

        public ICommand CPNextPageCommand { get; private set; }
        public ICommand CPPreviousPageCommand { get; private set; }
        public ICommand CPEditPageCommand { get; private set; }
        public ICommand CPCreatePlayerCommand { get; private set; }
        
        private static void ExecuteCPNextPageCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPThirdViewModel;
        }

        private static void ExecuteCPPreviousPageCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPFirstViewModel;
        }

        private static void ExecuteCPEditPageCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPEditPlayerViewModel;
        }
        private static void ExecuteCPCreatePlayerCommand()
        {
            //FirstNameField.SetVisibility("True");

        }
        public CPSecondViewModel()
        {
            CPNextPageCommand = new RelayCommand(() => ExecuteCPNextPageCommand());
            CPPreviousPageCommand = new RelayCommand(() => ExecuteCPPreviousPageCommand());
            CPEditPageCommand = new RelayCommand(() => ExecuteCPEditPageCommand());
            CPCreatePlayerCommand = new RelayCommand(() => ExecuteCPCreatePlayerCommand());
        }
    }
}
