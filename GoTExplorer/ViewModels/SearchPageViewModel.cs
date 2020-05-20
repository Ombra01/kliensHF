using GoTExplorer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Controls;
using Template10.Mvvm;

namespace GoTExplorer.ViewModels
{
    /// <summary>
    ///     View model for the search page.
    /// </summary>
    class SearchPageViewModel : ViewModelBase
    {
        /// <summary>
        ///     Navigates to the books page.
        /// </summary>
        public void NavigateToBooksPage()
        {
            App.currentBooksPageNumber = 1;
            int pageNumber = App.currentBooksPageNumber;
            NavigationService.Navigate(typeof(BooksPage), pageNumber);
        }

        /// <summary>
        ///     Navigates to a book's details page.
        /// </summary>
        /// <param name="bookName">the name of the book whose page needs to be opened.</param>
        public void NavigateToBookDetailsPage(string bookName) { NavigationService.Navigate(typeof(BookDetailsPage), bookName); }

        /// <summary>
        ///     Navigates to the characters page.
        /// </summary>
        public void NavigateToCharactersPage()
        {
            App.currentCharactersPageNumber = 1;
            int pageNumber = App.currentCharactersPageNumber;
            NavigationService.Navigate(typeof(CharactersPage), pageNumber);
        }

        /// <summary>
        ///     Navigates to a character's details page.
        /// </summary>
        /// <param name="characterName">the name of the character whose page needs to be opened.</param>
        public void NavigateToCharacterDetailsPage(string characterName) { NavigationService.Navigate(typeof(CharacterDetailsPage), characterName); }

        /// <summary>
        ///     Navigates to the houses page.
        /// </summary>
        public void NavigateToHousesPage()
        {
            App.currentHousesPageNumber = 1;
            int pageNumber = App.currentHousesPageNumber;
            NavigationService.Navigate(typeof(HousesPage), pageNumber);
        }

        /// <summary>
        ///     Navigates to a house's details page.
        /// </summary>
        /// <param name="houseName">the name of the house whose page needs to be opened.</param>
        public void NavigateToHouseDetailsPage(string houseName) { NavigationService.Navigate(typeof(HouseDetailsPage), houseName); }

        /// <summary>
        ///     Navigates to the search page.
        /// </summary>
        public void NavigateToSearchPage() { NavigationService.Navigate(typeof(SearchPage)); }

        /// <summary>
        ///     Checks what was searched and decides which page needs to be opened.
        /// </summary>
        /// <param name="searchType">the type the user searched for.</param>
        /// <param name="searchName">the search string.</param>
        public void SearchNavigation(string searchType, string searchName)
        {
            if (searchType == "-- Please select --")
            {
                NavigateToSearchPage();
            }
            else if (searchType == "Book" && string.IsNullOrEmpty(searchName))
            {
                NavigateToBooksPage();
            }
            else if (searchType == "Character" && string.IsNullOrEmpty(searchName))
            {
                NavigateToCharactersPage();
            }
            else if (searchType == "House" && string.IsNullOrEmpty(searchName))
            {
                NavigateToHousesPage();
            }

            if (searchType == "Book" && !string.IsNullOrEmpty(searchName))
            {
                NavigateToBookDetailsPage(searchName);
            }
            else if (searchType == "Character" && !string.IsNullOrEmpty(searchName))
            {
                NavigateToCharacterDetailsPage(searchName);
            }
            else if (searchType == "House" && !string.IsNullOrEmpty(searchName))
            {
                NavigateToHouseDetailsPage(searchName);
            }
        }
    }
}
