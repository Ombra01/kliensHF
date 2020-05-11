using GoTExplorer.Models;
using GoTExplorer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace GoTExplorer.ViewModels
{
    public class BookDetailsPageViewModel : ViewModelBase
    {
        //public Book Book { get; set; } = new Book();
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { Set(ref _book, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var bookId = (int)parameter;
            var service = new BookService();
            Book = await service.GetBookAsync(bookId);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
