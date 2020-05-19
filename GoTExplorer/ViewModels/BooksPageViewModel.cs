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
            int pageNumber = (int)parameter;
            var service = new BookService();
            var booksList = await service.GetBooksAsync(pageNumber);
            foreach (var item in booksList)
            {
                Books.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToNextBooksPage(int booksListCount)
        {
            int newPageNumber;
            if (booksListCount == 10)
            {
                newPageNumber = ++App.currentBooksPageNumber;
            }
            else
            {
                newPageNumber = App.currentBooksPageNumber;
            }

            NavigationService.Navigate(typeof(BooksPage), newPageNumber);
        }

        public void NavigateToPreviousBooksPage()
        {
            int newPageNumber;
            if (App.currentBooksPageNumber > 1)
            {
                newPageNumber = --App.currentBooksPageNumber;
            }
            else
            {
                newPageNumber = 1;
            }

            NavigationService.Navigate(typeof(BooksPage), newPageNumber);
        }

        public void NavigateToBookDetailsPage(Book book)
        {
            string[] urlTokens = book.url.Split('/');
            int bookId = int.Parse(urlTokens[urlTokens.Length - 1]);

            NavigationService.Navigate(typeof(BookDetailsPage), bookId);
        }
    }
}