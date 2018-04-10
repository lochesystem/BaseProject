using DomainDrivenDesignArchitecture.Domain;
using DomainDrivenDesignArchitecture.Interface.Repository;
using DomainDrivenDesignArchitecture.Resource.Entity;
using FluentValidation;

namespace DomainDrivenDesignArchitecture.Service.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        private  IRepositoryUser repositoryUser;

        public UserValidator(IRepositoryUser repositoryUser)
        {

            this.repositoryUser = repositoryUser;

            //RuleFor(p => p.Login)
            //   .Must((m, t) => !userRepository.Query().Where(p => p.Login == m.Login.ToLower()).Any()).WithMessage(UserResource.Message_UserAlreadyExists);

            //RuleFor(f => f.UserAccessProfile)
            //    .Must((m, p) => EnumHelper.GetEnumList<UserAccessProfile>().Any(a => a.Value == (int)p)).WithName(UserResource.Property_UserAccessProfile);

            RuleFor(p => p.Login).NotEmpty().WithMessage(EntityResource.Validator_RequiredField);

            RuleFor(p => p.Password)
                .Length(4)
                .WithMessage(EntityResource.Validator_MaxFieldExceeded);
        }

    }
}
