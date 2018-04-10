using AutoMapper;
using DomainDrivenDesignArchitecture.Domain;
using DomainDrivenDesignArchitecture.Domain.CommandModel;

namespace DomainDrivenDesignArchitecture.API.AutoMapper
{
    public class ViewModelToServiceModelMapping : Profile
    {

        public ViewModelToServiceModelMapping()
        {
            CreateMap<SaveUserCommand, User>()
                .ForMember(dest => dest.Login, to => to.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, to => to.MapFrom(src => src.Password));
        }

    }
}