using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    ///     Page code behind for the not found page.
    /// </summary>
    public sealed partial class NotFoundPage : Page
    {
        /// <summary>
        ///     Initializes the page.
        /// </summary>
        public NotFoundPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Handles a click event on the new search button.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        public void NewSearchButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToSearchPage();
        }
    }
}
