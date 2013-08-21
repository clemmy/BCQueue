using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace BCQueue.ViewModels.MainMenuVM
{
    public class MMViewActiveGamesVM:ViewModelBase
    {
        public MMViewActiveGamesVM()
        {
            Hey = new RelayCommand(() => ExecuteHey());
        }

        public ICommand Hey { get; set; }
        public void ExecuteHey()
        {
            MessageBox.Show("hey");
        }

    }
}
