using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public class StateOfElectionSqlService : IStateOfElectionRepository
    {
        public void InitializeStateOfElection(StateOfElection stateOfElection)
        {
            using (var context = new Context())
            {
                context.StateOfElection.Add(stateOfElection);
                context.SaveChanges();
            }
        }

        public StateOfElection GetStateOfElection()
        {
            using (var context = new Context())
            {
                return context.StateOfElection.FirstOrDefault();
            }
        }

        public void UpdateStateOfElection(StateOfElection stateOfElection)
        {
            using (var context = new Context())
            {
                    context.StateOfElection.Update(stateOfElection);
                    context.SaveChanges();
            }
            
        }
    }
}
