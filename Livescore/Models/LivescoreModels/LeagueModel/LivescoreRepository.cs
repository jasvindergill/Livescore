using Livescore.DataModel.LeagueModel;
using Livescore.Models.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Models.LivescoreModels.LeagueModel
{
    public class LivescoreRepository : Base
    {
        private string actionUrl = string.Empty;

        public async Task<League> GetLeagues()
        {
            actionUrl = "get_leagues";

            var result = await GetResponse(actionUrl);

            if (result.Successful)
            {
                try
                {
                    var leagues = JsonConvert.DeserializeObject<League>(result.Response);
                    return leagues;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
                return null;
        }
    }
}

