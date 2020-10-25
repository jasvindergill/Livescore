using Livescore.DataModel.SocialMediaModel.FacebookUserModel;
using Livescore.DataModel.SocialMediaModel.SocialUserModel;
using Livescore.Views.Leagues;
using Livescore.Views.LoginScreen;
using Newtonsoft.Json;
using Plugin.FacebookClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Livescore.Models.SocialMediaModels
{
    public class FacebookModel
    {
        //Configure the interfaces
        public ICommand OnLoginWithFacebookCommand { get; set; }
        IFacebookClient _facebookClient = CrossFacebookClient.Current;

        public FacebookModel()
        {
            OnLoginWithFacebookCommand = new Command(async() => await LoginFacebookAsync());
        }

        private async Task LoginFacebookAsync()
        {
            try
            {
                //check if logged in
                if(_facebookClient.IsLoggedIn)
                {
                    //TODO: Give appropriate handler
                    _facebookClient.Logout();
                }

                

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    if (e == null)
                        return;

                    string url = string.Empty;

                    switch(e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            //Handles the FBEvent handler and deserialize it. This is a custom FB Event Handler, hence you can get e.Data
                            var fbUser = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                            
                            //A check on null picture
                            if(fbUser.Picture.Data.Url != null)
                            {
                                url = fbUser.Picture.Data.Url;
                            }

                            //Assign the deserialize values into a generic socialMediaUser model
                            var socialMediaProfile = new SocialMediaUser
                            {
                                Name = fbUser.FirstName,
                                Email = fbUser.Email,
                                PictureURL = url
                            };

                            //Login is completed
                            //Send the data to the "Select League" page
                            await App.Current.MainPage.Navigation.PushModalAsync(new SelectLeagues());
                            break;
                        case FacebookActionStatus.Canceled:
                            //Redirect back to login
                            await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                            break;
                    }
                    //_facebookClient.OnUserData -= userDataDelegate;
                };

                _facebookClient.OnUserData += userDataDelegate;

                string[] fbRequestFields = { "email", "first_name", "last_name", "picture" };
                string[] fbPermisions = { "email" };
                await _facebookClient.RequestUserDataAsync(fbRequestFields, fbPermisions);
            }
            catch(Exception e)
            {
                //TODO: A proper dialog command
                //https://github.com/aritchie/userdialogs/blob/master/src/Samples/Samples/ViewModels/StandardViewModel.cs
            }
        }
    }
}
