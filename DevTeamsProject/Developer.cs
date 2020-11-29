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
        public string DeveloperName { get; set; }
        public bool HasAccess { get; set; }

        public Developer() { }

        public Developer(int developerId, string developerName, bool hasAccess)
        {
            DeveloperId = developerId;
            DeveloperName = developerName;
            HasAccess = hasAccess;
        }
    }
}
