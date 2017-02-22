using System.Configuration;
using System.Net.Mime;
using GeneralFrame.Application.Contracts;
using GeneralFrame.Core;
using GeneralFrame.Core.Wcf;
using GeneralFrame.Data.Infrastructure;
using GeneralFrame.Data.Repositories;
using Microsoft.Practices.Unity;

namespace GeneralFrame.Service
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            var filePath = ConfigurationManager.AppSettings["fileLocation"];
            container.RegisterType<IDbContextUnitOfWork, MainUnitOfWork>(new HierarchicalLifetimeManager(),
                new InjectionConstructor(filePath));
            container.RegisterType<IGeneralFrameService, GeneralFrameService>();
            container.RegisterType<ISpecificRepository, SpecificRepository>();
        }
    }
}