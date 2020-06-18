using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebApi.Model;
using WebApi.Service;

namespace ElectorApp
{
    class Program
    {
        static void Main()
        {
            var program = new Program();
            program.Run();
        }

        WebApiService webApiService = new WebApiService();

        private void Run()
        {
            if (webApiService.GetStateOfElection().IsElectionStarted == false)
            {
                Console.WriteLine("ACCESS DENIED. Election has not started yet.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            if (webApiService.GetStateOfElection().IsElectionEnded == true)
            {
                Console.WriteLine("ACCESS DENIED. Election ended. You are late.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                var userPESEL = AskUserForPESEL();
                ValidatePESEL(userPESEL);

                List<Candidate> listOfCandidates = GetListOfCandidates();
                PrintListOfCandidates(listOfCandidates);

                int userVote = AskUserForCandidatesId(listOfCandidates);
                VoteForCandidateById(userVote);
                DeleteUserPESELfromList(userPESEL);
                Console.ReadKey();
            }
        }

        private void DeleteUserPESELfromList(int userPESEL)
        {
            var id = webApiService.GetListOfElectors().FirstOrDefault(x => x.PESEL == userPESEL).Id;
            webApiService.DeleteElector(id);
            Console.WriteLine($"Thank you, {userPESEL}, and have a nice day!");
        }

        private void VoteForCandidateById(int userVoteCandidateID)
        {
            webApiService.AddVote(userVoteCandidateID);
            Console.WriteLine("Your vote has been added.");
        }

        private int AskUserForCandidatesId(List<Candidate> listOfCandidates)
        {
            while (true)
            {
                Console.WriteLine("Write your candidate's number:");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userVoteId) && listOfCandidates.Exists(x => x.Id == userVoteId))
                {
                    Console.WriteLine("Vote correct.");
                    return userVoteId;                    
                }
                else
                { Console.WriteLine("Input is invalid"); }
            }
            
        }

        private List<Candidate> GetListOfCandidates()
        {
            return webApiService.GetListOfCandidates();
        }

        private bool ValidatePESEL(int userPESEL)
        {
            bool isPESELvalid = false;
            var listOfElectors = GetListOfElectors();
            if (listOfElectors.Exists(x => x.PESEL == userPESEL))
            {
                isPESELvalid = true;
                Console.WriteLine("PESEL is valid for voting.");
            }
            else
            {
                Console.WriteLine($"Sorry, your PESEL {userPESEL} is invalid. Buy a new one.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return isPESELvalid;
        }

        private List<Elector> GetListOfElectors()
        {
            return webApiService.GetListOfElectors();
        }

        private int AskUserForPESEL()
        {
            bool isPESELint = false;
            int userPESEL=0;
            while (isPESELint == false)
            {
                Console.WriteLine("Write your PESEL, elector:");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out userPESEL))
                {
                    isPESELint = true;
                }
                else
                {
                    Console.WriteLine("PESEL format is invalid.");
                }
            }
            return userPESEL;
        }

        private void PrintListOfCandidates(List<Candidate> listOfCandidates)
        {
            foreach (Candidate candidate in listOfCandidates)
            {
                Console.WriteLine($"{candidate.Id}. {candidate.LastName} {candidate.FirstName}");
            }
        }
    }
}
