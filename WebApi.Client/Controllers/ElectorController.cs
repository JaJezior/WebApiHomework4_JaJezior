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
    public class ElectorController : ControllerBase
    {
        private IElectorRepository _electorRepository;
        private ICandidateRepository _candidateRepository;
        public ElectorController(ICandidateRepository candidateRepository)
        {
            _electorRepository = new ElectorSqlService();
            _candidateRepository = candidateRepository;
            //to jest sposób na DI dla WebApi (generyczna funckja VS?)
        }
        [HttpGet]
        public List<Elector> GetListOfElectors()
        {
            List<Elector> listOfElectors = _electorRepository.GetListOfElectors();
            return listOfElectors;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _electorRepository.DeleteElectorFromList(id);
        }
        [HttpPost]
        public void Post([FromBody] Elector elector)
        {
            _electorRepository.RegisterElector(elector);
        }
    }
}
