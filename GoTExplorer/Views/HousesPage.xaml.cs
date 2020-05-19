using GoTExplorer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoTExplorer.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HousesPage : Page
    {
        public HousesPage()
        {
            this.InitializeComponent();
        }

        private void House_ItemClick(object sender, ItemClickEventArgs e)
        {
            var house = (House)e.ClickedItem;
            string[] urlTokens = house.url.Split('/');

            ViewModel.NavigateToHouseDetailsPage(int.Parse(urlTokens[urlTokens.Length - 1]));
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            int newPageNumber;
            if (HouseList.Items.Count == 10)
            {
                newPageNumber = ++App.currentHousesPageNumber;
            }
            else
            {
                newPageNumber = App.currentHousesPageNumber;
            }

            ViewModel.NavigateToHousesPage(newPageNumber);
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
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

            ViewModel.NavigateToHousesPage(newPageNumber);
        }
    }
}
