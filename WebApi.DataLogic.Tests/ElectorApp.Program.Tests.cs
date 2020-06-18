using System;
using System.Collections.Generic;
using ElectoralCommisionApp;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using WebApi.Model;
using ElectorApp;
using Xunit;

namespace WebApi.DataLogic.Tests
{
    public class ElectorAppProgramTests
    {
        [Fact]
        public void ValidatePESEL_ExistingPesel_PESELValid()
        {
            var program = new ElectorApp.Program();
            int userPesel = 3;
            var listOfElectors = new List<Elector>()
            {
                new Elector() { Id = 2, PESEL = 2},
                new Elector() { Id = 3, PESEL = 3},
                new Elector() { Id = 4, PESEL = 4},
            };
            
            Assert.True(program.ValidatePESEL(userPesel, listOfElectors));

        }
    }
}
