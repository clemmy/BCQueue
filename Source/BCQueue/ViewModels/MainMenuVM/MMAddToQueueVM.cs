using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Collections.ObjectModel;
using DragDrop = GongSolutions.Wpf.DragDrop.DragDrop;
using GongSolutions.Wpf.DragDrop;
using System.Windows.Media;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;


namespace BCQueue.ViewModels.MainMenuVM
{
    public class MMAddToQueueVM : ViewModelBase, IDropTarget
    {
        /// <summary>
        /// List of players who are currently waiting on the queue; Will be displayed in the Active Games view
        /// </summary>
        public ObservableCollection<ObservableCollection<ObservableCollection<Member>>> QueueList;

        /// <summary>
        /// List of players who are not in any active games nor waiting on the queue
        /// </summary>
        public ObservableCollection<Member> AvailablePool { get; set; }


        /* 
         * Each one of these ObservableCollections should logically only hold 1 Member object.
         * The code is written this way as a workaround for the limitations of gong-wpf's drag'n'drop library.
         * This will likely be changed in the future.
         */

        public ObservableCollection<Member> Player1 { get; set; }
        public ObservableCollection<Member> Player2 { get; set; }
        public ObservableCollection<Member> Player3 { get; set; }
        public ObservableCollection<Member> Player4 { get; set; }

        #region drop handlers
        /// <summary>
        /// Similar to the default except it doesn't allow drop when IsDraggedIntoQueue is true
        /// </summary>
        /// <param name="dropInfo"></param>
        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            if (IsDraggedIntoQueue(dropInfo))
            {
                if (GongSolutions.Wpf.DragDrop.DefaultDropHandler.GetList(dropInfo.TargetCollection).Count != 0)
                {
                    return;
                }
            }
            if (GongSolutions.Wpf.DragDrop.DefaultDropHandler.CanAcceptData(dropInfo))
            {
                dropInfo.Effects = DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }
        }

        /// <summary>
        /// Moves the data upon drop
        /// </summary>
        /// <param name="dropInfo"></param>
        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            var insertIndex = dropInfo.InsertIndex;
            var destinationList = GongSolutions.Wpf.DragDrop.DefaultDropHandler.GetList(dropInfo.TargetCollection);
            var data = GongSolutions.Wpf.DragDrop.DefaultDropHandler.ExtractData(dropInfo.Data);
            var sourceList = GongSolutions.Wpf.DragDrop.DefaultDropHandler.GetList(dropInfo.DragInfo.SourceCollection);

            foreach (var o in data)
            {
                var index = sourceList.IndexOf(o);

                if (index != -1)
                {
                    sourceList.RemoveAt(index);

                    if (sourceList == destinationList && index < insertIndex)
                    {
                        --insertIndex;
                    }
                }
            }

            foreach (var o in data)
            {
                destinationList.Insert(insertIndex++, o);
                //sets isBusy to true when dragged into queue and sets isBusy to false when dragged out of queue
                if (IsDraggedIntoQueue(dropInfo))
                {
                    ((Member)o).IsBusy = true;
                }
                else
                {
                    ((Member)o).IsBusy = false;
                }
            }
        }

        /// <summary>
        /// Returns true if the VisualTarget in the DropInfo is named Player1, Player2, Player3, or Player4
        /// </summary>
        /// <param name="dropInfo"></param>
        /// <returns></returns>
        bool IsDraggedIntoQueue(IDropInfo dropInfo)
        {
            string name = ((FrameworkElement)(dropInfo.VisualTarget)).Name;
            if (name == "Player1" || name == "Player2" || name == "Player3" || name == "Player4")
                return true;
            else
                return false;
        }
        #endregion

        

        /// <summary>
        /// Adds a group of 2 teams onto the queue list
        /// </summary>
        public ICommand AddToQueueCommand { get; private set; }

        /// <summary>
        /// Execute method for AddToQueueCommand
        /// </summary>
        private void ExecuteAddToQueueCommand()
        {
            ObservableCollection<Member> temp = new ObservableCollection<Member>();
            
            //This condition indicates that a doubles games or singles game will occur
            if ((GetTeam1().Count==GetTeam2().Count)&&GetTeam1().Count!=0)
            {
                ObservableCollection<ObservableCollection<Member>> group = new ObservableCollection<ObservableCollection<Member>>();//add both
                group.Add(GetTeam1());
                group.Add(GetTeam2());

                #region Clear the DragIn boxes in the GUI
                Player1.Clear(); 
                Player2.Clear();
                Player3.Clear();
                Player4.Clear();
                #endregion

                QueueList.Add(group);
                Xceed.Wpf.Toolkit.MessageBox.Show("Successfully added to queue!","Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);


            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("A game must consist of either 2 or 4 players.","Incorrect Team Size Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        /// <summary>
        /// Returns an ObservableCollection of Team1 (players 1 and 2)
        /// </summary>
        /// <returns>ObservableCollection of Team1 (players 1 and 2)</returns>
        private ObservableCollection<Member> GetTeam1()
        {
            ObservableCollection<Member> temp = new ObservableCollection<Member>();
            if (Player1.Count>0)
            {
                temp.Add(Player1[0]);
            }
            if (Player2.Count>0)
            {
                temp.Add(Player2[0]);
            }
            return temp;
        }

        /// <summary>
        /// Returns an ObservableCollection of Team2 (players 3 and 4)
        /// </summary>
        /// <returns>ObservableCollection of Team2 (players 3 and 4)</returns>
        private ObservableCollection<Member> GetTeam2()
        {
            ObservableCollection<Member> temp = new ObservableCollection<Member>();
            if (Player3.Count>0)
            {
                temp.Add(Player3[0]);
            }
            if (Player4.Count>0)
            {
                temp.Add(Player4[0]);
            }
            return temp;
        }

        /// <summary>
        /// This constructor initializes all the ObservableCollection properties in the ViewModel to new, empty ones
        /// </summary>
        public MMAddToQueueVM()
        {
            AvailablePool = new ObservableCollection<Member>();
            Player1 = new ObservableCollection<Member>();
            Player2 = new ObservableCollection<Member>();
            Player3 = new ObservableCollection<Member>();
            Player4 = new ObservableCollection<Member>();
            QueueList = new ObservableCollection<ObservableCollection<ObservableCollection<Member>>>();
            AddToQueueCommand = new RelayCommand(() => ExecuteAddToQueueCommand());


        }
    }
}
