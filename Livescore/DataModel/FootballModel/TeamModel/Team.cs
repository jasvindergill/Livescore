using System;
using System.Collections.Generic;
using System.Text;

namespace Livescore.DataModel.TeamModel
{
    public class Team
    {
        public string team_key { get; set; }
        public string team_name { get; set; }
        public string team_badge { get; set; }
        public Player[] players { get; set; }
        public Coach[] coaches { get; set; }
    }
}
