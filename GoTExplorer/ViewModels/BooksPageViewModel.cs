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
    /// <summary>
    ///     View model for books page.
    /// </summary>
    public class BooksPageViewModel : ViewModelBase
    {
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        /// <summary>
        ///     Defines what happens when the page is navigated on.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        /// <param name="mode">navigation mode.</param>
        /// <param name="state">state.</param>
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

        /// <summary>
        ///     Controls paging when the next page is requested.
        /// </summary>
        /// <param name="booksListCount">checks the amount of books listed on the current page.</param>
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

        /// <summary>
        ///     Controls paging when the previous page is requested.
        /// </summary>
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

        /// <summary>
        ///     Navigates to a book's details page.
        /// </summary>
        /// <param name="book">the book whose page needs to be opened.</param>
        public void NavigateToBookDetailsPage(Book book)
        {
            string[] urlTokens = book.url.Split('/');
            int bookId = int.Parse(urlTokens[urlTokens.Length - 1]);

            NavigationService.Navigate(typeof(BookDetailsPage), bookId);
        }
    }
}