using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Model;

namespace WebApi.DataLogic
{
    public interface IElectorRepository
    {
        void RegisterElector(Elector elector); //post
        Elector GetElector(int pesel); //get
        void DeleteElectorFromList(int pesel); //delete
        List<Elector> GetListOfElectors();
        void AddListOfElectors(int amount);
    }
}
