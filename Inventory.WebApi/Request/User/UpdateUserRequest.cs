namespace Inventory.WebApi.Request.User
{
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using System;

    public class UpdateUserRequest : IRequest<bool>
    {
        public UpdateUserRequest(Guid id, UserViewModel userViewModel)
        {
            Id = id;
            UserViewModel = userViewModel;
        }

        public UserViewModel UserViewModel { get; set; }

        public Guid Id { get; set; }
    }
}