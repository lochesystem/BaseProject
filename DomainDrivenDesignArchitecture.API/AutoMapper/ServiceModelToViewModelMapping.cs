using AutoMapper;
using DomainDrivenDesignArchitecture.Domain;
using DomainDrivenDesignArchitecture.Domain.ReturnModel;

namespace DomainDrivenDesignArchitecture.API.AutoMapper
{
    public class ServiceModelToViewModelMapping : Profile
    {

        public ServiceModelToViewModelMapping()
        {

            CreateMap<User, UserReturn>()
                .ForMember(dest => dest.Login, to => to.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, to => to.MapFrom(src => src.Password));
        }

    }
}