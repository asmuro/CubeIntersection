using Autofac.Core;
using Autofac;
using Domain.Interfaces;
using Domain.Services;

namespace Application.DependencyInjection
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
            builder.RegisterType<IntersectionService>()
                .As<IIntersectionService>()
                .SingleInstance();

            _rootScope = builder.Build();
        }

        /// <summary>
        /// Resolves the type T using the container
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>The resolved object</returns>
        public static T Resolve<T>()
        {
            if (_rootScope == null)
                Start();

            return _rootScope.Resolve<T>(new Parameter[0]);
        }
    }
}
