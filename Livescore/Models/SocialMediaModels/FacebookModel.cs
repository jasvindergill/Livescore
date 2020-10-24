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
                            //TODO
                            break;
                        case FacebookActionStatus.Canceled:
                            //TDOD
                            break;
                    }
                };
            }
            catch(Exception e)
            {
                
            }
        }
    }
}
