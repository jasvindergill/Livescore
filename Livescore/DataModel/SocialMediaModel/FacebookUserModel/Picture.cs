using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livescore.DataModel.SocialMediaModel.FacebookUserModel
{

    public class Picture
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("is_silhouette")]
        public bool IsSilhouette { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }
}
