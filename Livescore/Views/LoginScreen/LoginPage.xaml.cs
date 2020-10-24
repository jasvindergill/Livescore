using Livescore.Models.SocialMediaModels;
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
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnGoogleButtonClicked(object sender, EventArgs e)
        {
            this.BindingContext = new GoogleModel();
        }

        private void OnFacebookButtonClicked(object sender, EventArgs e)
        {
            this.BindingContext = new FacebookModel();
        }
    }
}