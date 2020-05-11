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

        public void NavigateToBookDetails(int bookId) { NavigationService.Navigate(typeof(BookDetailsPage), bookId); }
    }
}
