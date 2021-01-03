namespace Inventory.WebApi.Request.Role
{
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using System.Collections.Generic;

    public class FetchRoleRequest : IRequest<IEnumerable<RoleViewModel>>
    {
    }
}