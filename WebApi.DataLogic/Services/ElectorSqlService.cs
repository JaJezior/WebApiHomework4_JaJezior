using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public interface IElectorRepository
    {
        void RegisterElector(Elector elector); //post
        Elector GetElector(int pesel); //get
        void DeleteElectorFromList(int pesel); //delete
        List<Elector> GetListOfElectors(); //get
        void AddListOfElectors(int amount); //post
    }
    public class ElectorSqlService : IElectorRepository
    {
        private readonly Context context;
        public ElectorSqlService(Context context)
        {
            this.context = context;
            //KOMENTARZ - zostawiam zakomentowany kod jako notatki na przyszłość.
            //ten konstruktor odpowiada za wstrzyknięcie dziedziczenia klasy Context za każdym razem, gdy jest tworzona instancja klasy tego serwisu.
            //dlatego można zakomentować usingi, gdyż w klasie Startup zdefiniowano tworzenie instancji klasy Context tylko na jedno zapytanie do WebApi.
        }
        public void AddListOfElectors(int amount)
        {
            //using (var context = new Context())
            {
                for (int x = 0; x <= amount; x++)
                {
                    context.Electors.Add(new Elector() { PESEL = x });
                }
            }
        }

        public void DeleteElectorFromList(int id)
        {
            //using (var context = new Context())
            {
                var elector = context.Electors.First(x => x.Id == id);
                context.Electors.Remove(elector);
                context.SaveChanges();
            }
        }

        public Elector GetElector(int pesel)
        {
            Elector elector;
            //using (var context = new Context())
            {
                elector = context.Electors.FirstOrDefault(x => x.PESEL == pesel);
            }
            return elector;
        }

        public List<Elector> GetListOfElectors()
        {
            var listOfElectors = new List<Elector>();
            //using (var context = new Context())
            {
                listOfElectors = context.Electors.ToList();
            }
            return listOfElectors;
        }

        public void RegisterElector(Elector elector)
        {
            //using (var context = new Context())
            {
                context.Electors.Add(elector);
                context.SaveChanges();
            }
        }
    }
}
