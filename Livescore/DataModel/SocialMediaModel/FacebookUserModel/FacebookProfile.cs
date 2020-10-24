using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livescore.DataModel.SocialMediaModel.FacebookUserModel
{
    public class FacebookProfile
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public Picture Picture { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
    }
}
