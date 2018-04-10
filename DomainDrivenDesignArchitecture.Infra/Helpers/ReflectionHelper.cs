using System;

namespace DomainDrivenDesignArchitecture.Infra.Helpers
{
    public static class ReflectionHelper
    {
        public static T CreateInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
