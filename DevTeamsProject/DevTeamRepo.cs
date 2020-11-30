using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddTeamToList(DevTeam content)
        {
            _devTeams.Add(content);
        }

        public void AddUserToTeamList(Developer developers, DevTeam devTeam)
        {
            devTeam.DeveloperList.Add(developers);
        }

        //DevTeam Read
        public List<DevTeam> GetTeamList()
        {
            return _devTeams;
        }

        //DevTeam Update
        public bool UpdateExistingTeam(int originalTeamId, DevTeam newContent)
        {
            DevTeam oldContent = GetTeamListById(originalTeamId);

            if (oldContent != null)
            {
                oldContent.TeamId = newContent.TeamId;
                oldContent.TeamName = newContent.TeamName;

                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool RemoveTeamFromList(int id)
        {
            DevTeam content = GetTeamListById(id);

            if (content == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(content);

            if (initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamListById(int id)
        {
            foreach (DevTeam info in _devTeams)
            {
                if (info.TeamId == id)
                {
                    return info;
                }
            }
            return null;
        }
    }
}
