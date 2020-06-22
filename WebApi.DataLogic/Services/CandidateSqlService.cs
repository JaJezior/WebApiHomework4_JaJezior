using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public interface ICandidateRepository
    {
        void AddCandidate(Candidate candidate); //post
        void VoteForCandidate(int id); //put 
        List<Candidate> GetListOfCandidates(); //get
    }
    public class CandidateSqlService : ICandidateRepository
    {
        private readonly Context context;

        public CandidateSqlService(Context context)
        {
            this.context = context;
            //KOMENTARZ - zostawiam zakomentowany kod jako notatki na przyszłość.
            //ten konstruktor odpowiada za wstrzyknięcie dziedziczenia klasy Context za każdym razem, gdy jest tworzona instancja klasy tego serwisu.
            //dlatego można zakomentować usingi, gdyż w klasie Startup zdefiniowano tworzenie instancji klasy Context tylko na jedno zapytanie do WebApi.
        }
        public void AddCandidate(Candidate candidate)
        {
            //using(var context = new Context())
            {
                context.Candidates.Add(candidate);
                context.SaveChanges();
            }
        }

        public List<Candidate> GetListOfCandidates()
        {
            var listOfCandidates = new List<Candidate>();
            //using (var context = new Context())
            {
                listOfCandidates = context.Candidates.ToList();
            }
            return listOfCandidates;
        }

        public void VoteForCandidate(int id)
        {
            //using (var context = new Context())
            {
                context.Candidates.FirstOrDefault(x => x.Id == id).Votes += 1;
                context.SaveChanges();
            }
        }
    }
}
