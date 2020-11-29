using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddUserToList(Developer content)
        {
            _developerDirectory.Add(content);
        }

        //Developer Read
        public List<Developer> GetUserList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateExistingUser(int originalId, Developer newContent)
        {
            Developer oldContent = GetUserListById(originalId);

            if (oldContent != null)
            {
                oldContent.DeveloperId = newContent.DeveloperId;
                oldContent.DeveloperFirstName = newContent.DeveloperFirstName;
                oldContent.DeveloperLastName = newContent.DeveloperLastName;
                oldContent.HasAccess = newContent.HasAccess;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Developer Delete
        public bool RemoveDeveloperFromList(int id)
        {
            Developer content = GetUserListById(id);

            if (content == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(content);

            if (initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetUserListById(int id)
        {
            foreach (Developer info in _developerDirectory)
            {
                if (info.DeveloperId == id)
                {
                    return info;
                }
            }
            return null;
        }

        /*public Developer UserAccess(bool access)
        {
            foreach (Developer info in _developerDirectory)
            {
                if(info.HasAccess == access)
                {
                    return info;
                }
            }
            return null;
        }*/
    }
}
