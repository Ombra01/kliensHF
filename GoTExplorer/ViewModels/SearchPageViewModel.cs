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
    class SearchPageViewModel : ViewModelBase
    {
        public void NavigateToBooksPage()
        {
            App.currentBooksPageNumber = 1;
            int pageNumber = App.currentBooksPageNumber;
            NavigationService.Navigate(typeof(BooksPage), pageNumber);
        }

        public void NavigateToBookDetailsPage(string bookName) { NavigationService.Navigate(typeof(BookDetailsPage), bookName); }

        public void NavigateToCharactersPage()
        {
            App.currentCharactersPageNumber = 1;
            int pageNumber = App.currentCharactersPageNumber;
            NavigationService.Navigate(typeof(CharactersPage), pageNumber);
        }

        public void NavigateToCharacterDetailsPage(string characterName) { NavigationService.Navigate(typeof(CharacterDetailsPage), characterName); }

        public void NavigateToHousesPage()
        {
            App.currentHousesPageNumber = 1;
            int pageNumber = App.currentHousesPageNumber;
            NavigationService.Navigate(typeof(HousesPage), pageNumber);
        }

        public void NavigateToHouseDetailsPage(string houseName) { NavigationService.Navigate(typeof(HouseDetailsPage), houseName); }

        public void NavigateToSearchPage() { NavigationService.Navigate(typeof(SearchPage)); }

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
