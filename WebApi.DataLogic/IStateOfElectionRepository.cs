using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public interface IStateOfElectionRepository
    {
        void InitializeStateOfElection(StateOfElection stateOfElection); //post
        StateOfElection GetStateOfElection(); //get
        void UpdateStateOfElection(StateOfElection stateOfElection); //put
    }
}
