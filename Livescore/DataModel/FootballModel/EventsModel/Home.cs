using System;
using System.Collections.Generic;
using System.Text;

namespace Livescore.DataModel.EventsModel
{
    public class Home
    {
        public object[] starting_lineups { get; set; }
        public object[] substitutes { get; set; }
        public object[] coach { get; set; }
        public object[] missing_players { get; set; }
    }
}
