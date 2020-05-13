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
    public class BookDetailsPageViewModel : ViewModelBase
    {
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { Set(ref _book, value); }
        }

        public ObservableCollection<Author> Authors { get; set; } = new ObservableCollection<Author>();

        private string _author;
        public string Author
        {
            get { return _author; }
            set { Set(ref _author, value); }
        }

        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Character> PoVCharacters { get; set; } = new ObservableCollection<Character>();

        private Character _character;
        public Character Character
        {
            get { return _character; }
            set { Set(ref _character, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
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

        private async void TransformUriToCharacter(string uri, ObservableCollection<Character> characterList)
        {
            string[] urlTokens = uri.Split('/');
            int characterId = int.Parse(urlTokens[urlTokens.Length - 1]);

            var service = new CharacterService();
            Character = await service.GetCharacterAsync(characterId);
            characterList.Add(Character);
        }

        public void NavigateToCharacterDetailsPage(int characterId) { NavigationService.Navigate(typeof(CharacterDetailsPage), characterId); }
    }
}
