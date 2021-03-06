﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Controls;
using GoTExplorer.Views;
using Template10.Mvvm;

namespace GoTExplorer.ViewModels
{
    /// <summary>
    ///     View model for the welcome page.
    /// </summary>
    class WelcomePageViewModel : ViewModelBase
    {
        /// <summary>
        ///     Navigates to the search page.
        /// </summary>
        public void NavigateToSearchPage() { NavigationService.Navigate(typeof(SearchPage)); }
    }
}
