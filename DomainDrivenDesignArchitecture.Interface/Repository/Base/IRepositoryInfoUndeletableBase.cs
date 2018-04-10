using DomainDrivenDesignArchitecture.Domain.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DomainDrivenDesignArchitecture.Interface.Repository.Base
{
    public interface IRepositoryInfoUndeletableBase<TEntity>
        where TEntity : DomainUndeletableBase
    {
        void Create(TEntity entity, bool commit = true, bool setCreatedAtAndUpdatedAt = true);
        void Update(TEntity entity, bool commit = true, bool setUpdatedAt = true);
        void Delete(Guid[] ids, bool commit = true);
        void Delete(Guid id, bool commit = true);
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Query(bool showDeleted = false, params Expression<Func<TEntity, object>>[] includes);
    }
}
