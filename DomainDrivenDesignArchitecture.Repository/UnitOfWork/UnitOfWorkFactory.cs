using DomainDrivenDesignArchitecture.Interface.Infra;

namespace DomainDrivenDesignArchitecture.Repository.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}
