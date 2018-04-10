using DomainDrivenDesignArchitecture.Domain;
using DomainDrivenDesignArchitecture.Infra.Helpers;
using DomainDrivenDesignArchitecture.Interface.Repository;
using DomainDrivenDesignArchitecture.Interface.Service;
using DomainDrivenDesignArchitecture.Service.Base;
using DomainDrivenDesignArchitecture.Service.Validator;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DomainDrivenDesignArchitecture.Service.Service
{
    public class ServiceUser : ServiceBase<User, UserValidator>, IServiceUser
    {

        private IRepositoryUser repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser)
        {
            this.repositoryUser = repositoryUser;
        }

        public void Create(User entity, bool commit = true)
        {
            Begin();
            Validate(entity);


            if (!string.IsNullOrEmpty(entity.Password))
            {
                entity.Password = EncryptHelper.Encrypt(entity.Password);
            }

            repositoryUser.Create(entity, commit, true);
            Commit();
        }

        public void Delete(Guid id, bool commit = true)
        {
            Begin();
            repositoryUser.Delete(id, commit);
            Commit();
        }

        public void Delete(Guid[] ids, bool commit = true)
        {
            repositoryUser.Delete(ids);
        }

        public IQueryable<User> Query(params Expression<Func<User, object>>[] includes)
        {
            return repositoryUser.Query(includes);
        }

        public IQueryable<User> Query(bool showDeleted = false, params Expression<Func<User, object>>[] includes)
        {
            return repositoryUser.Query(showDeleted, includes);
        }

        public void Update(User entity, bool commit = true)
        {
            Begin();
            Validate(entity);

            if (!string.IsNullOrEmpty(entity.Password))
            {
                entity.Password = EncryptHelper.Encrypt(entity.Password);
            }

            repositoryUser.Update(entity, commit, true);
            Commit();
        }
    }
}
