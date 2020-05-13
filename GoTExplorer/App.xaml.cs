using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;

namespace GoTExplorer
{
    // sample: https://github.com/Windows-XAML/Template10/blob/master/Templates%20(Project)/Minimal/App.xaml.cs

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        public static int currentCharactersPageNumber;

        public App()
        {
            currentCharactersPageNumber = 1;
            InitializeComponent();
            RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Light;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            await NavigationService.NavigateAsync(typeof(Views.WelcomePage));
        }
    }
}

