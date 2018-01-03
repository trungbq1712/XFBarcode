using System;
using System.ComponentModel;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFBarcode.Custom;
using XFBarcode.Droid.Renderers;

[assembly: ExportRenderer(typeof(BarcodeImageView), typeof(BarcodeImageViewRenderer))]
namespace XFBarcode.Droid.Renderers
{
    public class BarcodeImageViewRenderer : ViewRenderer
    {

        BarcodeImageView formsView;
        ImageView imageView;
        public BarcodeImageViewRenderer()
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            formsView = Element as BarcodeImageView;
            if (e.NewElement == null)
                return;
            imageView = new ImageView(Forms.Context);
            SetNativeControl(imageView);
            regenerate();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            regenerate();
        }
        private void regenerate()
        {
            if (formsView != null && formsView.BarcodeValue != null)
            {
                var writer = new ZXing.Mobile.BarcodeWriter();

                if (formsView != null && formsView.BarcodeOptions != null)
                    writer.Options = formsView.BarcodeOptions;
                //if (formsView != null && formsView.BarcodeFormat != null)
                if (formsView != null )
                    writer.Format = formsView.BarcodeFormat;

                var value = formsView != null ? formsView.BarcodeValue : string.Empty;

                Device.BeginInvokeOnMainThread(() => {
                    var image = writer.Write(value);

                    imageView.SetImageBitmap(image);
                });
            }
        }
    }
}