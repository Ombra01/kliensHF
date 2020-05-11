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
        public void NavigateToBooksPage() { NavigationService.Navigate(typeof(BooksPage)); }

        public void NavigateToBookDetailsPage(int bookId) { NavigationService.Navigate(typeof(BookDetailsPage), bookId); }

        public void NavigateToBookDetailsPage(string bookName) { NavigationService.Navigate(typeof(BookDetailsPage), bookName); }

        public void NavigateToCharactersPage() { NavigationService.Navigate(typeof(CharactersPage)); }
    }
}
