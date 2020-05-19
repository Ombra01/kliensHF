using GoTExplorer.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GoTExplorer.Views
{
    public sealed partial class BooksPage : Page
    {
        public BooksPage()
        {
            InitializeComponent();
        }

        private void Book_ItemClick(object sender, ItemClickEventArgs e)
        {
            var book = (Book)e.ClickedItem;
            string[] urlTokens = book.url.Split('/');

            ViewModel.NavigateToBookDetailsPage(int.Parse(urlTokens[urlTokens.Length - 1]));
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            int newPageNumber;
            if (BookList.Items.Count == 10)
            {
                newPageNumber = ++App.currentBooksPageNumber;
            } else
            {
                newPageNumber = App.currentBooksPageNumber;
            }

            ViewModel.NavigateToBooksPage(newPageNumber);
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            int newPageNumber;
            if (App.currentBooksPageNumber > 1)
            {
                newPageNumber = --App.currentBooksPageNumber;
            }
            else
            {
                newPageNumber = 1;
            }

            ViewModel.NavigateToBooksPage(newPageNumber);
        }
    }
}
