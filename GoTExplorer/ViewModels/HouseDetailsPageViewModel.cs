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
    class HouseDetailsPageViewModel : DetailsPageViewModelBase
    {
        public ObservableCollection<Models.Attribute> Titles { get; set; } = new ObservableCollection<Models.Attribute>();
        public ObservableCollection<Models.Attribute> Seats { get; set; } = new ObservableCollection<Models.Attribute>();
        public ObservableCollection<Models.Attribute> AncestralWeapons { get; set; } = new ObservableCollection<Models.Attribute>();
        public ObservableCollection<Character> SwornMembers { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<House> CadetBranches { get; set; } = new ObservableCollection<House>();

        private string _attribute;
        public string Attribute
        {
            get { return _attribute; }
            set { Set(ref _attribute, value); }
        }

        private Character _lord;
        public Character CurrentLord
        {
            get { return _lord; }
            set { Set(ref _lord, value); }
        }

        private Character _heir;
        public Character Heir
        {
            get { return _heir; }
            set { Set(ref _heir, value); }
        }

        private Character _overlord;
        public Character Overlord
        {
            get { return _overlord; }
            set { Set(ref _overlord, value); }
        }

        private Character _founder;
        public Character Founder
        {
            get { return _founder; }
            set { Set(ref _founder, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            int intParam = 0;
            if (int.TryParse(parameter.ToString(), out intParam))
            {
                var houseId = (int)parameter;
                var service = new HouseService();
                House = await service.GetHouseAsync(houseId);
            }
            else
            {
                var houseName = (string)parameter;
                var service = new HouseService();

                var houseList = await service.GetHouseAsync(houseName);
                foreach (var item in houseList)
                {
                    House = item;
                }

            }

            if (House == null)
            {
                NavigateToNotFoundPage();
                return;
            }

            await base.OnNavigatedToAsync(parameter, mode, state);

            foreach (string title in House.titles)
            {
                Titles.Add(new Models.Attribute(title));
            }

            foreach (string seats in House.seats)
            {
                Seats.Add(new Models.Attribute(seats));
            }

            foreach (string ancestralWeapons in House.ancestralWeapons)
            {
                AncestralWeapons.Add(new Models.Attribute(ancestralWeapons));
            }

            foreach (string houseUri in House.cadetBranches)
            {
                TransformUriToHouse(houseUri, CadetBranches);
            }

            foreach (string characterUri in House.swornMembers)
            {
                TransformUriToCharacter(characterUri, SwornMembers);
            }

            TransformUriToCharacter(House.currentLord, CurrentLord);
            TransformUriToCharacter(House.heir, Heir);
            TransformUriToCharacter(House.overlord, Overlord);
            TransformUriToCharacter(House.founder, Founder);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToHouseDetailsPage(House house)
        {
            string[] urlTokens = house.url.Split('/');
            int houseId = int.Parse(urlTokens[urlTokens.Length - 1]);

            NavigationService.Navigate(typeof(HouseDetailsPage), houseId);
        }
        public void NavigateToCharacterDetailsPage(Character character)
        {
            string[] urlTokens = character.url.Split('/');
            int characterId = int.Parse(urlTokens[urlTokens.Length - 1]);

            NavigationService.Navigate(typeof(CharacterDetailsPage), characterId);
        }
    }
}
