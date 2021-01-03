namespace Inventory.WebApi.Request.Role
{
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using System;

    public class UpdateRoleRequest : IRequest<bool>
    {
        public UpdateRoleRequest(Guid id, RoleViewModel userViewModel)
        {
            Id = id;
            RoleViewModel = userViewModel;
        }

        public RoleViewModel RoleViewModel { get; set; }

        public Guid Id { get; set; }
    }
}