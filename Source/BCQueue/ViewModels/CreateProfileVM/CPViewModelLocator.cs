using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCQueue.ViewModels.CreateProfileVM
{
    class CPViewModelLocator
    {
        private static CPBaseViewModel _mainView;

        public CPViewModelLocator()
        {
            _mainView = new CPBaseViewModel();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CPBaseViewModel MainView
        {
            get { return _mainView; }
        }
    }
}
