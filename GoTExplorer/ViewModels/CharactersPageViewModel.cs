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
using Windows.Devices.PointOfService;
using Windows.UI.Xaml.Navigation;

namespace GoTExplorer.ViewModels
{
    /// <summary>
    ///     View model for characters page.
    /// </summary>
    class CharactersPageViewModel : ViewModelBase
    {
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();

        /// <summary>
        ///     Defines what happens when the page is navigated on.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        /// <param name="mode">navigation mode.</param>
        /// <param name="state">state.</param>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            int pageNumber = (int)parameter;
            var service = new CharacterService();
            var charactersList = await service.GetCharactersAsync(pageNumber);
            foreach (var item in charactersList)
            {
                Characters.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        ///     Controls paging when the next page is requested.
        /// </summary>
        /// <param name="charactersListCount">checks the amount of characters listed on the current page.</param>
        public void NavigateToNextCharactersPage(int charactersListCount)
        {
            int newPageNumber;
            if (charactersListCount == 10)
            {
                newPageNumber = ++App.currentCharactersPageNumber;
            }
            else
            {
                newPageNumber = App.currentCharactersPageNumber;
            }

            NavigationService.Navigate(typeof(CharactersPage), newPageNumber);
        }

        /// <summary>
        ///     Controls paging when the previous page is requested.
        /// </summary>
        public void NavigateToPreviousCharactersPage()
        {
            int newPageNumber;
            if (App.currentCharactersPageNumber > 1)
            {
                newPageNumber = --App.currentCharactersPageNumber;
            }
            else
            {
                newPageNumber = 1;
            }

            NavigationService.Navigate(typeof(CharactersPage), newPageNumber);
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