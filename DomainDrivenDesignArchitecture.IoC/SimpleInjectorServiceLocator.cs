using CommonServiceLocator;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesignArchitecture.IoC
{
    public class SimpleInjectorServiceLocator : IServiceLocator
    {
        private Container container;

        public SimpleInjectorServiceLocator(Container container)
        {
            this.container = container;
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetAllInstances(serviceType);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return (IEnumerable<TService>)container.GetAllInstances(typeof(TService));
        }

        public object GetInstance(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return container.GetInstance(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return (TService)container.GetInstance(typeof(TService));
        }

        public TService GetInstance<TService>(string key)
        {
            return (TService)container.GetInstance(typeof(TService));
        }

        public object GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }
    }
}
