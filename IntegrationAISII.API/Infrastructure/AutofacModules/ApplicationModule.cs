using Autofac;
using EventBus.Abstractions;
using IntegrationAISII.Infrastructure.Idempotency;

namespace IntegrationAISII.API.Infrastructure.AutofacModules
{

    public class ApplicationModule
        : Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();
        }
    }
}
