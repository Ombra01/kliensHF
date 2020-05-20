using GoTExplorer.Models;
using GoTExplorer.Services;
using GoTExplorer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace GoTExplorer.ViewModels
{
    /// <summary>
    ///     Common part fo the view model for details pages.
    /// </summary>
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

        private House _house;
        public House House
        {
            get { return _house; }
            set { Set(ref _house, value); }
        }

        /// <summary>
        ///     Transforms an uri to a book.
        /// </summary>
        /// <param name="uri">the uri which needs to be transformed.</param>
        /// <param name="bookList">the list in which the book is placed.</param>
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

        /// <summary>
        ///     Transforms an uri to a character.
        /// </summary>
        /// <param name="uri">the uri which needs to be transformed.</param>
        /// <param name="characterList">the list in which the character is placed.</param>
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

        /// <summary>
        ///     Transforms an uri to a house.
        /// </summary>
        /// <param name="uri">the uri which needs to be transformed.</param>
        /// <param name="houseList">the list in which the house is placed.</param>
        protected async void TransformUriToHouse(string uri, ObservableCollection<House> houseList)
        {
            string[] urlTokens = uri.Split('/');
            int houseId = int.Parse(urlTokens[urlTokens.Length - 1]);

            var service = new HouseService();
            House = await service.GetHouseAsync(houseId);
            houseList.Add(House);
        }

        /// <summary>
        ///     Transforms an uri to a character.
        /// </summary>
        /// <param name="uri">the uri which needs to be transformed.</param>
        /// <param name="character">the character object which holds the transformed character.</param>
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

        /// <summary>
        ///     Navigates to the not found page.
        /// </summary>
        public void NavigateToNotFoundPage() { NavigationService.Navigate(typeof(NotFoundPage)); }

        /// <summary>
        ///     Navigates to the search page.
        /// </summary>
        public void NavigateToSearchPage() { NavigationService.Navigate(typeof(SearchPage)); }

        /// <summary>
        ///     Navigates to a house's details page.
        /// </summary>
        /// <param name="house">the house whose page needs to be opened.</param>
        public void NavigateToHouseDetailsPage(House house)
        {
            string[] urlTokens = house.url.Split('/');
            int houseId = int.Parse(urlTokens[urlTokens.Length - 1]);

            NavigationService.Navigate(typeof(HouseDetailsPage), houseId);
        }

        /// <summary>
        ///     Navigates to a character's details page.
        /// </summary>
        /// <param name="character">the character whose page needs to be opened.</param>
        public void NavigateToCharacterDetailsPage(Character character)
        {
            string[] urlTokens = character.url.Split('/');
            int characterId = int.Parse(urlTokens[urlTokens.Length - 1]);

            NavigationService.Navigate(typeof(CharacterDetailsPage), characterId);
        }
    }
}
