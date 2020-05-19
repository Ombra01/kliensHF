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
            ViewModel.NavigateToBookDetailsPage((Book)e.ClickedItem);
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToNextBooksPage(BookList.Items.Count);
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToPreviousBooksPage();
        }
    }
}
