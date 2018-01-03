using Prism.Navigation;
using ZXing.Mobile;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace XFBarcode.ViewModels
{
    public class ScannerPageViewModel : ViewModelBase
    {

        public ScannerPageViewModel(INavigationService navigationService,MobileBarcodeScanningOptions options , ZXingDefaultOverlay customOverlay ) : base(navigationService)
        {
            var child = customOverlay.Children;
        }
    }
}
