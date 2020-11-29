using DevTeamsProject;
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
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\nSelect a menu option:\n" +
                    "1. View All Teams\n" +
                    "2. View Team By Id\n" +
                    "3. Create New Team\n" +
                    "4. Update Existing Team\n" +
                    "5. Delete Existing Team\n" +
                    "6. Exit");

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
                        Console.WriteLine("\nTake care now. Bye bye then!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayAllTeams()
        {
            Console.Clear();
            List<DevTeam> listOfTeams = _devTeams.GetTeamList();

            foreach (DevTeam content in listOfTeams)
            {
                Console.WriteLine($"\nTeam Name: {content.TeamName}\n" +
                    $"Team Id: {content.TeamId}");
            }
        }

        private void DisplayTeamsById()
        {
            Console.Clear();
            DisplayAllTeams();
            Console.WriteLine("\nEnter the Id of the team you'd like to see:");

            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);

            DevTeam content = _devTeams.GetTeamListById(idAsInt);

            Console.Clear();

            if (content != null)
            {
                Console.WriteLine($"\nTeam Name: {content.TeamName}\n" +
                    $"Team Id: {content.TeamId}");
            }
            else
            {
                Console.WriteLine("No team by that Id.");
            }
        }

        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newContent = new DevTeam();

            Console.WriteLine("\nEnter the new Team Name:");
            newContent.TeamName = Console.ReadLine();

            Console.WriteLine("Enter the new Team Id:");
            string teamIdAsString = Console.ReadLine();
            int teamIdAsInt = int.Parse(teamIdAsString);
            newContent.TeamId = teamIdAsInt;

            _devTeams.AddTeamToList(newContent);
        }

        private void UpdateExistingTeam()
        {
            DisplayAllTeams();

            Console.WriteLine("\nEnter the Team Id to update:");
            string oldteamIdAsString = Console.ReadLine();
            int oldteamIdAsInt = int.Parse(oldteamIdAsString);

            DevTeam newContent = new DevTeam();

            Console.WriteLine("\nEnter the new Team Name:");
            newContent.TeamName = Console.ReadLine();

            Console.WriteLine("Enter the new Team Id:");
            string teamIdAsString = Console.ReadLine();
            int teamIdAsInt = int.Parse(teamIdAsString);
            newContent.TeamId = teamIdAsInt;

            bool wasUpdated = _devTeams.UpdateExistingTeam(oldteamIdAsInt, newContent);
            if (wasUpdated)
            {
                Console.WriteLine("Team successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update team.");
            }
        }

        private void DeleteExistingTeam()
        {
            DisplayAllTeams();

            Console.WriteLine("\nEnter the Team Id to delete that team.");
            string teamIdAsString = Console.ReadLine();
            int teamIdAsInt = int.Parse(teamIdAsString);

            bool wasDeleted = _devTeams.RemoveTeamFromList(teamIdAsInt);

            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully deleted!");
            }
            else
            {
                Console.WriteLine("The team could not be deleted");
            }
        }

        private void SeedContentList()
        {
            DevTeam testOne = new DevTeam(1, "Test Team One");
            DevTeam testTwo = new DevTeam(2, "Test Team Two");
            DevTeam testThree = new DevTeam(3, "Test Team Three");

            _devTeams.AddTeamToList(testOne);
            _devTeams.AddTeamToList(testTwo);
            _devTeams.AddTeamToList(testThree);
        }
    }
}
