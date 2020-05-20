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
    /// <summary>
    ///     View model for character details pages.
    /// </summary>
    class CharacterDetailsPageViewModel : DetailsPageViewModelBase
    {

        public ObservableCollection<House> Allegiances { get; set; } = new ObservableCollection<House>();

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<Book> PoVBooks { get; set; } = new ObservableCollection<Book>();

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

        /// <summary>
        ///     Defines what happens when the page is navigated on.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        /// <param name="mode">navigation mode.</param>
        /// <param name="state">state.</param>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //Deciding if the character is searched by id or name.
            int intParam = 0;
            if (int.TryParse(parameter.ToString(), out intParam))
            {
                var characterId = (int)parameter;
                var service = new CharacterService();
                Character = await service.GetCharacterAsync(characterId);
            }
            else
            {
                var characterName = (string)parameter;
                var service = new CharacterService();

                var characterList = await service.GetCharacterAsync(characterName);
                foreach (var item in characterList)
                {
                    Character = item;
                }

            }

            //If no such character is found, navigate the user to the not found page.
            if (Character == null)
            {
                NavigateToNotFoundPage();
                return;
            }

            await base.OnNavigatedToAsync(parameter, mode, state);


            //Fill the lists on the UI, transforming uris if needed.
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

            foreach (string houseUri in Character.allegiances)
            {
                TransformUriToHouse(houseUri, Allegiances);
            }

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
