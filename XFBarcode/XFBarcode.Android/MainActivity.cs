using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using DryIoc;
using Prism.DryIoc;
using XFBarcode.Custom;
using XFBarcode.Droid.Renderers;

namespace XFBarcode.Droid
{
    [Activity(Label = "XFBarcode", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {


        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            
            
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            //ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
            UserDialogs.Init(this);
            LoadApplication(new App(new AndroidInitializer()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainer container)
        {
            container.RegisterInstance(typeof(BarcodeImageViewRenderer));
        }
    }
}

