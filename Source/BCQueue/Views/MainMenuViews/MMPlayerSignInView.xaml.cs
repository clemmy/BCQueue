using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace BCQueue.Views.MainMenuViews
{
    /// <summary>
    /// Interaction logic for MMPlayerSignInView.xaml
    /// </summary>
    public partial class MMPlayerSignInView : UserControl
    {
        public MMPlayerSignInView()
        {
            InitializeComponent();
            if ((App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members != null)
                MembersSignInList.DataContext = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members;
        }

        private void MemberClicked(object sender, EventArgs e)
        {
            BCQueue.ViewModels.MainMenuVM.MMPlayerSignInVM.SignInOutExecute((Button)sender);
        }

        private void Button_Initialized(object sender, EventArgs e)
        {
            Member m = ((Button)sender).Tag as Member;
            if (m.IsOnline == false)
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "offline");
            }
            else
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "online");
            }
        }

    }
}
