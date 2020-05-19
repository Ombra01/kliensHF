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
    public sealed partial class CharacterDetailsPage : Page
    {
        public CharacterDetailsPage()
        {
            this.InitializeComponent();
        }

        private void Book_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToBookDetailsPage((Book)e.ClickedItem);
        }

        private void House_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToHouseDetailsPage((House)e.ClickedItem);
        }
    }
}
