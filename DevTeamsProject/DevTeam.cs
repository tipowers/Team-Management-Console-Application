using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public DevTeam() { }

        public DevTeam(int teamId, string teamName)
        {
            TeamId = teamId;
            TeamName = teamName;
        }
    }
}
