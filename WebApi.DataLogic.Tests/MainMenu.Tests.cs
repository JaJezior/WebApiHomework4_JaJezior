using System;
using System.Collections.Generic;
using ElectoralCommisionApp;
using WebApi.Model;
using Xunit;

namespace WebApi.DataLogic.Tests
{
    public class MainMenuTests
    {
        [Fact]
        public void GetSumOfVotes_ProperInput_ProperReturn()
        {
            var menu = new MainMenu();
            var listOfCandidates = new List<Candidate>()
            {
                new Candidate(){Votes = 40},
                new Candidate(){Votes = 30},
                new Candidate(){Votes = 11},
                new Candidate(){Votes = 19},
            };

            Assert.Equal(100, menu.GetSumOfVotes(listOfCandidates));

        }
    }
}
