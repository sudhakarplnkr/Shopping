namespace Inventory.WebApi.Request.Role
{
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using System;

    public class FetchOneRoleRequest : IRequest<RoleViewModel>
    {
        public FetchOneRoleRequest(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }
    }
}