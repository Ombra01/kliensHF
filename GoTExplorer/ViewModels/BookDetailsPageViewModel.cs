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
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { Set(ref _book, value); }
        }

        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();

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

            CreateCharactersList();

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        private void CreateCharactersList()
        {
            foreach (string characterUri in Book.characters)
            {
                TransformUriToCharacter(characterUri);
                Characters.Add(Character);
            }
        }

        private async void TransformUriToCharacter(string uri)
        {
            string[] urlTokens = uri.Split('/');
            int characterId = int.Parse(urlTokens[urlTokens.Length - 1]);

            var service = new CharacterService();
            Character = await service.GetCharacterAsync(characterId);
        }
    }
}
