using Autofac;
using WebApi.DataLogic;
using Autofac.Integration.Mvc;

namespace WebApi.Client

{
    internal class ContainerBuilderCreator
    {
        public static ContainerBuilder CreateBasicContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();
            //Arku, próbowałem... ale nikt nie dałem rady ustawić DI w webApi, no po prostu nie. Proste rozwiązania, które były na zajęciach nie zdają rezultatu, a innych nikt nas jeszcze nie uczył. 

            //containerBuilder.RegisterType<ICandidateRepository>().As<CandidateSqlService>().InstancePerRequest();
            //containerBuilder.RegisterType<CandidateSqlService>().As<ICandidateRepository>().InstancePerRequest();
            
            //containerBuilder.Register(x=> new CandidateSqlService()).As<ICandidateRepository>().InstancePerRequest();

            //containerBuilder.Register(x => new CandidateSqlService()).AsSelf().InstancePerRequest();
            //containerBuilder.RegisterType<CandidateSqlService>().AsSelf().InstancePerRequest();
            //containerBuilder.RegisterType<CandidateSqlService>().AsSelf().SingleInstance().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<CandidateSqlService>().AsSelf().SingleInstance();
            //containerBuilder.RegisterType<IStateOfElectionRepository>().As<StateOfElectionSqlService>().SingleInstance();
            //containerBuilder.RegisterType<IElectorRepository>().As<ElectorSqlService>().SingleInstance();
            //ps. żadne z powyższych nie zadziałało.
            return containerBuilder;
        }
    }
}