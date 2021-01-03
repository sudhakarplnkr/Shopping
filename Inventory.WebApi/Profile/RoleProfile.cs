namespace Inventory.WebApi.Profile
{
    using AutoMapper;
    using Inventory.WebApi.Data.Entity;
    using Inventory.WebApi.ViewModel;

    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleViewModel>()
            .ReverseMap();
        }
    }
}