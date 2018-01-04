using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using ZXing.Common;

namespace XFBarcode.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public string ImageSource { get; set; }
        private ZXing.BarcodeFormat _barcodeFormat;
        public ZXing.BarcodeFormat BarcodeFormat
        {
            get => _barcodeFormat;
            set => SetProperty(ref _barcodeFormat, value);
        }

        private EncodingOptions _options;
        public EncodingOptions Options
        {
            get => _options;
            set => SetProperty(ref _options, value);
        }
        private string _barcodeValue;

        public string BarcodeValue
        {
            get => _barcodeValue;
            set => SetProperty(ref _barcodeValue, value);
                
        }


        public DelegateCommand ScanCommand { get; set; }
        public DelegateCommand EncodeCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService): base (navigationService)
        {
            
            Title = "Main Page";
            ScanCommand = new DelegateCommand(OnScan);
            EncodeCommand = new DelegateCommand(OnEncode);
            BarcodeValue = "My name is trung";
            BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            Options = new ZXing.Common.EncodingOptions()
            {
                Height = 200,
                Width = 200,
            };
        }

        private void OnEncode()
        {
            //BarcodeValue = "Hello dev";
            //BarcodeFormat = ZXing.BarcodeFormat.CODE_128;

            var prompt = new PromptConfig() {
                Title="Input",
                Message="Keyin text you wanna to encode(Barcode)",
                Placeholder="Text Encode",
                OkText="Encode",
                OnAction = (result) => {
                    if(result.Ok==true && result.Text!="")
                    {
                        BarcodeValue = "Hello dev";
                        BarcodeFormat = ZXing.BarcodeFormat.CODE_128;
                    }
                    else
                    {
                        var toastConfig = new ToastConfig("Ok,thanks!");
                        toastConfig.SetDuration(3000);
                        //toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(12, 131, 193));
                        toastConfig.SetPosition(ToastPosition.Top);
                        UserDialogs.Instance.Toast(toastConfig);
                    }
                }
            };
            UserDialogs.Instance.Prompt(prompt);
            
        }

        private async void OnScan()
        {
           await  NavigationService.NavigateAsync("ScanPage");
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            
            if (parameters.TryGetValue("Result", out ZXing.Result param) && parameters.GetValue<string>("__NavigationMode") =="Back")
            {
                if(param is ZXing.Result resultcode)
                {
                    if(param != null)
                    {
                        var alert = new AlertConfig()
                        {
                            Title = "Bar Code",
                            Message = resultcode.Text + "(" + resultcode.BarcodeFormat + ")",
                            OkText = "Close",
                            OnAction = () => {
                                //do something when user click ok
                            }
                        };
                        UserDialogs.Instance.Alert(alert);
                    }
                    else
                    {
                        var toastConfig = new ToastConfig("No bar code");
                        toastConfig.SetDuration(3000);
                        //toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(12, 131, 193));
                        toastConfig.SetPosition(ToastPosition.Top);
                        UserDialogs.Instance.Toast(toastConfig);
                    }
                }
            }
        }
    }
}
