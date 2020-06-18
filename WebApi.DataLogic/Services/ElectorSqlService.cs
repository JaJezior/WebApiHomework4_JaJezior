using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public class ElectorSqlService : IElectorRepository
    {
        public void AddListOfElectors(int amount)
        {
            using (var context = new Context())
            {
                for (int x = 0; x <= amount; x++)
                {
                    context.Electors.Add(new Elector() { PESEL = x });
                }
            }
        }

        public void DeleteElectorFromList(int id)
        {
            using (var context = new Context())
            {
                var elector = context.Electors.First(x => x.Id == id);
                context.Electors.Remove(elector);
                context.SaveChanges();
            }
        }

        public Elector GetElector(int pesel)
        {
            Elector elector;
            using (var context = new Context())
            {
                elector = context.Electors.FirstOrDefault(x => x.PESEL == pesel);
            }
            return elector;
        }

        public List<Elector> GetListOfElectors()
        {
            var listOfElectors = new List<Elector>();
            using (var context = new Context())
            {
                listOfElectors = context.Electors.ToList();
            }
            return listOfElectors;
        }

        public void RegisterElector(Elector elector)
        {
            using (var context = new Context())
            {
                context.Electors.Add(elector);
                context.SaveChanges();
            }
        }
    }
}
