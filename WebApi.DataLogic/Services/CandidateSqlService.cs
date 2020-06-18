using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public class CandidateSqlService : ICandidateRepository
    {
        public void AddCandidate(Candidate candidate)
        {
            using(var context = new Context())
            {
                context.Candidates.Add(candidate);
                context.SaveChanges();
            }
        }

        public List<Candidate> GetListOfCandidates()
        {
            var listOfCandidates = new List<Candidate>();
            using (var context = new Context())
            {
                listOfCandidates = context.Candidates.ToList();
            }
            return listOfCandidates;
        }

        public void VoteForCandidate(int id)
        {
            using (var context = new Context())
            {
                context.Candidates.FirstOrDefault(x => x.Id == id).Votes += 1;
                context.SaveChanges();
            }
        }
    }
}
