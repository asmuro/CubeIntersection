using Autofac;
using Domain.Interfaces;
using Domain.Services;
using Autofac.Core;

namespace Domain.DependencyInjection
{
    /// <summary>
    /// Static container for DI
    /// </summary>
    public static class ContainerConfigurationModule
    {
        private static ILifetimeScope? _rootScope;

        private static void Start()
        {
            if (_rootScope != null)
                return;

            var builder = new ContainerBuilder();
            builder.RegisterType<IntersectionFactory>()
                .As<IIntersectionFactory>()
                .SingleInstance();

            _rootScope = builder.Build();
        }

        public static T Resolve<T>()
        {
            if (_rootScope == null)
                Start();

            return _rootScope.Resolve<T>(new Parameter[0]);
        }
    }
}
