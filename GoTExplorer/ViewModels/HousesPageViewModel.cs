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
    class HousesPageViewModel : ViewModelBase
    {
        public ObservableCollection<House> Houses { get; set; } = new ObservableCollection<House>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            int pageNumber = (int)parameter;
            var service = new HouseService();
            var housesList = await service.GetHousesAsync(pageNumber);
            foreach (var item in housesList)
            {
                Houses.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToNextHousesPage(int housesListCount)
        {
            int newPageNumber;
            if (housesListCount == 10)
            {
                newPageNumber = ++App.currentHousesPageNumber;
            }
            else
            {
                newPageNumber = App.currentHousesPageNumber;
            }

            NavigationService.Navigate(typeof(HousesPage), newPageNumber);
        }

        public void NavigateToPreviousHousesPage()
        {
            int newPageNumber;
            if (App.currentHousesPageNumber > 1)
            {
                newPageNumber = --App.currentHousesPageNumber;
            }
            else
            {
                newPageNumber = 1;
            }

            NavigationService.Navigate(typeof(HousesPage), newPageNumber);
        }

        public void NavigateToHouseDetailsPage(House house)
        {
            string[] urlTokens = house.url.Split('/');
            int houseId = int.Parse(urlTokens[urlTokens.Length - 1]);

            NavigationService.Navigate(typeof(HouseDetailsPage), houseId);
        }
    }
}
