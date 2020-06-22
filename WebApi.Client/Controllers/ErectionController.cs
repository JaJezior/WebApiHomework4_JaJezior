using Microsoft.AspNetCore.Mvc;
using WebApi.DataLogic;
using WebApi.Model;

namespace WebApi.Client.Controllers
{
    [ApiController]
    [Route("[controller]")] //Nazwa, czyli url [controller] jest brana z nazwy klasy ___Controller, tutaj Election
    public class ElectionController : ControllerBase
    {

        private IStateOfElectionRepository _stateOfElection;
        public ElectionController(IStateOfElectionRepository stateOfElection)
        {
            _stateOfElection = stateOfElection;
            //to jest sposób na DI dla WebApi (generyczna funckja VS?)
        }
        [HttpGet]
        public StateOfElection GetElectionStatus()
        {
            var stateOfElection = _stateOfElection.GetStateOfElection();
            return stateOfElection;
        }
        [HttpPut]
        public void Put([FromBody] StateOfElection stateOfElection)
        {
            _stateOfElection.UpdateStateOfElection(stateOfElection);
        }
        [HttpPost]
        public void Post([FromBody] StateOfElection stateOfElection)
        {
            _stateOfElection.InitializeStateOfElection(stateOfElection);
        }

    }
}
