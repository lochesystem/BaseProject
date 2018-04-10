using DomainDrivenDesignArchitecture.Domain.Base;
using DomainDrivenDesignArchitecture.Infra.Helpers;
using DomainDrivenDesignArchitecture.Interface.Service.Base;

namespace DomainDrivenDesignArchitecture.Service.Base
{
    public class ServiceFactory<TEntity> : IServiceFactory<TEntity>
         where TEntity : DomainBase
    {
        public virtual TEntity CreateInstance()
        {
            return ReflectionHelper.CreateInstance<TEntity>();
        }
    }
}
