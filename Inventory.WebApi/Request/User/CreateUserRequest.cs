namespace Inventory.WebApi.Request.User
{
    using Inventory.WebApi.ViewModel;
    using MediatR;

    public class CreateUserRequest : IRequest<bool>
    {
        public CreateUserRequest(UserViewModel userViewModel)
        {
            UserViewModel = userViewModel;
        }

        public UserViewModel UserViewModel { get; set; }
    }
}