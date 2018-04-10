using CommonServiceLocator;
using System;

namespace DomainDrivenDesignArchitecture.Infra.Helpers
{
    public static class LocatorHelper
    {
        public static T GetInstance<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        public static object GetInstance(Type type)
        {
            return ServiceLocator.Current.GetInstance(type);
        }
    }
}
