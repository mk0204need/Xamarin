using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            List<ImageSource> vs = new List<ImageSource>
            {
               ImageSource.FromFile( "ne.jpg"),
               ImageSource.FromFile( "photo.jpg"),
               ImageSource.FromFile( "phototrc.jpg"),
               ImageSource.FromFile( "zx.jpg")
            };
            LVPhotos.ItemsSource = vs;
        }
        private string SetImageFileName(string fileName = null)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                if (fileName != null)
                    App.ImageIdToSave = fileName;
                else
                    App.ImageIdToSave = App.DefaultImageId;

                return App.ImageIdToSave;
            }
            else
            {
                //To iterate, on iOS, if you want to save images to the devie, set 
                if (fileName != null)
                {
                    App.ImageIdToSave = fileName;
                    return fileName;
                }
                else
                    return null;
            }
        }
        
        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
                
            myImage.Source = App.Instance.imageSource;
            
        }

        private async void BtnAddGalery_Clicked(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                myImage.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}