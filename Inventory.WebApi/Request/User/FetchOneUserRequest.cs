namespace Inventory.WebApi.Request.User
{
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using System.Collections.Generic;
    using System;

    public class FetchOneUserRequest : IRequest<UserViewModel>
    {
        public FetchOneUserRequest(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }
    }
}