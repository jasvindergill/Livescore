using Android.Content;
using Livescore.DataModel.SocialMediaModel.SocialUserModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Livescore.Utils.Settings
{
    public class UserDetailsSetting
    {
        public void SaveUserDetails(SocialMediaUser socialMediaUser)
        {
            Preferences.Set("Email", socialMediaUser.Email);
            Preferences.Set("Name", socialMediaUser.Name);
        }

        public SocialMediaUser GetUserDetails()
        {
            SocialMediaUser smu = new SocialMediaUser();

            smu.Email = Preferences.Get("Email", "");
            smu.Name = Preferences.Get("Name", "");

            return smu;
        }

        public bool CheckAvailableUserSettings()
        {
            bool hasKey = Preferences.ContainsKey("Email");
            return hasKey;
        }
    }
}
