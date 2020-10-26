using Livescore.DataModel.SocialMediaModel.GoogleUserModel;
using Livescore.DataModel.SocialMediaModel.SocialUserModel;
using Livescore.Views.Leagues;
using Livescore.Views.LoginScreen;
using Newtonsoft.Json;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Livescore.Models.SocialMediaModels
{
    public class GoogleModel
    {
        //Initialize the plugin interface
        IGoogleClientManager googleClient = CrossGoogleClient.Current;

        //We get/set the command from XAML
        public ICommand OnLoginWithGoogleCommand { get; set; }

        public GoogleModel()
        {
            //Now we bind the command from view into ICommand above and set the async method
            OnLoginWithGoogleCommand = new Command(async () => await LoginGoogleAsync());
        }

        private async Task LoginGoogleAsync()
        {
            try
            {
                //Check if the user is already logged in
                //potentially will remove this in the future otherwise create appropriate handler
                if(!string.IsNullOrEmpty((googleClient.AccessToken)))
                {
                    googleClient.Logout();
                }

                //Create the event/delegate of Google user type and initialize it
                EventHandler<GoogleClientResultEventArgs<GoogleUser>> userLoginDelegate = null;

                //Lets do the login
                userLoginDelegate = async (object sender, GoogleClientResultEventArgs<GoogleUser> e) =>
                {
                    switch(e.Status)
                    {
                        case GoogleActionStatus.Completed:
                            var googleResultString = JsonConvert.SerializeObject(e.Data);

                            //A check with the user profile image is empty
                            string url = string.Empty;
                            if(e.Data.Picture.AbsoluteUri != null)
                            {
                                url = e.Data.Picture.AbsoluteUri;
                            }

                            //map the e.data into our SocialMediaUser model
                            var socialMediaUser = new SocialMediaUser
                            {
                                Email = e.Data.Email,
                                Name = e.Data.Name,
                                PictureURL = url
                            };

                            //Once the model is set, send it to the selectLeague page
                            await App.Current.MainPage.Navigation.PushModalAsync(new SelectLeagues());
                            break;
                        case GoogleActionStatus.Canceled:
                            /*For now we will display an alert here but we will move this elsewhere
                             * so that we can just return a msg into that VM and display it properly
                             * and finally navigate to login page
                             */
                            await App.Current.MainPage.DisplayAlert("Google Login", "Google Login Cancelled by user", "OK");
                            await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                            break;
                        case GoogleActionStatus.Error:
                            /*For now we will display an alert here but we will move this elsewhere
                             * so that we can just return a msg into that VM and display it properly
                             * and finally navigate to login page
                             */
                            await App.Current.MainPage.DisplayAlert("Google Login", "Error from Google signing in", "OK");
                            await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                            break;
                    }
                    googleClient.OnLogin -= userLoginDelegate;
                };

                googleClient.OnLogin += userLoginDelegate;

                await googleClient.LoginAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
                //await App.Current.MainPage.DisplayAlert("Google Login", e.Message, "OK");
            }
        }
    }
}
