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
    ///     Page code behind for the characters page.
    /// </summary>
    public sealed partial class CharactersPage : Page
    {
        /// <summary>
        ///     Initializes the page.
        /// </summary>
        public CharactersPage()
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
        ///     Handles a click event on the next page button.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToNextCharactersPage(CharacterList.Items.Count);
        }

        /// <summary>
        ///     Handles a click event on the previous page button.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToPreviousCharactersPage();
        }
    }
}
