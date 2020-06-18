using System;

namespace WebApi.Model
{
    public class Candidate
    {
        public Candidate()
        {
            Votes = 0;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Votes { get; set; }
    }
}
