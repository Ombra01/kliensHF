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
using Windows.UI.Xaml.Navigation;

namespace GoTExplorer.ViewModels
{
    class CharacterDetailsPageViewModel : DetailsPageViewModelBase
    {
        /*private Character _character;
        public Character Character
        {
            get { return _character; }
            set { Set(ref _character, value); }
        }*/

        /*public ObservableCollection<House> Allegiances { get; set; } = new ObservableCollection<House>();

        private House _house;
        public House House
        {
            get { return _house; }
            set { Set(ref _house, value); }
        }*/

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<Book> PoVBooks { get; set; } = new ObservableCollection<Book>();

        /*private Book _book;
        public Book Book
        {
            get { return _book; }
            set { Set(ref _book, value); }
        }*/

        public ObservableCollection<Models.Attribute> Titles { get; set; } = new ObservableCollection<Models.Attribute>();
        public ObservableCollection<Models.Attribute> Aliases { get; set; } = new ObservableCollection<Models.Attribute>();
        public ObservableCollection<Models.Attribute> Series { get; set; } = new ObservableCollection<Models.Attribute>();
        public ObservableCollection<Models.Attribute> Actors { get; set; } = new ObservableCollection<Models.Attribute>();

        private string _attribute;
        public string Attribute
        {
            get { return _attribute; }
            set { Set(ref _attribute, value); }
        }

        private Character _father;
        public Character Father
        {
            get { return _father; }
            set { Set(ref _father, value); }
        }

        private Character _mother;
        public Character Mother
        {
            get { return _mother; }
            set { Set(ref _mother, value); }
        }

        private Character _spouse;
        public Character Spouse
        {
            get { return _spouse; }
            set { Set(ref _spouse, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var characterId = (int)parameter;
            var service = new CharacterService();
            Character = await service.GetCharacterAsync(characterId);

            await base.OnNavigatedToAsync(parameter, mode, state);

            foreach (string title in Character.titles)
            {

                Titles.Add(new Models.Attribute(title));
            }

            foreach (string alias in Character.aliases)
            {

                Aliases.Add(new Models.Attribute(alias));
            }

            foreach (string serie in Character.tvSeries)
            {

                Series.Add(new Models.Attribute(serie));
            }

            foreach (string actor in Character.playedBy)
            {

                Actors.Add(new Models.Attribute(actor));
            }

            /*foreach (string house in Character.allegiances)
            {
                TransformUriToHouse(house, Allegiances);
            }*/

            foreach (string characterUri in Character.books)
            {
                TransformUriToBook(characterUri, Books);
            }

            foreach (string characterUri in Character.povBooks)
            {
                TransformUriToBook(characterUri, PoVBooks);
            }

            TransformUriToCharacter(Character.father, Father);
            TransformUriToCharacter(Character.mother, Mother);
            TransformUriToCharacter(Character.spouse, Spouse);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /*private async void TransformUriToHouse(string uri, ObservableCollection<House> houseList)
        {
            string[] urlTokens = uri.Split('/');
            int houseId = int.Parse(urlTokens[urlTokens.Length - 1]);

            var service = new HouseService();
            House = await service.GetBookAsync(houseId);
            houseList.Add(House);
        }*/

        /*private async void TransformUriToBook(string uri, ObservableCollection<Book> bookList)
        {
            string[] urlTokens = uri.Split('/');
            int bookId = int.Parse(urlTokens[urlTokens.Length - 1]);

            var service = new BookService();
            Book = await service.GetBookAsync(bookId);
            bookList.Add(Book);
        }

        private async void TransformUriToCharacter(string uri, Character character)
        {
            if (uri != null && !uri.Equals(""))
            {
                string[] urlTokens = uri.Split('/');
                int characterId = int.Parse(urlTokens[urlTokens.Length - 1]);

                var service = new CharacterService();
                character = await service.GetCharacterAsync(characterId);
            }
        }*/

        //public void NavigateToHouseDetailsPage(int bookId) { NavigationService.Navigate(typeof(HouseDetailsPage), houseId); }
        public void NavigateToBookDetailsPage(int bookId) { NavigationService.Navigate(typeof(BookDetailsPage), bookId); }
    }
}
