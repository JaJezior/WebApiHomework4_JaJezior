using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public interface IStateOfElectionRepository
    {
        void InitializeStateOfElection(StateOfElection stateOfElection); //post
        StateOfElection GetStateOfElection(); //get
        void UpdateStateOfElection(StateOfElection stateOfElection); //put
    }
    public class StateOfElectionSqlService : IStateOfElectionRepository
    {
        private readonly Context context;

        public StateOfElectionSqlService(Context context)
        {
            this.context = context;
            //KOMENTARZ - zostawiam zakomentowany kod jako notatki na przyszłość.
            //ten konstruktor odpowiada za wstrzyknięcie dziedziczenia klasy Context za każdym razem, gdy jest tworzona instancja klasy tego serwisu.
            //dlatego można zakomentować usingi, gdyż w klasie Startup zdefiniowano tworzenie instancji klasy Context tylko na jedno zapytanie do WebApi.
        }
        public void InitializeStateOfElection(StateOfElection stateOfElection)
        {
            //using (var context = new Context())
            {
                context.StateOfElection.Add(stateOfElection);
                context.SaveChanges();
            }
        }

        public StateOfElection GetStateOfElection()
        {
            //using (var context = new Context())
            {
                return context.StateOfElection.FirstOrDefault();
            }
        }

        public void UpdateStateOfElection(StateOfElection stateOfElection)
        {
            //using (var context = new Context())
            {
                    context.StateOfElection.Update(stateOfElection);
                    context.SaveChanges();
            }
            
        }
    }
}
