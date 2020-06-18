using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.DataLogic;
using WebApi.Model;

namespace WebApi.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        
        private IElectorRepository electorRepository;
        private ICandidateRepository _candidateRepository;

        public CandidateController(/*ICandidateRepository candidateRepository*/)
        {
            //electorRepository = new ElectorSqlService();

            _candidateRepository = new CandidateSqlService();
            //_candidateRepository = candidateRepository;
            //to jest sposób na DI dla WebApi (generyczna funckja VS?)
            
            //var c1 = new Candidate { Id = 1, FirstName = "Andżej", LastName = "Duduś" };
            //var c2 = new Candidate { Id = 2, FirstName = "Andriu", LastName = "Leppa" };
            //_candidateRepository.AddCandidate(c1);
            //_candidateRepository.AddCandidate(c2);
        }
        [HttpGet]
        public List<Candidate> Get()
        {
            //var testList = new List<Candidate>();
            //var c1 = new Candidate { Id = 1, FirstName = "Andżej", LastName = "Duduś" };
            //var c2 = new Candidate { Id = 2, FirstName = "Andriu", LastName = "Leppa" };
            
            List<Candidate> listOfCandidates = _candidateRepository.GetListOfCandidates();
            //listOfCandidates.Add(c1);
            //listOfCandidates.Add(c2);
            return listOfCandidates;
        }
        [HttpPost]
        public void Post([FromBody] Candidate candidate)
        {
            _candidateRepository.AddCandidate(candidate);
        }
        [HttpPut("{id}")]
        public void Put(int id)
        {
            _candidateRepository.VoteForCandidate(id);
        }
    }
}
