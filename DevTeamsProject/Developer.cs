using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string DeveloperFirstName { get; set; }
        public string DeveloperLastName { get; set; }
        public bool HasAccess { get; set; }

        public Developer() { }

        public Developer(int developerId, string developerFirstName, string developerLastName, bool hasAccess)
        {
            DeveloperId = developerId;
            DeveloperFirstName = developerFirstName;
            DeveloperLastName = developerLastName;
            HasAccess = hasAccess;
        }
    }
}
