using GoTExplorer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace GoTExplorer.ViewModels
{
    /// <summary>
    ///     View model for the not found page.
    /// </summary>
    class NotFoundPageViewModel : ViewModelBase
    {
        /// <summary>
        ///     Navigates to the search page.
        /// </summary>
        public void NavigateToSearchPage() { NavigationService.Navigate(typeof(SearchPage)); }
    }
}
