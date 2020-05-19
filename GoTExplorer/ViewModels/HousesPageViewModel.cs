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

        public void NavigateToHousesPage(int pageNumber) { NavigationService.Navigate(typeof(HousesPage), pageNumber); }
        public void NavigateToHouseDetailsPage(int houseId) { NavigationService.Navigate(typeof(HouseDetailsPage), houseId); }
    }
}
