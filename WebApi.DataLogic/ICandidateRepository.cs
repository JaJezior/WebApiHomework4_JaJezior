using System;
using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public interface ICandidateRepository
    {
        void AddCandidate(Candidate candidate); //post
        void VoteForCandidate(int id); //put 
        List<Candidate> GetListOfCandidates(); //get
    }
}
