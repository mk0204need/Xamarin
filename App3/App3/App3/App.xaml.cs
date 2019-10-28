using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    public partial class App : Application
    {
        public static App Instance;
        readonly Image image = new Image();
        public ImageSource imageSource;
        public static string DefaultImageId = "default_image";
        public static string ImageIdToSave = null;
        public event Action ShouldTakePicture = () => { };
        public App()
        {
            InitializeComponent();
            Instance = this;
            var button = new Button
            {
                Text = "Snap!",
                Command = new Command(o => ShouldTakePicture()),
            };
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
 button,
 image,
 },
                },
            };
            //MainPage = new MainPage();
            

        }
        public void ShowImage(string filepath)
        {
            image.Source = ImageSource.FromFile(filepath);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
