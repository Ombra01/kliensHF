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
    class CharactersPageViewModel : ViewModelBase
    {
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();

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

        public void NavigateToCharacterDetailsPage(Character character)
        {
            string[] urlTokens = character.url.Split('/');
            int characterId = int.Parse(urlTokens[urlTokens.Length - 1]);

            NavigationService.Navigate(typeof(CharacterDetailsPage), characterId);
        }
    }
}