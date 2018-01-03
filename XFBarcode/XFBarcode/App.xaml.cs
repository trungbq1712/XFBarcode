using XFBarcode.ViewModels;
using XFBarcode.Views;
using DryIoc;
using Prism.DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using XFBarcode.Custom;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFBarcode
{
    public partial class App 
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() {
            
        }

        public App(IPlatformInitializer initializer) : base(initializer) {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>("NavigationPage");
            Container.RegisterTypeForNavigation<MainPage,MainPageViewModel>("MainPage");
            Container.RegisterTypeForNavigation<ScanPage, ScanPageViewModel>("ScanPage");
            Container.RegisterTypeForNavigation<ScannerPage, ScannerPageViewModel>("ScannerPage");
            Container.RegisterInstance(typeof(BarcodeImageView));
        }
    }
}
