using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace XFBarcode.ViewModels
{
    public class ScanPageViewModel : ViewModelBase
    {
        public ZXing.Result Result { get; set; }

        private bool _isAnalyzing ;
        public bool IsAnalyzing
        {
            get => _isAnalyzing;
            set => SetProperty(ref _isAnalyzing, value);
        }

        private bool _isScanning;
        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }
        private bool _isTorchOn;
        public bool IsTorchOn
        {
            get => _isTorchOn;
            set => SetProperty(ref _isTorchOn, value);
        }


        public DelegateCommand QRScanResultCommand { get; }
        public ICommand FlashOnCommand { get; }
        public DelegateCommand TurnOnCommand { get; }

        public ScanPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
            QRScanResultCommand = new DelegateCommand(OnScanResult);
            FlashOnCommand = new DelegateCommand(OnFlash);
            TurnOnCommand = new DelegateCommand(OnTurnOn);
            //IsTorchOn = true;
            IsAnalyzing = true;
            IsScanning = true;
            
        }

        public void OnTurnOn()
        {
            IsTorchOn = !IsTorchOn;
        }

        public void OnFlash()
        {
            IsTorchOn = !IsTorchOn;
        }

        private void OnScanResult()
        {
            IsAnalyzing = false;
            IsScanning = false;
            Device.BeginInvokeOnMainThread(async () =>
            {
               var reult = await NavigationService.GoBackAsync(new NavigationParameters { { "Result", Result } });
            });

            IsAnalyzing = true;
            IsScanning = true;
        }
    }
}
