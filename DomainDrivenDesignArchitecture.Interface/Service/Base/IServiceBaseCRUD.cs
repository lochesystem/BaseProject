using DomainDrivenDesignArchitecture.Domain.Base;
using System;

namespace DomainDrivenDesignArchitecture.Interface.Service.Base
{
    public interface IServiceBaseCRUD<TEntity> : IServiceBaseReadOnly<TEntity>
        where TEntity : DomainBase
    {
        void Create(TEntity entity, bool commit = true);
        void Update(TEntity entity, bool commit = true);
        void Delete(Guid id, bool commit = true);
        void Delete(Guid[] ids, bool commit = true);
    }
}
