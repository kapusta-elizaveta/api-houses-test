using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousesApiTest
{
    class HousesModel
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "coatOfArms")]
        public string CoatOfArms { get; set; }

        [JsonProperty(PropertyName = "words")]
        public string Words { get; set; }
        
        [JsonProperty(PropertyName = "titles")]
        public string[] Titles { get; set; }

        [JsonProperty(PropertyName = "seats")]
        public string[] Seats { get; set; }

        [JsonProperty(PropertyName = "currentLord")]
        public string CurrentLord { get; set; }
        
        [JsonProperty(PropertyName = "heir")]
        public string Heir { get; set; }

        [JsonProperty(PropertyName = "overlord")]
        public string Overlord { get; set; }

        [JsonProperty(PropertyName = "founded")]
        public string Founded { get; set; }

        [JsonProperty(PropertyName = "founder")]
        public string Founder { get; set; }

        [JsonProperty(PropertyName = "diedOut")]
        public string DiedOut { get; set; }

        [JsonProperty(PropertyName = "ancestralWeapons")]
        public string[] AncestralWeapons { get; set; }

        [JsonProperty(PropertyName = "cadetBranches")]
        public string[] CadetBranches { get; set; }

        [JsonProperty(PropertyName = "swornMembers")]
        public string[] SwornMembers { get; set; }
    }
}
