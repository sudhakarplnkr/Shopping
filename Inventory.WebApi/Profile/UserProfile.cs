namespace Inventory.WebApi.Profile
{
    using AutoMapper;
    using Inventory.WebApi.Data.Entity;
    using Inventory.WebApi.ViewModel;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
            .ReverseMap();
        }
    }
}