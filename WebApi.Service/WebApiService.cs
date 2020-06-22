using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WebApi.Model;

namespace WebApi.Service
{
    public class WebApiService
    {
        HttpClient _client = new HttpClient();
        public WebApiService()
        {
            _client.BaseAddress = new Uri("https://localhost:44339");
        }

        public List<Candidate> GetListOfCandidates()
        {
            var response = _client.GetAsync("Candidate").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResult = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Candidate>>(stringResult);
                return obj;
            }
            else
            {
                throw new Exception("Wrong response code");
            }
        }

        public void InitializeListOfElectors(int amountOfElectors)
        {
            for (int x=0; x <= amountOfElectors; x++)
            {
                var elector = new Elector() { PESEL = 1000 + x };
                var stringJson = JsonConvert.SerializeObject(elector);
                HttpContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                var response = _client.PostAsync("Elector", content).Result;
            }
        }

        public void AddNewCandidate(Candidate candidate)
        {
            var stringJson = JsonConvert.SerializeObject(candidate);
            HttpContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
            var response = _client.PostAsync("Candidate", content).Result;
        }

        public StateOfElection GetStateOfElection()
        {
            var response = _client.GetAsync("Election").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResult = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<StateOfElection>(stringResult);
                return obj;
            }
            else
            {
                throw new Exception("Wrong response code");
            }
        }

        public void RestoreElection()
        {
            var electionState = GetStateOfElection();
            electionState.IsElectionStarted = true;
            electionState.IsElectionEnded = false;

            var stringJson = JsonConvert.SerializeObject(electionState);
            HttpContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");

            var response = _client.PutAsync($"Election", content).Result;
        }

        public void AddNewStateOfElection()
        {
            var electionState = new StateOfElection();

            var stringJson = JsonConvert.SerializeObject(electionState);
            HttpContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");

            var response = _client.PostAsync($"Election", content).Result;
        }

        public void EndElection()
        {
            var electionState = GetStateOfElection();
            electionState.IsElectionEnded= true;

            var stringJson = JsonConvert.SerializeObject(electionState);
            HttpContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");

            var response = _client.PutAsync($"Election", content).Result;
        }

        public void StartElection()
        {
            var electionState = GetStateOfElection();
            electionState.IsElectionStarted = true;

            var stringJson = JsonConvert.SerializeObject(electionState);
            HttpContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");

            var response = _client.PutAsync($"Election", content).Result;
        }

        public void DeleteElector(int id)
        {
            var response = _client.DeleteAsync($"Elector/{id}").Result;
        }

        public void AddVote(int candidateId)
        {
            var stringJson = JsonConvert.SerializeObject(candidateId);
            HttpContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");

            var response = _client.PutAsync($"Candidate/{candidateId}", content).Result;
        }

        public List<Elector> GetListOfElectors()
        {
            var response = _client.GetAsync("Elector").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResult = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Elector>>(stringResult);
                return obj;
            }
            else
            {
                throw new Exception("Wrong response code");
            }
        }
    }
}
