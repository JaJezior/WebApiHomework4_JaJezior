using Autofac;
using WebApi.DataLogic;
using Autofac.Integration.Mvc;

namespace WebApi.Client

{//Ta klasa nie jest nigdzie używana, zostawiłem jako notatki z autofaca.
    internal class ContainerBuilderCreator
    {
        public static ContainerBuilder CreateBasicContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();
            //NOTATKI - różne sposoby dodawania w autofacu
            //containerBuilder.RegisterType<ICandidateRepository>().As<CandidateSqlService>().InstancePerRequest();
            //containerBuilder.RegisterType<CandidateSqlService>().AsSelf().SingleInstance().InstancePerLifetimeScope();

            return containerBuilder;
        }
    }
}