using System.Web.Http;

namespace EasyMemo.Services
{
    using Apworks.Application;
    using Apworks.Config.Fluent;
    using Apworks.Repositories;
    using Apworks.Repositories.EntityFramework;
    using EasyMemo.Repositories;
    using Microsoft.Practices.Unity;
    using Unity.WebApi;


    public static class ApworksConfig
    {
        public static void Initialize()
        {
            AppRuntime
                .Instance
                .ConfigureApworks()
                .UsingUnityContainerWithDefaultSettings()
                .Create((sender, e) =>
                {
                    var unityContainer = e.ObjectContainer.GetWrappedContainer<UnityContainer>();
                    unityContainer.RegisterInstance(new EasyMemoContext(), new PerResolveLifetimeManager())
                        .RegisterType<IRepositoryContext, EntityFrameworkRepositoryContext>(
                            new HierarchicalLifetimeManager(),
                            new InjectionConstructor(new ResolvedParameter<EasyMemoContext>()))
                        .RegisterType(typeof (IRepository<>), typeof (EntityFrameworkRepository<>));

                    GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(unityContainer);
                })
                .Start();
        }
    }
}