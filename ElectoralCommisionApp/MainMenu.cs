using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using WebApi.Model;
using WebApi.Service;

namespace ElectoralCommisionApp
{
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            AddMenuItem("Show election results", ShowElectionResults);
            AddMenuItem("Start election", StartElection);
            AddMenuItem("End election", EndElection);
            AddMenuItem("Add candidate", AddCandidate);
            AddMenuItem("Initialize list of electors", AddElectors);
        }
        WebApiService webApiService = new WebApiService();

        private void AddElectors()
        {
            while (true)
            {
                Console.WriteLine("How many fake, russian electors would you like to create?");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int amount))
                {
                    webApiService.InitializeListOfElectors(amount);
                    break;
                }
                else
                {
                    Console.WriteLine("incorrect format");
                }
            }
            
        }
        
        private void AddCandidate()
        {
            if (webApiService.GetStateOfElection().IsElectionStarted == true)
            {
                Console.WriteLine("Cannot add a candidate. Election has already been started.");
            }
            else
            {
                var candidate = new Candidate();

                //candidate.Id = AskUserForId();

                Console.WriteLine("Enter candidate's first name:");
                candidate.FirstName = Console.ReadLine();

                Console.WriteLine("Enter candidate's last name:");
                candidate.LastName = Console.ReadLine();

                webApiService.AddNewCandidate(candidate);


                Console.WriteLine($"Candidate: {candidate.FirstName} {candidate.LastName}  has been added.");
                //Console.WriteLine($"Candidate: {candidate.Id}. {candidate.FirstName} {candidate.LastName}  has been added.");
            }
        }

        private void EndElection()
        {
            if (webApiService.GetStateOfElection().IsElectionStarted == false)
            {
                Console.WriteLine("You cannot end elecion. It has not started yet.");
            }
            if (webApiService.GetStateOfElection().IsElectionEnded == true)
            {
                Console.WriteLine("Election has been ended before.");
            }
            if (webApiService.GetStateOfElection().IsElectionStarted == true)
            {
                webApiService.EndElection();
                Console.WriteLine("Election process has been ended. Voting unavailable.");
            }
        }

        private void StartElection()
        {
            if(webApiService.GetStateOfElection().IsElectionStarted == false)
            {
                webApiService.StartElection();
                Console.WriteLine("Election process has been started. No candidates can be added. Electors now can vote.");
            }
            if (webApiService.GetStateOfElection().IsElectionStarted == true)
            {
                Console.WriteLine("Cannot start elections, it has already been started!");
            }
            if(webApiService.GetStateOfElection().IsElectionEnded == true)
            {
                Console.WriteLine("Elections ended. Do you want to restore? Y/N");
                var input = Console.ReadLine();
                if(input =="Y" || input == "y")
                {
                    webApiService.RestoreElection();
                    Console.WriteLine("Election has been restored.  No candidates can be added. Electors now can vote.");
                }
                else
                {
                    Console.WriteLine("Election is still ended.");
                }
            }
        }

        private void ShowElectionResults()
        {
            var listOfCandidates = webApiService.GetListOfCandidates();
            int sumOfVotes = GetSumOfVotes(listOfCandidates);
            if(sumOfVotes == 0)
            {
                Console.WriteLine("Nobody has voted yet.");
            }
            else
            {
                foreach (Candidate candidate in listOfCandidates)
                {
                    double percentageResult = Math.Round((100f * candidate.Votes / sumOfVotes));
                    Console.WriteLine($"{candidate.Id}. {candidate.LastName} {candidate.FirstName} [ Votes: {candidate.Votes}, (percent of total: {percentageResult}%) ]");
                }
            }
        }

        private int GetSumOfVotes(List<Candidate> listOfCandidates)
        {
            int sumOfVotes = 0;
            foreach (Candidate candidate in listOfCandidates)
            {
                sumOfVotes += candidate.Votes;
            }
            return sumOfVotes;
        }

        private int AskUserForId()
        {
            while (true)
            {
                Console.WriteLine("Enter candidate's ID:");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int id) && !webApiService.GetListOfCandidates().Exists(x => x.Id == id))
                {
                    return id;
                }
                else
                {
                    Console.WriteLine("Choosen ID already exists or your input had incorrect format.");
                }
            }
        }
    }
}
