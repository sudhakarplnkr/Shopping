namespace Inventory.WebApi.Request.Role
{
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using System.Collections.Generic;
    using System;

    public class DeleteRoleRequest : IRequest<bool>
    {
        public DeleteRoleRequest(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }
    }
}