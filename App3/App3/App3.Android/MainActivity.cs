
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using App3.Droid;
using Environment = Android.OS.Environment;
using Java.IO;
using System.IO;
using Android.Provider;
using Android.Net;
using File = Java.IO.File;

[assembly: Dependency(typeof(PhotoPickerService))]
namespace App3.Droid
{
    [Activity(Label = "App3", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }
        static readonly File file = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "tmp.jpg");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Instance = this;
            
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            App.Instance.ShouldTakePicture += () => {
                var intent = new Intent(MediaStore.ActionImageCapture);
                intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(file));
                StartActivityForResult(intent, 0);
            };
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        public static readonly int PickImageId = 1000;


        public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }
        
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            App.Instance.ShowImage(file.Path);
            //if (requestCode == PickImageId)
            //{
            //    if ((resultCode == Result.Ok) && (intent != null))
            //    {
            //        Android.Net.Uri uri = intent.Data;
            //        Stream stream = ContentResolver.OpenInputStream(uri);
            //        // Set the Stream as the completion of the Task
            //        PickImageTaskCompletionSource.SetResult(stream);
            //    }
            //    else
            //    {
            //        PickImageTaskCompletionSource.SetResult(null);
            //    }
            //}
            //else
            //{
                
            //}
        }
    }
}