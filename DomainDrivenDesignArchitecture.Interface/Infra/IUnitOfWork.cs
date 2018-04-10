namespace DomainDrivenDesignArchitecture.Interface.Infra
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
    }
}
