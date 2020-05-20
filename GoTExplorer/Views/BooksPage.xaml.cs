using GoTExplorer.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GoTExplorer.Views
{
    /// <summary>
    ///     Page code behind for the books page.
    /// </summary>
    public sealed partial class BooksPage : Page
    {
        /// <summary>
        ///     Initializes the page.
        /// </summary>
        public BooksPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Handles a click event on a book list.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void Book_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToBookDetailsPage((Book)e.ClickedItem);
        }

        /// <summary>
        ///     Handles a click event on the next page button.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToNextBooksPage(BookList.Items.Count);
        }

        /// <summary>
        ///     Handles a click event on the previous page button.
        /// </summary>
        /// <param name="sender">sender object.</param>
        ///  <param name="e">event args.</param>
        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToPreviousBooksPage();
        }
    }
}
