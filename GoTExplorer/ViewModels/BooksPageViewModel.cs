using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using GoTExplorer.Models;
using GoTExplorer.Services;
using GoTExplorer.Views;

namespace GoTExplorer.ViewModels
{
    public class BooksPageViewModel : ViewModelBase
    {
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new BookService();
            var booksList = await service.GetBooksAsync();
            foreach (var item in booksList)
            {
                Books.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToBookDetails(int bookId) { NavigationService.Navigate(typeof(BookDetailsPage), bookId); }
    }
}

