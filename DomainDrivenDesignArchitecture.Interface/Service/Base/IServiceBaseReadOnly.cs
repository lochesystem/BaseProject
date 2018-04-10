using DomainDrivenDesignArchitecture.Domain.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DomainDrivenDesignArchitecture.Interface.Service.Base
{
    public interface IServiceBaseReadOnly<TEntity>
         where TEntity : DomainBase
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Query(bool showDeleted = false, params Expression<Func<TEntity, object>>[] includes);
    }
}
