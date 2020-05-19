using GoTExplorer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace GoTExplorer.ViewModels
{
    class NotFoundPageViewModel : ViewModelBase
    {
        public void NavigateToSearchPage() { NavigationService.Navigate(typeof(SearchPage)); }
    }
}
