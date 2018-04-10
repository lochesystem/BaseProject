using DomainDrivenDesignArchitecture.Domain.Base;
using DomainDrivenDesignArchitecture.Infra.Helpers;
using DomainDrivenDesignArchitecture.Interface.Infra;
using DomainDrivenDesignArchitecture.Interface.Service.Base;
using FluentValidation;

namespace DomainDrivenDesignArchitecture.Service.Base
{
    public abstract class ServiceBase<TEntity, TValidator> : ServiceFactory<TEntity>, IServiceBase<TEntity>
        where TEntity : DomainBase
        where TValidator : IValidator<TEntity>
    {
        private IUnitOfWork unitOfWork;

        public virtual void Validate(TEntity entity)
        {
            try
            {
                LocatorHelper.GetInstance<TValidator>().ValidateAndThrow(entity);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }

        public virtual void Begin()
        {
            var factory = LocatorHelper.GetInstance<IUnitOfWorkFactory>();
            unitOfWork = factory.Create();

            unitOfWork.Begin();
        }

        public virtual void Commit()
        {
            unitOfWork.Commit();
        }
    }
}
