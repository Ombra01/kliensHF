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
    }
}
