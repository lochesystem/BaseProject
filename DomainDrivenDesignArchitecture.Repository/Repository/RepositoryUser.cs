using DomainDrivenDesignArchitecture.Domain;
using DomainDrivenDesignArchitecture.Interface.Repository;
using DomainDrivenDesignArchitecture.Repository.Base;

namespace DomainDrivenDesignArchitecture.Repository.Repository
{
    public class RepositoryUser : RepositoryInfoUndeletableBase<User>, IRepositoryUser
    {
        public RepositoryUser(SimpleContext context)
        : base(context)
        {
        }
    }
}
