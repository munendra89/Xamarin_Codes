using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTube.DataModel
{
    [JsonObject]
    public class UserInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("picture")]
        public Uri Picture { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }
    }
}
