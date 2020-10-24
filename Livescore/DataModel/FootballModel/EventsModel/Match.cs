using System;
using System.Collections.Generic;
using System.Text;

namespace Livescore.DataModel.EventsModel
{
    public class Match
    {
        public string match_id { get; set; }
        public string country_id { get; set; }
        public string country_name { get; set; }
        public string league_id { get; set; }
        public string league_name { get; set; }
        public string match_date { get; set; }
        public string match_status { get; set; }
        public string match_time { get; set; }
        public string match_hometeam_id { get; set; }
        public string match_hometeam_name { get; set; }
        public string match_hometeam_score { get; set; }
        public string match_awayteam_name { get; set; }
        public string match_awayteam_id { get; set; }
        public string match_awayteam_score { get; set; }
        public string match_hometeam_halftime_score { get; set; }
        public string match_awayteam_halftime_score { get; set; }
        public string match_hometeam_extra_score { get; set; }
        public string match_awayteam_extra_score { get; set; }
        public string match_hometeam_penalty_score { get; set; }
        public string match_awayteam_penalty_score { get; set; }
        public string match_hometeam_ft_score { get; set; }
        public string match_awayteam_ft_score { get; set; }
        public string match_hometeam_system { get; set; }
        public string match_awayteam_system { get; set; }
        public string match_live { get; set; }
        public string match_round { get; set; }
        public string match_stadium { get; set; }
        public string match_referee { get; set; }
        public string team_home_badge { get; set; }
        public string team_away_badge { get; set; }
        public string league_logo { get; set; }
        public string country_logo { get; set; }
        public object[] goalscorer { get; set; }
        public object[] cards { get; set; }
        public Substitutions substitutions { get; set; }
        public Lineup lineup { get; set; }
        public object[] statistics { get; set; }
    }
}
