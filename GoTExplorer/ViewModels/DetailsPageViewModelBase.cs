using GoTExplorer.Models;
using GoTExplorer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace GoTExplorer.ViewModels
{
    public class DetailsPageViewModelBase : ViewModelBase
    {
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { Set(ref _book, value); }
        }

        private Character _character;
        public Character Character
        {
            get { return _character; }
            set { Set(ref _character, value); }
        }

        protected async void TransformUriToBook(string uri, ObservableCollection<Book> bookList)
        {
            if (uri != null && !uri.Equals(""))
            {
                string[] urlTokens = uri.Split('/');
                int bookId = int.Parse(urlTokens[urlTokens.Length - 1]);

                var service = new BookService();
                Book = await service.GetBookAsync(bookId);
                bookList.Add(Book);
            }
        }

        protected async void TransformUriToCharacter(string uri, ObservableCollection<Character> characterList)
        {
            if (uri != null && !uri.Equals(""))
            {
                string[] urlTokens = uri.Split('/');
                int characterId = int.Parse(urlTokens[urlTokens.Length - 1]);

                var service = new CharacterService();
                Character = await service.GetCharacterAsync(characterId);
                characterList.Add(Character);
            }
        }

        protected async void TransformUriToCharacter(string uri, Character character)
        {
            if (uri != null && !uri.Equals(""))
            {
                string[] urlTokens = uri.Split('/');
                int characterId = int.Parse(urlTokens[urlTokens.Length - 1]);

                var service = new CharacterService();
                character = await service.GetCharacterAsync(characterId);
            }
        }
    }
}
