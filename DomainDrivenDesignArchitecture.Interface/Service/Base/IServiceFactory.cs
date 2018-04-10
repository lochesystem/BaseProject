using DomainDrivenDesignArchitecture.Domain.Base;

namespace DomainDrivenDesignArchitecture.Interface.Service.Base
{
    public interface IServiceFactory<TEntity>
       where TEntity : DomainBase
    {
        TEntity CreateInstance();
    }
}
