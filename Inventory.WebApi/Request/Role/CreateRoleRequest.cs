namespace Inventory.WebApi.Request.Role
{
    using Inventory.WebApi.ViewModel;
    using MediatR;

    public class CreateRoleRequest : IRequest<bool>
    {
        public CreateRoleRequest(RoleViewModel userViewModel)
        {
            RoleViewModel = userViewModel;
        }

        public RoleViewModel RoleViewModel { get; set; }
    }
}