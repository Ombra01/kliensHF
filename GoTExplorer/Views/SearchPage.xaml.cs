using GoTExplorer.Models;
using GoTExplorer.ViewModels;
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
    ///     Page code behind for the search page.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        /// <summary>
        ///     Initializes the page.
        /// </summary>
        public SearchPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Handles a click event on the search button. Starts the search.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SearchNavigation((TypeSelection.SelectedItem as ComboBoxItem).Content.ToString(), NameSearch.Text);
        }
    }
}
