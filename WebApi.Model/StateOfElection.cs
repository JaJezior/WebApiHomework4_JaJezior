using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Model
{
    public sealed class StateOfElection
    {
        //private static StateOfElection instance = null;
        //public static StateOfElection StateOfThisElection
        //{ 
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new StateOfElection();
        //        }
        //        return instance;
        //    }
        //}
        public int Id { get; set; }
        public bool IsElectionStarted { get; set; }
        public bool IsElectionEnded { get; set; }
        //użyć AsSingle(?) w autofacu
        public StateOfElection()
        {
            IsElectionStarted = false;
            IsElectionEnded = false;
        }
    }
}
