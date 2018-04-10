using DomainDrivenDesignArchitecture.Domain.Base;

namespace DomainDrivenDesignArchitecture.Interface.Service.Base
{
    public interface IServiceBase<TEntity> : IServiceFactory<TEntity>
         where TEntity : DomainBase
    {
        /// <summary>
        /// Throws exception when invalid
        /// </summary>
        /// <param name="entity"></param>
        void Validate(TEntity entity);
    }
}
