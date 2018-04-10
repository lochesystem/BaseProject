namespace DomainDrivenDesignArchitecture.Interface.Infra
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
