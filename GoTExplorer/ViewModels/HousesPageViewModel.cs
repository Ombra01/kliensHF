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
    ///     View model for houses page.
    /// </summary>
    class HousesPageViewModel : ViewModelBase
    {
        public ObservableCollection<House> Houses { get; set; } = new ObservableCollection<House>();

        /// <summary>
        ///     Defines what happens when the page is navigated on.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        /// <param name="mode">navigation mode.</param>
        /// <param name="state">state.</param>
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

        /// <summary>
        ///     Controls paging when the next page is requested.
        /// </summary>
        /// <param name="housesListCount">checks the amount of houses listed on the current page.</param>
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

        /// <summary>
        ///     Controls paging when the previous page is requested.
        /// </summary>
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
    }
}
