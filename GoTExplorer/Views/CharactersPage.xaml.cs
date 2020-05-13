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
    public sealed partial class CharactersPage : Page
    {
        public CharactersPage()
        {
            this.InitializeComponent();
        }

        private void Character_ItemClick(object sender, ItemClickEventArgs e)
        {
            var character = (Character)e.ClickedItem;
            string[] urlTokens = character.url.Split('/');

            ViewModel.NavigateToCharacterDetailsPage(int.Parse(urlTokens[urlTokens.Length - 1]));
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            int newPageNumber = ++App.currentCharactersPageNumber;
            ViewModel.NavigateToCharactersPage(newPageNumber);
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            int newPageNumber;
            if (App.currentCharactersPageNumber > 1)
            {
                newPageNumber = --App.currentCharactersPageNumber;
            } else
            {
                newPageNumber = 1;
            }

            ViewModel.NavigateToCharactersPage(newPageNumber);
        }
    }
}
