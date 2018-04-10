using DomainDrivenDesignArchitecture.Domain.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DomainDrivenDesignArchitecture.Interface.Repository.Base
{
    public interface IRepositoryBase<TEntity>
        where TEntity : DomainBase
    {
        void Create(TEntity entity, bool commit = true);
        void Update(TEntity entity, bool commit = true);
        void Delete(Guid[] ids, bool commit = true);
        void Delete(Guid id, bool commit = true);
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);

    }
}
