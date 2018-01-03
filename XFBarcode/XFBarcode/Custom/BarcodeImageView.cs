using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing;
using ZXing.Common;

namespace XFBarcode.Custom
{
    public class BarcodeImageView : Image
    {
        public BarcodeImageView() : base()
        {
            //tess
            //test 2
        } 

        public static readonly BindableProperty BarcodeFormatProperty =
            BindableProperty.Create(nameof(BarcodeFormat), typeof(BarcodeFormat), typeof(BarcodeImageView),
                defaultValue: BarcodeFormat.QR_CODE,
                defaultBindingMode: BindingMode.TwoWay);

        public BarcodeFormat BarcodeFormat
        {
            get { return (BarcodeFormat)GetValue(BarcodeFormatProperty); }
            set { SetValue(BarcodeFormatProperty, value); }
        }

        public static readonly BindableProperty BarcodeValueProperty =
            BindableProperty.Create(nameof(BarcodeValue), typeof(string), typeof(BarcodeImageView),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay);

        public string BarcodeValue
        {
            get { return (string)GetValue(BarcodeValueProperty); }
            set { SetValue(BarcodeValueProperty, value); }
        }

        public static readonly BindableProperty BarcodeOptionsProperty =
            BindableProperty.Create(nameof(BarcodeOptions), typeof(EncodingOptions), typeof(BarcodeImageView),
                defaultValue: new EncodingOptions(),
                defaultBindingMode: BindingMode.TwoWay);

        public EncodingOptions BarcodeOptions
        {
            get { return (EncodingOptions)GetValue(BarcodeOptionsProperty); }
            set { SetValue(BarcodeOptionsProperty, value); }
        }
    }
}
