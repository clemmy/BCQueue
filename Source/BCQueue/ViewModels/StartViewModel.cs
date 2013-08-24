using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BCQueue.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        public StartViewModel()
        {
            ShowLoadClubInterface = new RelayCommand(() => LoadClubInterfaceExecute());
            ShowCreateClubInterface = new RelayCommand(() => CreateClubInterfaceExecute());
        }

        public ICommand ShowCreateClubInterface { get; private set; }
        public ICommand ShowLoadClubInterface { get; private set; }

        /// <summary>
        /// Launches the CreateClubProfile UI, which will guide the user through a set-up process, then serialize it into a .bcq save file
        /// </summary>
        private void CreateClubInterfaceExecute()
        {
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.CurrentViewModel = MainViewModel._cPBaseViewModel;
            temp();

        }

        public static void temp()
        {
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.ClubName = "TFSS Club";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.NumRows = 2;
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.NumColumns = 3;
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.TimerValue = 20;
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[0].FirstName = "Clement";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[0].LastName = "Hoang";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[1].FirstName = "Mustaqeem";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[1].LastName = "Khowaja";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[1].AboutMe = "Hi, I love FF6.";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[2].FirstName = "Joshua";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[2].LastName = "Fontana";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[3].FirstName = "Joshua";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[3].LastName = "Dude";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[4].FirstName = "Aniket";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[4].LastName = "Verma";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[5].FirstName = "Aiket";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[5].LastName = "Vera";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[6].FirstName = "iket";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[6].LastName = "Ver";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[7].FirstName = "ike";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[7].LastName = "ma";

            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.NumColumns = 4;
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.NumRows = 3;
            for (int i = 1; i <= (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.NumCourts; i++)
            {
                (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Courts.Add(new Court(i));
            }
            foreach (Court x in (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Courts)
                x.IsCourtActive = true;
        }

        /// <summary>
        /// Launches the LoadClub UI, which will allow the user to select a .bcq save file to load, then it will be deserialized
        /// </summary>
        private static void LoadClubInterfaceExecute()
        {
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.CurrentViewModel = MainViewModel._homeViewModel;

            //Temporary for testing purposes

            temp();
             
            //End temp

            
            
            
        }

    }
}
