using GoTExplorer.Models;
using GoTExplorer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace GoTExplorer.ViewModels
{
    class CharacterDetailsPageViewModel : ViewModelBase
    {
        private Character _character;
        public Character Character
        {
            get { return _character; }
            set { Set(ref _character, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var characterId = (int)parameter;
            var service = new CharacterService();
            Character = await service.GetCharacterAsync(characterId);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
