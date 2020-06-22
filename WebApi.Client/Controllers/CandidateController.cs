using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
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
        //ICandidateRepository _candidateRepository = new CandidateSqlService();
        ICandidateRepository _candidateRepository;
        public CandidateController(ICandidateRepository candidateRepository)
        {
            //var container = ContainerBuilderCreator.CreateBasicContainerBuilder().Build();
            //_candidateRepository = container.Resolve<CandidateSqlService>();
            _candidateRepository = candidateRepository;
        }
        [HttpGet]
        public List<Candidate> Get()
        {
            List<Candidate> listOfCandidates = _candidateRepository.GetListOfCandidates();
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
