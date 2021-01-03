namespace Inventory.WebApi.Request.User
{
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using System.Collections.Generic;

    public class FetchUserRequest : IRequest<IEnumerable<UserViewModel>>
    {
    }
}