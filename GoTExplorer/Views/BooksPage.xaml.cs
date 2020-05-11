using GoTExplorer.Models;
using System;
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

            ViewModel.NavigateToBookDetails(int.Parse(urlTokens[urlTokens.Length - 1]));
        }
    }
}
