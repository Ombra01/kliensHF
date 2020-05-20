using GoTExplorer.Models;
using GoTExplorer.Services;
using GoTExplorer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace GoTExplorer.ViewModels
{
    /// <summary>
    ///     View model for book details pages.
    /// </summary>
    public class BookDetailsPageViewModel : DetailsPageViewModelBase
    {
        public ObservableCollection<Author> Authors { get; set; } = new ObservableCollection<Author>();

        private string _author;
        public string Author
        {
            get { return _author; }
            set { Set(ref _author, value); }
        }

        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Character> PoVCharacters { get; set; } = new ObservableCollection<Character>();

        /// <summary>
        ///     Defines what happens when the page is navigated on.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        /// <param name="mode">navigation mode.</param>
        /// <param name="state">state.</param>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //Deciding if the book is searched by id or name.
            int intParam = 0;
            if (int.TryParse(parameter.ToString(), out intParam))
            {
                var bookId = (int)parameter;
                var service = new BookService();
                Book = await service.GetBookAsync(bookId);
            } else
            {
                var bookName = (string)parameter;
                var service = new BookService();

                var booksList = await service.GetBookAsync(bookName);
                foreach (var item in booksList)
                {
                    Book = item;
                }
                
            }

            //If no such book is found, navigate the user to the not found page.
            if (Book == null)
            {
                NavigateToNotFoundPage();
                return;
            }

            //Fill the lists on the UI, transforming uris if needed.
            foreach (string authorName in Book.authors)
            {
                Authors.Add(new Author(authorName));
            }

            foreach (string characterUri in Book.characters)
            {
                TransformUriToCharacter(characterUri, Characters);
            }

            foreach (string characterUri in Book.povCharacters)
            {
                TransformUriToCharacter(characterUri, PoVCharacters);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
