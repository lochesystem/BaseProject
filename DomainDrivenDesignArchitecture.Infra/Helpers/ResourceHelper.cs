using System;
using System.Resources;

namespace DomainDrivenDesignArchitecture.Infra.Helpers
{
    public static class ResourceHelper
    {
        public static string GetString(Type resourceType, string name)
        {
            var resourceManager = new ResourceManager(resourceType);
            return resourceManager.GetString(name);
        }

        public static string GetString<T>(string name)
        {
            return ResourceHelper.GetString(typeof(T), name);
        }

        public static bool IsThere(Type type, string name)
        {
            try
            {
                ResourceHelper.GetString(type, name);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool IsThere<T>(string name)
        {
            return ResourceHelper.IsThere(typeof(T), name);
        }
    }
}
