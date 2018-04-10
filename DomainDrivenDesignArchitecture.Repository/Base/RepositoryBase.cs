using DomainDrivenDesignArchitecture.Domain.Base;
using DomainDrivenDesignArchitecture.Interface.Repository.Base;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DomainDrivenDesignArchitecture.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : DomainBase
    {

        private SimpleContext _context;

        public RepositoryBase(SimpleContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual void Create(TEntity entity, bool commit = true)
        {
            Set.Add(entity);

            if (commit) this.Commit();
        }

        public virtual void Delete(Guid[] ids, bool commit = true)
        {
            foreach (var id in ids)
            {
                this.Delete(id, false);
            }

            if (commit) this.Commit();
        }

        public virtual void Delete(Guid id, bool commit = true)
        {
            TEntity entity = Set.FirstOrDefault(s => s.Id == id);

            Set.Remove(entity);

            if (commit) this.Commit();
        }

        public virtual IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = (IQueryable<TEntity>)Set;

            foreach (var include in includes)
                query = query.Include(include);

            return query;
        }

        public void Update(TEntity entity, bool commit = true)
        {
            _context.Entry(entity).State = EntityState.Modified;

            if (commit) this.Commit();
        }

        protected DbSet<TEntity> Set
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }
    }
}
