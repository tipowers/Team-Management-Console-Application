﻿using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsConsole
{
    class ProgramUI
    {
        private readonly DevTeamRepo _devTeams = new DevTeamRepo();
        private readonly DeveloperRepo _developerRepo = new DeveloperRepo();

        public void Run()
        {
            SeedContentList();
            PrimaryMenu();
        }

        public void PrimaryMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n\n" +
                    "1. View All Teams\n" +
                    "2. View Team By Id\n" +
                    "3. Create New Team\n" +
                    "4. Update Existing Team\n" +
                    "5. Delete Existing Team\n\n" +
                    "6. View All Team Members\n" +
                    "7. View Team Member By Id\n" +
                    "8. Create New Team Member\n" +
                    "9. Update Existing Team Member\n" +
                    "10. Delete Existing Team Member\n\n" +
                    "11. Pluralsight Report\n\n" +
                    "0. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllTeams();
                        break;
                    case "2":
                        DisplayTeamsById();
                        break;
                    case "3":
                        CreateNewTeam();
                        break;
                    case "4":
                        UpdateExistingTeam();
                        break;
                    case "5":
                        DeleteExistingTeam();
                        break;
                    case "6":
                        DisplayAllTeamMembers();
                        break;
                    case "7":
                        DisplayTeamMemberById();
                        break;
                    case "8":
                        CreateNewTeamMember();
                        break;
                    case "9":
                        UpdateExistingTeamMember();
                        break;
                    case "10":
                        DeleteExistingTeamMember();
                        break;
                    case "11":
                        PluralsightReport();
                        break;
                    case "0":
                        Console.WriteLine("\nTake care now. Bye bye then!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Continue();
            }
        }

        public void Continue()
        {
            Console.WriteLine("\nPlease press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private void DisplayAllTeams()
        {
            Console.Clear();
            List<DevTeam> listOfTeams = _devTeams.GetTeamList();

            foreach (DevTeam teamContent in listOfTeams)
            {
                Console.WriteLine($"\nTeam Id: {teamContent.TeamId}\n" +
                    $"Team Name: {teamContent.TeamName}\n");

                foreach (Developer memberContent in teamContent.DeveloperList)
                {
                    Console.WriteLine($"Team Member Details:\n" +
                        $"Developer Id: {memberContent.DeveloperId}\n" +
                        $"First Name: {memberContent.DeveloperFirstName}\n" +
                        $"Last Name: {memberContent.DeveloperLastName}\n" +
                        $"Pluralsight Access: {memberContent.HasAccess}\n");
                }
            }
        }

        private void DisplayAllTeamMembers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetUserList();

            foreach (Developer memberContent in listOfDevelopers) {
                Console.WriteLine($"Developer Id: {memberContent.DeveloperId}\n" +
                    $"First Name: {memberContent.DeveloperFirstName}\n" +
                    $"Last Name: {memberContent.DeveloperLastName}\n" +
                    $"Pluralsight Access: {memberContent.HasAccess}\n");
            }
        }

        private void DisplayTeamsById()
        {
            Console.Clear();
            DisplayAllTeams();

            Console.WriteLine("Enter the Id of the team you'd like to see:");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);

            DevTeam teamContent = _devTeams.GetTeamListById(idAsInt);

            Console.Clear();

            if (teamContent != null)
            {
                Console.WriteLine($"\nTeam Id: {teamContent.TeamId}\n" +
                    $"Team Name: {teamContent.TeamName}\n");

                foreach (Developer memberContent in teamContent.DeveloperList)
                {
                    Console.WriteLine($"Team Member Details:\n" +
                        $"Developer Id: {memberContent.DeveloperId}\n" +
                        $"First Name: {memberContent.DeveloperFirstName}\n" +
                        $"Last Name: {memberContent.DeveloperLastName}\n" +
                        $"Pluralsight Access: {memberContent.HasAccess}\n");
                }
            }
            else
            {
                Console.WriteLine("No team by that Id.\n");
            }
        }

        private void DisplayTeamMemberById()
        {
            Console.Clear();
            DisplayAllTeamMembers();

            Console.WriteLine("Enter the Id of the team member you'd like to see:");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);

            Developer memberContent = _developerRepo.GetUserListById(idAsInt);

            Console.Clear();

            if (memberContent != null)
            {
                Console.WriteLine($"Team Member Details:\n" +
                    $"\nDeveloper Id: {memberContent.DeveloperId}\n" +
                    $"First Name: {memberContent.DeveloperFirstName}\n" +
                    $"Last Name: {memberContent.DeveloperLastName}\n" +
                    $"Pluralsight Access: {memberContent.HasAccess}\n");
            }
            else
            {
                Console.WriteLine("No user by that Id.\n");
            }
        }

        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newContent = new DevTeam();

            Console.WriteLine("Enter the new Team Name:");
            newContent.TeamName = Console.ReadLine();

            Console.WriteLine("\nEnter the new Team Id:");
            string teamIdAsString = Console.ReadLine();
            int teamIdAsInt = int.Parse(teamIdAsString);
            newContent.TeamId = teamIdAsInt;

            _devTeams.AddTeamToList(newContent);
        }

        private void CreateNewTeamMember()
        {
            Console.Clear();
            Developer newMember = new Developer();

            Console.WriteLine("Enter the new member's Id: (Take note of duplications and update accordingly)");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);
            newMember.DeveloperId = idAsInt;

            Console.WriteLine("\nEnter the new member's first name:");
            newMember.DeveloperFirstName = Console.ReadLine();

            Console.WriteLine("\nEnter the new member's last name:");
            newMember.DeveloperLastName = Console.ReadLine();

            Console.WriteLine("\nEnter the member's Pluralsight status: ('true' for yes and 'false' for no)");
            string boolAsString = Console.ReadLine();
            bool boolAsBool = bool.Parse(boolAsString);
            newMember.HasAccess = boolAsBool;

            _developerRepo.AddUserToList(newMember);
        }

        private void UpdateExistingTeam()
        {
            DisplayAllTeams();

            Console.WriteLine("Enter the Team Id to update:");
            string oldteamIdAsString = Console.ReadLine();
            int oldteamIdAsInt = int.Parse(oldteamIdAsString);

            DevTeam newContent = new DevTeam();

            Console.WriteLine("\nEnter the new Team Name:");
            newContent.TeamName = Console.ReadLine();

            Console.WriteLine("\nEnter the new Team Id:");
            string teamIdAsString = Console.ReadLine();
            int teamIdAsInt = int.Parse(teamIdAsString);
            newContent.TeamId = teamIdAsInt;

            bool wasUpdated = _devTeams.UpdateExistingTeam(oldteamIdAsInt, newContent);
            if (wasUpdated)
            {
                Console.WriteLine("\nTeam successfully updated!");
            }
            else
            {
                Console.WriteLine("\nCould not update team.");
            }
        }

        private void UpdateExistingTeamMember()
        {
            DisplayAllTeamMembers();

            Console.WriteLine("Enter the team member Id to update:");
            string oldidAsString = Console.ReadLine();
            int oldIdAsInt = int.Parse(oldidAsString);

            Developer newMemberContent = new Developer();

            Console.WriteLine("\nEnter the team member's new Id:");
            string newIdAsString = Console.ReadLine();
            int newIdAsInt = int.Parse(newIdAsString);
            newMemberContent.DeveloperId = newIdAsInt;

            Console.WriteLine("\nEnter the team member's new first name:");
            newMemberContent.DeveloperFirstName = Console.ReadLine();

            Console.WriteLine("\nEnter the team member's new last name:");
            newMemberContent.DeveloperLastName = Console.ReadLine();

            Console.WriteLine("\nEnter the member's new Pluralsight status: ('true' for yes and 'false' for no)");
            string boolAsString = Console.ReadLine();
            bool boolAsBool = bool.Parse(boolAsString);
            newMemberContent.HasAccess = boolAsBool;

            bool wasUpdated = _developerRepo.UpdateExistingUser(oldIdAsInt, newMemberContent);
            if (wasUpdated)
            {
                Console.WriteLine("\nTeam member successfully updated!");
            }
            else
            {
                Console.WriteLine("\nCould not update team member.");
            }
        }

        private void DeleteExistingTeam()
        {
            DisplayAllTeams();

            Console.WriteLine("Enter the Team Id to delete that team.");
            string teamIdAsString = Console.ReadLine();
            int teamIdAsInt = int.Parse(teamIdAsString);

            bool wasDeleted = _devTeams.RemoveTeamFromList(teamIdAsInt);

            if (wasDeleted)
            {
                Console.WriteLine("\nThe team was successfully deleted!");
            }
            else
            {
                Console.WriteLine("\nThe team could not be deleted");
            }
        }

        private void DeleteExistingTeamMember()
        {
            DisplayAllTeamMembers();

            Console.WriteLine("Enter the Team Member Id to delete member:");
            string memberIdAsString = Console.ReadLine();
            int memberIdAsInt = int.Parse(memberIdAsString);

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(memberIdAsInt);

            if (wasDeleted)
            {
                Console.WriteLine("\nThe team member was successfully deleted!");
            }
            else
            {
                Console.WriteLine("\nCould not delete team member.");
            }
        }

        private void PluralsightReport()
        {
            Console.Clear();
            List<Developer> developerList = _developerRepo.GetUserList();

            Console.WriteLine("Team Members WITH Pluralsight:");
            foreach (Developer teamMemberAccess in developerList)
            {
                if (teamMemberAccess.HasAccess == true)
                {
                    Console.WriteLine($"\nDeveloper Id: {teamMemberAccess.DeveloperId}\n" +
                        $"Full Name: {teamMemberAccess.DeveloperFirstName} {teamMemberAccess.DeveloperLastName}\n");
                }
            }

            Console.WriteLine($"\n\nTeam Members WITHOUT Pluralsight:");
            foreach (Developer teamMemberAccess in developerList)
            {
                if (teamMemberAccess.HasAccess != true)
                {
                    Console.WriteLine($"\nDeveloper Id: {teamMemberAccess.DeveloperId}\n" +
                        $"Full Name: {teamMemberAccess.DeveloperFirstName} {teamMemberAccess.DeveloperLastName}");
                }
            }
        }

        private void SeedContentList()
        {

            Developer devOne = new Developer(1, "Tommy", "Oliver", true);
            Developer devTwo = new Developer(2, "Kimberly", "Hart", false);
            Developer devThree = new Developer(3, "Jason", "Scott", true);
            Developer devFour = new Developer(4, "Billy", "Cranston", false);
            Developer devFive = new Developer(5, "Trini", "Kwan", true);
            Developer devSix = new Developer(6, "Zack", "Taylor", false);

            _developerRepo.AddUserToList(devOne);
            _developerRepo.AddUserToList(devTwo);
            _developerRepo.AddUserToList(devThree);
            _developerRepo.AddUserToList(devFour);
            _developerRepo.AddUserToList(devFive);
            _developerRepo.AddUserToList(devSix);

            DevTeam testOne = new DevTeam(1, "MMPR", new List<Developer>() { devOne, devTwo });
            DevTeam testTwo = new DevTeam(2, "Zeo", new List<Developer>() { devThree, devFour });
            DevTeam testThree = new DevTeam(3, "Turbo", new List<Developer>() { devFive, devSix });

            _devTeams.AddTeamToList(testOne);
            _devTeams.AddTeamToList(testTwo);
            _devTeams.AddTeamToList(testThree);
        }
    }
}
