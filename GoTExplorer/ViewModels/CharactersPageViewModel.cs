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

        public void NavigateToCharactersPage(int pageNumber) { NavigationService.Navigate(typeof(CharactersPage), pageNumber); }
        public void NavigateToCharacterDetailsPage(int characterId) { NavigationService.Navigate(typeof(CharacterDetailsPage), characterId); }
    }
}