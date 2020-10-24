using Livescore.DataModel.LeagueModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Livescore.Utils.Preference
{
    static class LeaguePreference
    {
        public static List<League> SavedLeagueList
        {
            get
            {
                var savedLeagueList = Deserialize<List<League>>(Preferences.Get(nameof(SavedLeagueList), null));
                return savedLeagueList ?? new List<League>();
            }
            set
            {
                var serializedLeagueList = Serialize(value);
                Preferences.Set(nameof(SavedLeagueList), serializedLeagueList);
            }
        }

        //May need to reference T to League
        static T Deserialize<T>(string serializedObject) => JsonConvert.DeserializeObject<T>(serializedObject);

        static string Serialize<T>(T objectToSerialize) => JsonConvert.SerializeObject(objectToSerialize);
    }

    //Method to implement at main 
    //void AddToList(string text)
    //{
    //    var savedList = new List<string>(Preferences.SavedList);

    //    savedList.Add(text);

    //    Preferences.SavedList = savedList;
    //}
}
