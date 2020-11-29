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

        /*public List<Developer> _developerDirectory { get; set; }

        public List<Developer> _developerDirectory = new List<Developer>();*/

        public DevTeam() { }

        public DevTeam(int teamId, string teamName)
        {
            TeamId = teamId;
            TeamName = teamName;
        }

        /*public DevTeam(int teamId, string teamName, List<Developer> devList)
        {
            TeamId = teamId;
            TeamName = teamName;
            _developerDirectory = devList;
        }*/
    }
}
