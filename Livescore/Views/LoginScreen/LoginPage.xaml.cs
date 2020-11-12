using Livescore.Models.SocialMediaModels;
using Livescore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livescore.Views.LoginScreen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        IFirebaseAuthentication auth;
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnGoogleButtonClicked(object sender, EventArgs e)
        {
            
            this.BindingContext = new GoogleModel();
        }

        private void OnFacebookButtonClicked(object sender, EventArgs e)
        {
            this.BindingContext = new FacebookModel();
        }
    }
}