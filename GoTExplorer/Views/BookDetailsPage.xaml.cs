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
using GoTExplorer.Models;

namespace GoTExplorer.Views
{
    /// <summary>
    ///     Page code behind for a book's details page.
    /// </summary>
    public sealed partial class BookDetailsPage : Page
    {
        /// <summary>
        ///     Initializes the page.
        /// </summary>
        public BookDetailsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Handles a click event on a character list.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void Character_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToCharacterDetailsPage((Character)e.ClickedItem);
        }

        /// <summary>
        ///     Handles a click event on the new search button.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void NewSearchButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToSearchPage();
        }
    }
}
