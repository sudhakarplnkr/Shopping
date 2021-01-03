namespace Inventory.WebApi.Controllers
{
    using System.Threading.Tasks;
    using Inventory.WebApi.Request.User;
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task<bool> Post(UserViewModel userViewModel)
        {
            return mediator.Send(new CreateUserRequest(userViewModel));
        }
    }
}
