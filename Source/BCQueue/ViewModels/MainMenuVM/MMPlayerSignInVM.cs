using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;
using BCQueue.Resources;
using Xceed.Wpf.Toolkit;

namespace BCQueue.ViewModels.MainMenuVM
{
    public class MMPlayerSignInVM:ViewModelBase
    {
        public MMPlayerSignInVM()
        {
        }

        /// <summary>
        /// Determines whether the displayed member should sign in or out, then follows up with the corresponding actions
        /// </summary>
        /// <param name="sender">A parameter of type button is passed through a Click Event in code-behind that calls this method</param>
        public static void SignInOutExecute(Button sender)
        {
            Member m = ((Button)sender).Tag as Member;
            //Changes visual display, sets the model's isOnline property correspondingly, then adds the Member to 
            //an Observable Collection of Online Members
            if (m.IsOnline == false)
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "online"); //sets appropriate avatar
                m.IsOnline = true;
                m.IsBusy = false; //just in case
                (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.OnlinePool.Add(m); 
                MainViewModel._mMAddToQueueVM.AvailablePool.Add(m);
            }
            else
            {
                if (m.IsBusy == false)
                {
                    ((Button)sender).SetResourceReference(Button.BackgroundProperty, "offline"); //sets appropriate avatar
                    (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.OnlinePool.Remove(m);
                    m.IsOnline = false;
                    MainViewModel._mMAddToQueueVM.AvailablePool.Remove(m);
                    //Uses an extension method Sort to sort the ObservableCollection by name and online status (online members preceding, and alphabetical order)
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Unable to sign this player off.\nMake sure the player is not on the queue list or participating in active games.", "Busy Player Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members.Sort((x, y) => x.FullName.CompareTo(y.FullName));
            (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members.Sort((y, x) => x.IsOnline.CompareTo(y.IsOnline));
            
        }
    }
}
