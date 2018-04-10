using DomainDrivenDesignArchitecture.Domain;
using DomainDrivenDesignArchitecture.Interface.Repository.Base;

namespace DomainDrivenDesignArchitecture.Interface.Repository
{
    public interface IRepositoryUser : IRepositoryInfoUndeletableBase<User>
    {
    }
}
