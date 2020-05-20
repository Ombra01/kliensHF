using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Services.NavigationService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GoTExplorer.Views
{
    /// <summary>
    ///     Page code behind for the welcome page.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        /// <summary>
        ///     Initializes the page.
        /// </summary>
        public WelcomePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Navigates the user to the search page.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void ValarMorghulisButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToSearchPage();
        }
    }
}
