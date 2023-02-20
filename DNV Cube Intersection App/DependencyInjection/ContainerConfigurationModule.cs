using Application.ApplicationsServices.Interfaces;
using Autofac;
using System;
using Application.ApplicationsServices;
using Autofac.Core;
using Domain.Interfaces;
using Domain.Services;

namespace DNV_Cube_Intersection_App.DependencyInjection
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
            builder.RegisterType<IntersectionApplicationService>()
                .As<IIntersectionApplicationService>()
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
