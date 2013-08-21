using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace BCQueue.ViewModels
{
    public class MainViewModel: ViewModelBase, INotifyPropertyChanged
    {
        public Profile Profile { get; set; }//temp for moose

        /// <summary>
        /// holds the instance of the club profile that will be used throughout the program
        /// </summary>
        public Profile MyProfile { get; set; } 
        /// <summary>
        /// holds the members that are currently online (displayed in the SignInView)
        /// </summary>
        public ObservableCollection<Member> OnlinePool { get; set; }
        
        /// <summary>
        /// backing field for HomeButtonVisibility
        /// </summary>
        private string _homeButtonVisibility;
        /// <summary>
        /// property for the visibility of the Home Button that can be found in MainWindow.xaml 
        /// </summary>
        public string HomeButtonVisibility { 
            get { return _homeButtonVisibility; } 
            set 
            {
                if (value == "Collapsed" || value == "Hidden" || value == "Visible")
                {
                    _homeButtonVisibility = value;
                    RaisePropertyChanged("HomeButtonVisibility");
                }
            }
        }

        private ViewModelBase _currentViewModel;

        #region Static Instances of ViewModels

        //Static Instance of CPBaseViewModel
        /// <summary>
        /// Static Instance of CPBaseViewModel
        /// </summary>
        public readonly static CreateProfileVM.CPBaseViewModel _cPBaseViewModel = new CreateProfileVM.CPBaseViewModel();

        //Static Instances in the root ViewModels folder
        /// <summary>
        /// Static Instance of HomeViewModel
        /// </summary>
        public readonly static HomeViewModel _homeViewModel = new HomeViewModel();
        /// <summary>
        /// Static Instance of StartViewModel
        /// </summary>
        public readonly static StartViewModel _startViewModel = new StartViewModel();
      
        //Static Instances in ViewModels/MainMenuVM/
        /// <summary>
        /// Static Instance of MMAboutVM
        /// </summary>
        public readonly static MainMenuVM.MMAboutVM _mMAboutVM = new MainMenuVM.MMAboutVM();
        /// <summary>
        /// Static Instance of MMAddToQueueVM
        /// </summary>
        public readonly static MainMenuVM.MMAddToQueueVM _mMAddToQueueVM = new MainMenuVM.MMAddToQueueVM();
        /// <summary>
        /// Static Instance of MMConfigureClubProfileVM
        /// </summary>
        public readonly static MainMenuVM.MMConfigureClubProfileVM _mMConfigureClubProfileVM = new MainMenuVM.MMConfigureClubProfileVM();
        /// <summary>
        /// Static Instance of MMPlayerSignInVM
        /// </summary>
        public readonly static MainMenuVM.MMPlayerSignInVM _mMPlayerSignInVM = new MainMenuVM.MMPlayerSignInVM();
        /// <summary>
        /// Static Instance of MMViewActiveGamesVM
        /// </summary>
        public readonly static MainMenuVM.MMViewActiveGamesVM _mMViewActiveGamesVM = new MainMenuVM.MMViewActiveGamesVM();
        /// <summary>
        /// Static Instance of MMViewPlayerProfilesVM
        /// </summary>
        public readonly static MainMenuVM.MMViewPlayerProfilesVM _mMViewPlayerProfilesVM = new MainMenuVM.MMViewPlayerProfilesVM();

        #endregion 

        /// <summary>
        /// Holds the CurrentViewModel (which is set as the datacontext of the current view in App.xaml)
        /// Changing this changes the view that is displayed in the GUI.
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }
        
        public ICommand HomeViewCommand { get; private set; }
        public ICommand MMAboutViewCommand { get; private set; }
        public ICommand MMAddToQueueViewCommand { get; private set; }
        public ICommand MMConfigureCPViewCommand { get; private set; }
        public ICommand MMPlayerSignInViewCommand { get; private set; }
        public ICommand MMViewActiveGamesViewCommand { get; private set; }
        public ICommand MMViewPPViewCommand { get; private set; }
        
        /// <summary>
        /// Navigates to the Home View 
        /// </summary>
        private void ExecuteHomeViewCommand()
        {
            CurrentViewModel = MainViewModel._homeViewModel;
            _mMViewPlayerProfilesVM.RTHCleanUp(); //cleans up labels in the profileviewer upon exit
            HomeButtonVisibility = "Collapsed";
        }
        /// <summary>
        /// Navigates to the About View
        /// </summary>
        private void ExecuteMMAboutViewCommand()
        {
            CurrentViewModel = MainViewModel._mMAboutVM;
            HomeButtonVisibility = "Visible";
        }
        /// <summary>
        /// Navigates to the AddToQueue View
        /// </summary>
        private void ExecuteMMAddToQueueViewCommand()
        {
            CurrentViewModel = MainViewModel._mMAddToQueueVM;
            HomeButtonVisibility = "Visible";
        }
        /// <summary>
        /// Navigates to the Configure View
        /// </summary>
        private void ExecuteMMConfigureCPViewCommand()
        {
            CurrentViewModel = MainViewModel._mMConfigureClubProfileVM;
            HomeButtonVisibility = "Visible";
        }
        /// <summary>
        /// Navigates to the PlayerSignIn View
        /// </summary>
        private void ExecuteMMPlayerSignInViewCommand()
        {
            CurrentViewModel = MainViewModel._mMPlayerSignInVM;
            HomeButtonVisibility = "Visible";
        }
        /// <summary>
        /// Navigate to the ActiveGames View
        /// </summary>
        private void ExecuteMMViewActiveGamesViewCommand()
        {
            CurrentViewModel = MainViewModel._mMViewActiveGamesVM;
            HomeButtonVisibility = "Visible";
        }
        /// <summary>
        /// Navigates to the ProfileViewer View
        /// </summary>
        private void ExecuteMMViewPPViewCommand()
        {
            CurrentViewModel = MainViewModel._mMViewPlayerProfilesVM;
            HomeButtonVisibility = "Visible";
        }

     
        /// <summary>
        /// Called in ViewModelLocator's constructor; ViewModelLocator should be declaratively initialised in XAML
        /// </summary>
        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._startViewModel; //begins program with the StartViewModel
            HomeButtonVisibility = "Collapsed"; //initially hidden home button

            Profile = new Profile();//temp for moose

            //creates new instances of the following public properties
            MyProfile = new Profile();
            OnlinePool = new ObservableCollection<Member>();

            HomeViewCommand = new RelayCommand(() => ExecuteHomeViewCommand());
            MMAboutViewCommand = new RelayCommand(() => ExecuteMMAboutViewCommand());
            MMAddToQueueViewCommand = new RelayCommand(() => ExecuteMMAddToQueueViewCommand());
            MMConfigureCPViewCommand = new RelayCommand(() => ExecuteMMConfigureCPViewCommand());
            MMPlayerSignInViewCommand = new RelayCommand(() => ExecuteMMPlayerSignInViewCommand());
            MMViewActiveGamesViewCommand = new RelayCommand(() => ExecuteMMViewActiveGamesViewCommand());
            MMViewPPViewCommand = new RelayCommand(() => ExecuteMMViewPPViewCommand());
        }

        

      

    }
}
