using AutoMapper;

namespace DomainDrivenDesignArchitecture.API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ServiceModelToViewModelMapping>();
                x.AddProfile<ViewModelToServiceModelMapping>();
            });
        }

    }
}