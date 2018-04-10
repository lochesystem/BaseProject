using DomainDrivenDesignArchitecture.Infra.Helpers;
using DomainDrivenDesignArchitecture.Interface.Infra;

namespace DomainDrivenDesignArchitecture.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IContextManager contextManager;
        public void Begin()
        {
            contextManager = LocatorHelper.GetInstance<IContextManager>();
        }

        public void Commit()
        {
            contextManager.Dispose();
        }
    }
}
