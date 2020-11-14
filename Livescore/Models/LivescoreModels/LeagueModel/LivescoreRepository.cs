using Livescore.DataModel.LeagueModel;
using Livescore.Models.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Models.LivescoreModels.LeagueModel
{
    public class LivescoreRepository : Base, INotifyPropertyChanged
    {
        private string actionUrl = string.Empty;
        readonly IList<League> source;
        public ObservableCollection<League> Leagues { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LivescoreRepository()
        {
            source = new List<League>();
            GetLeagues();
        }

        public async void GetLeagues()
        {
            actionUrl = "get_leagues";

            var result = await GetResponse(actionUrl);

            if (result.Successful)
            {
                try
                {
                    List<League> leagues = new List<League>();
                    leagues = JsonConvert.DeserializeObject<List<League>>(result.Response);
                    foreach (var league in leagues)
                    {
                        source.Add(league);
                    }

                    Leagues = new ObservableCollection<League>(source);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
            
        }
    }
}

