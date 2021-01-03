namespace Inventory.WebApi.Controllers
{
    using System.Threading.Tasks;
    using Inventory.WebApi.Request.User;
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<UserViewModel>> Get()
        {
            return mediator.Send(new FetchUserRequest());
        }

        [HttpGet]
        [Route("{id}")]
        public Task<UserViewModel> Get(Guid id)
        {
            return mediator.Send(new FetchOneUserRequest(id));
        }

        [HttpPut]
        [Route("{id}")]
        public Task<bool> Put(Guid id, UserViewModel userViewModel)
        {
            return mediator.Send(new UpdateUserRequest(id, userViewModel));
        }

        [HttpPost]
        public Task<bool> Post(UserViewModel userViewModel)
        {
            return mediator.Send(new CreateUserRequest(userViewModel));
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<bool> Delete(Guid id)
        {
            return mediator.Send(new DeleteUserRequest(id));
        }
    }
}
