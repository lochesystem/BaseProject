using CommonServiceLocator;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesignArchitecture.IoC
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            RegisterDictionary(ref container, InfraModule.GetTypes());
            RegisterDictionary(ref container, RepositoryModule.GetTypes());
            RegisterDictionary(ref container, ServiceModule.GetTypes());

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocator(container));

            return container;
        }
        private static void RegisterDictionary(ref Container container, Dictionary<Type, Type> iocs)
        {
            foreach (var ioc in iocs)
            {
                container.Register(ioc.Key, ioc.Value, Lifestyle.Transient);
            }
        }

    }
}
