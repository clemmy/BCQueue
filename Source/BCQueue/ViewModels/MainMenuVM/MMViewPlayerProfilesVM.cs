using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.ComponentModel;

namespace BCQueue.ViewModels.MainMenuVM
{
    public class MMViewPlayerProfilesVM:ViewModelBase, INotifyPropertyChanged
    {
        #region Fields and Properties for Label Binding
        private string _nameBoxText;
        private string _genderLabelText;
        private string _skillLevelLabelText;
        private string _preferredDisciplineLabelText;
        private string _gamesWonLabelText;
        private string _gamesLostLabelText;
        private string _totalGamesLabelText;
        private string _aboutMeText;

        public string NameBoxText
        {
            get { return _nameBoxText; }
            set
            {
                _nameBoxText = value;
                RaisePropertyChanged("NameBoxText");
            }
        }
        public string GenderLabelText
        {
            get { return _genderLabelText; }
            set
            {
                _genderLabelText = value;
                RaisePropertyChanged("GenderLabelText");
            }
        }
        public string SkillLevelLabelText
        {
            get { return _skillLevelLabelText; }
            set
            {
                _skillLevelLabelText = value;
                RaisePropertyChanged("SkillLevelLabelText");
            }
        }
        public string PreferredDisciplineLabelText
        {
            get { return _preferredDisciplineLabelText; }
            set
            {
                _preferredDisciplineLabelText = value;
                RaisePropertyChanged("PreferredDisciplineLabelText");
            }
        }
        public string GamesWonLabelText
        {
            get { return _gamesWonLabelText; }
            set
            {
                _gamesWonLabelText = value;
                RaisePropertyChanged("GamesWonLabelText");
            }
        }
        public string GamesLostLabelText
        {
            get { return _gamesLostLabelText; }
            set
            {
                _gamesLostLabelText = value;
                RaisePropertyChanged("GamesLostLabelText");
            }
        }
        public string TotalGamesLabelText
        {
            get { return _totalGamesLabelText; }
            set
            {
                _totalGamesLabelText = value;
                RaisePropertyChanged("TotalGamesLabelText");
            }
        }
        public string AboutMeText
        {
            get { return _aboutMeText; }
            set
            {
                _aboutMeText = value;
                RaisePropertyChanged("AboutMeText");
            }
        }
        #endregion

        public void localCleanUp()
        {
            GenderLabelText = "";
            SkillLevelLabelText = "";
            PreferredDisciplineLabelText = "";
            GamesWonLabelText = "";
            GamesLostLabelText = "";
            TotalGamesLabelText = "";
            AboutMeText = "";
        }
        public void RTHCleanUp()
        {
            localCleanUp();
            NameBoxText = "";
        }
        public MMViewPlayerProfilesVM()
        {
            SearchMembersCommand = new RelayCommand(() => ExecuteSearchMembersCommand());
        }
        public ICommand SearchMembersCommand { get; private set; }
        public void ExecuteSearchMembersCommand() //yet to implement support for multiple members with the same name
        {
            localCleanUp();
            for (int i = 0; i < (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members.Count; i++)
            {
                if ((App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members[i].FullName.Equals(NameBoxText))
                {
                    #region Set labels to the correct text
                    GenderLabelText = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members[i].Gender.ToString();
                    SkillLevelLabelText = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members[i].SkillLevel.ToString();
                    PreferredDisciplineLabelText = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members[i].PreferredDiscipline.ToString();
                    GamesWonLabelText = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members[i].GamesWon.ToString();
                    GamesLostLabelText = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members[i].GamesLost.ToString();
                    TotalGamesLabelText = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members[i].TotalGames.ToString();
                    AboutMeText = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members[i].AboutMe;
                    #endregion
                }
            }
        }
    }
}
