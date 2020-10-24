using Livescore.Views.LoginScreen;
using Livescore.Views.SplashScreen;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livescore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new WelcomeScreen();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
