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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoTExplorer.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if ((TypeSelection.SelectedItem as ComboBoxItem).Content.ToString() == "-- Please select --")
            {
                Frame.Navigate(typeof(SearchPage));
            } 
            else if ((TypeSelection.SelectedItem as ComboBoxItem).Content.ToString() == "Book" && string.IsNullOrEmpty(NameSearch.Text))
            {
                //ResultsFrame.Navigate(typeof(BooksPage));
                ViewModel.NavigateToBooksPage();
            }
            else if ((TypeSelection.SelectedItem as ComboBoxItem).Content.ToString() == "Character" && string.IsNullOrEmpty(NameSearch.Text))
            {
                ViewModel.NavigateToCharactersPage();
            }
            /*else
            {
                Frame.Navigate(typeof(WelcomePage));
            }*/

            if ((TypeSelection.SelectedItem as ComboBoxItem).Content.ToString() == "Book" && !string.IsNullOrEmpty(NameSearch.Text))
            {
                ViewModel.NavigateToBookDetailsPage(NameSearch.Text);
            }
            else if ((TypeSelection.SelectedItem as ComboBoxItem).Content.ToString() == "Character" && !string.IsNullOrEmpty(NameSearch.Text))
            {
                ViewModel.NavigateToCharacterDetailsPage(NameSearch.Text);
            }
        }
    }
}
