using GoTExplorer.Models;
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
    ///     Page code behind for the books page.
    /// </summary>
    public sealed partial class HousesPage : Page
    {
        /// <summary>
        ///     Initializes the page.
        /// </summary>
        public HousesPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Handles a click event on a house list.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void House_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToHouseDetailsPage((House)e.ClickedItem);
        }

        /// <summary>
        ///     Handles a click event on the next page button.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToNextHousesPage(HouseList.Items.Count);
        }

        /// <summary>
        ///     Handles a click event on the previous page button.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToPreviousHousesPage();
        }
    }
}
